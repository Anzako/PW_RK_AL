using NUnit.Framework;
using Data;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Runtime.Serialization;
using System.Timers;
using System.Threading.Tasks;

namespace DataTest
{
    public class Tests
    {
        private DataAbstractApi _api;

        [SetUp]
        public void Setup()
        {
            _api = DataAbstractApi.CreateApi(800, 600);
        }
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("DUPA");
            throw new NotImplementedException();
        }
        [Test]
        public void BallTest()
        {
            Timer timer = new Timer(5);
            timer.Elapsed += OnTimedEvent;
            timer.Enabled = true;
            timer.AutoReset = true; 
            timer.Start();
            int delat = 0;

            Ball testBall = new Ball(50,50,20,20,30,30);
            Assert.IsInstanceOf<Ball>(testBall);
            Assert.AreEqual(testBall.XPosition, 50);
            Assert.AreEqual(testBall.YPosition, 50);

            Assert.AreEqual(testBall.XVelocity, 20);
            Assert.AreEqual(testBall.YVelocity, 20);

            Assert.AreEqual(testBall.Radius, 30);
            Assert.AreEqual(testBall.Weight, 30);
            /*
            testBall.Move();
            for(int i = 0; i < 100; i++)
            {
                delat++;
            }

            Assert.AreEqual(testBall.XPosition, 70);
            Assert.AreEqual(testBall.YPosition, 70);
            */
            
            Console.WriteLine("Press key");
        }

        [Test]
        public void BoardTest()
        {
            Assert.AreEqual(_api.getBoardWidth(), 800);
            Assert.AreEqual(_api.getBoardHeight(), 600);
        }
        /*
        [Test]
        public void BallsListTest()
        {
            Assert.IsInstanceOf<IList>(_api.CreateBallsList(4));
            Assert.AreEqual(_api.GetCount, 4);
            Assert.IsInstanceOf<Ball>(_api.getBallFromList(0));
        }

        [Test]
        public void GetterSEtterTest()
        {
            _api.CreateBallsList(1);
            Assert.AreEqual(_api.GetCount, 1);


            Assert.IsTrue(_api.GetPositionY(0) < _api.getBoardHeight());
            Assert.IsTrue(_api.GetPositionX(0) < _api.getBoardWidth());
            Assert.IsTrue(_api.GetPositionY(0) > 0);
            Assert.IsTrue(_api.GetPositionX(0) > 0);

            Assert.IsTrue(_api.GetRadius(0) > 0);
            Assert.IsTrue(_api.GetWeight(0) > 0);


            _api.SetVelocityX(0, 30);
            _api.SetVelocityY(0, 50);
            Assert.IsTrue(_api.GetVelocityX(0) == 30);
            Assert.IsTrue(_api.GetVelocityY(0) == 50);
        }
        */
    }
}