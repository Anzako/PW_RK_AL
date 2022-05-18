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
        public abstract IList createBalls(int amount);
        public abstract int getAmountOfBalls();
        public abstract int GetCount { get; }
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

        public override int GetCount { get => DataApi.GetCount; }

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
            for (int i = 0; i < DataApi.GetCount; i++)
            {
                DataApi.getBallFromList(i).CreateMovementTask(30);
            }
        }

        public override void Stop()
        {
            for (int i = 0; i < DataApi.GetCount; i++)
            {
                DataApi.getBallFromList(i).Stop();

            }
        }

        public override double GetPositionX(int i)
        {
            return DataApi.GetPositionX(i);
        }

        public override double GetPositionY(int i)
        {
            return DataApi.GetPositionY(i);
        }

        public override IList createBalls(int amount)
        {
            int previousCount = DataApi.GetCount;
            IList temp = DataApi.CreateBallsList(amount);
            for (int i = 0; i < DataApi.GetCount - previousCount; i++)
            {
                DataApi.getBallFromList(previousCount + i).PropertyChanged += BallPositionChanged;
            }
            return temp;
        }

        public void BallPositionChanged(object sender, PropertyChangedEventArgs args)
        {
            IBall ball = (IBall)sender;
            mutex.WaitOne();
            //WallCollision(ball);
            //BallBounce(ball);
            //WallCollision(ball);
            mutex.ReleaseMutex();
        }
    }
}