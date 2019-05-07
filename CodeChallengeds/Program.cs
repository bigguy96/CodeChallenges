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
            var checkNums = CodingChallenges.CheckNums(10, 10);
            var checkNums2 = CodingChallenges.CheckNums(10, 100);
            var checkNums3 = CodingChallenges.CheckNums(100, 10);
            var timeConvert = CodingChallenges.TimeConvert(126);
            var alphabetSoup = CodingChallenges.AlphabetSoup("dfghdsetqwerw");
            var kaprekar = CodingChallenges.KaprekarsConstant(9831);
            var scaleBalancing = CodingChallenges.ScaleBalancing(new[] { "[13, 4]", "[1, 2, 3, 6, 14]" });


            Console.WriteLine(word);
            Console.WriteLine(factorial);
            Console.WriteLine(reverse);
            Console.WriteLine(letterChange);
            Console.WriteLine(simpleAdding);
            Console.WriteLine(letterCapitalize);
            Console.WriteLine(simpleSymbols);
            Console.WriteLine(simpleSymbols2);
            Console.WriteLine(checkNums);
            Console.WriteLine(checkNums2);
            Console.WriteLine(checkNums3);
            Console.WriteLine(timeConvert);
            Console.WriteLine(alphabetSoup);
            Console.WriteLine(kaprekar);
            Console.WriteLine(scaleBalancing);

            Console.ReadKey();
        }
    }
}
