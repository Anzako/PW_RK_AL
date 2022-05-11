using NUnit.Framework;
using ViewModel;
using System;
using System.Diagnostics;
using Model;

namespace presentationTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Test1()
        {
            //Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            ModelAbstractApi abstractApi = ModelAbstractApi.CreateModelApi(10, 10, 10);
            //Console.WriteLine(abstractApi.height);
            //Assert.AreEqual(10, abstractApi.getWidth());

           // MainWindowViewModel viewModel = new MainWindowViewModel();
            //Console.WriteLine(viewModel.Height);
            //Assert.Equals(2000, viewModel.Height);
            //Assert.Pass();
        }
    }
}