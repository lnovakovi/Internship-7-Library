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
    public partial class AuthorDetails : Form
    {
        private readonly AuthorRepository _authorRepository;
        private readonly BookRepository _bookRepository;
        private Author _wantedAuthor;
        
        public AuthorDetails()
        {
            InitializeComponent();
            _authorRepository = new AuthorRepository();
            _bookRepository = new BookRepository();
           
        }
        public bool AddAuthors()
        {
            cmbAuthor.Items.Clear();
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
            
        }

        private void cmbAuthor_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstBooks.Items.Clear();
            var selectedAuthor = cmbAuthor.SelectedItem.ToString();        
            _wantedAuthor = _authorRepository.GetAuthorByName(selectedAuthor);
            var books = _bookRepository.GetBooksByAuthor(_wantedAuthor);
            txtDate.Text = _wantedAuthor.DateOfBirth.ToShortDateString();
            txtGender.Text = _wantedAuthor.Gender.ToString();
            foreach (var book in books)
            {
                lstBooks.Items.Add(book.Name);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_wantedAuthor == null)
            {
                MessageBox.Show(@"Choose an author first!", @"WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var editForm = new EditAuthor(_wantedAuthor);
            editForm.ShowDialog();
            Close();

        }

        private void btnDeleteAuthor_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(@"Are you sure? ", @"WARNING", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.OK:
                {
                    if (cmbAuthor.SelectedItem == null)
                    {
                        MessageBox.Show(@"Choose an author", @"WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var author = _authorRepository.GetAuthorByName(cmbAuthor.SelectedItem.ToString());
                    var books = _bookRepository.GetBooksByAuthor(author);
                    if (books.Count>0)
                    {
                        MessageBox.Show(@"Can't delete author without removing his book first", @"INFO", MessageBoxButtons.OK);
                        return;
                    }

                    if (_authorRepository.TryDelete(author))
                        MessageBox.Show($@"Deleted {author.NameSurname()}");
                        break;
                }
            }
            
            Close();
        }
    }
}
