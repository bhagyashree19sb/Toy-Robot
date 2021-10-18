using System;
using System.Collections.Generic;
using System.Text;
using ToyRobot.BL.Commands;
using ToyRobot.BL.MoveOperations;

namespace ToyRobot.BL
{
    public interface IToyRobot
    {
        int MaxEast { get; }
        int MaxNorth { get; }
        int PositionX { get; set; }
        int PositionY { get; set; }
        DirectionEnum Direction { get; set; }
        bool IsRobotPlacedOnTheTable();
        string ExecuteCommand(string command);
        void MoveDirection();
    }
}
