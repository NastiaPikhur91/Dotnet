using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            #region Lab_1
            Student student = new Student();
            Console.WriteLine("1. " + student.ToShortString());

            Console.Write("2. ");
            Console.WriteLine("Is Master? " + student[Education.Master]);
            Console.WriteLine("Is Bachelor? " + student[Education.Bachelor]);
            Console.WriteLine("Is SecondEducation? " + student[Education.SecondEducation]);

            student.Person = new Person("John", "Doe", new DateTime(1999, 9, 1));
            student.Education = Education.Bachelor;
            student.Group = 401;
            student.Exams = new Exam[]
            {
                new Exam("C# programming", 5, new DateTime(2018, 6, 1)),
                new Exam("Network security", 4, new DateTime(2018, 6, 5)),
                new Exam("Modern databases", 3, new DateTime(2018, 6, 9))
            };
            Console.WriteLine("3. " + student);

            student.AddExams
            (
                new Exam("Calculus", 4, new DateTime(2018, 6, 13)),
                new Exam("Numerical analysis", 5, new DateTime(2018, 6, 17))
            );
            Console.WriteLine("4. " + student);
            Console.WriteLine(student.ToShortString());

            Console.Write("Enter number of rows and number of columns (split by [space] or [comma]): ");
            string[] numbers = Console.ReadLine().Split(new char[] { ' ', ',' });
            int nRows = int.Parse(numbers[0]);
            int nColumns = int.Parse(numbers[1]);
            Exam[] flatArray = new Exam[nRows * nColumns];
            for (int i = 0; i < nRows * nColumns; i++)
            {
                flatArray[i] = new Exam(string.Empty, 0, DateTime.Now);
            }
            Exam[,] twoDimArray = new Exam[nRows, nColumns];
            for (int i = 0; i < nRows; i++)
            {
                for (int j = 0; j < nColumns; j++)
                {
                    twoDimArray[i, j] = new Exam(string.Empty, 0, DateTime.Now);
                }
            }
            Exam[][] stairsArray = new Exam[nRows][];
            for (int i = 0; i < nRows; i++)
            {
                stairsArray[i] = new Exam[nColumns];
            }
            for (int i = 0; i < nRows; i++)
            {
                for (int j = 0; j < nColumns; j++)
                {
                    stairsArray[i][j] = new Exam(string.Empty, 0, DateTime.Now);
                }
            }

            int saveTick = Environment.TickCount;
            for (int i = 0; i < nRows * nColumns; i++)
            {
                flatArray[i].DateOfPassing = DateTime.Now;
                flatArray[i].Grade = 100;
                flatArray[i].SubjectName = "Test";
            }
            Console.WriteLine(Environment.TickCount - saveTick);

            saveTick = Environment.TickCount;
            for (int i = 0; i < nRows; i++)
            {
                for (int j = 0; j < nColumns; j++)
                {
                    twoDimArray[i, j].DateOfPassing = DateTime.Now;
                    twoDimArray[i, j].Grade = 100;
                    twoDimArray[i, j].SubjectName = "Test";
                }
            }
            Console.WriteLine(Environment.TickCount - saveTick);

            saveTick = Environment.TickCount;
            for (int i = 0; i < nRows; i++)
            {
                for (int j = 0; j < nColumns; j++)
                {
                    stairsArray[i][j].DateOfPassing = DateTime.Now;
                    stairsArray[i][j].Grade = 100;
                    stairsArray[i][j].SubjectName = "Test";
                }
            }
            Console.WriteLine(Environment.TickCount - saveTick);

            Console.ReadKey();
            #endregion
            */
            /*
            #region Lab_2
            Person a = new Person("Ivan", "Ivanov", new DateTime(2000, 1, 1));
            Person b = new Person("Ivan", "Ivanov", new DateTime(2000, 1, 1));
            Console.WriteLine("a == b ? " + (a == b));
            Console.WriteLine("hash a : " + a.GetHashCode() + ", hash b : " + b.GetHashCode());
            Student student = new Student("John", "Johnson", new DateTime(1999, 2, 1), Education.Bachelor, 313);
            student.Exams = new ArrayList
            {
                 new Exam("Calculus", 4, DateTime.Now),
                new Exam("C#", 5, DateTime.Now)
            };
            student.Tests = new ArrayList
            {
                new Test("Java", true),
                new Test("Databases", true)
            };
            Console.WriteLine(student);
            Console.WriteLine(student.Person);

            Student copy = (Student)student.DeepCopy();

            foreach (Test test in student.Tests)
            {
                test.IsPassed = false;
            }
            (student.Exams[0] as Exam).Grade = 2;

            Console.WriteLine('\n' + student.ToString() + '\n' + copy.ToString());

            try
            {
                student.Group = 9000;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            foreach (Exam exam in student.GetExamsGraderThan(3))
            {
                Console.WriteLine(exam);
            }
            Console.ReadKey();
            #endregion
            */

            #region Lab_3
            Student student1 = new Student("Ffff_A", "Iaaa_A", DateTime.Now, Education.Bachelor, 401, new List<Exam>()
            {
                new Exam("Math", 5, DateTime.Now),
                new Exam("Phisics", 4, DateTime.Now)
            });
            Student student2 = new Student("Ybdsv_B", "Ohghv_B", DateTime.Now, Education.Master, 501, new List<Exam>()
            {
                new Exam("Math", 3, DateTime.Now),
                new Exam("Phisics", 4, DateTime.Now)
            });

            StudentCollection studentCollection = new StudentCollection();
            studentCollection.AddStudents(student1, student2);

            Console.WriteLine("Unsorted\n" + studentCollection.ToString());
            studentCollection.SortByLastName();
            Console.WriteLine("Sorted by name\n" + studentCollection.ToString());
            studentCollection.SortByDateOfBirth();
            Console.WriteLine("Sorted by date\n" + studentCollection.ToString());
            studentCollection.SortByAvgGrade();
            Console.WriteLine("Sorted by avg grade" + studentCollection.ToString());

            Console.WriteLine("Max\n" + studentCollection.MaxAveGrade());
            Console.WriteLine("Education master\n" + studentCollection.MasterStudents().ToString());

            Console.ReadKey();
            #endregion
        }
    }
}
