using System;
using System.Collections.Generic;
using System.Linq;
using Library.Data.Entities;
using Library.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Domain.Repositories
{
    public class LoanRepository
    {
        private readonly LibraryContext _context;
        private readonly StudentRepository _studentRepository;
        private readonly BookRepository _bookRepository;
        private readonly HistoryRepository _historyRepository;
        public LoanRepository()
        {
           _context = new LibraryContext();
           _studentRepository=new StudentRepository();
           _historyRepository = new HistoryRepository();
           _bookRepository=new BookRepository();
        }

        public string AddLoan(Loan loan)
        {
            if (IsPossibleToLoan(loan.Student))
            {
                return "Student already has loan!";
            }

            if (_bookRepository.ReturnNumOfCopies(loan.Book) == 0)
                return "All books are out!";
            _context.Attach(loan.Student);
            _context.Attach(loan.Book);
            var bookToRent = _context.Books.First(book => book == loan.Book);
            bookToRent.NumberOfCopies -= 1;
            _context.Add(loan);
            _context.SaveChanges();
            return "Loan activated";
        }

        public string CloseLoan(string loanDetails)
        {
            var actualLoan =
                _context.Loans.FirstOrDefault(actLoan => actLoan.LoanDetails() == loanDetails);
            if (actualLoan == null)
                return "No loan";
            var returnedBook = _context.Books.FirstOrDefault(book => book.BookId == actualLoan.BookId);
            returnedBook.NumberOfCopies += 1;
            actualLoan.ReturnDate = DateTime.Now;
            var histroy = new History
            {
                Loan = actualLoan.LoanDetails()
            };
            _historyRepository.AddLoan(histroy);
            _context.SaveChanges();
            return
                $"Loan closed, student needs to pay:{actualLoan.CalculateOverdue(actualLoan.LoanDate, DateTime.Now)} kn";

        }

        public List<Loan> GetAllLoans()
        {
            return _context.Loans.Include(be => be.Student).Include(bc => bc.Book).ToList();
        }

        public List<Loan> GetActiveLoans()
        {
            return GetAllLoans().Where(loan => loan.ReturnDate == null).ToList();
        }

        public List<Loan> GetStudentsLoans(string student)
        {
            return GetAllLoans().Where(loan => loan.Student.NameSurname() == student).ToList();
        }

        public bool IsPossibleToLoan(Student student)
        {
            return _context.Loans.Any(loan=> loan.StudentId == student.StudentId && loan.ReturnDate ==null);
        }

    }
}
