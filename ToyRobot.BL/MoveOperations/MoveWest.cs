using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot.BL.MoveOperations
{
    public class MoveWest : IMove
    {
        public void Move(IToyRobot robot)
        {
            // Check if move to West will cause the robot to fall
            if (robot.PositionX - 1 >= 0)
            {
                --robot.PositionX;
            }

            // Else do not move
        }
    }
}
