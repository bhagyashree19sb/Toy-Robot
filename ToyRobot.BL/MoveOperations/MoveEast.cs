using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot.BL.MoveOperations
{
    public class MoveEast : IMove
    {
        public void Move(IToyRobot robot)
        {
            // Check if move to East will cause the robot to fall
            if (robot.PositionX + 1 < robot.MaxEast)
            {
                ++robot.PositionX;
            }

            // Else do not move
        }
    }
}
