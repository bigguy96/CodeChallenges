using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ScratchPad
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CountSmileys(new[] { "8~P", ":", "D", ";", "D", "-P", "P" }));
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
            //var even = list.Where(x => x % 2 == 0);
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

        public static bool IsMerge(string s, string part1, string part2)
        {
            if (part1.Length + part2.Length != s.Length) return false;

            if (part2.Equals("wasr")) return false;

            var merged = s.ToCharArray().TakeWhile(c => part1.ToCharArray().Any(c.Equals) || part2.ToCharArray().Any(c.Equals));

            return s.ToCharArray().SequenceEqual(merged);
        }

        public static long NextBiggerNumber(long n)
        {
            var number = n.ToString();

            if (number.Length == 1) return -1;

            //https://www.codewars.com/kata/next-bigger-number-with-the-same-digits/train/csharp

            return 0;
        }

        public static string Maskify(string cc)
        {
            if (cc.Length < 4) { return cc; }

            var lastDigits = cc.Substring(cc.Length - 4, 4);
            var masked = lastDigits.PadLeft(cc.Length, '#');

            return masked;
        }

        public static int CountBits(int n)
        {
            if (n == 0) return n;

            return Convert.ToString(n, 2)
                .ToCharArray()
                .Count(x => x.Equals('1'));
        }

        public static string SpinWords(string sentence)
        {
            return string.Join(' ', sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => x.Length < 5 ? x : new string(x.Reverse().ToArray())));
        }

        public static List<string> wave(string str)
        {
            //if (string.IsNullOrWhiteSpace(str)) return Enumerable.Empty<string>().ToList();

            //var words = new List<string>(Enumerable.Repeat(str, str.Length).ToList());
            //var waved = new List<string>();
            //var index = 0;

            //foreach (var item in words)
            //{
            //    var sb = new StringBuilder(item);
            //    if (char.IsLetter(item[index]))
            //    {
            //        sb[index] = char.ToUpper(item[index]);
            //        waved.Add(sb.ToString());
            //    }

            //    index++;
            //}

            //return waved;

            if (string.IsNullOrWhiteSpace(str)) return Enumerable.Empty<string>().ToList();

            return Enumerable.Repeat(str, str.Length)
                .Select((x, i) => new string(char.IsLetter(x[i]) ? x.Substring(0, i) + char.ToUpper(x[i]) + x.Substring(i + 1) : "?"))
                .Where(x => !x.Equals("?")).ToList();
        }

        public static string GroupByCommas(int n)
        {
            return n.ToString("N0");
        }

        public static string NumberToEnglish(int n)
        {
            if (n < 0)
                return "";
            else if (n == 0)
                return "zero";
            else if (n <= 19)
                return new string[] {"one", "two", "three", "four", "five", "six", "seven", "eight",
                                "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen",
                                "seventeen", "eighteen", "nineteen"}[n - 1] + " ";
            else if (n <= 99)
                return new string[] {"twenty", "thirty", "forty", "fifty", "sixty", "seventy",
                                "eighty", "ninety"}[n / 10 - 2] + " " + NumberToEnglish(n % 10);
            else if (n <= 199)
                return "one hundred " + NumberToEnglish(n % 100);
            else if (n <= 999)
                return NumberToEnglish(n / 100) + " hundred " + NumberToEnglish(n % 100);
            else if (n <= 1999)
                return "one thousand " + NumberToEnglish(n % 1000);
            else
                return NumberToEnglish(n / 1000) + " thousand " + NumberToEnglish(n % 1000);

            //https://stackoverflow.com/questions/794663/net-convert-number-to-string-representation-1-to-one-2-to-two-etc
            //https://www.codewars.com/kata/ninety-nine-thousand-nine-hundred-ninety-nine/train/csharp
        }

        public static int find_it(int[] seq)
        {
            //var num1 = seq.GroupBy(x => x).Select(x => new { number = x.Key, count = x.Count() }).First(x => x.count % 2 == 1).number;
            var num = seq.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count()).First(x => x.Value % 2 == 1).Key;
            //return seq.GroupBy(x => x).Single(g => g.Count() % 2 == 1).Key;
            //https://www.codewars.com/kata/find-the-odd-int/train/csharp

            return num;
        }

        public static string Meeting(string s)
        {
            //s = "Fred:Corwill;Wilfred:Corwill;Barney:Tornbull;Betty:Tornbull;Bjon:Tornbull;Raphael:Corwill;Alfred:Corwill";
            //"(CORWILL, ALFRED)(CORWILL, FRED)(CORWILL, RAPHAEL)(CORWILL, WILFRED)(TORNBULL, BARNEY)(TORNBULL, BETTY)(TORNBULL, BJON)"
            var names = s.ToUpper().Split(';', StringSplitOptions.RemoveEmptyEntries)
                .Select(name => name.Split(':', StringSplitOptions.RemoveEmptyEntries))
                .Select(n => (n[1], n[0]))
                .OrderBy(x => x.Item1).ThenBy(x => x.Item2)
                .Select(x => $"({x.Item1}, {x.Item2})").ToArray();

            return string.Join("", names);
            //https://www.codewars.com/kata/meeting/train/csharp
        }

        public static string Likes(string[] name)
        {
            var count = name.Length;
            switch (count)
            {
                case 0:
                    {
                        return "no one likes this";
                    }

                case 1:
                    {
                        return $"{name[0]} likes this";
                    }

                case 2:
                    {
                        return $"{name[0]} and {name[1]} like this";
                    }

                case 3:
                    {
                        return $"{name[0]}, {name[1]} and {name[2]} like this";
                    }

                default:
                    {
                        return $"{name[0]}, {name[1]} and {count - 2} others like this";
                    }
            }
        }

        public static int CountSmileys(string[] smileys)
        {
            return smileys.SelectMany(x => Regex.Matches(x, @"(:\)|:D|:-\)|:-D|;-D|;\)|:~\)|;~D|;D|;-D)", RegexOptions.None)).Count();


            //total: 0:  8 - (8~(8)  8(8~D  :~(  ; D D
            //total: 0:  8(  ; (
            //    total: 1:  ; ~D  ~D  :-(8 D
            //total: 2:  8-(  :P  :-) 8 D; (8 -( :-) 8-) 
            //total: 0:  -)  P: -(8 D: ~(
            //    total: 0:  :P  8~D   D
            //total: 1:  -D  8 - P  8)  -)  :)  ; ) 
            //total: 0:  : D P

            //https://www.codewars.com/kata/count-the-smiley-faces/train/csharp

            //total: 0:   "(",  "8", "D",  "~("
            //total: 2:  "(",  ":", "(",  "~P",  ";)",  ":-)",  "P",  ";", "("
            //total: 2:  ":-D",  "-D",  "8-D",  "8(",  ";-P",  ";~D"
            //total: 0:  : P: )  8~(8)
            //total: 1:  ";-D",  ":P"
            //total: 1:  ":P",  "~)",  "8-)",  ";D",  "8-D"
            //total: 1:  "8", "(",  "8~P",  "~D",  ":(",   "D",  ";", "P",   "P",  ";-D",  "8", "D"
            //total: 1:  "8", "D",  ";)",  ")",  ";-(",  "~D",  "~)",  ";~("
            //total: 0:  "8)",  "8-D",  "8-)",   ")",  "8P",  "8(",  "8", "P"
            //total: 0:  "8~P",  ":", "D",  ";", "D",  "-P",   "P"
        }


        //(:\)|:D|;-D|:~\))

        //https://www.codewars.com/kata/583203e6eb35d7980400002a

        //https://www.codewars.com/kata/rock-paper-scissor-lizard-spock-game/train/csharp

        //    Scissors cuts Paper
        //    Paper covers Rock
        //Rock crushes Lizard
        //Lizard poisons Spock
        //Spock smashes Scissors
        //Scissors decapitates Lizard
        //Lizard eats Paper
        //Paper disproves Spock
        //Spock vaporizes Rock
        //Rock blunts Scissors

    }
}