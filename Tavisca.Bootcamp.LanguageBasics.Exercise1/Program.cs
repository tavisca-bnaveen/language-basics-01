using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        {
            int i, s = -1, q = -1, e = -1;
            // char c;
            for (i = 0; i < equation.Length; i += 1)
            {
                if (equation[i] == '*')
                    s = i;
                else if (equation[i] == '=')
                    e = i;
                else if (equation[i] == '?')
                    q = i;
            }
            //Console.WriteLine($"{s}{e}{q}");
            if (q < e)
            {
                string value = equation.Substring(e + 1, (equation.Length) - e - 1);
                // Console.WriteLine($"{value}");
                int val = int.Parse(value);
                string ope1, ope2;
                if (s < q)
                {
                    ope1 = equation.Substring(0, s);
                    ope2 = equation.Substring(s + 1, e - s - 1);
                }
                else
                {
                    ope1 = equation.Substring(s + 1, e - s - 1);
                    ope2 = equation.Substring(0, s);
                }
                /*Console.WriteLine($"{ope1}");
                Console.WriteLine($"{ope2}");*/
                int operand1 = int.Parse(ope1);
                int answer = val / operand1;
                if (val % operand1 != 0)
                    return -1;
                string answer1 = Convert.ToString(answer);
                if (answer1.Length == ope2.Length)
                {
                    for (i = 0; i < ope2.Length; i += 1)
                    {
                        if (ope2[i] == '?')
                        {
                            int ans = int.Parse(answer1.Substring(i, 1));
                            return ans;
                        }
                    }
                }
                else
                    return -1;
            }
            else
            {
                string ope1 = equation.Substring(0, s);
                string ope2 = equation.Substring(s + 1, e - s - 1);
                string value = equation.Substring(e + 1, (equation.Length) - e - 1);
                int operand1 = int.Parse(ope1);
                int operand2 = int.Parse(ope2);
                int answer = operand1 * operand2;
                string answer1 = Convert.ToString(answer);
                if (answer1.Length == value.Length)
                {
                    for (i = 0; i < value.Length; i += 1)
                    {
                        if (value[i] == '?')
                        {
                            int ans = int.Parse(answer1.Substring(i, 1));
                            return ans;
                        }
                    }
                }
                else
                    return -1;
            }
            return 0;
            throw new NotImplementedException();
        }
    }
}
