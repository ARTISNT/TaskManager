namespace Calculator.Abstractions;

public interface ICalculatorUi
{
    void ShowMenu();
    void ShowError(string error);
    void ShowResult(double result);
    int ReadMenuChoice();
    double ReadNumber();
    char ReadSignOfOperation();
}