using Data;
using System;
using System.Collections;
using System.ComponentModel;
using System.Threading;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Logic
{
    public abstract class LogicAbstractApi
    {
        public abstract int Width { get; }
        public abstract int Height { get; }
        public abstract IList createBalls(int amount);
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
        private ObservableCollection<IBall> balls { get; }
        private readonly ConcurrentQueue<IBall> queue;
  
        public override int Width { get; }
        public override int Height { get; }
      
       

        public BallLogic(int width, int height)
        {
            DataApi = DataAbstractApi.CreateApi(width, height);
            Width = width;
            Height = height;
            balls = new ObservableCollection<IBall>();
            queue = new ConcurrentQueue<IBall>();
        }

        public override void Start()
        {
            for (int i = 0; i < balls.Count; i++)
            {
                balls[i].PropertyChanged += BallPositionChanged;
                balls[i].CreateMovementTask(30, queue);
            }
            DataApi.CreateLoggingTask(queue);
        }

        public override void Stop()
        {
            for (int i = 0; i < balls.Count; i++)
            {
                balls[i].Stop();
                balls[i].PropertyChanged -= BallPositionChanged;
            }
        }

        public override IList createBalls(int amount)
        {
            int actualNumberOfBalls = balls.Count;

            for (int i = actualNumberOfBalls; i < actualNumberOfBalls + amount; i++)
            {
                balls.Add(DataApi.CreateBall());
            }
            return balls;
        }

        public void BallPositionChanged(object sender, PropertyChangedEventArgs args)
        {
            IBall ball = (IBall)sender;
            WallCollision(ball);
            BallBounce(ball);
        }

        internal void WallCollision(IBall ball)
        {
            double diameter = ball.Radius;
            double right = Width - diameter;
            double down = Height - diameter;

            if (ball.XPosition <= 5)
            { 
                if (ball.XVelocity <= 0)
                {
                    ball.changeVelocity(-ball.XVelocity, ball.YVelocity);
                }
            }
            else if (ball.XPosition >= right - 5)
            {
                if (ball.XVelocity > 0)
                {
                    ball.changeVelocity(-ball.XVelocity, ball.YVelocity);
                }     
            }

            if (ball.YPosition <= 5)
            {
                if (ball.YVelocity <= 0)
                {
                    ball.changeVelocity(ball.XVelocity, -ball.YVelocity);
                }   
            }
            else if (ball.YPosition >= down - 5)
            {
                if (ball.YVelocity > 0)
                {
                    ball.changeVelocity(ball.XVelocity, -ball.YVelocity);
                }
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
            lock (ball)
            {
                for (int i = 0; i < balls.Count; i++)
                {
                    IBall secondBall = balls[i];
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

                        ball.changeVelocity(u1x, u1y);
                        secondBall.changeVelocity(u2x, u2y);
                        
                        return;

                    }
                }
            }
            
        }
    }
}