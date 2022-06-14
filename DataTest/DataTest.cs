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
using System.Collections.Concurrent;

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

        [Test]
        public void CreateApiTest()
        {
            Assert.IsNotNull(_api);
        }


        [Test]
        public void BallTest()
        {
            Ball testBall = new Ball(50,50,20,20,30,30);
            Assert.IsInstanceOf<Ball>(testBall);
            Assert.AreEqual(testBall.XPosition, 50);
            Assert.AreEqual(testBall.YPosition, 50);

            Assert.AreEqual(testBall.XVelocity, 20);
            Assert.AreEqual(testBall.YVelocity, 20);

            Assert.AreEqual(testBall.Radius, 30);
            Assert.AreEqual(testBall.Weight, 30);
        }

        [Test]
        public void BoardTest()
        {
            Assert.AreEqual(_api.getBoardWidth(), 800);
            Assert.AreEqual(_api.getBoardHeight(), 600);
        }

        [Test]
        public void changeVelocityTest()
        {
            Ball testBall = new Ball(50, 50, 20, 20, 30, 30);
            testBall.changeVelocity(10, 10);
            Assert.AreEqual(testBall.XVelocity, 10);
            Assert.AreEqual(testBall.YVelocity, 10);
        }
    }
}