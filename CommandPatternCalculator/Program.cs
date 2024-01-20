using CommandPatternCalculator.Commands;
using CommandPatternCalculator.Services;

// client interact directly to receiver 
var calculator = new Calculator();
calculator.Add(2.90);
calculator.Add(2.90);
// command manager 
var calculatorCommandManager = new CalculatorCommandManger();
calculatorCommandManager.Compute('*', 10);