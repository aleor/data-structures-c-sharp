using System;
using System.Collections.Generic;


namespace SimplePostfixCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            var _stack = new Stack<int>();

            if (args.Length == 0)
            {
                Console.WriteLine("No input provided.");
                Console.ReadKey();
                return;
            }

            foreach (var token in args)
            {
                int digit;
                if (int.TryParse(token, out digit))
                {
                    _stack.Push(digit);
                }
                else
                {
                    if (_stack.Count < 2)
                    {
                        throw new ArgumentException("Unexpected token");
                    }

                    var rightOperand = _stack.Pop();
                    var leftOperand = _stack.Pop();

                    switch (token)
                    {
                        case "*":
                            _stack.Push(rightOperand * leftOperand);
                            break;
                        case "+":
                            _stack.Push(rightOperand + leftOperand);
                            break;
                        case "-":
                            _stack.Push(rightOperand - leftOperand);
                            break;
                        case "/":
                            _stack.Push(rightOperand / leftOperand);
                            break;
                        default:
                            throw new ArgumentException("Token " + token + " is not valid.");
                    }
                }

            }

            Console.WriteLine("Result: " + _stack.Pop());
            Console.ReadKey();
        }
    }
}
