using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ScratchPad
{
    class Program
    {
        static void Main(string[] args)
        {



            Console.WriteLine(ToCamelCase("The_Stealth_Warrior"));
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
            var camelCase = new StringBuilder("");

            foreach (var word in words)
            {
                var firstLetter = word[0];
                int code = firstLetter;

                if (code >= 65 || code <= 90)
                {
                    camelCase.Append(word);
                }
                else
                {
                    //var uppercase = char.ToUpper(firstLetter) + word.Substring(1);
                    //camelCase.Append($"{uppercase}");
                    camelCase.Append(word);
                }
            }

            return camelCase.ToString();
        }
    }
}
