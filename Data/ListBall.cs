using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ListBall
    {
        private readonly List<Ball> ballList;

        public ListBall()
        {
            this.ballList = new List<Ball>();
        }

        public void Add(Ball ball)
        {
            ballList.Add(ball);
        }

        public Ball Get(int i)
        {
            return ballList[i];
        }

        public int Count()
        {
            return ballList.Count;
        }

    }
}
