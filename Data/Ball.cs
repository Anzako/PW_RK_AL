using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class Ball
    {
        private int _xPosition;
        private int _yPosition;
        private int _xVelocity;
        private int _yVelocity;

        public Ball(int xPosition, int yPosition)
        {
            _xPosition = xPosition;
            _yPosition = yPosition;
            _xVelocity = 2;
            _yVelocity = 2;
        }

        public int XPosition
        {
            get { return _xPosition; }
            set { _xPosition = value; }
        }

        public int YPosition
        {
            get { return _yPosition; }
            set { _yPosition = value; }
        }

        public int XVelocity
        {
            get { return _xVelocity; }
            set { _xVelocity = value; }
        }

        public int YVelocity
        {
            get { return _yVelocity; }
            set { _yVelocity = value; }
        }
    }
}
