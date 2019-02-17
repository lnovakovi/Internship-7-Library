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
using Library.Presentation.EditForms;

namespace Library.Presentation.DetailsForm
{
    public partial class BookDetails : Form
    {
        private readonly BookRepository _bookRepository;
        private List<Book> _listOfBooks;
        private Book _wantedBook;
        public BookDetails()
        {
            InitializeComponent();
            _bookRepository = new BookRepository();
            _listOfBooks = _bookRepository.GetAllBooks();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BookDetails_Load(object sender, EventArgs e)
        {
            if (AddBooks()) return;
            MessageBox.Show(@"No details because base is empty", @"WARNING");
            Close();          
        }

        private void cmbBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedBook = cmbBook.SelectedItem.ToString();
            _wantedBook = _listOfBooks.First(book => book.Name == selectedBook);
            txtCopies.Text = _wantedBook.NumberOfCopies.ToString();
            txtPages.Text = _wantedBook.NumberOfPages.ToString();
            txtPublisher.Text = _wantedBook.Publisher.Name;
            txtYear.Text = _wantedBook.YearOfPublish.ToString();
            txtAuthor.Text = _wantedBook.Author.NameSurname();
        }

        private bool AddBooks()
        {
            foreach (var book in _listOfBooks)
            {
                cmbBook.Items.Add(book.Name);
            }
            return cmbBook.Items.Count != 0;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (cmbBook.SelectedItem == null)
            {
                MessageBox.Show(@"You have to choose book", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
               
            var editBookForm = new EditBook(_wantedBook);
            editBookForm.ShowDialog();
            AddBooks();
        }
        // -------------add delete book
    }
}
