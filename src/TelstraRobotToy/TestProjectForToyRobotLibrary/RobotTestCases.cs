using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using ToyRobotLibrary;
using ToyRobotLibrary.Interfaces;

namespace TestProjectForToyRobotLibrary
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        private void process(string[] inputCommands, List<string> expected)
        {
            List<string> actual = new List<string>();

            IRobot maxRobot = new ToyRobot();


            foreach (var instruction in inputCommands)
            {
                var result = maxRobot.Execute(instruction);
                actual.Add(result.CommandAction);
            }
            Assert.AreEqual(expected, actual);
        }

        /*
         a) PLACE 0,0,NORTH
            MOVE
            REPORT
            Output: 0,1,NORTH
        */
        [Test]
        public void Test_A()
        {
            string[] inputCommands = new string[] {"PLACE 0,0,NORTH",
                                            "MOVE",
                                            "REPORT"};

            int expectedX = 0, expectedY = 1; DIRECTION expectedDirection = DIRECTION.NORTH;

            List<string> expected = new List<string>()
                                {
                                    ROBOTRESPONSE.COMMAND_EXECUTED,
                                    ROBOTRESPONSE.COMMAND_EXECUTED,
                                    string.Format(ROBOTRESPONSE.REPORT_RESPONSE_FORMAT, expectedX, expectedY, expectedDirection.ToString())
                                };

            process(inputCommands, expected);
        }

        /*
        b)
        PLACE 0,0,NORTH
        LEFT
        REPORT
        Output: 0,0,WEST
        */
        [Test]
        public void Test_B()
        {
            string[] inputCommands = new string[] {"PLACE 0,0,NORTH",
                                            "LEFT",
                                            "REPORT"};

            int expectedX = 0, expectedY = 0; DIRECTION expectedDirection = DIRECTION.WEST;

            List<string> expected = new List<string>()
                                {
                                    ROBOTRESPONSE.COMMAND_EXECUTED,
                                    ROBOTRESPONSE.COMMAND_EXECUTED,
                                    string.Format(ROBOTRESPONSE.REPORT_RESPONSE_FORMAT, expectedX, expectedY, expectedDirection.ToString())
                                };

            process(inputCommands, expected);

        }

        /*c)
        PLACE 1,2,EAST
        MOVE
        MOVE
        LEFT
        MOVE
        REPORT
        Output: 3,3,NORTH
        */
        [Test]
        public void Test_C()
        {
            string[] inputCommands = new string[] {
                                            "PLACE 1,2,EAST",
                                            "MOVE",
                                            "MOVE",
                                            "LEFT",
                                            "MOVE",
                                            "REPORT"};

            int expectedX = 3, expectedY = 3; DIRECTION expectedDirection = DIRECTION.NORTH;

            List<string> expected = new List<string>()
                                {
                                    ROBOTRESPONSE.COMMAND_EXECUTED,
                                    ROBOTRESPONSE.COMMAND_EXECUTED,
                                    ROBOTRESPONSE.COMMAND_EXECUTED,
                                    ROBOTRESPONSE.COMMAND_EXECUTED,
                                    ROBOTRESPONSE.COMMAND_EXECUTED,
                                    string.Format(ROBOTRESPONSE.REPORT_RESPONSE_FORMAT, expectedX, expectedY, expectedDirection.ToString())
                                };

            process(inputCommands, expected);

        }

        /*
        d)
        PLACE 1,2,EAST
        MOVE
        LEFT
        MOVE
        PLACE 3,1
        MOVE
        REPORT
        Output: 3,2,NORTH
        */
        [Test]
        public void Test_D()
        {
            string[] inputCommands = new string[] {"PLACE 1,2,EAST",
                                            "MOVE",
                                            "LEFT",
                                            "MOVE",
                                            "PLACE 3,1",
                                            "MOVE",
                                            "REPORT"};

            int expectedX = 3, expectedY = 2; DIRECTION expectedDirection = DIRECTION.NORTH;

            List<string> expected = new List<string>()
                                {
                                    ROBOTRESPONSE.COMMAND_EXECUTED,
                                    ROBOTRESPONSE.COMMAND_EXECUTED,
                                    ROBOTRESPONSE.COMMAND_EXECUTED,
                                    ROBOTRESPONSE.COMMAND_EXECUTED,
                                    ROBOTRESPONSE.COMMAND_EXECUTED,
                                    ROBOTRESPONSE.COMMAND_EXECUTED,
                                    string.Format(ROBOTRESPONSE.REPORT_RESPONSE_FORMAT, expectedX, expectedY, expectedDirection.ToString())
                                };
            process(inputCommands, expected);
        }

        [Test]

        public void Test_E()
        {
            string[] inputCommands = new string[] {"PLACE 22,2,EAST",
                                                    "PLACE 2,2,RWEWE",
                                                    "PLACE 2,2,NORTH",
                                                    "fsafasfasf",

                                            };

            int expectedX = 3, expectedY = 2; DIRECTION expectedDirection = DIRECTION.NORTH;

            List<string> expected = new List<string>()
                                {
                                    ROBOTRESPONSE.INVALID_POISITION_RESPONSE,
                                    ROBOTRESPONSE.INVALID_COMMAND_RESPONSE,
                                    ROBOTRESPONSE.COMMAND_EXECUTED,
                                    ROBOTRESPONSE.INVALID_COMMAND_RESPONSE
                                };
            process(inputCommands, expected);
        }

        /*
         Robot Not Placed

         */
        [Test]
        public void Test_RobotNotPlaced()
        {
            string[] inputCommands = new string[] {
                                            "MOVE",
                                            "PLACE 1,2,EAST",
                                            "MOVE",
                                            "LEFT",
                                            "MOVE",
                                            "PLACE 3,1",
                                            "MOVE",
                                            "REPORT"};

            int expectedX = 3, expectedY = 2; DIRECTION expectedDirection = DIRECTION.NORTH;

            List<string> expected = new List<string>()
                                {
                                    ROBOTRESPONSE.ROBOT_NOT_PLACED_RESPONSE,
                                    ROBOTRESPONSE.COMMAND_EXECUTED,
                                    ROBOTRESPONSE.COMMAND_EXECUTED,
                                    ROBOTRESPONSE.COMMAND_EXECUTED,
                                    ROBOTRESPONSE.COMMAND_EXECUTED,
                                    ROBOTRESPONSE.COMMAND_EXECUTED,
                                    ROBOTRESPONSE.COMMAND_EXECUTED,
                                    string.Format(ROBOTRESPONSE.REPORT_RESPONSE_FORMAT, expectedX, expectedY, expectedDirection.ToString())
                                };

            process(inputCommands, expected);

        }

        /*
       Invalid Command

       */
        [Test]
        public void Test_InvalidCommand()
        {
            string[] inputCommands = new string[] {
                                            "MOVE",
                                            "place 1,2,EAST",
                                            "PLACE 1,2,EAST",
                                            "MOVE",
                                            "LEFT",
                                            "MOVE",
                                            "",
                                            "PLACE 3,1",
                                            "MOVE",
                                            "REPORT"};

            int expectedX = 3, expectedY = 2; DIRECTION expectedDirection = DIRECTION.NORTH;

            List<string> expected = new List<string>()
                                {
                                    ROBOTRESPONSE.ROBOT_NOT_PLACED_RESPONSE,
                                    ROBOTRESPONSE.COMMAND_EXECUTED,
                                    ROBOTRESPONSE.COMMAND_EXECUTED,
                                    ROBOTRESPONSE.COMMAND_EXECUTED,
                                    ROBOTRESPONSE.COMMAND_EXECUTED,
                                    ROBOTRESPONSE.COMMAND_EXECUTED,
                                    ROBOTRESPONSE.INVALID_COMMAND_RESPONSE,
                                    ROBOTRESPONSE.COMMAND_EXECUTED,
                                    ROBOTRESPONSE.COMMAND_EXECUTED,
                                    string.Format(ROBOTRESPONSE.REPORT_RESPONSE_FORMAT, expectedX, expectedY, expectedDirection.ToString())
                                };

            process(inputCommands, expected);

        }


        /*
      Invalid Position

      */
        [Test]
        public void Test_InvalidPosition()
        {
            string[] inputCommands = new string[] {
                                            "MOVE",
                                            "place 1,2,EAST",
                                            "PLACE 1,2,EAST",
                                            "LEFT",
                                            "LEFT",
                                            "MOVE",
                                            "MOVE",
                                            "MOVE",
                                            "RIGHT",
                                            "RIGHT",
                                            "MOVE",
                                            "MOVE",
                                            "LEFT",
                                            "MOVE",
                                            "",
                                            "PLACE 3,1",
                                            "MOVE",
                                            "REPORT"};

            int expectedX = 3, expectedY = 2; DIRECTION expectedDirection = DIRECTION.NORTH;

            List<string> expected = new List<string>()
                                {
                                    ROBOTRESPONSE.ROBOT_NOT_PLACED_RESPONSE,
                                    ROBOTRESPONSE.COMMAND_EXECUTED,
                                    ROBOTRESPONSE.COMMAND_EXECUTED,
                                    ROBOTRESPONSE.COMMAND_EXECUTED,
                                    ROBOTRESPONSE.COMMAND_EXECUTED,
                                    ROBOTRESPONSE.COMMAND_EXECUTED,
                                    ROBOTRESPONSE.INVALID_POISITION_RESPONSE,
                                    ROBOTRESPONSE.INVALID_POISITION_RESPONSE,
                                    ROBOTRESPONSE.COMMAND_EXECUTED,
                                    ROBOTRESPONSE.COMMAND_EXECUTED,
                                    ROBOTRESPONSE.COMMAND_EXECUTED,
                                    ROBOTRESPONSE.COMMAND_EXECUTED,
                                    ROBOTRESPONSE.COMMAND_EXECUTED,
                                    ROBOTRESPONSE.COMMAND_EXECUTED,
                                    ROBOTRESPONSE.INVALID_COMMAND_RESPONSE,
                                    ROBOTRESPONSE.COMMAND_EXECUTED,
                                    ROBOTRESPONSE.COMMAND_EXECUTED,
                                    string.Format(ROBOTRESPONSE.REPORT_RESPONSE_FORMAT, expectedX, expectedY, expectedDirection.ToString())
                                };

            process(inputCommands, expected);

        }
    }
}