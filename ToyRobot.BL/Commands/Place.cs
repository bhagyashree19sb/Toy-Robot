using System;
using System.Collections.Generic;
using System.Text;
using ToyRobot.BL.MoveOperations;

namespace ToyRobot.BL.Commands
{
    public class Place : ICommand
    {
        private bool ValidateRequiredCommandInput(IToyRobot robot, string[] commandArgs)
        {
            // If robot is already placed on the table, then the existing direction can be used
            if (robot.IsRobotPlacedOnTheTable())
            {
                // Validate number of inputs
                if (commandArgs.Length != 3 && commandArgs.Length != 4)
                {
                    return false;
                }
            }
            else
            {
                // Validate number of inputs
                if (commandArgs.Length != 4)
                {
                    return false;
                }
            }

            return true;
        }

        private bool ValidateXCoordinate(string x, out int outX)
        {
            return int.TryParse(x, out outX);
        }

        private bool ValidateYCoordinate(string y, out int outY)
        {
            return int.TryParse(y, out outY);
        }

        public bool ValidateDirection(string direction, out DirectionEnum directionEnum)
        {
            return Enum.TryParse(direction, true, out directionEnum);
        }


        public string Execute(IToyRobot robot, string command = "")
        {
            // Read individual inputs
            string[] commandArgs = command.Split(" ");

            // Validate argument count
            if (!ValidateRequiredCommandInput(robot, commandArgs))
            {
                throw new Exception("Insufficient inputs. Please provide the initial coordinates and the direction.");
            }

            // validate cooridnate values
            if(!ValidateXCoordinate(commandArgs[1], out int x))
            {
                throw new Exception("Invalid X coordinate.");
            }

            if (!ValidateYCoordinate(commandArgs[2], out int y))
            {
                throw new Exception("Invalid Y coordinate.");
            }

            // Check if the coordinates are within the scope
            if (x >= robot.MaxEast || y >= robot.MaxNorth || x < 0 || y < 0)
            {
                // if not, discard 
                return null;
            }

            // validate direction when provided
            if (commandArgs.Length == 4)
            {
                if (!ValidateDirection(commandArgs[3], out DirectionEnum direction))
                {
                    throw new Exception("Invalid direction.");
                }

                robot.Direction = direction;
            }

            robot.PositionX = x;
            robot.PositionY = y;

            return null;
        }
    }
}
