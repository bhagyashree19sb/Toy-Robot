using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot.BL.MoveOperations
{
    public class MoveNorth: IMove
    {
        public void Move(IToyRobot robot)
        {
            // Check if move to North will cause the robot to fall
            if (robot.PositionY + 1 < robot.MaxNorth)
            {
                ++robot.PositionY;
            }

            // Else do not move
        }
    }
}
