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
            return createBall(random.Next(0, _board.getWidth()), random.Next(0, _board.getHeight()));
        }

        public void addBall(Ball ball)
        {
            balls.Add(ball);
        }

        public Ball GetBall(int index)
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