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

            Console.WriteLine(word);
            Console.WriteLine(factorial);
            Console.WriteLine(reverse);
            Console.WriteLine(letterChange);
            Console.WriteLine(simpleAdding);

            Console.ReadKey();
        }
    }
}
