using System;
using System.Collections;
using System.Collections.Generic;

namespace practice
{
    class Program
    
    {
        static void Main(string[] args)
        {
            Student jason = new Student("Jason C", "Dec 17");
            Student jasonClone = new Student("Jason C", "Dec 17");
            //creating a new instance makes it NOT the same thing anymore
            Student sameJason = jason;

            Console.WriteLine("Is jason equals jason? {0}", jason.Equals(jason));
            Console.WriteLine("Is jason equals jasonClone? {0}", jason.Equals(jasonClone));
            Console.WriteLine("Is jason equals sameJason? {0}", jason.Equals(sameJason));

            String x = "my String";
            String y = "my String";
            //for string equality it just checks the strings themselves, not the instances

            Console.WriteLine("is x equals to y? {0}", x.Equals(y));


            Stack things = new Stack();
            //not a stack of strings
            //not a stack of students
            //general stack of objects

            things.Push(x);
            things.Push(y);
            things.Push(jason);
            things.Push(jasonClone);
        }
    }

    public class Cohort<T>
    //the letter T is generic that means general same type of things
    {
        List<T> theCohort;
        //list of the things in my cohort
        String name;
        DateTime theDate;
        public T getFirst()
        {
            if (theCohort == null || theCohort.Count== 0)
            {
                return default(T);
                //default return null?
                //when you say its generic it doesnt have to be a class
                //could be anything
                //there are no null int
                //why you cant return null
                //default return the same way as null but for generics
            }
            else
            {
                return theCohort[0];
            }
        }
    }
    public class Student
    {
        String name{get;}
        String dob{get;}

        public Student(String name, String dob)
        {
            this.name = name;
            this.dob = dob;
        }
    }
}
