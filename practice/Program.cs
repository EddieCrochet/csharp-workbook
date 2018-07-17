using System;

namespace practice
{
    class Program
    {
        static void Main(string[] args)
        {
//GOT TO CALL THE FUNCTIONS HERE (or wherever you want them)
substringExample();
IndexOfExample();
JoinExample();
        }

        static void substringExample()
        {
            string haystack = "some long string";
            int index = 3;
            int length = 10;
            string subString1 = haystack.Substring(index);
            string subString2 = haystack.Substring(index, length);
            Console.WriteLine("substring1 = {0}", subString1);
            Console.WriteLine("substring2 = {0}", subString2);
        }

        static void IndexOfExample()
        {
            string haystack = "The quick brown fox jumps over the lazy dog.";
            string needle = "a";
            int index = haystack.IndexOf(needle);
            Console.WriteLine("found the needle starting at position {0}", index );
        }
           
        static void JoinExample()
        {
            string fname = "John";
            string lname = "Doe";
            string mname = "Billy";

            string[] nameParts = new string[3];
            nameParts[0] = fname;
            nameParts[1] = mname;
            nameParts[2] = lname;

            string separator = " ";

            String fullName = String.Join(separator, nameParts);
            Console.WriteLine(fullName);
        }
    }
}
