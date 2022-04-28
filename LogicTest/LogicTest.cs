using NUnit.Framework;
using Logic;
using Data;

namespace LogicTest
{
    public class Tests
    {
        BallLogic ballLogic;
        

        [SetUp]
        public void Setup()
        {
            ballLogic = new BallLogic();
        }

        [Test]
        public void generateBallTest()
        {
            Ball generatedBall = ballLogic.generateBall();
            Assert.IsInstanceOf<Ball>(generatedBall);
        }

        [Test]
        public void createBallsTest()
        {
            ballLogic.createBalls(3);
            Assert.AreEqual(3, ballLogic.getAmountOfBalls());
        }

        [Test]
        public void getBallTest()
        {
            ballLogic.createBalls(1);
            Assert.IsInstanceOf<Ball>(ballLogic.getBall(0));
        }

        [Test]
        public void checkValues()
        {
            ballLogic.createBalls(4);

            Assert.IsTrue(ballLogic.getBall(0).XPosition <= ballLogic.Board.Width);
            Assert.IsTrue(ballLogic.getBall(0).XPosition >= 0);
            Assert.IsTrue(ballLogic.getBall(0).YPosition <= ballLogic.Board.Height);
            Assert.IsTrue(ballLogic.getBall(0).YPosition >= 0);

            Assert.IsTrue(ballLogic.getBall(1).XPosition <= ballLogic.Board.Width);
            Assert.IsTrue(ballLogic.getBall(1).XPosition >= 0);
            Assert.IsTrue(ballLogic.getBall(1).YPosition <= ballLogic.Board.Height);
            Assert.IsTrue(ballLogic.getBall(1).YPosition >= 0);

            Assert.IsTrue(ballLogic.getBall(2).XPosition <= ballLogic.Board.Width);
            Assert.IsTrue(ballLogic.getBall(2).XPosition >= 0);
            Assert.IsTrue(ballLogic.getBall(2).YPosition <= ballLogic.Board.Height);
            Assert.IsTrue(ballLogic.getBall(2).YPosition >= 0);

            Assert.IsTrue(ballLogic.getBall(3).XPosition <= ballLogic.Board.Width);
            Assert.IsTrue(ballLogic.getBall(3).XPosition >= 0);
            Assert.IsTrue(ballLogic.getBall(3).YPosition <= ballLogic.Board.Height);
            Assert.IsTrue(ballLogic.getBall(3).YPosition >= 0);
        }
    }
}