using CommandPatternCalculator.Services;

// client interact directly to receiver 
var calculator = new Calculator();
calculator.Add(2.90);


// client interacts with command manager adding layer between the calculator and the client
var calculatorManager = new CalculatorManager();
//calculatorManager.Compute('+', 5.0);
calculatorManager.Compute('/', 1);