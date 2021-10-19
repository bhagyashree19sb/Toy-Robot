using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ToyRobot.BL.Tests
{
    [TestClass]
    public class ToyRobotTests
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
        public void ToyRobot_NoCommand_Pass()
        {
            var result = robot.ExecuteCommand("");

            Assert.IsNull(result, "Result is not null when no command is entered");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ToyRobot_InvalidCommand_Fail()
        {
            robot.ExecuteCommand("Test");
        }
    }
}
