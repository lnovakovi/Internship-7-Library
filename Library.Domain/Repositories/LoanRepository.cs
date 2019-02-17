using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;
using Library.Data.Entities;
using Library.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Domain.Repositories
{
    public class LoanRepository
    {
        private readonly LibraryContext _context;
        private readonly StudentRepository _studentRepository;
        public LoanRepository()
        {
           _context = new LibraryContext();
           _studentRepository=new StudentRepository();
        }

        public string AddLoan(Loan loan)
        {
            if (IsPossibleToLoan(loan.Student))
            {
                return "Student already has loan!";
            }
            _context.Attach(loan.Student);
            _context.Attach(loan.Book);
            var bookToRent = _context.Books.First(book => book == loan.Book);
            bookToRent.NumberOfCopies -= 1;
            _context.Add(loan);
            _context.SaveChanges();
            return "Loan activated";
        }

        public void CloseLoan(string loanDetails)
        {
            var actualLoan =
                _context.Loans.FirstOrDefault(actLoan => actLoan.LoanDetails() == loanDetails);
            if(actualLoan == null)
                return;
            var returnedBook = _context.Books.FirstOrDefault(book => book.BookId == actualLoan.BookId);
            returnedBook.NumberOfCopies += 1;
            actualLoan.ReturnDate = DateTime.Now;
            _context.SaveChanges();

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
