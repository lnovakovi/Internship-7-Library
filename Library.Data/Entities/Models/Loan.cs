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
        public double Overdue { get; set; }
        public Student Student { get; set; }
        public Book Book { get; set; }

        public void CalculateOverdue()
        {
            var dateToReturn = new DateTime(LoanDate.Year,LoanDate.Month+1,LoanDate.Day);
            if (dateToReturn.Month > 12)
            {
                dateToReturn = new DateTime(dateToReturn.Year+1,1,dateToReturn.Day);
            }
            if (this.ReturnDate == null && DateTime.Now > dateToReturn)
            {
                var price = 0.5;
                var totalDays = (DateTime.Now - dateToReturn).Days;
                this.Overdue = totalDays * price;
            }
            else if (DateTime.Now > dateToReturn)
            {
                var price = 0.5;
                var totalDays = (DateTime.Now - dateToReturn).Days;
                this.Overdue = totalDays * price;
            }
        }
        public string LoanDetails()
        {
            return
                $"{Student.NameSurname()} Book: {Book.Name} Start: {LoanDate.Date.ToShortDateString()}, End: {ReturnDate}, Overdue: {Overdue}";
        }
    }
}
