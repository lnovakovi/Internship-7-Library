using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data.Entities;
using Library.Data.Entities.Models;
using Library.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Parsing.Structure.IntermediateModel;
using Remotion.Linq.Utilities;

namespace Library.Domain.Repositories
{
    public class BookRepository
    {
        private readonly LibraryContext _context;

        public BookRepository()
        {
            _context = new LibraryContext();
        }

        public List<Book> GetAllBooks()
        {
            return _context.Books.Include(book => book.Publisher).Include(aut => aut.Author).ToList();
        }

        public int ReturnNumOfCopies(Book book)
        {
            return book == null ? 0 : _context.Books.FirstOrDefault(bk => bk.BookId == book.BookId).NumberOfCopies;
        }

        public bool TryDelete(Book toDelete)
        {
            _context.Books.Remove(toDelete);
            var numberOfChanges = _context.SaveChanges();
            return numberOfChanges != 0;
        }
        public List<Book> GetBooksByAuthor(Author authorToGet)
        {
            return _context.Books.Where(book => book.Author == authorToGet).ToList();
        }
        public List<Book> GetBooksByPublisher(Publisher pubToGet)
        {
            return _context.Books.Where(book => book.Publisher == pubToGet).ToList();
        }

        public Book GetBookByName(string name)
        {
            return _context.Books.First(b => b.Name == name);
        }

        public string AddBook(Book bookToAdd)
        {
            if (CheckIfBookExists(bookToAdd))
            {
                return "Book already in database";
            }
            var book = new Book
            {
                Name = bookToAdd.Name,
                Description = bookToAdd.Description,
                NumberOfPages = bookToAdd.NumberOfPages,
                YearOfPublish = bookToAdd.YearOfPublish,
                Genre = bookToAdd.Genre,
                NumberOfCopies = bookToAdd.NumberOfCopies,
                Author = _context.Authors.Find(bookToAdd.Author.AuthorID),
                Publisher = _context.Publishers.Find(bookToAdd.Publisher.PublisherId)
            };
            _context.Add(book);
            _context.SaveChanges();
            return "Saved!";
        }

        public bool CheckIfBookExists(Book bookToCheck)
        {
            return _context.Books.Any(book => book.Name == bookToCheck.Name && book.Author == bookToCheck.Author);
        }

        public bool EditBook(Book newBook)
        {

            var bookToEdit = _context.Books.Find(newBook.BookId);
            //_context.Authors.Attach(newBook.Author);
            //_context.Publishers.Attach(newBook.Publisher);
            if (!newBook.Name.CheckIfEmpty())
                bookToEdit.Name = newBook.Name;
            if (!newBook.Description.CheckIfEmpty())
                bookToEdit.Description = newBook.Description;
            bookToEdit.Author = _context.Authors.Find(newBook.Author.AuthorID);
            bookToEdit.Publisher = _context.Publishers.Find(newBook.Publisher.PublisherId);
            bookToEdit.YearOfPublish = newBook.YearOfPublish;
            bookToEdit.NumberOfCopies = newBook.NumberOfCopies;
            bookToEdit.NumberOfPages = newBook.NumberOfCopies;
            bookToEdit.Genre = newBook.Genre;

            return 0!= _context.SaveChanges();
            

        }






    }
}
