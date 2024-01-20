using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandPatternCalculator.Interfaces;
using CommandPatternCalculator.Services;

namespace CommandPatternCalculator.Commands
{
    public class AddCommand : ICommand
    {
        private ICalculator _calcualtor;
        private double _operand;

        public double Operand
        {
            get
            {
                return _operand;
            }
        }

        public AddCommand(ICalculator calculator, double operand) {
            _calcualtor = calculator;
            _operand = operand;
        }

        public void Execute()
        {
            _calcualtor.Add(_operand);
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
