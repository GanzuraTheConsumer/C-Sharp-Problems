using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosterList
{
    public class Program
    {
        public static void Main()
        {
            var Math = new Course("Mathmatics");

            var DaveG = new Student("Dave", "Green", new DateTime(1990, 3, 15));
            Math.AddStudent(DaveG);
            var AlexT = new Student("Alexander", "Trimble", new DateTime(2000, 3, 15));
            Math.AddStudent(AlexT);
            var FrankG = new Student("Frank", "Green", new DateTime(1990, 3, 15));
            Math.AddStudent(FrankG);

            Console.WriteLine(Math.CourseName());
            Math.ListStudents();
        }
    }

    public class Person
    {
        public Person(string firstName, string lastName, DateTime dateOfBirth)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
        }

        protected string FirstName { get; private set; }
        protected string LastName { get; private set; }
        public DateTime DateOfBirth { get; private set; }

        public string FullName { get { return $"{this.FirstName} {this.LastName}"; } }

        public bool IsAnAdult()
        {
            var eighteenYearsAgo = DateTime.Today.AddYears(-18);
            return this.DateOfBirth < eighteenYearsAgo;
        }
    }

    public class Student : Person
    {
        public Student(string firstName, string lastName, DateTime dateOfBirth)
            : base(firstName, lastName, dateOfBirth)
        { }
        public string SchoolName { get; private set; }

        public string RosterName { get { return $"{this.LastName}, {this.FirstName}"; } }
    }

    public class Course
    {
        private List<Student> EnrolledStudents = new List<Student>();
        private string _CourseName;

        public Course(string _courseName)
        {
            _CourseName = _courseName;
        }

        public string CourseName()
        {
            return _CourseName;
        }

        public void AddStudent(Student student)
        {
            EnrolledStudents.Add(student);
        }

        public void ListStudents()
        {
            for (var i = 0; i < EnrolledStudents.Count; i++)
            {
                Console.WriteLine(EnrolledStudents[i].RosterName);
            }
        }
    }
}
