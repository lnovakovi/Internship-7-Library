﻿using System;
using System.Windows.Forms;
using Library.Domain.Repositories;
using Library.Presentation.AddForms;
using Library.Presentation.Borrowings;
using Library.Presentation.DetailsForm;

namespace Library.Presentation.Main
{
    public partial class MainForm : Form
    {
        private readonly LoanRepository _loanRepository;

        public MainForm()
        {
            InitializeComponent();
            _loanRepository = new LoanRepository();
           
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
                lstLoans.Items.Add($"{loan.LoanDetails()}");
            }
        }

        private void btnCloseBorrow_Click(object sender, EventArgs e)
        {

            if (lstLoans.SelectedItem == null)
            {
                MessageBox.Show(@"Choose loan", @"WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
                
            
            var selectedLoan = lstLoans.SelectedItem.ToString();

            MessageBox.Show(_loanRepository.CloseLoan(selectedLoan));
            ResetLoans();
        }

        private void btnAllLoans_Click(object sender, EventArgs e)
        {
            var allLoans = new AllLoans();
            allLoans.ShowDialog();
        }
    }
}
