using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Board
    {
        private int _width { get;}
        private int _height { get;}

        public Board(int width, int height)
        {
            this._width = width;
            this._height = height;
        }
    }
}
