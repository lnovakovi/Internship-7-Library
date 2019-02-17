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

        public Author GetAuthorByName(string name)
        {
            return GetAllAuthors().First(author => author.NameSurname() == name);
        }

        public bool EditAuthor(Author oldAuthor, Author newAuthor)
        {
            var authToEdit = _context.Authors.FirstOrDefault(author => author.AuthorID == oldAuthor.AuthorID);
            if (authToEdit != null)
            {
                authToEdit.Name = newAuthor.Name;
                authToEdit.Surname = newAuthor.Surname;
                authToEdit.DateOfBirth = newAuthor.DateOfBirth;
                authToEdit.Gender = newAuthor.Gender;
            }

            return _context.SaveChanges() != 0;
        }

        public bool TryDelete(Author toDelete)
        {
            
            _context.Authors.Remove(toDelete);
            var numberOfChanges = _context.SaveChanges();
            return numberOfChanges != 0;
        }


    }
}
