using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot.BL.Commands
{
    public class Left : ICommand
    {
        public string Execute(IToyRobot robot, string command = "")
        {
            // Execute only if the robot is on the table
            if (robot.IsRobotPlacedOnTheTable())
            {
                switch (robot.Direction)
                {
                    case DirectionEnum.NORTH:
                        robot.Direction = DirectionEnum.WEST;
                        break;
                    case DirectionEnum.WEST:
                        robot.Direction = DirectionEnum.SOUTH;
                        break;
                    case DirectionEnum.SOUTH:
                        robot.Direction = DirectionEnum.EAST;
                        break;
                    case DirectionEnum.EAST:
                        robot.Direction = DirectionEnum.NORTH;
                        break;
                }
            }            

            return null;
        }
    }
}
