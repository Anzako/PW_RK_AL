using NUnit.Framework;
using Logic;
using System.Collections;
using System.Threading;

namespace LogicTest
{
    public class Tests
    {
        private LogicAbstractApi _api;

        [SetUp]
        public void Setup()
        {
            _api = LogicAbstractApi.CreateLogicApi(800, 600);
        }

        [Test]
        public void ListTest()
        {
            Assert.IsInstanceOf<IList>(_api.createBalls(4));
            Assert.AreEqual(_api.GetCount, 4);
            Assert.AreEqual(_api.getAmountOfBalls(), 4);
        }

        [Test]
        public void GetterTest()
        {
            Assert.AreEqual(_api.Width, 800);
            Assert.AreEqual(_api.Height, 600);

            for (int i = 0; i < _api.getAmountOfBalls(); i++)
            {
                Assert.IsTrue(_api.GetPositionX(i) > 0);
                Assert.IsTrue(_api.GetPositionY(i) > 0);
                Assert.IsTrue(_api.GetPositionX(i) < _api.Width);
                Assert.IsTrue(_api.GetPositionY(i) > _api.Height);
            }
        }

        [Test]
        public void StartStopTest()
        {
            _api.createBalls(1);
            double X = _api.GetPositionX(0);
            double Y = _api.GetPositionY(0);

            _api.Start();
            Thread.Sleep(1000);
            _api.Stop();

            Assert.AreNotEqual(X, _api.GetPositionX(0));
            Assert.AreNotEqual(Y, _api.GetPositionY(0));
        }

    }
}