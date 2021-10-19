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
            // Validate number of inputs
            if (commandArgs.Length != 2)
            {
                return false;
            }

            // If robot is already placed on the table, then the existing direction can be used
            string[] placeArgs = commandArgs[1].Split(",");
            if (robot.IsRobotPlacedOnTheTable())
            {
                if (placeArgs.Length != 2 && placeArgs.Length != 3)
                {
                    return false;
                }
            }            
            else
            {
                // Validate number of inputs
                if (placeArgs.Length != 3)
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
            // Enum parse passes number inputs
            if (Enum.TryParse(direction, true, out directionEnum))
            {
                return !int.TryParse(direction, out int enumValue);
            }

            return false;
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

            string[] placeArgs = commandArgs[1].Split(",");

            // validate cooridnate values
            if(!ValidateXCoordinate(placeArgs[0], out int x))
            {
                throw new Exception("Invalid X coordinate.");
            }

            if (!ValidateYCoordinate(placeArgs[1], out int y))
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
            if (placeArgs.Length == 3)
            {
                if (!ValidateDirection(placeArgs[2], out DirectionEnum direction))
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
