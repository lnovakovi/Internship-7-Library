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

namespace Library.Presentation.DetailsForm
{
    public partial class BookDetails : Form
    {
        private readonly BookRepository _bookRepository;
        private List<Book> _listOfBooks;
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
            foreach (var book in _listOfBooks)
            {
                cmbBook.Items.Add(book.Name);
            }
        }

        private void cmbBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedBook = cmbBook.SelectedItem.ToString();
            var wantedBook = _listOfBooks.First(book => book.Name == selectedBook);
            txtCopies.Text = wantedBook.NumberOfCopies.ToString();
            txtPages.Text = wantedBook.NumberOfPages.ToString();
            txtPublisher.Text = wantedBook.Publisher.Name;
            txtYear.Text = wantedBook.YearOfPublish.ToString();
            txtAuthor.Text = wantedBook.Author.NameSurname();
        }
        // -------------add delete book
    }
}
