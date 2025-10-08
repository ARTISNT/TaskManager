using Calculator.Abstractions;

namespace Calculator.Implementation;

public class Calculator : ICalculator
{
    private readonly Dictionary<char, Func<double, double, double>> _operations = new()
    {
        ['+'] = (a, b) => a + b,
        ['-'] = (a, b) => a - b, 
        ['*'] = (a, b) => a * b,
        ['/'] = (a, b) => b == 0 ? throw new DivideByZeroException($"{a} cannot be divided by zero."): a / b,
    };
    
    public double Calculate(char signOfOperation, double firstNumber, double secondNumber)
    {
        if (!_operations.TryGetValue(signOfOperation, out var operation))
            throw new InvalidOperationException($"Unknown sign of operation: {signOfOperation}");
        
        double result = operation(firstNumber, secondNumber);
        ValidateResult(result);
        
        return result;
    }

    public bool AddOperation(char signOfOperation, Func<double, double, double> operation)
    {
        return _operations.TryAdd(signOfOperation, operation);
    }

    private void ValidateResult(double result)
    {
        if (double.IsNaN(result) || double.IsInfinity(result))
        {
            throw new ArithmeticException("Result is not a number");
        }
    }
}

