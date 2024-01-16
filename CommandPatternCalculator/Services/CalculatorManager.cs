using CommandPatternCalculator.Commands;
using CommandPatternCalculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPatternCalculator.Services
{
    public class CalculatorManager
    {
        private Stack<ICommand> _commands = new Stack<ICommand>();
        private Calculator _calculator = new Calculator();
        public CalculatorManager() { }

        public void Compute(char @operator,double operand)
        {
            ICommand command = null;

            switch (@operator)
            {
                case '+':
                    command = new AddCommand(_calculator, operand);
                    break;
                case '-':
                    command = new SubtractCommand(_calculator, operand);
                    break;
                case '*':
                    break;
                case '/':
                    break;
            }
            command.Execute();

        }
    }
}
