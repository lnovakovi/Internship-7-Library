using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library.Data.Entities.Models;
using Library.Domain.Repositories;
using Library.Presentation.Main;

namespace Library.Presentation.AddForms
{
    public partial class NewBorrow : Form
    {
        private readonly StudentRepository _studentRepository;
        private readonly BookRepository _bookRepository;
        private readonly LoanRepository _loanRepository;
        private readonly HistoryRepository _historyRepository;
        public NewBorrow()
        {
            InitializeComponent();
            _studentRepository = new StudentRepository();
            _bookRepository = new BookRepository();
            _loanRepository = new LoanRepository();
            _historyRepository = new HistoryRepository();
            AddStudents();
            AddBooks();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddBooks()
        {
           var listOfBooks = _bookRepository.GetAllBooks();
            foreach (var book in listOfBooks)
            {
                cmbBook.Items.Add(book.Name);
            }
        }

        private void AddStudents()
        {
            var listOfStudents = _studentRepository.GetAllStudents();
            foreach (var student in listOfStudents)
            {
                cmbStudent.Items.Add(student.NameSurname());
            }
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            var main = new MainForm();
            if (cmbStudent.SelectedItem == null || cmbBook.SelectedItem == null)
            {
                MessageBox.Show(@"You have to choose both",@"INFO");
                return;
            }
            var selectedStudent = cmbStudent.SelectedItem.ToString();
            var selectedBook = cmbBook.SelectedItem.ToString();

            var wantedStudent = _studentRepository.GetAllStudents().First(student => student.NameSurname() == selectedStudent);
            var wantedBook = _bookRepository.GetAllBooks().First(book => book.Name == selectedBook);
            var loan = new Loan
            {
                LoanDate = DateTime.Now.Date,
                ReturnDate = null,
                Student = wantedStudent,
                Book = wantedBook
            };
            
            MessageBox.Show(_loanRepository.AddLoan(loan),@"INFO");
            main.ResetLoans();

            Close();
        }
    }
}
