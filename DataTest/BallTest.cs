using NUnit.Framework;
using System.Numerics;

namespace Data.DataTest
{
    public class BallTest
    {
        private Ball testingBall1;
        private Ball testingBall2;
        private ListBall list;

        [SetUp]
        public void Setup()
        {
            testingBall1 = new Ball(new Vector2(0, 0));
            testingBall2 = new Ball(new Vector2(1, 0));
            list = new ListBall();
        }

        [Test]
        public void TestBall()
        {
            Assert.AreEqual(new Vector2(0, 0), testingBall1.GetPosition());
            testingBall1.SetPosition(new Vector2(2, 2));
            Assert.AreEqual(new Vector2(2, 2), testingBall1.GetPosition());
        }

        [Test]
        public void TestList()
        {
            Assert.AreEqual(0, list.Count());
            list.Add(testingBall1);
            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(testingBall1, list.Get(0));
        }
    }
}