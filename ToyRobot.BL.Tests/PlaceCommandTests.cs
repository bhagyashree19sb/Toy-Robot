using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ToyRobot.BL.Tests
{
    [TestClass]
    public class PlaceCommandTests
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

        [DataTestMethod]
        [DataRow("PLACE")]
        [DataRow("PLACE 0")]
        [DataRow("PLACE 0,0")]
        [ExpectedException(typeof(Exception))]
        public void PlaceCommand_InsufficientInputs_Fail(string command)
        {
            robot.ExecuteCommand(command); 
        }

        [DataTestMethod]
        [DataRow("PLACE X,0,North")]
        [DataRow("PLACE $,0,North")]
        [ExpectedException(typeof(Exception))]
        public void PlaceCommand_InvalidXCoordinate_Fail(string command)
        {
            robot.ExecuteCommand(command);
        }

        [DataTestMethod]
        [DataRow("PLACE 0,Y,North")]
        [DataRow("PLACE 0,$,North")]
        [ExpectedException(typeof(Exception))]
        public void PlaceCommand_InvalidYCoordinate_Fail(string command)
        {
            robot.ExecuteCommand(command);
        }

        [DataTestMethod]
        [DataRow("PLACE 0,0,10")]
        [DataRow("PLACE 0,0,Northeast")]
        [ExpectedException(typeof(Exception))]
        public void PlaceCommand_InvalidDirection_Fail(string command)
        {
            robot.ExecuteCommand(command);
        }

        [DataTestMethod]
        [DataRow("PLACE -1,0,NORTH")] // X less than min
        [DataRow("PLACE 6,0,NORTH")] // X greater than max
        [DataRow("PLACE 0,-1,NORTH")] // Y less than min
        [DataRow("PLACE 0,6,NORTH")] // Y greater than max
        [DataRow("PLACE -1,-1,NORTH")] // X & Y less than min
        [DataRow("PLACE 6,6,NORTH")] // X & Y greater than max
        public void PlaceCommand_OutOfScopeCoorinates_Ignore_Pass(string command)
        {
            robot.ExecuteCommand(command);

            Assert.AreEqual(-1, robot.PositionX, "Robot X coordinate is initialized");
            Assert.AreEqual(-1, robot.PositionY, "Robot Y coordinate is initialized");
            Assert.IsNull(robot.Direction, "Robot direction is initialized");
        }

        [DataTestMethod]
        [DataRow("PLACE", "0", "0", "NORTH")]
        [DataRow("PLACE", "0", "5", "NORTH")]
        [DataRow("PLACE", "5", "0", "NORTH")]
        [DataRow("PLACE", "5", "5", "NORTH")]
        public void PlaceCommand_ValidInputs_Pass(string command, string x, string y, string direction)
        {
            robot.ExecuteCommand($"{command} {x},{y},{direction}");

            Assert.AreEqual(Convert.ToInt32(x), robot.PositionX, "Robot X coordinate - invalid initialization");
            Assert.AreEqual(Convert.ToInt32(y), robot.PositionY, "Robot Y coordinate - invalid initialization");
            Assert.AreEqual(Enum.Parse(typeof(DirectionEnum), direction), robot.Direction, "Robot direction - invalid initialization");

            string expectedReport = $"{robot.PositionX},{robot.PositionY},{robot.Direction}";

            var obtainedReport = robot.ExecuteCommand("REPORT");
            Assert.AreEqual(expectedReport, obtainedReport, "Report is not as expected");
        }

        [TestMethod]
        public void PlaceCommand_reinitialize_withDirection_Pass()
        {
            string command = "PLACE";
            int x = 0;
            int y = 0;
            string direction = "NORTH";

            robot.ExecuteCommand($"{command} {x},{y},{direction}");

            x = 5;
            y = 5;
            direction = "SOUTH";

            robot.ExecuteCommand($"{command} {x},{y},{direction}");

            Assert.AreEqual(Convert.ToInt32(x), robot.PositionX, "Robot X coordinate - invalid re-initialization");
            Assert.AreEqual(Convert.ToInt32(y), robot.PositionY, "Robot Y coordinate - invalid re-initialization");
            Assert.AreEqual(Enum.Parse(typeof(DirectionEnum), direction), robot.Direction, "Robot direction - invalid re-initialization");
        }

        [TestMethod]
        public void PlaceCommand_reinitialize_withoutDirection_Pass()
        {
            string command = "PLACE";
            int x = 0;
            int y = 0;
            string direction = "NORTH";

            robot.ExecuteCommand($"{command} {x},{y},{direction}");

            x = 5;
            y = 5;

            robot.ExecuteCommand($"{command} {x},{y},{direction}");

            Assert.AreEqual(Convert.ToInt32(x), robot.PositionX, "Robot X coordinate - invalid re-initialization");
            Assert.AreEqual(Convert.ToInt32(y), robot.PositionY, "Robot Y coordinate - invalid re-initialization");
            Assert.AreEqual(Enum.Parse(typeof(DirectionEnum), direction), robot.Direction, "Robot direction should not change");
        }
    }
}
