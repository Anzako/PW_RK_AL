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

        public override bool Equals(object? obj)
        {
            return obj is Ball ball &&
                   _xPosition == ball._xPosition &&
                   _yPosition == ball._yPosition &&
                   _xVelocity == ball._xVelocity &&
                   _yVelocity == ball._yVelocity;
        }
    }
}