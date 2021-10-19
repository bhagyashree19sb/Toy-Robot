using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot.BL.Tests
{
    [TestClass]
    public class MoveCommandTests
    {
        IToyRobot robot;

        [TestInitialize]
        public void Initialize()
        {
            robot = new ToyRobot(6, 6);
        }

        [TestCleanup]
        public void Cleanup()
        {
            robot = null;
        }

        [TestMethod]
        public void MoveCommand_RobotNotYetInitialized_Ignore_Pass()
        {
            robot.ExecuteCommand("MOVE");

            Assert.AreEqual(-1, robot.PositionX, "Robot X coorodinate has changed");
            Assert.AreEqual(-1, robot.PositionY, "Robot Y coorodinate has changed");
            Assert.IsNull(robot.Direction, "Robot didn't move");
        }

        [DataTestMethod]
        [DataRow("PLACE", 0, 0, "NORTH")] // Bottom left corner movements
        [DataRow("PLACE", 0, 4, "NORTH")] // Bottom right corner movements
        [DataRow("PLACE", 5, 0, "NORTH")] // Top left corner movements
        [DataRow("PLACE", 5, 4, "NORTH")] // Top right corner movements
        [DataRow("PLACE", 3, 3, "NORTH")] // Center movements
        public void MoveCommand_North_WithinScope_Pass(string command, int x, int y, string direction)
        {
            robot.ExecuteCommand($"{command} {x},{y},{direction}");

            robot.ExecuteCommand("MOVE");

            Assert.AreEqual(x, robot.PositionX, "Robot X coordinate has changed");
            Assert.AreEqual(y + 1, robot.PositionY, "Robot hasn't moved East");
            Assert.AreEqual(Enum.Parse(typeof(DirectionEnum), direction), robot.Direction, "Robot direction has changed");

            var report = robot.ExecuteCommand("REPORT");
            Assert.AreEqual($"{x},{y + 1},{direction}", report, "Report mismatch");
        }

        [DataTestMethod]
        [DataRow("PLACE", 0, 5, "NORTH")] // Top left corner movements
        [DataRow("PLACE", 5, 5, "NORTH")] // Top right corner movements
        public void MoveCommand_North_DontMoveAlongTheBoundary_Pass(string command, int x, int y, string direction)
        {
            robot.ExecuteCommand($"{command} {x},{y},{direction}");

            robot.ExecuteCommand("MOVE");

            Assert.AreEqual(x, robot.PositionX, "Robot X coordinate has changed");
            Assert.AreEqual(y, robot.PositionY, "Robot has moved East");
            Assert.AreEqual(Enum.Parse(typeof(DirectionEnum), direction), robot.Direction, "Robot direction has changed");

            var report = robot.ExecuteCommand("REPORT");
            Assert.AreEqual($"{x},{y},{direction}", report, "Report mismatch");
        }

        [DataTestMethod]
        [DataRow("PLACE", 0, 0, "EAST")] // Bottom left corner movements
        [DataRow("PLACE", 4, 0, "EAST")] // Bottom right corner movements
        [DataRow("PLACE", 0, 5, "EAST")] // Top left corner movements
        [DataRow("PLACE", 4, 5, "EAST")] // Top right corner movements
        [DataRow("PLACE", 3, 3, "EAST")] // Center movements
        public void MoveCommand_East_WithinScope_Pass(string command, int x, int y, string direction)
        {
            robot.ExecuteCommand($"{command} {x},{y},{direction}");

            robot.ExecuteCommand("MOVE");

            Assert.AreEqual(x + 1, robot.PositionX, "Robot hasn't moved East");
            Assert.AreEqual(y, robot.PositionY, "Robot Y coordinate has changed");
            Assert.AreEqual(Enum.Parse(typeof(DirectionEnum), direction), robot.Direction, "Robot direction has changed");

            var report = robot.ExecuteCommand("REPORT");
            Assert.AreEqual($"{x + 1},{y},{direction}", report, "Report mismatch");
        }

        [DataTestMethod]
        [DataRow("PLACE", 5, 0, "EAST")] // Bottom right corner movements
        [DataRow("PLACE", 5, 5, "EAST")] // Top right corner movements
        public void MoveCommand_East_DontMoveAlongTheBoundary_Pass(string command, int x, int y, string direction)
        {
            robot.ExecuteCommand($"{command} {x},{y},{direction}");

            robot.ExecuteCommand("MOVE");

            Assert.AreEqual(x, robot.PositionX, "Robot has moved East");
            Assert.AreEqual(y, robot.PositionY, "Robot Y coordinate has changed");
            Assert.AreEqual(Enum.Parse(typeof(DirectionEnum), direction), robot.Direction, "Robot direction has changed");

            var report = robot.ExecuteCommand("REPORT");
            Assert.AreEqual($"{x},{y},{direction}", report, "Report mismatch");
        }

        [DataTestMethod]
        [DataRow("PLACE", 0, 1, "SOUTH")] // Bottom left corner movements
        [DataRow("PLACE", 5, 1, "SOUTH")] // Bottom right corner movements
        [DataRow("PLACE", 0, 5, "SOUTH")] // Top left corner movements
        [DataRow("PLACE", 5, 5, "SOUTH")] // Top right corner movements
        [DataRow("PLACE", 3, 3, "SOUTH")] // Center movements
        public void MoveCommand_South_WithinScope_Pass(string command, int x, int y, string direction)
        {
            robot.ExecuteCommand($"{command} {x},{y},{direction}");

            robot.ExecuteCommand("MOVE");

            Assert.AreEqual(x, robot.PositionX, "Robot X coordinate has changed");
            Assert.AreEqual(y - 1, robot.PositionY, "Robot hasn't moved South");
            Assert.AreEqual(Enum.Parse(typeof(DirectionEnum), direction), robot.Direction, "Robot direction has changed");

            var report = robot.ExecuteCommand("REPORT");
            Assert.AreEqual($"{x},{y - 1},{direction}", report, "Report mismatch");
        }

        [DataTestMethod]
        [DataRow("PLACE", 0, 0, "SOUTH")] // Bottom left corner movements
        [DataRow("PLACE", 5, 0, "SOUTH")] // Bottom right corner movements
        public void MoveCommand_South_DontMoveAlongTheBoundary_Pass(string command, int x, int y, string direction)
        {
            robot.ExecuteCommand($"{command} {x},{y},{direction}");

            robot.ExecuteCommand("MOVE");

            Assert.AreEqual(x, robot.PositionX, "Robot X coordinate has changed");
            Assert.AreEqual(y, robot.PositionY, "Robot has moved South");
            Assert.AreEqual(Enum.Parse(typeof(DirectionEnum), direction), robot.Direction, "Robot direction has changed");

            var report = robot.ExecuteCommand("REPORT");
            Assert.AreEqual($"{x},{y},{direction}", report, "Report mismatch");
        }

        [DataTestMethod]
        [DataRow("PLACE", 1, 0, "WEST")] // Bottom left corner movements
        [DataRow("PLACE", 5, 0, "WEST")] // Bottom right corner movements
        [DataRow("PLACE", 1, 5, "WEST")] // Top left corner movements
        [DataRow("PLACE", 5, 5, "WEST")] // Top right corner movements
        [DataRow("PLACE", 3, 3, "WEST")] // Center movements
        public void MoveCommand_West_WithinScope_Pass(string command, int x, int y, string direction)
        {
            robot.ExecuteCommand($"{command} {x},{y},{direction}");

            robot.ExecuteCommand("MOVE");

            Assert.AreEqual(x - 1, robot.PositionX, "Robot hasn't moved West");
            Assert.AreEqual(y, robot.PositionY, "Robot Y coordinate has changed");
            Assert.AreEqual(Enum.Parse(typeof(DirectionEnum), direction), robot.Direction, "Robot direction has changed");

            var report = robot.ExecuteCommand("REPORT");
            Assert.AreEqual($"{x - 1},{y},{direction}", report, "Report mismatch");
        }

        [DataTestMethod]
        [DataRow("PLACE", 0, 5, "WEST")] // Top left corner movements
        [DataRow("PLACE", 0, 0, "WEST")] // Bottom left corner movements
        public void MoveCommand_West_DontMoveAlongTheBoundary_Pass(string command, int x, int y, string direction)
        {
            robot.ExecuteCommand($"{command} {x},{y},{direction}");

            robot.ExecuteCommand("MOVE");

            Assert.AreEqual(x, robot.PositionX, "Robot has moved West");
            Assert.AreEqual(y, robot.PositionY, "Robot Y coordinate has changed");
            Assert.AreEqual(Enum.Parse(typeof(DirectionEnum), direction), robot.Direction, "Robot direction has changed");

            var report = robot.ExecuteCommand("REPORT");
            Assert.AreEqual($"{x},{y},{direction}", report, "Report mismatch");
        }
    }
}
