using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library.Presentation.AddForms;

namespace Library.Presentation.Main
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void btnAddAuthor_Click(object sender, EventArgs e)
        {
            var addForm = new AddAuthor();
            addForm.ShowDialog();
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            var addBook = new AddBook();
            addBook.ShowDialog();
        }

        private void btnAddPublisher_Click(object sender, EventArgs e)
        {
            var addPublisher = new AddPublisher();
            addPublisher.ShowDialog();
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            var addStudent = new AddPublisher();
            addStudent.ShowDialog();
        }
    }
}
