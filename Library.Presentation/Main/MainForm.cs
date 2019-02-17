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
using Library.Presentation.AddForms;
using Library.Presentation.DetailsForm;
using Library.Presentation.EditForms;

namespace Library.Presentation.Main
{
    public partial class MainForm : Form
    {
        private readonly LoanRepository _loanRepository;
        private readonly StudentRepository _studentRepository;
        private readonly BookRepository _bookRepository;

        public MainForm()
        {
            InitializeComponent();
            _loanRepository = new LoanRepository();
            _studentRepository = new StudentRepository();
            _bookRepository = new BookRepository();
        }

        private void btnAddAuthor_Click(object sender, EventArgs e)
        {
            var addForm = new AddAuthor();
            addForm.ShowDialog();
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            var addBook = new AddBook();
            addBook.ShowDialog();
        }

        private void btnAddPublisher_Click(object sender, EventArgs e)
        {
            var addPublisher = new AddPublisher();
            addPublisher.ShowDialog();
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            var addStudent = new AddStudent();
            addStudent.ShowDialog();
        }


        private void btnAuthorDetails_Click(object sender, EventArgs e)
        {
            var authorDet = new AuthorDetails();
            authorDet.ShowDialog();
        }

        private void btnStudentDetails_Click(object sender, EventArgs e)
        {
            var studentDet = new StudentDetails();
            studentDet.ShowDialog();
        }

        private void btnBookDetails_Click(object sender, EventArgs e)
        {
            var bookDet = new BookDetails();
            bookDet.ShowDialog();
        }

        private void btnPublisherDetails_Click(object sender, EventArgs e)
        {
            var publisherDet = new PublisherDetails();
            publisherDet.ShowDialog();
        }

        private void btnEditAuthor_Click(object sender, EventArgs e)
        {
            var editA = new MainEditForm();
            editA.ShowDialog();
        }

        private void btnEditStudent_Click(object sender, EventArgs e)
        {
            var editS = new EditStudent();
            editS.ShowDialog();
        }

        private void btnEditBook_Click(object sender, EventArgs e)
        {
            var editB = new EditBook();
            editB.ShowDialog();
        }

        private void btnEditPublisher_Click(object sender, EventArgs e)
        {
            var edit = new EditPublisher();
            edit.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            var newBorrow = new NewBorrow();
            newBorrow.ShowDialog();
            ResetLoans();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ResetLoans();
        }

        public void ResetLoans()
        {
            lstLoans.Items.Clear();
            var loans = _loanRepository.GetActiveLoans();
            foreach (var loan in loans)
            {
                lstLoans.Items.Add( loan.LoanDetails());
            }
        }

        private void btnCloseBorrow_Click(object sender, EventArgs e)
        {
            var selectedLoan = lstLoans.SelectedItem.ToString();
            _loanRepository.CloseLoan(selectedLoan);
            ResetLoans();
        }

    }
}
