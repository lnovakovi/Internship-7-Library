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

namespace Library.Presentation.AddForms
{
    public partial class AddStudent : Form
    {
        private readonly StudentRepository _studentRepository;
        public AddStudent()
        {
            InitializeComponent();
            _studentRepository = new StudentRepository();
            AddGender();
            AddGrade();
        }

        private void btnReturn_Click(object sender, EventArgs e)
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
                cmbGender.Items.Add(g);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var name = txtName.Text;
            var surname = txtSurname.Text;
            var dateofBirth = dateBirth.Value;
            var gender = cmbGender.SelectedItem;
            var grade = cmbGrade.SelectedItem;

            if (name.CheckIfEmpty() || surname.CheckIfEmpty() || gender == null || grade == null)
            {
                MessageBox.Show(@"All fields required");
                return;
            }

            var student = new Student()
            {
                Name = name,
                Surname = surname,
                DateOfBirth = dateofBirth,
                Gender = (Gender)Enum.Parse(typeof(Gender), gender.ToString()),
                Grade = (Grade)Enum.Parse(typeof(Grade),grade.ToString())
            };

            MessageBox.Show(_studentRepository.AddStudent(student));
            Close();
        }
    }
}
