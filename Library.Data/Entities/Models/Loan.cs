using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Entities.Models
{
    public class Loan
    {
        public int LoanId { get; set; }
        public int StudentId { get; set; }
        public int BookId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public Student Student { get; set; }
        public Book Book { get; set; }

       
        public string LoanDetails()
        {
            return
                $"{Student.NameSurname()} Book: {Book.Name} Start: {LoanDate.Date.ToShortDateString()}, End: {ReturnDate}";
        }
    }
}
