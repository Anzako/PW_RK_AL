using Data;
using System;
using System.Collections;
using System.ComponentModel;
using System.Threading;

namespace Logic
{
    public abstract class LogicAbstractApi
    {
        public abstract int Width { get; }
        public abstract int Height { get; }
        public abstract double GetPositionX(int i);
        public abstract double GetPositionY(int i);
        public abstract IBall createBalls(int amount);
        public abstract int getAmountOfBalls();
        public abstract void Start();
        public abstract void Stop();
        
        public static LogicAbstractApi CreateLogicApi(int width, int height)
        {
            return new BallLogic(width, height);
        }
    }
    internal class BallLogic : LogicAbstractApi
    {
        private DataAbstractApi DataApi;
        private readonly Mutex mutex = new Mutex();

        public override int Width
        {
            get { return DataApi.getBoardWidth(); }
        }

        public override int Height
        {
            get { return DataApi.getBoardHeight(); }
        }

        public BallLogic(int width, int height)
        {
            DataApi = DataAbstractApi.CreateApi(width, height);
        }
        public override int getAmountOfBalls()
        {
            return DataApi.getAmount();
        }

  

        public override void Start()
        {
            for (int i = 0; i < dataApi.GetCount; i++)
            {
                dataApi.GetBall(i).CreateMovementTask(30);
            }
        }

        public override void Stop()
        {
            timer.Stop();
        }

   
    }
}