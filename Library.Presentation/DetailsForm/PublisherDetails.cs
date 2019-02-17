using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library.Data.Entities.Models;
using Library.Domain.Repositories;
using Library.Presentation.EditForms;

namespace Library.Presentation.DetailsForm
{
    public partial class PublisherDetails : Form
    {
        private readonly PublisherRepository _publisherRepository;
        private readonly BookRepository _bookRepository;

        private List<Publisher> _listOfPublishers;
        private Publisher _wantedPublisher;

        public PublisherDetails()
        {
            InitializeComponent();
            _publisherRepository = new PublisherRepository();
            _bookRepository = new BookRepository();
            _listOfPublishers = _publisherRepository.GetAllPublishers();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstBooks.Items.Clear();
            var selectedPublisher = cmbName.SelectedItem.ToString();
            _wantedPublisher = _listOfPublishers.First(pub => pub.Name == selectedPublisher);
            txtAddress.Text = _wantedPublisher.Address;
            foreach (var book in _wantedPublisher.Books)
            {
                lstBooks.Items.Add(book.Name);
            }
        }

        public bool LoadPublishers()
        {
            cmbName.Items.Clear();
            foreach (var pub in _listOfPublishers)
            {
                cmbName.Items.Add(pub.Name);
            }

            return cmbName.Items.Count != 0;
        }

        private void PublisherDetails_Load(object sender, EventArgs e)
        {
            if (LoadPublishers()) return;
            MessageBox.Show(@"No details because base is empty", @"WARNING");
            Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var editForm = new EditPublisher(_wantedPublisher);
            editForm.ShowDialog();
            LoadPublishers();
            txtAddress.Clear();
            cmbName.Text = "";

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(@"Are you sure? ", @"WARNING", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.OK:
                {
                    if (cmbName.SelectedItem == null)
                    {
                        MessageBox.Show(@"Choose a publisher", @"WARNING", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    var publisher = _publisherRepository.GetPublisherByName(cmbName.SelectedItem.ToString());
                    var books = _bookRepository.GetBooksByPublisher(publisher);
                    if (books.Count > 0)
                    {
                        MessageBox.Show(@"Can't delete publisher without removing his book first", @"INFO",
                            MessageBoxButtons.OK);
                        return;
                    }

                    if (_publisherRepository.TryDelete(publisher))
                        MessageBox.Show($@"Deleted {publisher.Name}");
                    break;
                }
            }
        }
    }
}
