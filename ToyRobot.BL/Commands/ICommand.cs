using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot.BL.Commands
{
    public interface ICommand
    {
        string Execute(IToyRobot robot, string command = "");
    }
}
