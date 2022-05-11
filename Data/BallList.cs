using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    internal class BallList
    {
        private List<Ball> listOfBalls;
        private Random _random = new Random();
        public BallList() 
        {
            listOfBalls = new List<Ball>();
        }

        public void addBall(Ball ball)
        {
            listOfBalls.Add(ball);
        }

        public Ball generateBall(int width, int height)
        {
            return new Ball(_random.Next(5, width - 25), _random.Next(5, height - 25));
        }
        
        public Ball getBall(int indeks)
        {
            return listOfBalls[indeks];
        }
        
        public int getAmount()
        {
            return listOfBalls.Count;
        }
    }
}
