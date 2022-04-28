using NUnit.Framework;
using Logic;
using Data;

namespace LogicTest
{
    public class Tests
    {
        BallLogic ballLogic;
        Board board;

        [SetUp]
        public void Setup()
        {
            ballLogic = new BallLogic();
            board = new Board(20, 20);
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
    }
}