using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs
{
    public class Person
    {
        public const string DATE_FORMAT = "dd/M/yyyy";

        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;

      
        public Person(string firstName, string lastName, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }

        public Person()
        {
            FirstName = "Noname";
            LastName = "Noname";
            DateOfBirth = DateTime.Now;
        }


        public string FirstName
        {
            get => firstName;
            set => firstName = value;
        }

        public string LastName
        {
            get => lastName;
            set => lastName = value;
        }

        public DateTime DateOfBirth
        {
            get => dateOfBirth;
            set => dateOfBirth = value;
        }

        public int YearOfBirth
        {
            get => dateOfBirth.Year;
            set => dateOfBirth = new DateTime(value, dateOfBirth.Month, dateOfBirth.Day);
        }


        public override string ToString()
        {
            return "\n - Person name: " + firstName + "\n - Person surname: " + lastName + "\n - DateOfbirthday: " + dateOfBirth.ToString(DATE_FORMAT);
        }

        public virtual string ToShortString()
        {
            return "\nPerson name: " + firstName + "\nPerson surname: " + lastName;
        }
    }
}
