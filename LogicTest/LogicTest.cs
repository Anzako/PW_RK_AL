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
            Assert.AreEqual(8, _api.createBalls(4).Count);
        }

        [Test]
        public void BorderTest()
        {
            Assert.AreEqual(_api.Width, 800);
            Assert.AreEqual(_api.Height, 600);
        }

    }
}