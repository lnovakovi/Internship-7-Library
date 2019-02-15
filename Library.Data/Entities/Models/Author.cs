using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data.Enums;
using Library.Infrastructure.Extensions;

namespace Library.Data.Entities.Models
{
    public class Author
    {
        public int AuthorID { get; set; }
        private string _surname;
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

        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value.RemoveWhiteSpaces();
                _surname = _surname.CapitalizeEachWord();
            }
        }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public ICollection<Book> Books { get; set; }
        
        public override string ToString()
        {
            return $"Name: {NameSurname()} Date of Birth: {DateOfBirth.ToShortDateString()}";
        }

        public string NameSurname()
        {
            return $"Name: {Name} {Surname}";
        }
    }
}
