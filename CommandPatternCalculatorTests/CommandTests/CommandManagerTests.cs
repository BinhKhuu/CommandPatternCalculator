﻿using CommandPatternCalculator.Commands;
using CommandPatternCalculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPatternCalculatorTests.CommandTests
{
    public class CommandManagerTests
    {
        public CommandManagerTests() 
        {
        
        }

        [Fact]
        public void CommandManagerShouldThrowErrorWhenOperationIsUnknown()
        {
            var calculatorCommandManager = new CalculatorCommandManger();

            var exception = Assert.Throws<ArgumentException>(() => calculatorCommandManager.Compute('1', 0));
            Assert.Equal("operator (Parameter 'is not expected value')", exception.Message);
        }

        [Theory]
        [InlineData('+', 1,typeof(AddCommand))]
        [InlineData('/', 1, typeof(DivideCommand))]
        [InlineData('*', 1, typeof(MultiplyCommand))]
        [InlineData('-', 1, typeof(SubtractCommand))]
        public void CommandManagerShouldExecuteCorrectOperationsAndAddHistory(char @operator, double operand, Type expectedResults)
        {
            var calculatorCommandManager = new CalculatorCommandManger();
            
            calculatorCommandManager.Compute(@operator, operand);
            var commandType = calculatorCommandManager.PeekCommand();
            
            Assert.NotNull(commandType);
            Assert.Equal(expectedResults, commandType.GetType());
        }


    }
}