using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;

namespace ScratchPad
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(AddLetters(new char[] { 'y', 'c', 'b' }));
            Console.ReadKey();
        }

        public static long DescendingOrder(int num)
        {
            var numbers = num
                .ToString()
                .OrderByDescending(x => (int)x)
                .Select(x => x.ToString());

            return Convert.ToInt64(string.Join("", numbers));
        }

        public static bool ValidatePin(string pin)
        {

            if (!pin.All(char.IsNumber)) return false;

            var regex = new Regex(@"^(\d{4}|\d{6})$");
            var match = regex.IsMatch(pin);

            return match;
        }

        public static string Disemvowel(string str)
        {
            var vowels = "aeiouAEIOU";
            var phrase = str.Where(x => !vowels.Contains(x)).ToArray();

            return string.Join("", phrase).Trim();
        }

        public static int NbYear(int p0, double percent, int aug, int p)
        {
            var count = 0;
            while (p0 < p)
            {
                count++;

                var percentage = p0 * (percent * 0.01);
                p0 = p0 + (int)percentage + aug;
            }

            return count;
        }

        public static int Solution(int value)
        {
            var total = 0;

            for (int i = 0; i < value; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    total += i;
                }
            }

            return total;
        }

        public static string ToCamelCase(string str)
        {
            var words = str.Split(new char[] { '-', '_' });
            var camelCase = new StringBuilder(words[0]);

            for (int i = 1; i < words.Length; i++)
            {
                var firstletter = words[i].Substring(0, 1)[0];
                var code = firstletter;

                if (code >= 65 && code <= 90)
                {
                    camelCase.Append(words[i]);
                }
                else
                {
                    var uppercase = char.ToUpper(firstletter) + words[i].Substring(1);
                    camelCase.Append(uppercase);
                }
            }

            return camelCase.ToString();
        }

        public static int DuplicateCount(string str)
        {
            var count = str
                    .ToUpper()
                    .GroupBy(c => c)
                    .Select(g => new { Letter = g.Key, Count = g.Count() })
                    .Count(c => c.Count > 1);

            return count;
        }

        public static string Order(string words)
        {
            if (string.IsNullOrEmpty(words)) return "";

            var dic = new Dictionary<int, string>();
            var split = words.Split(new char[0]);

            foreach (var word in split)
            {
                foreach (var letter in word)
                {
                    if (!char.IsNumber(letter)) continue;

                    dic.Add(letter, word);
                    break;
                }
            }

            var ordered = dic.OrderBy(x => x.Key).Select(x => x.Value).ToArray();

            return string.Join(" ", ordered);
        }

        public static int GetSum(int a, int b)
        {
            if (a == b) return a;

            var numbers = new List<int>();
            var min = Math.Min(a, b);
            var max = Math.Max(a, b);

            while (min <= max)
            {
                numbers.Add(min);
                min++;
            }

            return numbers.Sum();
        }

        public static string Tickets(int[] peopleInLine)
        {
            (int twentyFives, int fifties) register = (0, 0);

            foreach (var cash in peopleInLine)
            {
                switch (cash)
                {
                    case 25:
                        register.twentyFives++;

                        break;

                    case 50:
                        register.twentyFives--;
                        register.fifties++;

                        break;

                    case 100 when register.fifties == 0:
                        register.twentyFives -= 3;

                        break;

                    case 100:
                        register.twentyFives--;
                        register.fifties--;

                        break;
                }

                if (register.twentyFives < 0 || register.fifties < 0)
                {
                    return "NO";
                }
            }

            return "YES";
        }

        public static int Persistence(long n)
        {
            var count = 0;
            var number = n.ToString();

            while (number.Length > 1)
            {
                count++;
                number = number.Select(x => int.Parse(x.ToString())).Aggregate((a, b) => a * b).ToString();
            }
            return count;
        }

        public static string ToWeirdCase(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return s;

            var words = s.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            var sb = new StringBuilder("");

            foreach (var word in words)
            {
                var characters = word.ToCharArray();

                for (var i = 0; i < characters.Length; i++)
                {
                    sb.Append(i % 2 == 0 ? char.ToUpper(word[i]) : char.ToLower(word[i]));

                }

                sb.Append(" ");
            }

            return sb.ToString().TrimEnd();
        }

        public static int[] SortArray(int[] array)
        {
            if (!array.Any()) return array;

            var list = array.ToList();
            var odd = list.Where(x => x % 2 != 0).OrderBy(x => x).ToArray();
            var queue = new Queue(odd);
            var ordered = new int[array.Length];

            for (var i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                {
                    ordered[i] = (int)queue.Dequeue();
                }
                else
                {
                    ordered[i] = array[i];
                }
            }

            return ordered;
        }

        public static List<string> Anagrams(string word, List<string> words)
        {
            var sorted = SortWord(word);
            var anagrams = new List<string>();

            foreach (var item in words)
            {
                var s = SortWord(item);

                if (s.Equals(sorted)) anagrams.Add(item);
            }

            return anagrams;
        }

        private static string SortWord(string word)
        {
            return new string(word.ToCharArray().OrderBy(x => x).Select(x => x).ToArray());
        }

        public static int[] DeleteNth(int[] arr, int x)
        {
            return GetNumbers(arr, x).ToArray();
        }

        private static IEnumerable<int> GetNumbers(int[] arr, int x)
        {
            var dic = new Dictionary<int, int>();
            foreach (var item in arr)
            {
                if (!dic.ContainsKey(item))
                {
                    dic.Add(item, 1);
                }
                else
                {
                    dic[item]++;
                }

                if (dic[item] <= x)
                {

                    yield return item;
                }
            }
        }

        public static string Rgb(int r, int g, int b)
        {
            r = r < 0 ? 0 : r;
            g = g < 0 ? 0 : g;
            b = b < 0 ? 0 : b;

            r = r > 255 ? 255 : r;
            g = g > 255 ? 255 : g;
            b = b > 255 ? 255 : b;

            Color c = Color.FromArgb(r, g, b);

            return $"{c.R:X2}{c.G:X2}{c.B:X2}";
        }

        public static string bonus_time(int salary, bool bonus)
        {
            return bonus ? $"${salary}0" : $"${salary}";
        }

        public static string balanceStatements(string lst)
        {
            //https://www.codewars.com/kata/ease-the-stockbroker/train/csharp
            //String l = "GOOG 300 542.0 B, AAPL 50 145.0 B, CSCO 250.0 29 B, GOOG 200 580.0 S";
            //String r = "Buy: 169850 Sell: 116000; Badly formed 1: CSCO 250.0 29 B ;";
            var split = lst.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            decimal buy = 0;
            decimal sell = 0;
            var bad = new List<string>();

            foreach (var s in split)
            {
                var s1 = s.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var isNumber = int.TryParse(s1[1], out _);
                var isDecimal = decimal.TryParse(s1[2], out _);
                var action = s1[3];
                var isGood = isNumber && isDecimal;

                if (isGood)
                {
                    var amount = decimal.Parse(s1[1]);
                    var price = decimal.Parse(s1[2]);

                    if (action.Equals("B", StringComparison.CurrentCultureIgnoreCase))
                    {

                        buy += amount * price;
                    }
                    else
                    {
                        sell += amount * price;
                    }
                }
                else
                {
                    bad.Add(s);
                }
            }

            var result = $"Buy: {Math.Round(buy)} Sell: {Math.Round(sell)}";

            if (bad.Any())
            {
                result += $"; Badly formed {bad.Count}:{string.Join(";", bad)} ;";
            }

            return result;
        }

        public static bool ValidParentheses(string input)
        {
            if (input.Length <= 1) return false;
            if (input.StartsWith(")") || input.EndsWith("(")) return false;

            var count = 0;
            foreach (var c in input)
            {
                if (count == -1)
                    return false;

                if (c == '(')
                    count++;

                if (c == ')')
                    count--;
            }

            return count == 0;
        }

        public static string Meeting(string s)
        {
            //var m = Regex.Match(s, @"([\(\)])");
            //var t = Regex.Split(s, @"\(([^)]*)\)", RegexOptions.Multiline).Where(x => !x.Equals(string.Empty));

            //"Fred:Corwill;Wilfred:Corwill;Barney:Tornbull;Betty:Tornbull;Bjon:Tornbull;Raphael:Corwill;Alfred:Corwill"
            //(CORWILL, ALFRED)(CORWILL, FRED)(CORWILL, RAPHAEL)(CORWILL, WILFRED)(TORNBULL, BARNEY)(TORNBULL, BETTY)(TORNBULL, BJON)

            var list = s
                .ToUpper()
                .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries))
                .Select(x => new { LastName = x[1].Trim(), FirstName = x[0].Trim() })
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Select(s1 => $"({s1.LastName}, {s1.FirstName})");


            return string.Join("", list);

        }

        public static long DivisibleCount(long x, long y, long k)
        {
            long lower = x / k; //2, 3, 2, 2
            long upper = y / k; //5, 5, 5, 4

            return upper - lower + (x % k == 0 ? 1 : 0);
        }

        public static char AddLetters(char[] letters)
        {
            if (!letters.Any()) return 'z';
            if (letters.Length == 1) return letters[0];
            
            var alphabet = Enumerable.Range(97, 26).Select((x, y) => new { letter = (char)x, number = y + 1 }).ToList();
            var count = 0;

            foreach (var item in letters)
            {
                count += alphabet.Single(x => Equals(x.letter, item)).number;

                if (count > 26)  count -= 26;
            }

            //-96
            return alphabet[count - 1].letter;            
        }
    }
}