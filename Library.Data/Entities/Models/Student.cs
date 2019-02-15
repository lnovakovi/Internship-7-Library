using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data.Enums;
using Library.Infrastructure.Extensions;

namespace Library.Data.Entities.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        private string _name;
        private string _surname;
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
                _surname = _name.CapitalizeEachWord();
            }
        }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public Grade Grade { get; set; }
        public ICollection<Loan> Loans { get; set; }

        public override string ToString()
        {
            return $"Name: {NameSurname()} + Date of birth: {DateOfBirth.ToShortDateString()}";
        }

        public string NameSurname()
        {
            return $"{Name} {Surname}";
        }
    }
}
