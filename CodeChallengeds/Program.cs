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
            var simpleSymbols = CodingChallenges.SimpleSymbols("+d+=3=+s+");
            var simpleSymbols2 = CodingChallenges.SimpleSymbols("f++d+");

            Console.WriteLine(word);
            Console.WriteLine(factorial);
            Console.WriteLine(reverse);
            Console.WriteLine(letterChange);
            Console.WriteLine(simpleAdding);
            Console.WriteLine(letterCapitalize);
            Console.WriteLine(simpleSymbols);
            Console.WriteLine(simpleSymbols2);

            Console.ReadKey();
        }
    }
}
