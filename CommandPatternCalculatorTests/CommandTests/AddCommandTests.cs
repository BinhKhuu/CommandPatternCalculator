using CommandPatternCalculator.Commands;
using CommandPatternCalculator.Interfaces;
using CommandPatternCalculator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ICommand = CommandPatternCalculator.Interfaces.ICommand;

namespace CommandPatternCalculatorTests.CommandTests
{
    public class AddCommandTests
    {
        private ICalculator _calculator;
        public AddCommandTests() {

            _calculator = new Calculator();
        }

        [Theory]
        [InlineData(2,2)]
        [InlineData(0,0)]
        [InlineData(5.9,5.9)]
        public void ShouldAddOperand(double operand, double expectedResult)
        {
            var addCommand = new AddCommand(_calculator, operand);
            addCommand.Execute();

            Assert.Equal(expectedResult, _calculator.Result);
        }
    }
}
