using System;
using System.Collections.Generic;
using ToyRobot.BL;
using ToyRobot.BL.Commands;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IToyRobot toyRobot = new ToyRobot.BL.ToyRobot(6, 6);
            Console.WriteLine("Hi there! Please provide commands");

            var command = Console.ReadLine().ToString();

            // Enter exit to close the program
            while (!command.Equals("Exit", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    var result = toyRobot.ExecuteCommand(command);
                    
                    // Display result if any
                    if (!string.IsNullOrEmpty(result))
                    {
                        Console.WriteLine(result);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                command = Console.ReadLine();
            }
        }
    }
}
