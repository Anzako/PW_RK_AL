namespace Data

{
    public class Ball
    {
        private float _xPosition { get; set; }
        private float _yPosition { get; set; }
        private float _xVelocity { get; set; }
        private float _yVelocity { get; set; }

        public Ball(float xPosition, float yPosition)
        {
            _xPosition = xPosition;
            _yPosition = yPosition;
        }
    }
}