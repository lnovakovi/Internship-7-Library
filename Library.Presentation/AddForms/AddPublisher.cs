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
using Library.Infrastructure.Extensions;

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
            
            var name = txtName.Text;
            var address = txtAddress.Text;
            if (name.CheckIfEmpty() || address.CheckIfEmpty())
            {
                MessageBox.Show(@"All fields required", @"WARNING");
                return;
            }
            var publisher = new Publisher
            {
                Name = name,
                Address = address
            };
            MessageBox.Show(_publisherRepository.AddPublisher(publisher),@"INFO");
            Close();
        }
    }
}
