using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
// Compiler version 4.0, .NET Framework 4.5


namespace Calculator
{
    public class ArithmeticEvaluator
    {

        static char[] Operators { get; } =
          {'+', '-', '/',  '*', '^' };

        public bool hasParanthesis(string expr)
        {
            return expr.StartsWith('(') &&
            expr.EndsWith(')');
        }

        public bool hasOperators(string expr)
        {
            Regex rx = new(@"[*/^+-]");
            return rx.IsMatch(expr);
        }
        public bool IsExpr(string expr)
        {
            return hasParanthesis(expr) || hasOperators(expr);
        }

        public double Eval(string expr)
        {

            if (hasParanthesis(expr))
            {
                expr = expr.Substring(1, expr.Length - 2);
                return Eval(expr);
            }

            if (expr.Contains('+'))
            {
                string[] expressions = expr.Split('+');
                return Operate(expressions, '+');
            }

            if (expr.Contains('-'))
            {
                string[] expressions = expr.Split('-');
                return Operate(expressions, '-');
            }

            if (expr.Contains('*'))
            {
                string[] expressions = expr.Split('*');
                return Operate(expressions, '*');
            }

            if (expr.Contains('/'))
            {
                string[] expressions = expr.Split('/');
                return Operate(expressions, '/');
            }

            if (expr.Contains('^'))
            {
                string[] expressions = expr.Split('^');
                return Operate(expressions, '^');
            }

            //split string with operators 
            //and call operate() according
            return 0;
        }

        public double Operate(string[] args,
         char OpSymbol)
        {
            double res = 0;
            double x;
            
            if (OpSymbol == '+')
            {
                res = GetDoubleValue(args[0]);
                for (int i = 1; i < args.Length; i++)
                {
                    x = GetDoubleValue(args[i]);
                    res += x;
                }
                return res;
            }
            if (OpSymbol == '-')
            {
                res = GetDoubleValue(args[0]);
                for (int i = 1; i < args.Length; i++)
                {
                    x = GetDoubleValue(args[i]);
                    res -= x;
                }
                return res;
            }

            if (OpSymbol == '*')
            {
                res = GetDoubleValue(args[0], "1");
                for (int i = 1; i < args.Length; i++)
                {
                    x = GetDoubleValue(args[i], "1");
                    res *= x;
                }
                return res;
            }
            if (OpSymbol == '/')
            {
                res = GetDoubleValue(args[0], "1");
                for (int i = 1; i < args.Length; i++)
                {
                    x = GetDoubleValue(args[i], "1");
                    res /= x;
                }
                return res;
            }
            if (OpSymbol == '^')
            {
                res = GetDoubleValue(args[0], "1");
                for (int i = 1; i < args.Length; i++)
                {
                    x = GetDoubleValue(args[i], "1");
                    res = Math.Pow(res, x);
                }
                return res;
            }
            return res;
        }

        public double GetDoubleValue(string a, string baseValue = "0")
        {
            double res = 0;
            a = a.Trim();
            if (a == string.Empty || a == null)
            {
                a = baseValue;
            }
            res = IsExpr(a) ? Eval(a) : double.Parse(a);
            return res;
        }
    }
}