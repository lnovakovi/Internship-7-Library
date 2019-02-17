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

namespace Library.Presentation.EditForms
{
    public partial class EditPublisher : Form
    {
        private readonly PublisherRepository _publisherRepository;
        private readonly Publisher _pubToEdit;
        public EditPublisher(Publisher publisherToEdit)
        {
            InitializeComponent();
            _publisherRepository= new PublisherRepository();
            _pubToEdit = publisherToEdit;
            txtName.Text = _pubToEdit.Name;
            txtAddress.Text = _pubToEdit.Address;
        }

        

        private void btnSave_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(@"Are you sure? ", @"WARNING", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.OK:
                {
                    var name = txtName.Text;
                    var address = txtAddress.Text;
                    if (name.CheckIfEmpty())
                        name = _pubToEdit.Name;
                    if (address.CheckIfEmpty())
                        address = _pubToEdit.Address;
                    var newPub = new Publisher
                    {
                        Name = name,
                        Address = address
                    };
                    MessageBox.Show(_publisherRepository.EditPublisher(_pubToEdit, newPub), @"Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
            }
            Close();
           

        }
    }
}
