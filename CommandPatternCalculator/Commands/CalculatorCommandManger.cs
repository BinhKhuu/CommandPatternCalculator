using CommandPatternCalculator.Interfaces;
using CommandPatternCalculator.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPatternCalculator.Commands
{
    public class CalculatorCommandManger
    {
        private Stack<ICommand> _commandHistory = new Stack<ICommand>();
        public ReadOnlyCollection<ICommand> CommandHistory
        {
            get { return _commandHistory.ToList().AsReadOnly(); }
            private set { }
        }

        private readonly Calculator _calculator;
        public CalculatorCommandManger() 
        {
            _calculator = new Calculator();
        }
        public void Compute(char @operator, double operand)
        {
            ICommand command = @operator switch
            {
                '+' => new AddCommand(_calculator, operand),
                '-' => new SubtractCommand(_calculator, operand),
                '*' => new MultiplyCommand(_calculator, operand),
                '/' => new DivideCommand(_calculator, operand),
                _ => throw new ArgumentException(nameof(@operator), "is not expected value")
            };

            command.Execute();
            _commandHistory.Push(command);
        }

        public ICommand PeekCommand()
        {
            if (_commandHistory.Count == 0)
                return null;

            return _commandHistory.Peek();
        }
    }
}
