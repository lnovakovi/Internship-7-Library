using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data.Enums;
using Library.Infrastructure.Extensions;

namespace Library.Data.Entities.Models
{
    public class Book
    {
        public int BookId { get; set; }
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value.RemoveWhiteSpaces();
                _name = _name.CapitalizeEachWord();
            }
        }
        public string Description { get; set; }
        public int NumberOfCopies { get; set; }
        public int YearOfPublish { get; set; }
        public int NumberOfPages { get; set; }

        public Genre Genre { get; set; }
        public Publisher Publisher { get; set; }
        public ICollection<AuthorBook> AuthorsBooks { get; set; }
        public ICollection<Loan> Loans { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}  Number of Copies {NumberOfCopies} Num of pages: {NumberOfPages}" +
                   $"Publisher: {Publisher.Name} + Genre: {Genre.ToString()}";
        }
    }
}
