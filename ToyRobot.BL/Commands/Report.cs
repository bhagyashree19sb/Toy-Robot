using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot.BL.Commands
{
    public class Report : ICommand
    {
        public string Execute(IToyRobot robot, string command = "")
        {
            // Execute only if the robot is on the table
            if (robot.IsRobotPlacedOnTheTable())
            {
                return $"{robot.PositionX},{robot.PositionY},{robot.Direction.ToString()}";
            }

            return null;
        }
    }
}
