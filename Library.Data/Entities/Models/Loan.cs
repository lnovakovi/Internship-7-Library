using System;

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

        public double CalculateOverdue(DateTime start, DateTime end)
        {
            var total = (start - end).TotalDays;
            if (total > 30)
                return total * 0.5;
            return 0;

        }
        
    }
}
