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
            _context.SaveChanges();
            return 0 != _context.SaveChanges();
        }
    }
}
