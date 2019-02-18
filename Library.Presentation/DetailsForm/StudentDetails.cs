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
using Library.Presentation.EditForms;

namespace Library.Presentation.DetailsForm
{
    public partial class StudentDetails : Form
    {
        private readonly StudentRepository _studentRepository;
        private List<Student> _listOfStudents;
        private readonly LoanRepository _loanRepository;
        public StudentDetails()
        {
            InitializeComponent();
            _studentRepository=new StudentRepository();
            _loanRepository = new LoanRepository();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void StudentDetails_Load(object sender, EventArgs e)
        {
            if (AddStudents()) return;
            MessageBox.Show(@"No details because base is empty.", @"WARNING");
            Close();
        }
        public bool AddStudents()
        {
            _listOfStudents = _studentRepository.GetAllStudents();
            foreach (var student in _listOfStudents)
            {
                cmbStudent.Items.Add(student.NameSurname());
            }
            return _listOfStudents.Count != 0;
        }

        private void cmbStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstLoans.Items.Clear();
            var selectedStudent = cmbStudent.SelectedItem.ToString();
            var wantedStudent = _listOfStudents.First(student => student.NameSurname() == selectedStudent);
            txtDate.Text = wantedStudent.DateOfBirth.ToShortDateString();
            txtGender.Text = wantedStudent.Gender.ToString();
            txtGrade.Text = wantedStudent.Grade.ToString();
            var loans = _loanRepository.GetStudentsLoans(selectedStudent);
            foreach (var loan in loans)
            {
                lstLoans.Items.Add(loan.LoanDetails());
            }



        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cmbStudent.SelectedItem == null)
            {
                MessageBox.Show(@"First choose student", @"WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //need to check if student is in active loan
            var student = _studentRepository.GetAllStudents().Find(s => s.NameSurname() == cmbStudent.SelectedItem.ToString());
            var activeLoan = _loanRepository.GetActiveLoans();
            foreach (var loan in activeLoan)
            {
                if (student.StudentId == loan.StudentId)
                {
                    MessageBox.Show(@"Can't delete student that is in active loan!");
                    return;
                }
            }

            MessageBox.Show(_studentRepository.Delete(student));
            Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var selected = _studentRepository.GetStudentByName(cmbStudent.SelectedItem.ToString());
            var editForm = new EditStudent(selected);
            editForm.ShowDialog();
            Close();
        }
    }
}
