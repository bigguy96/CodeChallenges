﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace ScratchPad
{
    class Program
    {
        static void Main(string[] args)
        {



            Console.WriteLine(Tickets(new int[] { 25, 100 }));
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
    }
}


//public static string Tickets(int[] peopleInLine)
//{
//var bank = 0;
//    foreach (int x in peopleInLine)
//{
//    if (x == 25)
//    {
//        bank += 25;
//        continue;
//    }
//    else
//    {
//        bank -= x - 25;
//        if (bank <= 0)
//            return "NO";
//        bank += 25;
//    }
//}
//return "YES";
//}