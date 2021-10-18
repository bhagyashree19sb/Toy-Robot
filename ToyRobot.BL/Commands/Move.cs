using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot.BL.Commands
{
    public class Move : ICommand
    {
        public string Execute(IToyRobot robot, string command = "")
        {
            // Execute only if the robot is on the table
            if (robot.IsRobotPlacedOnTheTable())
            {
                robot.MoveDirection();
            }

            return null;
        }
    }
}
