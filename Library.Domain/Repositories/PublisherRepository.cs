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
    public class PublisherRepository
    {
        public PublisherRepository()
        {
            _context = new LibraryContext();
        }

        private readonly LibraryContext _context;
        public string AddPublisher(Publisher toAdd)
        {
            if (CheckIfPublisherExists(toAdd))
            {
                return "Publisher already in base";
            }
            _context.Publishers.Add(toAdd);
            _context.SaveChanges();
            return "Saved!";
        }

        public List<Publisher> GetAllPublishers()
        {
            return _context.Publishers.Include(pub=> pub.Books).ToList();
        }
        public bool CheckIfPublisherExists(Publisher publisherToCheck)
        {
            return _context.Publishers.Any(pub => pub.Name.ToLower() == publisherToCheck.Name.ToLower());
        }
    }
}
