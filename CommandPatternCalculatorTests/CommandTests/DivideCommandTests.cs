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
    public class DivideCommandTests
    {
        private ICalculator _calculator;

        public DivideCommandTests()
        {
            _calculator = new Calculator();
        }

        [Theory]
        [InlineData(2.0, 0)]
        public void ShouldDivideOperand(double operand, double expectedResult)
        {
            var divideCommand = new DivideCommand(_calculator, operand);
            divideCommand.Execute();

            Assert.Equal(expectedResult, _calculator.Result);
        }

        [Fact]
        public void ShouldNotDivideByZero()
        {
            var divideCommand = new DivideCommand(_calculator, 0);
            var exception = Assert.Throws<DivideByZeroException>(() => divideCommand.Execute());

        }
    }
}
