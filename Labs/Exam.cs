using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs
{
    public class Exam : IDateAndCopy

    {

        public string SubjectName
        {
            get;
            set;
        }

        public int Grade
        {
            get;
            set;
        }

        public DateTime DateOfPassing
        {
            get;
            set;
        }
        public DateTime Date
        {
            get;
            set;
        }

        private Exam() { }
        public Exam(string subjectName, int grade, DateTime dateOfPassing)
        {
            SubjectName = subjectName;
            Grade = grade;
            DateOfPassing = dateOfPassing;
        }

        public override string ToString()
        {
            return SubjectName + ", grade: " + Grade + ", date: " + DateOfPassing.ToString(Person.DATE_FORMAT);
        }
        public bool Equals(Exam other)
        {
            if (other is null)
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return SubjectName.Equals(other.SubjectName)
                && Grade.Equals(other.Grade)
                && DateOfPassing.Equals(other.DateOfPassing);
        }

        public override bool Equals(object obj)
        {
            Exam other = obj as Exam;
            if (other is null)
            {
                return false;
            }
            return Equals(other);
        }

        public override int GetHashCode()
        {
            return SubjectName.GetHashCode()
                ^ Grade.GetHashCode()
                ^ DateOfPassing.GetHashCode();
        }

        public object DeepCopy()
        {
            return new Exam
            {
                SubjectName = this.SubjectName,
                Grade = this.Grade,
                DateOfPassing = this.DateOfPassing
            };
        }
        public static bool operator ==(Exam self, Exam other)
        {
            if (self is null)
            {
                return other is null;
            }
            return self.Equals(other);
        }

        public static bool operator !=(Exam self, Exam other)
        {
            return !(self == other);
        }
    }
}
