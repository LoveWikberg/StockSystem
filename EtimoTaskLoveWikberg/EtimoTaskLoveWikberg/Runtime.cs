using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtimoTaskLoveWikberg
{
    class Runtime
    {
        public void Start()
        {
            string helpMessage = String.Format("Type 'S' followed by a number to sell x amount from stock{0}Type 'I' followed by a number to add x amount to stock{1}Type 'L' to check stock"
                , Environment.NewLine, Environment.NewLine);
            Console.WriteLine(helpMessage + Environment.NewLine);

            // This is the main loop for the application
            while (true)
            {
                Console.WriteLine(CheckInput(Console.ReadLine(), helpMessage));
            }
        }

        string CheckInput(string input, string helpMessage)
        {
            Console.Clear();
            Console.WriteLine(helpMessage + Environment.NewLine);

            if (!string.IsNullOrEmpty(input))
            {
                var stockHandler = new StockHandler();
                switch (input.ToUpper().First())
                {
                    case 'S':
                        return TryToEditStockAndReturnMessage(input, stockHandler.RemoveFromStock);

                    case 'I':
                        return TryToEditStockAndReturnMessage(input, stockHandler.AddToStock);

                    case 'L':
                        if (input.Length == 1)
                            return String.Format("Current stock: {0}", StockHandler.stock);
                        return "Invalid input";

                    default:
                        return "Invalid input";
                }
            }
            else
                return "Invalid input";
        }


        string TryToEditStockAndReturnMessage(string input, Action<int> methodThatTakeOneInt)
        {
            // Check if all chars expect the first char in "input" are digits only
            bool isInteger = Int32.TryParse(input.Substring(1), out int number);

            if (isInteger && !input.Contains("+") && !input.Contains("-"))
            {
                methodThatTakeOneInt(number);
                return "Stock was changed";
            }
            else
                return "Invalid input";
        }
    }
}
