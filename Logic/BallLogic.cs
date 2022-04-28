using Data;

namespace Logic
{
    public class BallLogic : DataAbstractApi
    {
        private Board _board = createBoard(20, 20);
        private List<Ball> balls = new List<Ball>();
        Random random = new Random();

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
    }
}