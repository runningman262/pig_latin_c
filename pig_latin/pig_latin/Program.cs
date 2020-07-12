using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pig_latin
{
    class Program
    {
        static void Main(string[] args)
        {
            /*words beginning with consanants, 
            move all letters up to the first vowel to the end and add ay
            ex. smile would be ilesmay*/
            
            /*words beginning with vowels
             * no letters move and yay gets added to the end
             * 
             * optional, if there are multiple syllables, 
             * all letters up to the next vowel move to the end and add ay*/
            
            Console.WriteLine("Enter a word or phrase to translate to Pig Latin.");
            string inputPhrase = Console.ReadLine().ToLower();

            string[] arrayPhrase = new string[] { };
            int i = 0;
            while (inputPhrase.Length > 0)
            {
                int spacePos = inputPhrase.IndexOf(" ");
                int wordEnd = (spacePos > 0) ? spacePos : inputPhrase.Length;
                Array.Resize(ref arrayPhrase, arrayPhrase.Length + 1);
                arrayPhrase[i] = inputPhrase.Substring(0, wordEnd);
                inputPhrase = (spacePos > 0) ? inputPhrase.Substring(wordEnd + 1) : "";
                i++;

            }

            string pigLatinPhrase;
            i = 0;
            foreach (var item in arrayPhrase)
            {
                int startPos = FindFirstVowel(arrayPhrase[i]);
                pigLatinPhrase = ToPigLatin(arrayPhrase[i], startPos);
                Console.Write($"{pigLatinPhrase} ");
                i++;
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        static int FindFirstVowel(string inputPhraseYay)
        {
            // need to find the first instance of a, e, i, o, or u.
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            int firstVowel = inputPhraseYay.IndexOfAny(vowels);

            //if no standard vowel is found, find and set y as the vowel.
            if (firstVowel == -1)
            {
                return inputPhraseYay.IndexOf("y");
            }
            else
            {
                return firstVowel;
            }
        }

        static string ToPigLatin(string inputPhraseYay, int start)
        {
            if (start == 0)
            {
                return inputPhraseYay + "yay";

            } 
            else
            {
                return inputPhraseYay.Substring(start) + inputPhraseYay.Substring(0, start) + "ay";
            }
        }

    }
}
