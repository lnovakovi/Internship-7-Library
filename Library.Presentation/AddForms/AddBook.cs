using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Library.Data.Entities.Models;
using Library.Data.Enums;
using Library.Domain.Repositories;
using Library.Infrastructure.Extensions;

namespace Library.Presentation.AddForms
{
    public partial class AddBook : Form
    {
        private readonly BookRepository _bookRepository;
        private readonly PublisherRepository _publisherRepository;
        private readonly AuthorRepository _authorRepository;


        public AddBook()
        {
            InitializeComponent();
            _bookRepository = new BookRepository();
            _publisherRepository = new PublisherRepository();
            _authorRepository = new AuthorRepository();
            
        }

        private void AddBook_Load(object sender, EventArgs e)
        {
            AddGenre();
            if (AddAuthors() && AddPublisher()) return;
            MessageBox.Show(@"Can't add book because there are no authors or publishers in database");
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var name = txtName.Text;
            var desc = txtDescription.Text;
            var copy = txtNumCopy.Text;
            var pages = txtNumPages.Text;
            var year = txtNumPages.Text;
            var publisher = cmbPublisher.SelectedItem as Publisher;
            var author = cmbAuthor.SelectedItem as Author;
            var genre = cmbGenre.SelectedItem;

            if (name.CheckIfEmpty() || desc.CheckIfEmpty() || copy.CheckIfEmpty() || !copy.TryParseInt() ||
                pages.CheckIfEmpty() || !pages.TryParseInt() || year.CheckIfEmpty() || !year.TryParseInt()
                || cmbPublisher.SelectedItem == null || cmbAuthor.SelectedItem == null || cmbGenre.SelectedItem == null)
            {
                MessageBox.Show(@"All fields required", @"Wrong input error");
                return;
            }

            var book = new Book
            {
                Name = name,
                Description = desc,
                NumberOfCopies = int.Parse(copy),
                NumberOfPages = int.Parse(pages),
                YearOfPublish = int.Parse(year),
                Publisher = publisher,
                Genre = (Genre)Enum.Parse(typeof(Genre), genre.ToString()),
                Author = author
            };

            ;
            MessageBox.Show(_bookRepository.AddBook(book),@"INFO",MessageBoxButtons.OKCancel);
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
            var publishers = _publisherRepository.GetPublishers();
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
                cmbAuthor.Items.Add(author);
            }
            return authors.Count != 0;
        }

    }
}

