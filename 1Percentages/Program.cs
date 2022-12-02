using System;
using System.Linq;

namespace Percentages
{
    class Program
    {
        public static double Calculate(string userInput)
        {
            double[] result = userInput.Split().Select(double.Parse).ToArray();
            double sum = result[0], nominal = userInput[0], percent = result[1], time = result[2];
            for (int i = 0; i < time; i++)
            {
                sum += sum * percent / 100.0 + nominal / 12.0;
            }
            return sum;
        }
        static void Main()
        {
            string userInput = Console.ReadLine();
            Calculate(userInput);        
        }
    }
}

