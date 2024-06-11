﻿using LoggingHandlers;

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
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    break;
                default:
                    break;
            }
            
            loggingHandling.LogCalculation(op, num1, num2, result);

            return result;
        }
    }
}