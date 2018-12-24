using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs
{
    public class Exam
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
    }
}
