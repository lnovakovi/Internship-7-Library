﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data.Entities;
using Library.Data.Entities.Models;

namespace Library.Domain.Repositories
{
    public class PublisherRepository
    {
        public PublisherRepository()
        {
            _context = new LibraryContext();
        }

        private readonly LibraryContext _context;
        public void AddPublisher(Publisher toAdd)
        {
            _context.Publishers.Add(toAdd);
            _context.SaveChanges();
        }

        public ICollection<Publisher> GetPublishers()
        {
            return _context.Publishers.ToList();
        }
    }
}
