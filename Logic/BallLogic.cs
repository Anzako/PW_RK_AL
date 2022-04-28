using Data;

namespace Logic
{
    public abstract class LogicApi
    {
        public abstract int MaxSpeed { get; set; }

        public abstract List<Ball> Balls { get; }
        public abstract Ball generateBall();

        public abstract Board? Board { get; }

        public abstract void createBalls(int amount);

        public abstract Board createBoard(int width, int height);

        public abstract void addBall(Ball ball);

        public abstract int getAmountOfBalls();

        public abstract void setRandomXVelocity(Ball ball, int x, int y);

        public abstract void setRandomYVelocity(Ball ball, int x, int y);

        public abstract void moveBall(Ball ball);

        public static LogicApi CreateLogicApi(int maxSpeed, int width, int height)
        {
           return new BallLogic(maxSpeed, width, height);
        }

    }
    internal class BallLogic : LogicApi
    {
        private Random _random = new Random();
        public override List<Ball> Balls { get; }
        public override Board? Board { get; }

        private DataAbstractApi DataL;

        public override int MaxSpeed
        {
            get { return MaxSpeed; }
            set { MaxSpeed = value; }
        }

        public BallLogic(int maxSpeed, int width, int height)
        {
            DataL = DataAbstractApi.CreateApi();
            MaxSpeed = maxSpeed;
            Balls = new List<Ball>();
            Board = createBoard(width, height);
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
            return new Ball(_random.Next(0, Board.Width), _random.Next(0, Board.Height));
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

            }
            else
            {
                ball.XPosition = ball.XPosition + ball.XVelocity;
            }

            if (ball.YPosition + ball.YVelocity < 0)
            {
                ball.YPosition = 0;
            }
            else if (ball.YPosition + ball.YVelocity > Board.Height)
            {
                ball.YPosition = Board.Height;
            }
            else
            {
                ball.YPosition = ball.YPosition + ball.YVelocity;
            }
        }
    }
}