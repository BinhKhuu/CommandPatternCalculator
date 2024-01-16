using CommandPatternCalculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPatternCalculator.Commands
{
    public class MultiplyCommand
    {
        private ICalculator _calcualtor;
        private double _operand;

        public MultiplyCommand(ICalculator calcualtor, double operand)
        {
            _calcualtor = calcualtor;
            _operand = operand;
        }
        public void Execute()
        {
            _calcualtor.Multiply(_operand);
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
