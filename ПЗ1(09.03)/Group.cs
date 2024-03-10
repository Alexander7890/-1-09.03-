using System.Collections.Generic;
using System.Linq;

namespace ПЗ1_09._03_
{
    public class Group
    {
        public string Name { get; set; }
        public string Specialty { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();

        public string DisplayStudents()
        {
            return string.Join(", ", Students.Select(s => s.Surname));
        }
        public Student FindStudentBySurname(string surname)
        {
            return Students.FirstOrDefault(s => s.Surname == surname);
        }
        public List<Student> FindStudentsByGrade(int grade)
        {
            return Students.Where(s => s.Grade == grade).ToList();
        }

        public void AddStudent(Student student)
        {
            Students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            Students.Remove(student);
        }
    }
}
