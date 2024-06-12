using CalculatorLibrary;
using LoggingHandlers;
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
