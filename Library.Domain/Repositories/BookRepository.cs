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

        public string EditBook(Book oldBook, Book newBook)
        {
            /// not working!!
            var wantedBook = GetAllBooks().FirstOrDefault(b => b.ToString() == oldBook.ToString());
            if (!newBook.Name.CheckIfEmpty())
                if (wantedBook != null)
                    wantedBook.Name = newBook.Name;
            if (!newBook.Description.CheckIfEmpty())
                if (wantedBook != null)
                    wantedBook.Description = newBook.Description;
            wantedBook.Author = _context.Authors.First(author => author == newBook.Author);
            wantedBook.Publisher = _context.Publishers.First(publisher => publisher == newBook.Publisher);

            if (wantedBook != null)
            {
                wantedBook.YearOfPublish = newBook.YearOfPublish;
                wantedBook.NumberOfCopies = newBook.NumberOfCopies;
                wantedBook.NumberOfPages = newBook.NumberOfCopies;
                wantedBook.Author = newBook.Author;
                wantedBook.Publisher = newBook.Publisher;
                wantedBook.Genre = newBook.Genre;
            }

            
            _context.SaveChanges();
            return $"Edited {oldBook.Name}";

        }

      

    }
}
