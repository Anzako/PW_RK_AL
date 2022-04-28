using Data;

namespace Logic
{
    public class BallLogic : DataAbstractApi
    {
        private Board _board = createBoard(100, 100);
        private List<Ball> balls = new List<Ball>();
        Random random = new Random();
        int maxSpeed = 3;
        public Ball generateBall()
        {
            return createBall(random.Next(0, _board.Width), random.Next(0, _board.Height));
        }

        public void addBall(Ball ball)
        {
            balls.Add(ball);
        }

        public Ball getBall(int index)
        {
            return balls[index];
        }

        public int getAmountOfBalls()
        {
            return balls.Count;
        }

        public void createBalls(int amount)
        {
            for(int i = 0; i < amount; i++)
            {
                addBall(generateBall());
            }
        }

        public void setRandomXVelocity(Ball ball, int x, int y)
        {
            ball.XVelocity = random.Next(x, y);
        }

        public void setRandomYVelocity(Ball ball, int x, int y)
        {
            ball.YVelocity = random.Next(x, y);
        }

        public void moveBall(Ball ball)
        {
            if (ball.XPosition + ball.XVelocity < 0)
            {
                ball.XPosition = 0;
                setRandomXVelocity(ball, 0, maxSpeed);
            } else if(ball.XPosition + ball.XVelocity > _board.Width)
            {
                ball.XPosition = _board.Width;

            } else
            {
                ball.XPosition = ball.XPosition + ball.XVelocity;
            }

            if (ball.YPosition + ball.YVelocity < 0)
            {
                ball.YPosition = 0;
            }
            else if (ball.YPosition + ball.YVelocity > _board.Height)
            {
                ball.YPosition = _board.Height;
            } else
            {
                ball.YPosition = ball.YPosition + ball.YVelocity;
            }
        }
    }
}