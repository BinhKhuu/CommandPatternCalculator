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
        public double Total
        {
            get
            {
                return _calculator.Result;
            }
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

        public void Undo()
        {

            try
            {
                // to undo a command find the opposite operation
                var command = _commandHistory.Pop();
                ICommand undoCommand = command.GetType() switch
                {
                    Type t when t == typeof(AddCommand) => new SubtractCommand(_calculator, command.Operand),
                    Type t when t == typeof(SubtractCommand) => new AddCommand(_calculator, command.Operand),
                    Type t when t == typeof(MultiplyCommand) => new DivideCommand(_calculator, command.Operand),
                    Type t when t == typeof(DivideCommand) => new MultiplyCommand(_calculator, command.Operand)
                };
                undoCommand.Execute();
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Attempted to undo multiply when total is 0");

            }
        }
    }
}
