using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data.Entities;

namespace Library.Domain.Repositories
{
    public class Loan
    {
        public Loan()
        {
           _context = new LibraryContext();
        }

        private readonly LibraryContext _context;
    }
}
