using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data.Entities;
using Library.Data.Entities.Models;

namespace Library.Domain.Repositories
{
    public class AuthorRepository
    {
        public AuthorRepository()
        {
            _context = new LibraryContext();
        }

        private readonly LibraryContext _context;

        public void AddAuthor(Author toAdd)
        {
            _context.Authors.Add(toAdd);
            _context.SaveChanges();
        }
        public List<Author> GetAllAuthors()
        {
            return _context.Authors.OrderBy(author => author.Surname).ToList();
        }
    }
}
