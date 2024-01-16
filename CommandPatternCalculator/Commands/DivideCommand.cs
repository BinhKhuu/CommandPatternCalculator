using CommandPatternCalculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPatternCalculator.Commands
{
    public class DivideCommand
    {
        private ICalculator _calcualtor;
        private double _operand;

        public DivideCommand(ICalculator calcualtor, double operand)
        {
            _calcualtor = calcualtor;
            _operand = operand;
        }
        public void Execute()
        {
            _calcualtor.Divide(_operand);
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
