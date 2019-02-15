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

namespace Library.Presentation.AddForms
{
    public partial class AddPublisher : Form
    {
        private readonly PublisherRepository _publisherRepository;
        public AddPublisher()
        {
            InitializeComponent();
            _publisherRepository = new PublisherRepository();

        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // ---------CHECK INPUTS and CHECK IF PUBLISHER IN BASE
            var name = txtName.Text;
            var address = txtAddress.Text;
            var publisher = new Publisher
            {
                Name = name,
                Address = address
            };

            _publisherRepository.AddPublisher(publisher);
            MessageBox.Show(@"Saved");
            Close();
        }
    }
}
