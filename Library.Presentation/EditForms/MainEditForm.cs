using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library.Domain.Repositories;

namespace Library.Presentation.EditForms
{
    public partial class MainEditForm : Form
    {
        private readonly AuthorRepository _authorRepository;
        public MainEditForm()
        {
            InitializeComponent();
            _authorRepository = new AuthorRepository();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var selectedAuthor = _authorRepository.GetAuthorByName(lstAuthors.SelectedItem.ToString());
            var editForm = new EditAuthor(selectedAuthor);
            editForm.ShowDialog();
        }

        public bool LoadAuthor()
        {
            var authors = _authorRepository.GetAllAuthors();
            foreach (var author in authors)
            {
                lstAuthors.Items.Add(author.NameSurname());
            }

            return authors.Count != 0;
        }

        private void MainEditForm_Load(object sender, EventArgs e)
        {
            if (LoadAuthor()) return;
            MessageBox.Show(@"No authors in base");
            Close();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
