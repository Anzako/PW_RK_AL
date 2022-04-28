using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class DataAbstractApi
    {
        public static Ball createBall(float x, float y)
        {
            return new Ball(x, y);
        }

        public static Board createBoard(int w, int h)
        {
            return new Board(w, h);
        }



    }
}
