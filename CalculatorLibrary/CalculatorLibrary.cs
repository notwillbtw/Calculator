using LoggingHandlers;

namespace CalculatorLibrary
{
    public class CalculatorMethods
    {
        public double DoOperation(double num1, double num2, string op)
        {
            LoggingHandling loggingHandling = new LoggingHandling();

            double result = double.NaN;

            switch (op)
            {
                case "a":
                    result = num1 + num2;
                    break;
                case "s":
                    result = num1 - num2;
                    break;
                case "m":
                    result = num1 * num2;
                    break;
                case "d":
                    // Ask the user to enter a non-zero divisor.
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    break;
                // Return text for an incorrect option entry.
                default:
                    break;
            }

            
            loggingHandling.LogCalculation(op, num1, num2, result);

            return result;
        }
    }
}