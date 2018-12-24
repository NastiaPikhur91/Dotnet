using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs
{
    public class Student
    {
        private Person person;
        private Education education;
        private int group;
        private Exam[] exams;

        public Student(Person person, Education education, int group)
        {
            Person = person;
            Education = education;
            Group = group;
        }

        public Student()
        {
            Person = new Person();
        }


        public Person Person
        {
            get => person;
            set => person = value;
        }

        public Education Education
        {
            get => education;
            set => education = value;
        }

        public int Group
        {
            get => group;
            set => group = value;
        }

        public Exam[] Exams
        {
            get => exams;
            set => exams = value;
        }

        public double AvgGrade
        {
            get => exams != null
                ? exams.Average(exam => exam.Grade)
                : 0;
        }

        public bool this[Education toCompare]
        {
            get => education == toCompare;
        }

        
        public void AddExams(params Exam[] newExams)
        {
            if (exams != null && Exams.Length != 0)
            {
                Exam[] concatExams = new Exam[exams.Length + newExams.Length];
                exams.CopyTo(concatExams, 0);
                newExams.CopyTo(concatExams, exams.Length);
                exams = concatExams;
            }
            else
            {
                exams = newExams;
            }
        }

        public override string ToString()
        {
            string result = "Person: " + person.ToString() + "\n"
                + education.ToString() + ", " + group.ToString() + " group\nExams: ";
            if (exams != null)
            {
                result += string.Join<Exam>("\n", exams);
            }
            else
            {
                result += "none";
            }
            return result;
        }

        public virtual string ToShortString()
        {
            return "Student: " + person.ToString() + "\n"
                + education.ToString() + ", " + group.ToString() + " group\n"
                + "Average grade: " + AvgGrade.ToString();
        }
    }
}
