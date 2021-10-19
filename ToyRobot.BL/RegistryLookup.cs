using System;
using System.Collections.Generic;
using System.Text;
using ToyRobot.BL.Commands;
using ToyRobot.BL.MoveOperations;

namespace ToyRobot.BL
{
    public class RegistryLookup
    {
        // Register commands
        public static Dictionary<string, ICommand> Commands = new Dictionary<string, ICommand>(StringComparer.OrdinalIgnoreCase)
        {
            { "Place", new Place() } ,
            { "Move", new Move() },
            { "Report", new Report() },
            { "Left", new Left() },
            { "Right", new Right() }
        };

        // Register directions
        public static Dictionary<DirectionEnum, IMove> MoveInTheDirection = new Dictionary<DirectionEnum, IMove>()
        {
            { DirectionEnum.NORTH, new MoveNorth() },
            { DirectionEnum.EAST, new MoveEast() },
            { DirectionEnum.SOUTH, new MoveSouth() },
            { DirectionEnum.WEST, new MoveWest() }
        };

    }
}
