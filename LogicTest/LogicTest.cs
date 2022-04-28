using NUnit.Framework;
using Logic;
using Data;


namespace LogicTest
{
    public class Tests
    {

        LogicApi LogicLayerTest;

        [SetUp]
        public void Setup()
        {
            LogicLayerTest = LogicApi.CreateLogicApi(30, 1280, 720);
        }

        [Test]
        public void generateBallTest()
        {
            var ballTest =  LogicLayerTest.generateBall();
            Assert.IsInstanceOf<Ball>(ballTest);
        }

        [Test]
        public void createBallsTest()
        {
            LogicLayerTest.createBalls(3);
            Assert.AreEqual(3, LogicLayerTest.getAmountOfBalls());

            Assert.IsTrue(LogicLayerTest.getBallFromList(0).XPosition >= 0);
            Assert.IsTrue(LogicLayerTest.getBallFromList(0).XPosition <= LogicLayerTest.getBoardWidth());
            Assert.IsTrue(LogicLayerTest.getBallFromList(0).YPosition >= 0);
            Assert.IsTrue(LogicLayerTest.getBallFromList(0).YPosition <= LogicLayerTest.getBoardHeight());

            Assert.IsTrue(LogicLayerTest.getBallFromList(1).XPosition >= 0);
            Assert.IsTrue(LogicLayerTest.getBallFromList(1).XPosition <= LogicLayerTest.getBoardWidth());
            Assert.IsTrue(LogicLayerTest.getBallFromList(1).YPosition >= 0);
            Assert.IsTrue(LogicLayerTest.getBallFromList(1).YPosition <= LogicLayerTest.getBoardHeight());

            Assert.IsTrue(LogicLayerTest.getBallFromList(2).XPosition >= 0);
            Assert.IsTrue(LogicLayerTest.getBallFromList(2).XPosition <= LogicLayerTest.getBoardWidth());
            Assert.IsTrue(LogicLayerTest.getBallFromList(2).YPosition >= 0);
            Assert.IsTrue(LogicLayerTest.getBallFromList(2).YPosition <= LogicLayerTest.getBoardHeight());

        }
    }
}