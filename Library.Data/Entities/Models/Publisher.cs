using System.Collections.Generic;
using Library.Infrastructure.Extensions;

namespace Library.Data.Entities.Models
{
    public class Publisher
    {
        public int PublisherId { get; set; }
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
        public string Address { get; set; }
        public ICollection<Book> Books { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}  Address: {Address}";
        }


    }
}
