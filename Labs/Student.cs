using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs
{
    public class Student : Person, IDateAndCopy
    {
        private Education education;
        private int group;
        private ArrayList tests;
        private ArrayList exams;

        public Student() : base() { }

        public Student(string firstName, string lastName, DateTime dateOfBirth, Education education, int group)
            : base(firstName, lastName, dateOfBirth)
        {
            Education = education;
            Group = group;
        }

        public Student(Person person, Education education, int group)
            : base(person.FirstName, person.LastName, person.DateOfBirth)
        {
            Education = education;
            Group = group;
        }


        public Person Person
        {
            get => new Person(firstName, lastName, dateOfBirth);
            set
            {
                FirstName = value.FirstName;
                LastName = value.LastName;
                DateOfBirth = value.DateOfBirth;
            }
        }

        public Education Education
        {
            get => education;
            set => education = value;
        }

        public int Group
        {
            set
            {
                if (value <= 100 || value > 699)
                {
                    throw new ArgumentException("Number of group must be between 101 and 699, included.");
                }
                else
                {
                    group = value;
                }
            }

        }

        public ArrayList Exams
        {
            get => exams;
            set => exams = value;
        }
        public ArrayList Tests
        {
            get => tests;
            set => tests = value;
        }

        public double AvgGrade
        {
            get => exams != null
                ? exams.Cast<Exam>().Average(exam => exam.Grade)
                : 0;
        }
        

        public bool this[Education toCompare]
        {
            get => education == toCompare;
        }

        
        public void AddExams(params Exam[] newExams)
        {
            if (exams != null && Exams.Count != 0)
            {
                Exams.AddRange(newExams);
            }
            else
            {
                exams = new ArrayList(newExams);
            }
        }

        public override string ToString()
        {
            string result = "Person: " + base.ToString() + "\n"
                + education.ToString() + ", " + group.ToString() + " group\nExams: ";
            if (exams != null)
            {
                result += string.Join<Exam>("\n", exams.Cast<Exam>());
            }
            else
            {
                result += "none";
            }
            result += "\n, Tests:";
            if (tests != null)
            {
                result += string.Join<Test>("\n", tests.Cast<Test>());
            }
            else
            {
                result += "none";
            }
            return result;
        }

        public override string ToShortString()
        {
            return "Student: " + base.ToString() + "\n"
                 + education.ToString() + ", " + group.ToString() + " group\n"
                + "Average grade: " + AvgGrade.ToString();
        }

        public override object DeepCopy()
        {
            return new Student
            {
                Person = this.Person,
                Education = this.education,
                Group = this.group,
                Exams = new ArrayList(exams.Cast<Exam>().Select(exam => exam.DeepCopy()).ToArray()),
                Tests = new ArrayList(tests.Cast<Test>().Select(test => new Test(test.Name, test.IsPassed)).ToArray())
            };
        }

        public IEnumerable GetExamsGraderThan(double compare)
        {
            return exams.Cast<Exam>().Where(exam => exam.Grade > compare);
        }
        public IEnumerable ExamsAndTests
        {
            get
            {
                ArrayList examsAndTests = new ArrayList { exams };
                examsAndTests.AddRange(tests);
                return examsAndTests.Cast<object>();
            }
        }
    }
}
