using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs
{
    public class Person : IDateAndCopy
    {
        public const string DATE_FORMAT = "dd/M/yyyy";

        public string firstName;
        public string lastName;
        public DateTime dateOfBirth;

      
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
        public DateTime Date
        {
            get;
            set;
        }

        public override string ToString()
        {
            return "\n - Person name: " + firstName + "\n - Person surname: " + lastName + "\n - DateOfbirthday: " + dateOfBirth.ToString(DATE_FORMAT);
        }

        public virtual string ToShortString()
        {
            return "\nPerson name: " + firstName + "\nPerson surname: " + lastName;
        }


        public bool Equals(Person other)
        {
            if (other is null)
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return firstName.Equals(other.firstName)
                && lastName.Equals(other.lastName)
                && dateOfBirth.Equals(other.dateOfBirth);
        }

        public override bool Equals(object obj)
        {
            Person other = obj as Person;
            if (other is null)
            {
                return false;
            }
            return Equals(other);
        }

        public override int GetHashCode()
        {
            return firstName.GetHashCode()
                ^ lastName.GetHashCode()
                ^ dateOfBirth.GetHashCode();
        }

        public virtual object DeepCopy()
        {
            return new Person
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                DateOfBirth = this.DateOfBirth
            };
        }

        public static bool operator ==(Person self, Person other)
        {
            if (self is null)
            {
                return other is null;
            }
            return self.Equals(other);
        }

        public static bool operator !=(Person self, Person other)
        {
            return !(self == other);
        }
    }
}
