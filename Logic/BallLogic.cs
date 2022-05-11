using Data;
using System;
using System.Collections.Generic;

namespace Logic
{
    public abstract class LogicApi
    {

        public abstract event EventHandler Update;
        public abstract event EventHandler<int> CollisionXEvent;
        public abstract event EventHandler<int> CollisionYEvent;
        public abstract int MaxSpeed { get; }
        public abstract Ball generateBall();
        public abstract int Width { get; }
        public abstract int Height { get; }

        public abstract void createBalls(int amount);
        public abstract void addBall(Ball ball);
        public abstract int getAmountOfBalls();
        public abstract Ball getBall(int indeks);
        public abstract void moveBall(int indeks);
        public abstract void updateBalls();
        public abstract void Start();
        public abstract void Stop();
        public abstract void SetInterval(int ms);
        public static LogicApi CreateLogicApi(int maxSpeed, int width, int height, TimerApi timer = default(TimerApi))
        {
            return new BallLogic(maxSpeed, width, height, timer ?? TimerApi.CreateBallTimer());
        }
        public abstract void changeXDirection(object sender, int indeks);
        public abstract void changeYDirection(object sender, int indeks);

    }
    internal class BallLogic : LogicApi
    {
        private readonly TimerApi timer;
        private DataAbstractApi DataApi;  

        public override event EventHandler Update { add => timer.Tick += value; remove => timer.Tick -= value; }
        public override event EventHandler<int> CollisionXEvent;
        public override event EventHandler<int> CollisionYEvent;
        public override int MaxSpeed { get; }

        public override int Width
        {
            get{ return DataApi.getBoardWidth(); }
        }

        public override int Height
        {
            get{ return DataApi.getBoardHeight(); }
        }

        public override Ball getBall(int indeks)
        {
            return DataApi.getBallFromList(indeks);
        }

        public BallLogic(int maxSpeed, int width, int height, TimerApi WPFTimer)
        {
            DataApi = DataAbstractApi.CreateApi(width, height);
            MaxSpeed = maxSpeed;
            timer = WPFTimer;
            SetInterval(10);
            timer.Tick += (sender, args) => updateBalls();
        }

        public override void addBall(Ball ball)
        {
            DataApi.addBall(ball);
        }
        
        public override Ball generateBall()
        {
            return DataApi.generate();
        }
        public override void createBalls(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                addBall(generateBall());
            }
        }

        public override int getAmountOfBalls()
        {
            return DataApi.getAmount();
        }
        
        public override void changeXDirection(object sender, int i)
        {
            getBall(i).XVelocity = -getBall(i).XVelocity;
        }
        public override void changeYDirection(object sender, int i)
        {
            getBall(i).YVelocity = -getBall(i).YVelocity;
        }
        
        public override void moveBall(int indeks)
        {
            if (getBall(indeks).XPosition + getBall(indeks).XVelocity < 5)
            {
                getBall(indeks).XPosition = 5;
                CollisionXEvent?.Invoke(this, indeks);
            }
            else if (getBall(indeks).XPosition + getBall(indeks).XVelocity > Width - 25)
            {
                getBall(indeks).XPosition = Width - 25;
                CollisionXEvent?.Invoke(this, indeks);
            }
            else
            {
                getBall(indeks).XPosition += getBall(indeks).XVelocity;
            }

            if (getBall(indeks).YPosition + getBall(indeks).YVelocity < 5)
            {
                getBall(indeks).YPosition = 5;
                CollisionYEvent?.Invoke(this, indeks);
            }
            else if (getBall(indeks).YPosition + getBall(indeks).YVelocity > DataApi.getBoardHeight() - 25)
            {
                getBall(indeks).YPosition = DataApi.getBoardHeight() - 25;
                CollisionYEvent?.Invoke(this, indeks);
            }
            else
            {
                getBall(indeks).YPosition += getBall(indeks).YVelocity;
            }
            
        }
        
        public override void updateBalls()
        {
            for (int i = 0; i < getAmountOfBalls(); i++)
            {
                moveBall(i);
            }
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