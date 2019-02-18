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
using Library.Data.Enums;
using Library.Domain.Repositories;
using Library.Infrastructure.Extensions;

namespace Library.Presentation.EditForms
{
    public partial class EditBook : Form
    {
        private readonly Book _bookToEdit;
        private readonly BookRepository _bookRepository;
        private readonly PublisherRepository _publisherRepository;
        private readonly AuthorRepository _authorRepository;

        public EditBook(Book editBook)
        {
            InitializeComponent();
            _bookToEdit = editBook;
            _bookRepository = new BookRepository();
            _publisherRepository = new PublisherRepository();
            _authorRepository = new AuthorRepository();
            AddGenre();
            AddPublisher();
            AddAuthors();

            txtName.Text = editBook.Name;
            txtDesc.Text = editBook.Description;
            txtCopies.Text = editBook.NumberOfCopies.ToString();
            txtPages.Text = editBook.NumberOfPages.ToString();
            txtYear.Text = editBook.YearOfPublish.ToString();
            cmbGenre.Text = editBook.Genre.ToString();
            cmbAuthor.Text = editBook.Author.NameSurname();
            cmbPublisher.Text = editBook.Publisher.Name;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void AddGenre()
        {
            var enums = Enum.GetValues(typeof(Genre));
            foreach (var job in enums)
            {
                cmbGenre.Items.Add(job);
            }
        }

        public bool AddPublisher()
        {
            var publishers = _publisherRepository.GetAllPublishers();
            foreach (var publisher in publishers)
            {
                cmbPublisher.Items.Add(publisher);
            }

            return publishers.Count != 0;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            var newName = txtName.Text;
            var newDesc = txtDesc.Text;
            var newNumCopy = txtCopies.Text;
            var newNumPages = txtPages.Text;
            var newNumYear = txtYear.Text;

           var newAuth = cmbAuthor.SelectedItem != null ? _authorRepository.GetAuthorByName(cmbAuthor.SelectedItem.ToString()) : _bookToEdit.Author;
            var newPub = cmbPublisher.SelectedItem != null ? _publisherRepository.GetAllPublishers().First(pub => pub == cmbPublisher.SelectedItem as Publisher) : _bookToEdit.Publisher;
            var genre = (Genre)Enum.Parse(typeof(Genre), cmbGenre.SelectedItem.ToString()); //!= null ? (Genre) Enum.Parse(typeof(Genre), cmbGenre.SelectedItem.ToString()) : _bookToEdit.Genre;
           
            if (newNumCopy.CheckIfEmpty() || newNumPages.CheckIfEmpty() || newNumYear.CheckIfEmpty())
            { // if fields not empty, try parse them
                if (!newNumYear.TryParseInt() || !newNumPages.TryParseInt() || !newNumPages.TryParseInt())
                {
                    MessageBox.Show(@"Numbers required", @"Wrong input error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // if parse succeeded, check ages
                if (int.Parse(newNumYear) > 2019 || newNumYear.Length > 4 || newNumYear.Length < 4)
                {
                    MessageBox.Show(@"Can't add year that didn't happened", @"WARNING", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
            }
            var newBook = new Book
            {
                BookId = _bookToEdit.BookId,
                Name = newName,
                Description = newDesc,
                NumberOfCopies = int.Parse(newNumCopy),
                NumberOfPages = int.Parse(newNumPages),
                YearOfPublish = int.Parse(newNumYear),
                Author = newAuth,
                Publisher = newPub,
                Genre = genre
            };

            if (_bookRepository.EditBook(newBook))
            {
                MessageBox.Show(@"Edited", @"INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();

            }

        }
    }
}
