using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Data
{
    public interface IBall : INotifyPropertyChanged
    {
        double XPosition { get; set; }
        double YPosition { get; set; }
        double XVelocity { get; set; }
        double YVelocity { get; set; }

        void Move();
        void CreateMovementTask(int interval);

        void Stop();
    }


    public class Ball : IBall
    {
        private double _xPosition;
        private double _yPosition;
        private double _xVelocity;
        private double _yVelocity;
        private readonly Stopwatch stopwatch = new Stopwatch();
        private Task task;
        private bool stop = false;

        public Ball(double xPosition, double yPosition, double xVelocity, double yVelocity)
        {
            _xPosition = xPosition;
            _yPosition = yPosition;
            _xVelocity = xVelocity;
            _yVelocity = yVelocity;
        }

        public double XPosition
        {
            get { return _xPosition; }
            set { _xPosition = value; RaisePropertyChanged(nameof(XPosition)); }
        }

        public double YPosition
        {
            get { return _yPosition; }
            set { _yPosition = value; RaisePropertyChanged(nameof(YPosition)); }
        }

        public double XVelocity
        {
            get { return _xVelocity; }
            set { _xVelocity = value; }
        }

        public double YVelocity
        {
            get { return _yVelocity; }
            set { _yVelocity = value; }
        }

        public void Move()
        {
            XPosition += XVelocity;
            YPosition += YVelocity;
        }

        public void CreateMovementTask(int interval)
        {
            stop = false;
            task = Run(interval);
        }

        private async Task Run(int interval)
        {
            while (!stop)
            {
                stopwatch.Reset();
                stopwatch.Start();
                if (!stop)
                {
                    Move();
                    RaisePropertyChanged();
                }
                stopwatch.Stop();

                await Task.Delay((int)(interval - stopwatch.ElapsedMilliseconds));
            }
        }
        public void Stop()
        {
            stop = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        internal void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
