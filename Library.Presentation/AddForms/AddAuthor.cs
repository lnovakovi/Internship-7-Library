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
    public partial class AddAuthor : Form
    {
        private readonly AuthorRepository _authorRepository;
       
        public AddAuthor()
        {
            InitializeComponent();
            _authorRepository = new AuthorRepository();
            AddGender();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void AddGender()
        {
            var enums = Enum.GetValues(typeof(Gender));
            foreach (var job in enums)
            {
                cmbGender.Items.Add(job);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text.CheckIfEmpty() || txtSurname.Text.CheckIfEmpty() || cmbGender.SelectedItem == null)
            {
                MessageBox.Show(@"All fields required", @"WARNING");
                return;
            }

            if (!date.Value.CheckForAges(18,null))
            {
                MessageBox.Show("Must be older than 18");
                return;
            }
            var name = txtName.Text;
            var surname = txtSurname.Text;
            var dateOfBirth = date.Value.Date;
            var gender = (Gender)Enum.Parse(typeof(Gender), cmbGender.SelectedItem.ToString());           
            var author = new Author
             {
                 Name = name,
                 Surname = surname,
                 DateOfBirth = dateOfBirth,
                 Gender = gender
             };          
            MessageBox.Show(_authorRepository.AddAuthor(author), @"SAVED DATA");
            Close();


        }
    }
}
