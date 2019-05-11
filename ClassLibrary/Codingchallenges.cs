using System;
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
            var total = 0;

            for (var i = 1; i <= num; i++)
            {
                total += i;
            }

            return total;
        }

        //https://www.coderbyte.com/editor/guest:Letter%20Capitalize:Csharp
        public static string LetterCapitalize(string str)
        {
            var words = str.Split(new char[0]);
            var sb = new StringBuilder("");

            foreach (var word in words)
            {
                var firstLetter = char.ToUpper(word[0]).ToString();
                var remaining = word.Substring(1);
                var newWord = $"{firstLetter}{remaining} ";

                sb.Append(newWord);
            }

            return sb.ToString().TrimEnd();
        }

        //https://www.coderbyte.com/editor/guest:Simple%20Symbols:Csharp
        public static string SimpleSymbols(string str)
        {
            //var regex = new Regex(@"(?![a-z])\+?[a-zA-Z]\+?(?![a-z])");
            //TODO: Revisit regex.
            var regex = new Regex(@"(^\+{1})[a-zA-Z](\+?|$)");
            var match = regex.Match(str);

            return match.Success ? "true" : "false";
        }

        public static string CheckNums(int num1, int num2)
        {
            if (num1 == num2) return "-1";

            return num2 > num1 ? "true" : "false";
        }

        public static string TimeConvert(int num)
        {
            var ts = TimeSpan.FromMinutes(num);

            return $"{ts.Hours}:{ts.Minutes}";
        }

        //https://www.coderbyte.com/editor/guest:Alphabet%20Soup:Csharp
        public static string AlphabetSoup(string str)
        {
            var chars = str.ToCharArray();
            var ordered = chars.OrderBy(c => (int)c);

            return new string(ordered.ToArray());
        }

        //https://www.coderbyte.com/editor/guest:Kaprekars%20Constant:Csharp
        public static int KaprekarsConstant(int num)
        {
            int ReverseFunc(int number, bool isDescending) => isDescending ?
                Convert.ToInt32(new string(number.ToString("0000").OrderByDescending(x => x).ToArray())) :
                Convert.ToInt32(new string(number.ToString("0000").OrderBy(x => x).ToArray()));

            const int kaprekar = 6174;
            var difference = 0;
            var count = 0;
            var ascending = ReverseFunc(num, false);
            var descending = ReverseFunc(num, true);

            while (difference != kaprekar)
            {
                difference = descending - ascending;

                if (difference == kaprekar)
                {
                    count++;
                    break;
                }

                ascending = ReverseFunc(difference, false);
                descending = ReverseFunc(difference, true);

                count++;
            }

            return count;
        }

        //https://www.coderbyte.com/editor/guest:Scale%20Balancing:Csharp
        // ["[6, 2]", "[1, 10, 6, 5]"] -- fail.
        public static string ScaleBalancing(string[] strArr)
        {
            var scale = strArr[0].Replace("[", "").Replace("]", "");
            var weights = strArr[1].Replace("[", "").Replace("]", "");
            var scaleValues = scale.Split(',');
            var weightValues = weights.Split(',');
            var scaleNumbers = scaleValues.Select(x => Convert.ToInt32(x)).OrderByDescending(x => x).ToArray();
            var weightNumbers = weightValues.Select(x => Convert.ToInt32(x)).OrderBy(x => x).ToArray();
            var difference = scaleNumbers[0] - scaleNumbers[1];

            //are scale values the same?
            if (difference == 0) return "0";

            //does the difference already exist in the weights.
            var number = weightNumbers.FirstOrDefault(x => x == difference);
            if (number > 0) return number.ToString();

            //try to find a weight combination to even the scales.
            for (var i = 0; i < weightNumbers.Length - 1; i++)
            {
                var current = weightNumbers[i];
                var next = weightNumbers[i + 1];
                var sum = current + next;

                if (sum == difference) return $"{current},{next}";
            }

            return "not possible";
        }

        public static string QuestionsMarks(string str)
        {
            var charArray = str.ToCharArray();
            var chars = new List<char>();

            foreach (var item in charArray)
            {
                if (item.Equals('?') || char.IsDigit(item))
                {
                    chars.Add(item);
                }
            }

            var s = new string(chars.ToArray());
            var regex = new Regex(@"(\d\?*\d)", RegexOptions.Compiled);
            var matches = regex.Matches(s);
            
            var isValid = false;

            foreach (Match match in matches)
            {
                var count = match.Value.ToCharArray().Count(x => x.Equals('?'));

                if (count != 3)
                {
                    isValid = false;
                    break;
                }

                var value = match.Value.Replace("???", ",");
                var split = value.Split(',');
                var sum = 0;

                foreach (var num in split)
                {
                    sum += int.Parse(num);

                    if (sum == 10)
                    {
                        isValid = true;
                    }
                }
            }

            return isValid ? "true" : "false";
        }
    }
}
