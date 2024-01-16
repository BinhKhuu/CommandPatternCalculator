using CommandPatternCalculator.Commands;
using CommandPatternCalculator.Interfaces;
using CommandPatternCalculator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPatternCalculatorTests.CommandTests
{
    public class SubtractCommandTests
    {

        private ICalculator _calculator;

        public SubtractCommandTests() {
            _calculator = new Calculator();
        }

        [Theory]
        [InlineData(2.0,-2.0)]
        public void ShouldSubtractOperand(double operand, double expectedResult)
        {
            var subTractCommand = new SubtractCommand(_calculator, operand);
            subTractCommand.Execute();

            Assert.Equal(expectedResult, _calculator.Result);
        }
    }
}
