using System.Collections.Generic;
using System.Linq;
using Library.Data.Entities;
using Library.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Domain.Repositories
{
    public class StudentRepository
    {
        private readonly LibraryContext _context;
        public StudentRepository()
        {
            _context = new LibraryContext();
        }

        public string AddStudent(Student studentToAdd)
        {
            _context.Students.Add(studentToAdd);
            _context.SaveChanges();
            return "Saved to base";
        }
        
        public string Delete(Student studentToDelete)
        {
            _context.Students.Remove(studentToDelete);
            _context.SaveChanges();
            return $"{studentToDelete.NameSurname()} deleted";
        }

        public List<Student> GetAllStudents()
        {
            return _context.Students.Include(student => student.Loans).OrderBy(student => student.Surname).ToList();
        }

        public string UpdateStudent(Student old, Student newSt)
        {
            var student = _context.Students.Find(old.StudentId);
            student.Name = newSt.Name;
            student.Surname = newSt.Surname;
            student.DateOfBirth = newSt.DateOfBirth;
            student.Gender = newSt.Gender;
            student.Grade = newSt.Grade;
            _context.SaveChanges();
            return "Student edited";
        }

        public Student GetStudentByName(string name)
        {
            return GetAllStudents().Find(s => s.NameSurname() == name);
        }
    }
}
