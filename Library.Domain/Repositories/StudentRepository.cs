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
            
            //to do
            // delete all loans he has..
        }

        public List<Student> GetAllStudents()
        {
            return _context.Students.Include(student => student.Loans).OrderBy(student => student.Surname).ToList();
        }

    }
}
