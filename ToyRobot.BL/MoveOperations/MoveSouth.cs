using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot.BL.MoveOperations
{
    public class MoveSouth : IMove
    {
        public void Move(IToyRobot robot)
        {
            // Check if move to South will cause the robot to fall
            if (robot.PositionY - 1 >= 0)
            {
                --robot.PositionY;
            }

            // Else do not move
        }
    }
}
