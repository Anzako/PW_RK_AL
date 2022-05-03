using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class Board
    {
        private int _width;
        private int _height;

        public Board(int width, int height)
        {
            _width = width;
            _height = height;
        }

        public int Width
        {
            get { return _width; }
        }
        public int Height
        {
            get
            { return _height; }
        }
    }
}
