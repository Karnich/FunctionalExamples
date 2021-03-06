﻿using System;

namespace AnonymousMethods
{
    public delegate decimal MathOperation(decimal left, decimal right);

    class Program
    {
        public static MathOperation GetOperation(char oper)
        {
            switch (oper)
            {
                case '+': return delegate (decimal l, decimal r) { return l + r; };
                case '-': return delegate (decimal l, decimal r) { return l - r; };
                case '*': return delegate (decimal l, decimal r) { return l * r; };
                case '/': return delegate (decimal l, decimal r) { return l / r; };
            }

            throw new NotSupportedException();
        }
        public static decimal Eval(string expr)
        {
            var elements = expr.Split(new[] { ' ' }, 3);
            var l = Decimal.Parse(elements[0]);
            var r = Decimal.Parse(elements[1]);
            var op = elements[2][0];

            return GetOperation(op)(l, r);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("1 + 3  = " + Eval("1 3 +"));
            Console.WriteLine("10 - 5 = " + Eval("10 5 -"));
            Console.WriteLine("2 * 3  = " + Eval("2 3 *"));
            Console.WriteLine("14 / 2 = " + Eval("14 2 /"));
            Console.ReadKey();
        }
    }
}
