using CalculatorLibrary;
using Objects;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using System.Text.RegularExpressions;

namespace Helpers
{
    public class UsesListFunctions
    {
        public static void PrintUses()
        {
            Console.WriteLine("Past Uses Log");
            Console.WriteLine("------------------------ \n");
            int i = 0;
            foreach (var use in Objects.Uses.uses)
            {
                i++;
                Console.WriteLine($"{i}. \t{use.Operand1} {use.Op} {use.Operand2} = {use.Result} \n");
               
            }
        }

        public static void DeleteUses()
        {
            Objects.Uses.uses.Clear();

            Console.WriteLine("List emptied.");
        }

        public static void UsePastCalculation()
        {
            CalculatorMethods calculatorMethods = new CalculatorMethods();

            double result = 0;

            Console.WriteLine("Enter Index of calculation you want to use: ");
            string? calcIndexInput = Console.ReadLine();

            int calcIndex = 0;
            while (!int.TryParse(calcIndexInput, out calcIndex))
            {
                Console.WriteLine("Input invalid, please only input numeric values");
                calcIndexInput = Console.ReadLine();
            }

            while (!int.TryParse(calcIndexInput, out calcIndex) || calcIndex > Objects.Uses.uses.Count() || calcIndex < 0)
            {
                Console.WriteLine("Input is not a vail index, please only input an index in the list.\n");
                Console.WriteLine("Enter Index of calculation you want to use: ");
                calcIndexInput = Console.ReadLine();

                calcIndex = 0;
                while (!int.TryParse(calcIndexInput, out calcIndex))
                {
                    Console.WriteLine("Input invalid, please only input numeric values");
                    calcIndexInput = Console.ReadLine();
                }
            }
            calcIndex -= 1;

            Console.WriteLine($"selected calculation: {Objects.Uses.uses[calcIndex].Operand1} {Objects.Uses.uses[calcIndex].Op} {Objects.Uses.uses[calcIndex].Operand2} = {Objects.Uses.uses[calcIndex].Result}");
            Console.WriteLine("Would you  like to use the first operand (1), second operand (2), or result (3)?");
            string? usedComponentInput = Console.ReadLine();

            while (String.IsNullOrEmpty(usedComponentInput) || !Regex.IsMatch(usedComponentInput, "[1|2|3]"))
            {
                Console.WriteLine("enter valid input.");
                usedComponentInput = Console.ReadLine();
            }

            Console.WriteLine("Would you like to use it as the first operand (1) or second operand (2)?");
            string? componentLocation = Console.ReadLine();
            double num1 = 0;

            switch (componentLocation)
            {
                case "1":

                    switch (usedComponentInput)
                    {
                        case "1":
                            num1 = Convert.ToDouble(Uses.uses[calcIndex].Operand1);
                            break;
                        case "2":
                            num1 = Convert.ToDouble(Uses.uses[calcIndex].Operand2);
                               break;
                        case "3":
                            num1 = Convert.ToDouble(Uses.uses[calcIndex].Result);
                            break;
                        }

                    Console.WriteLine("Enter second number: ");
                    string? num2Input = Console.ReadLine();

                    double num2 = 0;
                    while (!double.TryParse(num2Input, out num2))
                    {
                        Console.WriteLine("Input invalid, please input a numeric value.");
                        num2Input = Console.ReadLine();
                    }

                    Console.WriteLine("Choose an operator from the following list:");
                    Console.WriteLine("\ta - Add");
                    Console.WriteLine("\ts - Subtract");
                    Console.WriteLine("\tm - Multiply");
                    Console.WriteLine("\td - Divide");
                    Console.Write("Your option? ");

                    string? op = Console.ReadLine();

                    // Validate input is not null, and matches the pattern
                    if (op == null || !Regex.IsMatch(op, "[a|s|m|d]"))
                    {
                        Console.WriteLine("Error: Unrecognized input.");
                    }
                    else
                    {
                        try
                        {
                            result = calculatorMethods.DoOperation(num1, num2, op);

                            if (double.IsNaN(result))
                            {
                                Console.WriteLine("This operation will result in a mathematical error.\n");
                            }
                            else Console.WriteLine("Your result: {0:0.##}\n", result);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                        }
                    }
                    break;

                case "2":
                Console.WriteLine("Enter first number: ");
                string? num1Input = Console.ReadLine();

                num1 = 0;
                while (!double.TryParse(num1Input, out num1))
                {
                    Console.WriteLine("Input invalid, please provide a numeric value.");
                    num1Input = Console.ReadLine();
                }

                num2 = Convert.ToDouble(Uses.uses[calcIndex]);

                Console.WriteLine("Choose an operator from the following list:");
                Console.WriteLine("\ta - Add");
                Console.WriteLine("\ts - Subtract");
                Console.WriteLine("\tm - Multiply");
                Console.WriteLine("\td - Divide");
                Console.Write("Your option? ");

                op = Console.ReadLine();

                // Validate input is not null, and matches the pattern
                if (op == null || !Regex.IsMatch(op, "[a|s|m|d]"))
                {
                    Console.WriteLine("Error: Unrecognized input.");
                }
                else
                {
                    try
                    {
                        result = calculatorMethods.DoOperation(num1, num2, op);

                        if (double.IsNaN(result))
                        {
                            if (double.IsNaN(result))
                            {
                                Console.WriteLine("This operation will result in a mathematical error.\n");
                            }
                            else Console.WriteLine("Your result: {0:0.##}\n", result);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                    }
                }
                break;

                default:
                Console.WriteLine("please enter a given option.");
                break;
            }
        }

        public static void AddToHistory(double operand1, double operand2, double result, string op = "no op applied")
        {
            switch (op)
            {
                case "m":
                    op = "*";
                    break;
                case "s":
                    op = "-";
                    break;
                case "a":
                    op = "+";
                    break;
                case "d":
                    op = "/";
                    break;
            }

            Objects.Uses.uses.Add(new CalcUse
            {
                Operand1 = operand1,
                Operand2 = operand2,
                Op = op,
                Result = result
            });
        }
    }
}
