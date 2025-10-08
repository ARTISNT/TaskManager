namespace Calculator.Abstractions;

public interface ICalculator
{
    public double Calculate(char signOfOperation, double operand1, double operand2);
}