using Calculator.Abstractions;

namespace Calculator.Implementation;

public class CalculatorUi : ICalculatorUi
{
    private readonly ICalculator _calculator;
    
    
    public void ShowMenu()
    {
        Console.WriteLine("Menu:\n" +
                          "1.Calculator\n" +
                          "2.Exit\n");
    }

    public void ShowError(string error)
    {
        Console.WriteLine($"Error message: {error}");
    }

    public void ShowResult(double result)
    {
        Console.WriteLine($"Result: {result}\n");
    }

    public int ReadMenuChoice()
    {
        return ReadValue<int>("Please enter a choice", "Please enter a valid choice", int.TryParse);
    }

    public double ReadNumber()
    {
        return ReadValue<double>("Enter a number", "Please enter a valid number",  double.TryParse);
    }

    public char ReadSignOfOperation()
    {
        return ReadValue<char>("Enter the sign of operation", "Please enter a valid sign of operations(+,*,/,-)", char.TryParse);
    }
    
    private T ReadValue<T>( string tip, string errorText, TryParseDelegate<T> tryParse)
    {
        Console.WriteLine(tip);
        while (true)
        {
            if (!tryParse(Console.ReadLine(), out var result))
            {
                Console.WriteLine(errorText);
            }
            else
            {
                return result;
            }
        }
    }

    private delegate bool TryParseDelegate<T>(string input, out T result);
}