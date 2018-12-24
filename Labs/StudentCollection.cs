using System;
using System.Collections.Generic;
using System.Linq;

namespace Labs
{
    public class StudentCollection
    {
        public event StudentListHandler StudentCountChanged;
        public event StudentListHandler StudentReferenceChanged;
        private readonly List<Student> students;

        public string Name
        {
            get;
            set;
        }

        public Student this[int index]
        {
            get
            {
                return students[index];
            }
            set
            {
                students[index] = value;

                StudentListHandlerEventArgs args = new StudentListHandlerEventArgs
                {
                    Name = this.Name,
                    Info = "Student reference changed",
                    Index = index
                };

                StudentReferenceChanged?.Invoke(value, args);
            }
        }

        public StudentCollection()
        {
            students = new List<Student>();
        }

        public StudentCollection(IEnumerable<Student> _students)
        {
            students = new List<Student>(_students);
        }

        public void AddDefaults(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Student student = new Student();
                students.Add(student);

                StudentListHandlerEventArgs args = new StudentListHandlerEventArgs
                {
                    Name = this.Name,
                    Info = "Default student added",
                    Index = students.Count - 1
                };

                StudentCountChanged?.Invoke(student, args);
            }
        }

        public void AddStudents(params Student[] _students)
        {
            foreach (Student student in _students)
            {
                students.Add(student);
                StudentListHandlerEventArgs args = new StudentListHandlerEventArgs
                {
                    Name = this.Name,
                    Info = "Student added",
                    Index = students.Count - 1
                };

                StudentCountChanged?.Invoke(student, args);
            }
        }

        public bool Remove(int index)
        {
            if (index <= 0 || index > students.Count())
            {
                StudentListHandlerEventArgs args = new StudentListHandlerEventArgs
                {
                    Name = this.Name,
                    Info = "Student removed",
                    Index = index
                };

                StudentCountChanged?.Invoke(students[index], args);

                students.RemoveAt(index);
            }
            else
            {
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            string result = "StudentCollection\n";
            foreach (Student student in students)
            {
                result += student.ToString() + "\n";
            }
            return result + "----------------\n";
        }

        public string ToShortString()
        {
            string result = "StudentCollection\n";
            foreach (Student student in students)
            {
                result += student.ToShortString() + "\n";
            }
            return result;
        }

        public void SortByLastName()
        {
            students.Sort();
        }

        public void SortByDateOfBirth()
        {
            students.Sort(new Person());
        }

        public void SortByAvgGrade()
        {
            students.Sort(new StudentComparer());
        }

        public double MaxAveGrade()
        {
            return students.DefaultIfEmpty(new Student()).Max(m => m.AvgGrade);
        }

        public StudentCollection MasterStudents()
        {
            return new StudentCollection(students
               .DefaultIfEmpty(new Student { Education = Education.Master })
               .Where(m => m.Education == Education.Master));
        }
    }
}
