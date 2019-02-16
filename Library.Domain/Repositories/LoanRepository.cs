using System;
using System.Collections.Generic;
using System.Linq;
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
        public LoanRepository()
        {
           _context = new LibraryContext();
        }

        public void AddLoan(Loan loan)
        {
            _context.Attach(loan.Student);
            _context.Attach(loan.Book);
            var bookToRent = _context.Books.First(book => book == loan.Book);
            bookToRent.NumberOfCopies -= 1;
            _context.Add(loan);
            _context.SaveChanges();
        }

        public void CheckIfCanLoan(Loan loan)
        {
            //to do
        }

        public List<Loan> GetAllLoans()
        {
            return _context.Loans.Include(be => be.Student).Include(bc => bc.Book).ToList();
        }
        public List<Loan> GetStudentsLoans(string student)
        {
            return GetAllLoans().Where(loan => loan.Student.NameSurname() == student).ToList();
        }

    }
}
