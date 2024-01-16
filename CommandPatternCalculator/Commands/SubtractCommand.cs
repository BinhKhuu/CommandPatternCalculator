using CommandPatternCalculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ICommand = CommandPatternCalculator.Interfaces.ICommand;

namespace CommandPatternCalculator.Commands
{
    public class SubtractCommand : ICommand
    {
        private ICalculator _calcualtor;
        private double _operand;

        public SubtractCommand(ICalculator calcualtor, double operand)
        {
            _calcualtor = calcualtor;
            _operand = operand;
        }
        public void Execute()
        {
            _calcualtor.Subtract(_operand);
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
