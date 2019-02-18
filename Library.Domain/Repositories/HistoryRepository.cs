using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data.Entities;
using Library.Data.Entities.Models;

namespace Library.Domain.Repositories
{
    public class HistoryRepository
    {
        private readonly LibraryContext _context;

        public HistoryRepository()
        {
            _context = new LibraryContext();
        }

        public List<History> GetAll()
        {
            return _context.Histories.ToList();
        }

        public bool AddLoan(History loanHistory)
        {
            _context.Histories.Add(loanHistory);
            return 0 != _context.SaveChanges();
        }

        public bool RemoveLoan(string loanHistory)
        {
            var wantedHistory = _context.Histories.First(history => history.Loan == loanHistory);
            _context.Histories.Remove(wantedHistory);
            return 0 != _context.SaveChanges();
        }
    }
}
