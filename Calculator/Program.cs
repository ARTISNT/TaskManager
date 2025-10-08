using Calculator.Implementation;

Calculator.Implementation.Calculator calculator = new Calculator.Implementation.Calculator();
CalculatorUi calculatorUi = new CalculatorUi();
ApplicationCalculator applicationCalculator = new ApplicationCalculator(calculator, calculatorUi);

applicationCalculator.RunCalculation();