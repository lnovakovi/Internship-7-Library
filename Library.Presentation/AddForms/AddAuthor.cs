﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library.Presentation.AddForms
{
    public partial class AddAuthor : Form
    {
        public AddAuthor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //open form to add book 
            var addBookForm = new AddBook();
            addBookForm.ShowDialog();
        }

        private void AddAuthor_Load(object sender, EventArgs e)
        {
            
        }
    }
}
