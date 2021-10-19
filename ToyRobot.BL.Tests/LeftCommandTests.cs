using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot.BL.Tests
{
    [TestClass]
    public class LeftCommandTests
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
        public void LeftCommand_RobotNotYetInitialized_Ignore_Pass()
        {
            robot.ExecuteCommand("LEFT");

            Assert.AreEqual(-1, robot.PositionX, "Robot X coorodinate has changed");
            Assert.AreEqual(-1, robot.PositionY, "Robot Y coorodinate has changed");
            Assert.IsNull(robot.Direction, "Robot didn't move");
        }

        [TestMethod]
        public void LeftCommand_NorthToWest_Pass()
        {
            string command = "PLACE";
            int x = 0;
            int y = 0;
            string direction = "NORTH";

            robot.ExecuteCommand($"{command} {x},{y},{direction}");

            robot.ExecuteCommand("LEFT");

            Assert.AreEqual(x, robot.PositionX, "Robot X coordinate has changed");
            Assert.AreEqual(y, robot.PositionY, "Robot Y coordinate has changed");
            Assert.AreEqual(DirectionEnum.WEST, robot.Direction, "Robot direction has not changed");

            var report = robot.ExecuteCommand("REPORT");
            Assert.AreEqual($"{x},{y},{DirectionEnum.WEST}", report, "Report mismatch");
        }

        [TestMethod]
        public void LeftCommand_WestToSouth_Pass()
        {
            string command = "PLACE";
            int x = 0;
            int y = 0;
            string direction = "WEST";

            robot.ExecuteCommand($"{command} {x},{y},{direction}");

            robot.ExecuteCommand("LEFT");

            Assert.AreEqual(x, robot.PositionX, "Robot X coordinate has changed");
            Assert.AreEqual(y, robot.PositionY, "Robot Y coordinate has changed");
            Assert.AreEqual(DirectionEnum.SOUTH, robot.Direction, "Robot direction has not changed");

            var report = robot.ExecuteCommand("REPORT");
            Assert.AreEqual($"{x},{y},{DirectionEnum.SOUTH}", report, "Report mismatch");
        }

        [TestMethod]
        public void LeftCommand_SouthToEast_Pass()
        {
            string command = "PLACE";
            int x = 0;
            int y = 0;
            string direction = "SOUTH";

            robot.ExecuteCommand($"{command} {x},{y},{direction}");

            robot.ExecuteCommand("LEFT");

            Assert.AreEqual(x, robot.PositionX, "Robot X coordinate has changed");
            Assert.AreEqual(y, robot.PositionY, "Robot Y coordinate has changed");
            Assert.AreEqual(DirectionEnum.EAST, robot.Direction, "Robot direction has not changed");

            var report = robot.ExecuteCommand("REPORT");
            Assert.AreEqual($"{x},{y},{DirectionEnum.EAST}", report, "Report mismatch");
        }

        [TestMethod]
        public void LeftCommand_EastToNorth_Pass()
        {
            string command = "PLACE";
            int x = 0;
            int y = 0;
            string direction = "EAST";

            robot.ExecuteCommand($"{command} {x},{y},{direction}");

            robot.ExecuteCommand("LEFT");

            Assert.AreEqual(x, robot.PositionX, "Robot X coordinate has changed");
            Assert.AreEqual(y, robot.PositionY, "Robot Y coordinate has changed");
            Assert.AreEqual(DirectionEnum.NORTH, robot.Direction, "Robot direction has not changed");

            var report = robot.ExecuteCommand("REPORT");
            Assert.AreEqual($"{x},{y},{DirectionEnum.NORTH}", report, "Report mismatch");
        }
    }
}
