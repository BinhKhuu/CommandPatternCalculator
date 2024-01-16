using CommandPatternCalculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPatternCalculator.Services
{
    public class Calculator : ICalculator
    {
        public double Result
        {
            get;
            set;
        } = 0;
        public Calculator() { }

        public void Add(double operand)
        {
            Result += operand;
            PrintResults(operand);
        }

        public void Subtract(double operand)
        {
            Result -= operand;
            PrintResults(operand);
        }
        public void Multiply(double operand)
        {
            Result *= operand;
            PrintResults(operand);
        }

        public void Divide(double operand)
        {
            if(operand == 0)
            {
                throw new DivideByZeroException();
            }
            Result /= operand;
            PrintResults(operand);
        }
        private void PrintResults(double operand)
        {
            Console.WriteLine($"Added {operand}, result is now {Result}");
        }


    }
}
