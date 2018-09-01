using System;
using System.IO;

namespace practice
{
    class Program
    {
        static void Main(string[] args)
        {
            //instantiated the reader
            StreamReader reader = new StreamReader(@"C:\\ThisPC\Desktop\words_alpha.txt");
            //create a reader and a copied version of data in writer to start with
            //instantiate a writer
            StreamWriter writer = new StreamWriter(@"C:\\ThisPC\Desktop\words.copy.txt");

            String line;

            while((line = reader.ReadLine()) != null)
            {
                writer.WriteLine(line);
            }

            reader.Close();
            writer.Flush();
            writer.Close();
        }
    }
}
