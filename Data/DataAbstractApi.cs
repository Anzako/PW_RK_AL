using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Threading;
namespace Data
{
    public abstract class DataAbstractApi
    {
        public static DataAbstractApi CreateApi(int width, int height)
        {
            return new DataApi(width, height);
        }
        public abstract double GetRadius(int i);
        public abstract double GetWeight(int i);
        public abstract double GetPositionX(int i);
        public abstract double GetPositionY(int i);
        public abstract double GetVelocityX(int i);
        public abstract double GetVelocityY(int i);
        public abstract void SetVelocityX(int i, double value);
        public abstract void SetVelocityY(int i, double value);
        public abstract int getBoardWidth();
        public abstract int getBoardHeight();
        public abstract int getAmount();
        public abstract int GetCount { get; }
        public abstract IBall getBallFromList(int indeks);
        public abstract IList CreateBallsList(int count);
    }
    internal class DataApi : DataAbstractApi
    {
        private readonly Mutex mutex = new Mutex();
        private readonly Random random = new Random();
        private Board board;
        private ObservableCollection<IBall> ballList { get; }
        public DataApi(int width, int height)
        {
            ballList = new ObservableCollection<IBall>();
            board = new Board(width, height);
        }
        public ObservableCollection<IBall> Balls => ballList;
        public override double GetRadius(int i)
        {
            return ballList[i].Radius;
        }
        public override double GetWeight(int i)
        {
            return ballList[i].Weight;
        }
        public override int getBoardWidth()
        {
            return board.Width;
        }

        public override int getBoardHeight()
        {
            return board.Height;
        }

        public override IBall getBallFromList(int indeks)
        {
            return ballList[indeks];
        }
        public override int GetCount { get => ballList.Count; }
        public override int getAmount()
        {
            return ballList.Count;
        }

        public override double GetPositionX(int i)
        {
            return ballList[i].XPosition;
        }

        public override double GetPositionY(int i)
        {
            return ballList[i].YPosition;
        }

        public override double GetVelocityX(int i)
        {
            return ballList[i].XVelocity;
        }

        public override double GetVelocityY(int i)
        {
            return ballList[i].YVelocity;
        }

        public override void SetVelocityX(int i, double value)
        {
            ballList[i].XVelocity = value;
        }

        public override void SetVelocityY(int i, double value)
        {
            ballList[i].YVelocity = value;
        }

        public override IList CreateBallsList(int count)
        {
            for (int i = 0; i < count; i++)
            {
                mutex.WaitOne();
                int radius = random.Next(20, 40);
                double weight = random.Next(30, 60);
                double x = random.Next(5, getBoardWidth() - radius - 5);
                double y = random.Next(5, getBoardHeight() - radius - 5);
                double VX = random.Next(-10, 10);
                double VY = random.Next(-10, 10);
                Ball ball = new Ball(x, y, VX, VY, radius, weight);

                ballList.Add(ball);
                mutex.ReleaseMutex();
            }
            return ballList;
        }
    }
}
