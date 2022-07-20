using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
// Compiler version 4.0, .NET Framework 4.5


namespace CalculatorApp
{
    public class Program
    {
        //static Form1 FormApp;
        static Action<string> PrintLine;
        static Action<string> Print;
        public static ArithmeticEvaluator Aritma = new ArithmeticEvaluator();
        
       static void Main()
        {
            //    [DllImport("kernel32.dll")]
            //    static extern bool AttachConsole(int dwProcessId);
            //private const int ATTACH_PARENT_PROCESS = -1;

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //FormApp = new Form1();
            PrintLine = Console.WriteLine;
            Print = Console.Write;

            string[] testExpressions_1 = { "24 + 3", "0 + 0", "0 + 1", "+ 2", "2 + ", "5 - 2", "2 - 8", "5 + 11 - 3", "2*5 + 3 - 9", "-10 + 5", "5 - 6 + 10 / 2", "4 - 2 - 5", "4 - 4 - 3" };
            double[] testResults_1 = { 24 + 3, 0 + 0, 0 + 1, 2, 2, 5 - 2, 2 - 8, 5 + 11 - 3, 2 * 5 + 3 - 9, -10 + 5, 5 - 6 + 5, 4 - 2 - 5, 4 - 4 - 3 };
            string[] testExpressions_2 = { "2 * 3", "1 * 2", "* 2", "4 / 2", "5 * 3 * 4", "0 * 2 ", "0*2", "1*4", "5*5", "5^2", "5^0", "(4 + 2) / 2", "(4 + 2)/2" };
            double[] testResults_2 = { 6, 2, 2, 2, 60, 0, 0, 4, 25, 25, 1, 3, 3 };

            int countFailed = 0;

            for (int i = 0; i < testExpressions_1.Length; i++)
            {
                if (!TestAritma(testExpressions_1[i], testResults_1[i])) countFailed++;
            }
            for (int i = 0; i < testExpressions_2.Length; i++)
            {
                if (!TestAritma(testExpressions_2[i], testResults_2[i])) countFailed++;
            }

            PrintLine($"number of failed tests : {countFailed}");

            
            //Application.Run(FormApp);

        }

        
        public static bool TestAritma(string expr, double expected)
        {
            double result = Aritma.Eval(expr);
            bool res = expected == result;
            Print("test expr: " + expr);
            Print("   expected: " + expected);
            PrintLine($"  result: {result}");

            if (res)
            {
                PrintLine($"   Passed");
            }
            else
            {
                PrintLine($"   Failed");
            }
            return res;
        }
    }
}
