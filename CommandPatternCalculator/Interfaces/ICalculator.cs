using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPatternCalculator.Interfaces
{
    public interface ICalculator
    {
        public double Result { get; set; }
        public void Add(double operand);
        public void Subtract(double operand);
        public void Multiply(double operand);
        public void Divide(double operand);
    }
}
