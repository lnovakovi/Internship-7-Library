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

namespace Library.Presentation.EditForms
{
    public partial class EditAuthor : Form
    {
        private readonly AuthorRepository _authorRepository;
        private Author _authToEdit;

        public EditAuthor(Author authToEdit)
        {
            InitializeComponent();
            _authorRepository= new AuthorRepository();
            _authToEdit = authToEdit;
            AddGender();
            txtAuthor.Text = authToEdit.Name;
            txtSurname.Text = authToEdit.Surname;
            dateBirth.Value = authToEdit.DateOfBirth;
            cmbGender.Text = authToEdit.Gender.ToString();

        }
        public void AddGender()
        {
            var enums = Enum.GetValues(typeof(Gender));
            foreach (var job in enums)
            {
                cmbGender.Items.Add(job);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var result =MessageBox.Show(@"Are you sure? ", @"WARNING", MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (DialogResult.OK == result)
            {
                var author = new Author
                {
                    Name = txtAuthor.Text,
                    Surname = txtSurname.Text,
                    DateOfBirth = dateBirth.Value,
                    Gender = (Gender) Enum.Parse(typeof(Gender), cmbGender.SelectedItem.ToString())
                };
                if (_authorRepository.EditAuthor(_authToEdit, author))
                    MessageBox.Show("Edited!", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
