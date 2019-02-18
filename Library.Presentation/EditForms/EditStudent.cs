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
using Library.Infrastructure.Extensions;

namespace Library.Presentation.EditForms
{
    public partial class EditStudent : Form
    {
        private readonly StudentRepository _studentRepository;
        private readonly Student _student;
        public EditStudent(Student studentToEdit)
        {
            InitializeComponent();
            _studentRepository=new StudentRepository();
            _student = studentToEdit;
            txtName.Text = studentToEdit.Name;
            txtSurname.Text = studentToEdit.Surname;
            dateBirth.Value = studentToEdit.DateOfBirth;
            cmbGender.Text = studentToEdit.Gender.ToString();
            cmbGrade.Text = studentToEdit.Grade.ToString();
            AddGender();
            AddGrade();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }


        public void AddGender()
        {
            var jobs = Enum.GetValues(typeof(Gender));
            foreach (var job in jobs)
            {
                cmbGender.Items.Add(job);
            }
        }
        public void AddGrade()
        {
            var grade = Enum.GetValues(typeof(Grade));
            foreach (var g in grade)
            {
                cmbGrade.Items.Add(g);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            var newDate= new DateTime();
            var newName = !txtName.Text.CheckIfEmpty() ? txtName.Text : _student.Name;
            var  newSurname = !txtSurname.Text.CheckIfEmpty() ? txtSurname.Text : _student.Surname;
            if (dateBirth.Value.CheckForAges(6, 17))
                newDate = dateBirth.Value;
            else
            {
                MessageBox.Show(@"Check ages! ( Students are aged between 6 and 17 years)", @"WARNING");
                return;
            }

            var gender = cmbGender.SelectedItem != null ? (Gender)Enum.Parse(typeof(Gender), cmbGender.SelectedItem.ToString()) : _student.Gender;
            var grade = cmbGender.SelectedItem != null ? (Grade)Enum.Parse(typeof(Grade), cmbGrade.SelectedItem.ToString()) : _student.Grade;

            var newSt = new Student
            {
                Name = newName,
                Surname = newSurname,
                DateOfBirth = dateBirth.Value,
                Gender = gender,
                Grade = grade
            };

            if (_studentRepository.UpdateStudent(_student, newSt))
                MessageBox.Show("Edited student");
            Close();




        }
    }
}
