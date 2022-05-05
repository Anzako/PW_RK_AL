using Data;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Logic
{
    public abstract class LogicApi
    {
        public abstract event EventHandler Update;
        public abstract int MaxSpeed { get; }
        public abstract List<Ball> Balls { get; }
        public abstract Ball generateBall();

        public abstract Board Board { get; }

        public abstract void createBalls(int amount);

        public abstract Board createBoard(int width, int height);

        public abstract void addBall(Ball ball);

        public abstract int getAmountOfBalls();

        public abstract void setRandomXVelocity(Ball ball, int x, int y);

        public abstract void setRandomYVelocity(Ball ball, int x, int y);

        public abstract void moveBall(Ball ball);

        public abstract Ball getBallFromList(int index);

        public abstract int getBallFromListXVAlue(int index);

        public abstract int getBallFromListYValue(int index);

        public abstract int getBoardWidth();

        public abstract int getBoardHeight();

        public abstract void updateBalls();
        public abstract void Start();
        public abstract void Stop();
        public abstract void SetInterval(int ms);
        public static LogicApi CreateLogicApi(int maxSpeed, int width, int height, TimerApi timer = default(TimerApi))
        {
            return new BallLogic(maxSpeed, width, height, timer ?? TimerApi.CreateBallTimer());
        }

    }
    internal class BallLogic : LogicApi
    {
        private readonly TimerApi timer;
        private Random _random = new Random();
        public override List<Ball> Balls { get; }
        public override Board Board { get; }

        private DataAbstractApi DataL;

        public override event EventHandler Update { add => timer.Tick += value; remove => timer.Tick -= value; }

        public override int MaxSpeed { get; }

        public BallLogic(int maxSpeed, int width, int height, TimerApi WPFTimer)
        {
            DataL = DataAbstractApi.CreateApi();
            MaxSpeed = maxSpeed;
            Balls = new List<Ball>();
            Board = createBoard(width, height);
            timer = WPFTimer;
            SetInterval(30);
            timer.Tick += (sender, args) => updateBalls();
        }

        public override void addBall(Ball ball)
        {
            Balls.Add(ball);
        }

        public override void createBalls(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                addBall(generateBall());
            }
        }

        public override Ball generateBall()
        {
            return new Ball(_random.Next(5, Board.Width - 25), _random.Next(5, Board.Height - 25));
        }

        public override Board createBoard(int width, int height)
        {
            return new Board(width, height);
        }

        public override int getAmountOfBalls()
        {
            return Balls.Count;
        }

        public override void setRandomXVelocity(Ball ball, int x, int y)
        {
            ball.XVelocity = _random.Next(x, y);
        }

        public override void setRandomYVelocity(Ball ball, int x, int y)
        {
            ball.YVelocity = _random.Next(x, y); ;
        }

        public override void moveBall(Ball ball)
        {
            if (ball.XPosition + ball.XVelocity < 0)
            {
                ball.XPosition = 0;
                setRandomXVelocity(ball, 0, MaxSpeed);
            }
            else if (ball.XPosition + ball.XVelocity > Board.Width)
            {
                ball.XPosition = Board.Width;
                setRandomXVelocity(ball, -MaxSpeed, 0);
            }
            else
            {
                ball.XPosition = ball.XPosition + ball.XVelocity;
            }

            if (ball.YPosition + ball.YVelocity < 0)
            {
                ball.YPosition = 0;
                setRandomYVelocity(ball, 0, MaxSpeed);
            }
            else if (ball.YPosition + ball.YVelocity > Board.Height)
            {
                ball.YPosition = Board.Height;
                setRandomYVelocity(ball, -MaxSpeed, 0);
            }
            else
            {
                ball.YPosition = ball.YPosition + ball.YVelocity;
            }
        }


        public override Ball getBallFromList(int index)
        {
            return Balls[index];
        }

        public override int getBoardWidth()
        {
            return Board.Width;
        }

        public override int getBoardHeight()
        {
            return Board.Height;
        }

        public override void updateBalls()
        {
            for (int i = 0; i < Balls.Count; i++)
            {
                moveBall(Balls[i]);
            }
        }

        public override int getBallFromListXVAlue(int index)
        {
            return Balls[index].XPosition;
        }

        public override int getBallFromListYValue(int index)
        {
            return Balls[index].YPosition;
        }

        public override void Start()
        {
            timer.Start();
        }

        public override void Stop()
        {
            timer.Stop();
        }

        public override void SetInterval(int ms)
        {
            timer.Interval = TimeSpan.FromMilliseconds(ms);
        }
    }
}