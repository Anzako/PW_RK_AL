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
            WallCollision(ball);
            BallBounce(ball);
            mutex.ReleaseMutex();
        }

        internal void WallCollision(IBall ball)
        {

            double diameter = ball.Radius;

            double right = Width - diameter;

            double down = Height - diameter;


            if (ball.XPosition <= 5)
            {
                ball.XVelocity *= -1;
            }
            else if (ball.XPosition >= right - 5)
            {
                ball.XVelocity *= -1;
            }

            if (ball.YPosition <= 5)
            {
                ball.YVelocity *= -1;
            }
            else if (ball.YPosition >= down - 5)
            {
                ball.YVelocity *= -1;
            }
        }

        internal double Distance(IBall a, IBall b)
        {
            double x1 = a.XPosition + a.Radius / 2 + a.XVelocity;
            double y1 = a.YPosition + a.Radius / 2 + a.YVelocity;
            double x2 = b.XPosition + b.Radius / 2 + b.XVelocity;
            double y2 = b.YPosition + b.Radius / 2 + b.YVelocity;

            return Math.Sqrt((Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2)));
        }
        internal bool Collision(IBall a, IBall b)
        {
            if (a == null || b == null)
            {
                return false;
            }

            return Distance(a, b) <= (a.Radius / 2 + b.Radius / 2);
        }

        internal void BallBounce(IBall ball)
        {
            for (int i = 0; i < DataApi.GetCount; i++)
            {
                IBall secondBall = DataApi.getBallFromList(i);
                if (ball == secondBall)
                {
                    continue;
                }

                if (Collision(ball, secondBall))
                {

                    double m1 = ball.Weight;
                    double m2 = secondBall.Weight;
                    double v1x = ball.XVelocity;
                    double v1y = ball.YVelocity;
                    double v2x = secondBall.XVelocity;
                    double v2y = secondBall.YVelocity;



                    double u1x = (m1 - m2) * v1x / (m1 + m2) + (2 * m2) * v2x / (m1 + m2);
                    double u1y = (m1 - m2) * v1y / (m1 + m2) + (2 * m2) * v2y / (m1 + m2);

                    double u2x = 2 * m1 * v1x / (m1 + m2) + (m2 - m1) * v2x / (m1 + m2);
                    double u2y = 2 * m1 * v1y / (m1 + m2) + (m2 - m1) * v2y / (m1 + m2);

                    ball.XVelocity = u1x;
                    ball.YVelocity = u1y;
                    secondBall.XVelocity = u2x;
                    secondBall.YVelocity = u2y;
                    return;

                }
            }
        }
    }
}