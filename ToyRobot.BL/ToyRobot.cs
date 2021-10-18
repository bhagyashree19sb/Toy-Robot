using System;
using ToyRobot.BL.Commands;
using ToyRobot.BL.MoveOperations;

namespace ToyRobot.BL
{
    public class ToyRobot: IToyRobot
    {
        public int MaxEast { get; }
        public int MaxNorth { get; }
        public int PositionX { get; set; } = -1;
        public int PositionY { get; set; } = -1;
        public DirectionEnum Direction { get; set; }

        // Initializes table space
        public ToyRobot(int maxEast, int maxNorth)
        {
            MaxEast = maxEast;
            MaxNorth = maxNorth;
        }        

        // Check if robot is initialized
        public bool IsRobotPlacedOnTheTable()
        {
            return (PositionX == -1 || PositionY == -1) ? false : true;
        }

        // Takes commands from the user as the input & invokes corresponding action
        public string ExecuteCommand(string command)
        {
            // Read individual inputs
            string[] commandArgs = command.Split(" ");

            // Check if command is entered
            if (commandArgs.Length == 0)
            {
                return null;
            }

            // Check if command is valid
            if (!Configs.RobotOperations.ContainsKey(commandArgs[0]))
            {
                throw new InvalidOperationException("Invalid command");
            }

            // Get the command instance from dictionary
            var operation = Configs.RobotOperations[commandArgs[0]];
            return operation.Execute(this, command);
        }

        public void MoveDirection()
        {
            var direction = Configs.MoveDirections[Direction];
            direction.Move(this);
        }
    }
}
