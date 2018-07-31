using System;

namespace PigLatin
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Enter text to convert to pig latin: ");
            string english = Console.ReadLine();
            //created separate string for the english and pig latin words
            string pigLatin = TranslateWord(english);
            Console.WriteLine(pigLatin);

            // leave this command at the end so your program does not close automatically
            Console.ReadLine();
        }
        
        public static string TranslateWord(string word)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'y', 
                       'A', 'E', 'I', 'O', 'U', 'Y' };
            string firstPart;
            string restOfWord;
            int letterPos = word.IndexOfAny(vowels);


            if (letterPos == 0)
            {
                if (word[0] == 'y')
                {
                    firstPart = word.Substring(0, 1);
                    restOfWord = word.Substring(1);
                    letterPos = restOfWord.IndexOfAny(vowels);
                    firstPart = firstPart + restOfWord.Substring(0, letterPos); 
                    restOfWord = restOfWord.Substring(letterPos);
                    //don't need an end point it will just segment to the end from the start point
                    return restOfWord + firstPart +"ay";              
                }
                return word +"yay";
            }
            else if (letterPos == -1)
            {
                return word + "ay";
            }
            else 
            {
                firstPart = word.Substring( 0, letterPos);
                restOfWord = word.Substring(letterPos);
                return restOfWord + firstPart +"ay";
            }
            // your code goes here{0}
            return word;
        }
    }
}
