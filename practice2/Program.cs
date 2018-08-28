using System;
using System.Linq;

namespace practice2
{
    class Program
    {
        public static Student[] makeSomeStudents(int numStudents)
        {
            Student[] theStudents = new Student[numStudents];
            for (int i = 0; i < numStudents; i++)
            {
                Student theNewStudent = new Student(i.ToString(), "first_name_"+i, "last_name_"+i);
                
                Random rnd = new Random();
                //instansiate the random you dont pass anything
                double randomDouble = rnd.NextDouble();
                int multiplyBy100k = (int) (randomDouble * 100000);
                double balance =  multiplyBy100k / 100.0;
                theNewStudent.balance = balance;

                theStudents[i] = theNewStudent;
            }
            return theStudents;
        }
        static void Main()
        {
            Student[] myStudents = makeSomeStudents(100);
            foreach(Student s in myStudents)
            {
                Console.WriteLine("{0} is {1} {2}", s.id, s.firstName, s.lastName);
            }

            var resultSet =
                from stu in myStudents
                where (stu.firstName.EndsWith("3")) && (stu.lastName.EndsWith("3")) && (stu.balance > 100)
                orderby stu.balance descending
                select stu;

            foreach(Student s in resultSet)
            {
                Console.WriteLine("{0} is {1} {2}", s.id, s.firstName, s.lastName);
            }

            int[] numbers = {0,1,2,3,4,5,6};
            var divisableThree =
                from num in numbers
                where (num % 3) == 0
                select num;

            foreach (int i in divisableThree)
            {
                Console.WriteLine(i);
            }
        }
    }

    public class Student
    {
        public String firstName;
        public String lastName;
        public double balance;
        public String id;

        public Student(String id, String firstName, String lastName)
        {
            this.balance = 0;
            this.firstName = firstName;
            this.lastName = lastName;
            this.id = id;
        }
    }
}

