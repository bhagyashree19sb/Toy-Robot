using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot.BL.MoveOperations
{
    public interface IMoveDirection
    {
        void Move(IToyRobot robot);
    }
}
