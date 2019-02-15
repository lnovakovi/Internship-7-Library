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

        public string AddAuthor(Author toAdd)
        {
            if (CheckIfAuthorExists(toAdd))
            {
                return "Author already in database";
            }
            _context.Authors.Add(toAdd);
            _context.SaveChanges();
            return "Saved to base";
        }
        public List<Author> GetAllAuthors()
        {
            return _context.Authors.OrderBy(author => author.Surname).ToList();
        }

        public bool CheckIfAuthorExists(Author authorToCheck)
        {
            return _context.Authors.Any(author => author.Name == authorToCheck.Name);
        }

        public void Delete()
        {
            //to do
        }

        public void GetBooks()
        {
            //to do
        }
    }
}
