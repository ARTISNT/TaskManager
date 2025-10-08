using Calculator.Abstractions;

namespace Calculator.Implementation;

public class ApplicationCalculator
{
    private readonly ICalculator _calculator;
    private readonly ICalculatorUi _calculatorUi;

    public ApplicationCalculator(ICalculator calculator, ICalculatorUi calculatorUi)
    {
        _calculator = calculator;
        _calculatorUi = calculatorUi;
    }
    public void RunCalculation()
    {
        while (true)
        {
            _calculatorUi.ShowMenu();
            int menuChoice = _calculatorUi.ReadMenuChoice();
            
            switch (menuChoice)
            {
                case 1:
                    try
                    {
                        double firstNumber = _calculatorUi.ReadNumber();
                        char signOfOperation = _calculatorUi.ReadSignOfOperation();
                        double secondNumber = _calculatorUi.ReadNumber();

                        double result = _calculator.Calculate(signOfOperation, firstNumber, secondNumber);
                        _calculatorUi.ShowResult(result);
                    }
                    catch (DivideByZeroException ex)
                    {
                        _calculatorUi.ShowError(ex.Message);
                    }
                    catch (InvalidOperationException ex)
                    {
                        _calculatorUi.ShowError(ex.Message);
                    }
                    catch (ArithmeticException ex)
                    {
                        _calculatorUi.ShowError(ex.Message);
                    }
                    catch (Exception)
                    {
                        _calculatorUi.ShowError("Something went wrong");
                    }
                    break;
                case 2:
                    Console.Write("Goodbye");
                    return;
                
                default:
                    _calculatorUi.ShowError("Invalid menu choice");
                    break;
            }
        }
    }
}