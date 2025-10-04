bool stopCalculations = false;

while (!stopCalculations)
{
    try
    {
        Console.WriteLine("1.Calculator\n" +
                          "2.Exit\n");

        if (!int.TryParse(Console.ReadLine(), out int indexOfChoice))
        {
            Console.WriteLine("Please enter a valid number");
            continue;
        }
        
        switch (indexOfChoice)
        {
            case 1:
                double result = 0.0;

                Console.WriteLine("Enter the first number:");
                if (!double.TryParse(Console.ReadLine(), out double firstNumber))
                {
                    Console.WriteLine("Please enter a valid number");
                    continue;
                }
                
                Console.WriteLine("Enter the sign of operations:");
                if (!char.TryParse(Console.ReadLine(), out char signOfOperation))
                {
                    Console.WriteLine("Please enter a valid sign of operations(+,*,/,-)");
                    continue;
                }

                Console.WriteLine("Enter the second number:");
                if (!double.TryParse(Console.ReadLine(), out double secondNumber))
                {
                    Console.WriteLine("Please enter a valid number");
                    continue;
                }
                
                switch (signOfOperation)
                {
                    case '+':
                        result = firstNumber + secondNumber;
                        break;
                    case '-':
                        result = firstNumber - secondNumber;
                        break;
                    case '*':
                        result = firstNumber * secondNumber;
                        break;
                    case '/':
                        if (secondNumber == 0)
                            throw new DivideByZeroException("Cannot divide by zero!");
                        
                        result = firstNumber / secondNumber;
                        break;

                    default:
                        Console.WriteLine("Wrong sign of operation!");
                        break;
                }

                if (double.IsNaN(result) || double.IsInfinity(result))
                {
                    throw new ArithmeticException("Result is not a number!\n");
                }

                Console.WriteLine($"The result is: {result}\n");
                break;
            case 2:
                Console.WriteLine("Goodbye.");
                stopCalculations = true;
                break;
        }
    }
    catch (DivideByZeroException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (ArithmeticException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (Exception)
    {
        Console.WriteLine("Something went wrong!");
    }
}