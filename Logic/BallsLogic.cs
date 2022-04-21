using System.Numerics;

namespace Logic
{
    public class BallsLogic
    {
        private int _radius;
        private Vector2 _ball;
        private int _x;
        private int _y;
        private float _speedBall;

        public BallsLogic () { }
        public BallsLogic(int x, int y, int radius, float speedBall)
        {
            _ball = new Vector2(x, y);
            _speedBall = speedBall;
            _radius = radius;
        }

        public int Radius { get => _radius; set => _radius = value; }
        public Vector2 Ball { get => _ball; set => _ball = value; }
        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }
        public float SpeedBall { get => _speedBall; set => _speedBall = value; }
    }
}