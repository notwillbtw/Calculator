﻿using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using CalculatorLibrary;
using Helpers;

class Program
{
    
    static void Main(string[] args)
    {
        int timesUsed = 0;

        bool endApp = false;
        // Display title as the C# console calculator app.
        Console.WriteLine("Console Calculator in C#\r");
        Console.WriteLine("------------------------\n");

        CalculatorMethods calculator = new CalculatorMethods();

        while (!endApp)
        {
            Console.WriteLine("Use calculator (c) or view past uses (v) or quit the program (q)");
            string? choice = Console.ReadLine();

            if (choice == "v")
            {
                Helpers.UsesListFunctions.PrintUses();
                Console.WriteLine("\nDelete list (D), Use past use for calculation (P) or Enter any key and press enter to return to calculator.");
                string? input = Console.ReadLine();

                if (input.ToLower() == "d")
                {
                    Helpers.UsesListFunctions.DeleteUses();
                    Console.ReadLine();
                }
                else if (input.ToLower() == "p")
                {
                    Helpers.UsesListFunctions.UsePastCalculation();
                }
                
                Console.Clear();

                Console.WriteLine("Console Calculator in C#\r");
                Console.WriteLine("------------------------\n");
                continue;
            }
            else if (choice == "c")
            {
                timesUsed++;

                Calculator();
                Console.Write($"You have used the calculator {timesUsed} time(s). Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "n") endApp = true;
            }
            else if (choice == "q")
            {
                //quit
            }
            else
            {
                Console.WriteLine("invalid input.");
            }

            // Add call to close the JSON writer before return
            calculator.Finish();
            return;
        }
            
    }

    internal static void Calculator(bool hasChosenResultForOperand1 = false, bool hasChosenResultForOperand2 = false)
    {

        CalculatorMethods calculator2 = new CalculatorMethods();

        // Declare variables and set to empty.
        // Use Nullable types (with ?) to match type of System.Console.ReadLine
        string? numInput1 = "";
        string? numInput2 = "";
        double result = 0;

        // Ask the user to type the first number.
        Console.Write("Type a number, and then press Enter: ");
        numInput1 = Console.ReadLine();

        double cleanNum1 = 0;
        while (!double.TryParse(numInput1, out cleanNum1))
        {
            Console.Write("This is not valid input. Please enter a numeric value: ");
            numInput1 = Console.ReadLine();
        }

        // Ask the user to type the second number.
        Console.Write("Type another number, and then press Enter: ");
        numInput2 = Console.ReadLine();

        double cleanNum2 = 0;
        while (!double.TryParse(numInput2, out cleanNum2))
        {
            Console.Write("This is not valid input. Please enter a numeric value: ");
            numInput2 = Console.ReadLine();
        }

        // Ask the user to choose an operator.
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
                
                result = calculator2.DoOperation(cleanNum1, cleanNum2, op);

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
        Console.WriteLine("------------------------\n");

        UsesListFunctions.AddToHistory(cleanNum1, cleanNum2, result, op);


        // Wait for the user to respond before closing.


        Console.Clear();
    }
}
