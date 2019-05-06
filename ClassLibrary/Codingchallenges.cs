﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ClassLibrary
{
    public class CodingChallenges
    {
        //https://www.coderbyte.com/editor/guest:Longest%20Word:Csharp
        public static string LongestWord(string sentence)
        {
            var regex = new Regex("(?:[^a-z0-9 ])", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
            var newSentence = regex.Replace(sentence, string.Empty);
            var words = newSentence.Split(new char[0]);
            var dictionary = new Dictionary<int, string>();

            foreach (var word in words)
            {
                var key = word.Length;

                if (!dictionary.ContainsKey(key)) dictionary.Add(key, word);
            }

            var longest = dictionary.Keys.Max();

            return dictionary[longest];
        }

        //https://www.coderbyte.com/editor/guest:First%20Factorial:Csharp
        public static int FirstFactorial(int num)
        {
            var list = Enumerable.Range(1, num);
            var reverse = list.Reverse();

            return reverse.Aggregate(1, (current, i) => current * i);
        }

        //https://www.coderbyte.com/editor/guest:First%20Reverse:Csharp
        public static string FirstReverse(string str)
        {
            var reverse = string.Empty;

            for (var i = str.Length - 1; i >= 0; i--)
            {
                reverse += str[i];
            }

            return reverse;
        }

        //https://www.coderbyte.com/editor/guest:Letter%20Changes:Csharp
        public static string LetterChanges(string word)
        {
            var newWord = new List<char>();

            foreach (var letter in word)
            {
                if (!char.IsLetter(letter))
                {
                    newWord.Add(letter);
                    continue;
                }

                char nextChar;
                if (letter == 'z' || letter == 'Z')
                    nextChar = 'A';
                else
                    nextChar = (char)(letter + 1);

                if (nextChar == 'a' || nextChar == 'e' || nextChar == 'i' || nextChar == 'o' || nextChar == 'u')
                {
                    nextChar = char.ToUpper(nextChar);
                }

                newWord.Add(nextChar);
            }

            return new string(newWord.ToArray());

        }

//        https://www.coderbyte.com/editor/guest:Simple%20Adding:Csharp
        public static int SimpleAdding(int num)
        {

            // code goes here  
            /* Note: In C# the return type of a function and the 
               parameter types being passed are defined, so this return 
               call must match the return type of the function.
               You are free to modify the return type. */

            return num;

        }
    }
}
