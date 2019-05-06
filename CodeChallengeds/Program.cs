using System;
using ClassLibrary;

namespace CodeChallengeds
{
    class Program
    {
        static void Main(string[] args)
        {
            var word = CodingChallenges.LongestWord("Hi!! How Are You??");
            var factorial = CodingChallenges.FirstFactorial(8);
            var reverse = CodingChallenges.FirstReverse("Hello World!");
            var letterChange = CodingChallenges.LetterChanges("fun times!");
            var simpleAdding = CodingChallenges.SimpleAdding(140);
            var letterCapitalize = CodingChallenges.LetterCapitalize("hello world how are you my friend");

            Console.WriteLine(word);
            Console.WriteLine(factorial);
            Console.WriteLine(reverse);
            Console.WriteLine(letterChange);
            Console.WriteLine(simpleAdding);
            Console.WriteLine(letterCapitalize);

            Console.ReadKey();
        }
    }
}
