using System.Numerics;

namespace Data
{
    public class Ball
    {
        private Vector2 position;

        public Vector2 GetPosition()
        {
            return position;
        }

        public void SetPosition(Vector2 value)
        {
            position = value;
        }

        public Ball(Vector2 position)
        {
            this.position = position;
        }
    }
}