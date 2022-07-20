using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Calculator
{
    public class Program
    {
        public static ArithmeticEvaluator Aritma = new ArithmeticEvaluator();
        public static void Main()
        {
            Console.WriteLine("started");

            string[] testExpressions_1 = { "24 + 3", "0 + 0", "0 + 1", "+ 2", "2 + ", "5 - 2", "2 - 8", "5 + 11 - 3", "2*5 + 3 - 9", "-10 + 5", "5 - 6 + 10 / 2", "4 - 2 - 5", "4 - 4 - 3" };
            double[] testResults_1 = { 24 + 3, 0 + 0, 0 + 1, 2, 2, 5 - 2, 2 - 8, 5 + 11 - 3, 2*5 + 3 - 9, -10 + 5, 5 - 6 + 5, 4 - 2 - 5, 4 - 4 - 3 };
            string[] testExpressions_2 = { "2 * 3", "1 * 2", "* 2", "4 / 2", "5 * 3 * 4", "0 * 2 ", "0*2", "1*4", "5*5", "5^2", "5^0", "2/2/2"};
            double[] testResults_2 = { 6, 2, 2, 2, 60, 0 , 0, 4, 25, 25, 1, 0.5 };

            int countFailed = 0;

            for (int i = 0; i < testExpressions_1.Length; i++)
            {
                if(! TestAritma(testExpressions_1[i], testResults_1[i]) ) countFailed++;
            }
            for (int i = 0; i < testExpressions_2.Length; i++)
            {
                if(! TestAritma(testExpressions_2[i], testResults_2[i]) )countFailed++;
            }

            Console.WriteLine($"number of failed tests : {countFailed}");
            //Console.Read();
        }
       

    public static bool TestAritma(string expr, double expected)
        {
            double result = Aritma.Eval(expr);
            bool res = expected == result;
            Console.Write("test expr: " + expr);
            Console.Write("   expected: " + expected);
            Console.WriteLine($"  result: {result}");

            if (res)
            {
                Console.WriteLine($"   Passed");
            } else
            {
                Console.WriteLine($"   Failed");
            }
            return res;
        }

        public struct TestItem
        {
            public int Id { get; init; }
            public string Expr { get; init; }
            public double Expected { get; init; }
            public TestItem(int i, string expr, double expected)
            {
                Id = i;
                Expr = expr;
                Expected = expected;
            }
        }
    }   
}
