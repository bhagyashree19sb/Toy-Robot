using System;
using System.Collections.Generic;
using System.Text;
using ToyRobot.BL.Commands;
using ToyRobot.BL.MoveOperations;

namespace ToyRobot.BL
{
    public class Configs
    {
        // Register commands
        public static Dictionary<string, ICommand> RobotOperations = new Dictionary<string, ICommand>(StringComparer.OrdinalIgnoreCase)
        {
            { "Place", new Place() } ,
            { "Move", new Move() },
            { "Report", new Report() },
            { "Left", new Left() },
            { "Right", new Right() }
        };

        // Register directions
        public static Dictionary<DirectionEnum, IMoveDirection> MoveDirections = new Dictionary<DirectionEnum, IMoveDirection>()
        {
            { DirectionEnum.NORTH, new North() },
            { DirectionEnum.EAST, new East() },
            { DirectionEnum.SOUTH, new South() },
            { DirectionEnum.WEST, new West() }
        };

    }
}
