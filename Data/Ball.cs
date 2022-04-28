namespace Data

{
    public class Ball
    {
        private float _xPosition;
        private float _yPosition;
        private float _xVelocity;
        private float _yVelocity;

        public Ball(float xPosition, float yPosition)
        {
            _xPosition = xPosition;
            _yPosition = yPosition;
        }

        public float XPosition 
        { 
            get { return _xPosition; } 
            set { _xPosition = value; } 
        }
           
        public float YPosition 
        { 
            get { return _yPosition; }
            set { _yPosition = value; }
        }

        public float XVelocity
        {
            get { return _xVelocity; }
            set { _xVelocity = value; }
        }

        public float YVelocity
        {
            get { return _yVelocity; }
            set { _yVelocity = value; }
        }
    }
}