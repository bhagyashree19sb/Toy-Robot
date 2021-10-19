using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot.BL.MoveOperations
{
    public interface IMove
    {
        void Move(IToyRobot robot);
    }
}
