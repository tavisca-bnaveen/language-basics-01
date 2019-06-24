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
        public static int Operand_needed(int star,int question_mark,int equal,string equation)
        {
            int i;
            string value = equation.Substring(equal + 1, (equation.Length) - equal - 1);
            int val = int.Parse(value);
            string ope1, ope2;
            if (star < question_mark)
            {
                ope1 = equation.Substring(0, star);
                ope2 = equation.Substring(star + 1, equal - star - 1);
            }
            else
            {
                ope1 = equation.Substring(star + 1, equal - star - 1);
                ope2 = equation.Substring(0, star);
            }
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
                        int ans = int.Parse(answer1.Substring(i, 1)); return ans;
                    }
                }

            }
                return -1;
        }
        public static int Value_needed(int star, int question_mark, int equal, string equation)
        {
            int i;
            string ope1 = equation.Substring(0, star);
            string ope2 = equation.Substring(star + 1, equal - star - 1);
            string value = equation.Substring(equal + 1, (equation.Length) - equal - 1);
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
                        int ans = int.Parse(answer1.Substring(i, 1)); return ans;
                    }
                }

            }
                return -1;
        }
        public static int FindDigit(string equation)
        {
            if (equation.Length == 0 || equation == null)
                return -1;
            int i, star = -1, question_mark = -1, equal = -1;
            for (i = 0; i < equation.Length; i += 1)
            {
                if (equation[i] == '*')
                    star = i;
                else if (equation[i] == '=')
                    equal = i;
                else if (equation[i] == '?')
                    question_mark = i;
            }
            if (question_mark < equal)
            {
                return Operand_needed(star, question_mark, equal, equation);
            }
            else
            {
                return Value_needed(star, question_mark, equal, equation);
            }
            
            //throw new NotImplementedException();
        }
    }
}
