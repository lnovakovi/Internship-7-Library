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

namespace Library.Presentation.DetailsForm
{
    public partial class PublisherDetails : Form
    {
        private readonly PublisherRepository _publisherRepository;
        private List<Publisher> _listOfPublishers;
        public PublisherDetails()
        {
            InitializeComponent();
            _publisherRepository = new PublisherRepository();
            _listOfPublishers = _publisherRepository.GetAllPublishers();
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedPublisher = cmbName.SelectedItem.ToString();
            var wantedPublisher = _listOfPublishers.First(pub => pub.Name == selectedPublisher);
            txtAddress.Text = wantedPublisher.Address;
            foreach (var book in wantedPublisher.Books)
            {
                lstBooks.Items.Add(book.Name);
            }
        }

        public bool LoadPublishers()
        {
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
    }
}
