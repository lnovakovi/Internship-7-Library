using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var numberOfChanges = _context.SaveChanges();
            return $"{studentToDelete.NameSurname()} deleted";
        }

        public List<Student> GetAllStudents()
        {
            return _context.Students.Include(student => student.Loans).OrderBy(student => student.Surname).ToList();
        }

        public bool UpdateStudent(Student old, Student newSt)
        {
            old.Name = newSt.Name;
            old.Surname = newSt.Surname;
            old.DateOfBirth = newSt.DateOfBirth;
            old.Gender = newSt.Gender;
            old.Grade = newSt.Grade;
            _context.SaveChanges();
            return 0 != _context.SaveChanges();
        }

        public Student GetStudentByName(string name)
        {
            return GetAllStudents().Find(s => s.NameSurname() == name);
        }
    }
}
