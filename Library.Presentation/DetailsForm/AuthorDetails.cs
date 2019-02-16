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
    public partial class AuthorDetails : Form
    {
        private readonly AuthorRepository _authorRepository;
        private readonly BookRepository _bookRepository;
        public AuthorDetails()
        {
            InitializeComponent();
            _authorRepository = new AuthorRepository();
            _bookRepository = new BookRepository();
           
        }
        public bool AddAuthors()
        {
            var authors = _authorRepository.GetAllAuthors();
            foreach (var author in authors)
            {
                cmbAuthor.Items.Add(author.NameSurname());
                
            }
            return authors.Count != 0;
        }

        private void AuthorDetails_Load(object sender, EventArgs e)
        {
            if (AddAuthors()) return;
            MessageBox.Show(@"No details because base is empty.", @"WARNING");
            Close();
        }

        private void cmbAuthor_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstBooks.Items.Clear();
            var selectedAuthor = cmbAuthor.SelectedItem.ToString();        
            var wantedAuthor = _authorRepository.GetAuthorByName(selectedAuthor);
            var books = _bookRepository.GetBooksByAuthor(wantedAuthor);
            txtDate.Text = wantedAuthor.DateOfBirth.ToShortDateString();
            foreach (var book in books)
            {
                lstBooks.Items.Add(book.Name);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
