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
    public class MultipleCommandTests
    {
        private ICalculator _calculator;

        public MultipleCommandTests()
        {
            _calculator = new Calculator();
        }

        [Theory]
        [InlineData(2.0, 0)]
        public void ShouldMultiplyOperand(double operand, double expectedResult)
        {
            var subTractCommand = new MultiplyCommand(_calculator, operand);
            subTractCommand.Execute();

            Assert.Equal(expectedResult, _calculator.Result);
        }
    }
}
