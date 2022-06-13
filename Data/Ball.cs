using System.ComponentModel;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Data
{
    public interface IBall : INotifyPropertyChanged
    {
        double XPosition { get; }
        double YPosition { get; }
        double XVelocity { get; }
        double YVelocity { get; }
        double Radius { get; }
        double Weight { get; }
        void changeVelocity(double XV, double YV);
        void Move(double time, ConcurrentQueue<IBall> queue);
        Task CreateMovementTask(int interval, ConcurrentQueue<IBall> queue);
        void SaveRequest(ConcurrentQueue<IBall> queue);
        void Stop();
    }


    public class Ball : IBall
    {
        private double _xPosition;
        private double _yPosition;
        private double _xVelocity;
        private double _yVelocity;
        private readonly double _radius;
        private readonly double _weight;
        private readonly Stopwatch stopwatch;
        private bool stop;
        private readonly object locker = new object();

        public event PropertyChangedEventHandler PropertyChanged;
        public Ball(double xPosition, double yPosition, double xVelocity, double yVelocity, double radius, double weight)
        {
            _xPosition = xPosition;
            _yPosition = yPosition;
            _xVelocity = xVelocity;
            _yVelocity = yVelocity;
            _radius = radius;
            _weight = weight;
            stop = false;
            stopwatch = new Stopwatch();
        }

        public double XPosition
        {
            get 
            {
                lock (locker) return _xPosition; 
            }
            set { _xPosition = value; }
        }

        public double YPosition
        {
            get 
            { 
                lock (locker) return _yPosition; 
            }
            set { _yPosition = value; }
        }

        public double XVelocity
        {
            get 
            { 
                lock (locker) return _xVelocity; 
            }
            set { _xVelocity = value; }
        }

        public double YVelocity
        {
            get { return _yVelocity; }
            set { _yVelocity = value; }
        }

        public double Radius 
        {
            get { return _radius; }
        }
        public double Weight 
        { 
            get { return _weight; }
        }

        public void changeVelocity(double XV, double YV)
        {
            lock (locker)
            {
                XVelocity = XV;
                YVelocity = YV;
            }
        }

        public void Move(double time, ConcurrentQueue<IBall> queue)
        {
            lock (locker)
            {
                XPosition += XVelocity * time;
                YPosition += YVelocity * time;
                RaisePropertyChanged(nameof(XPosition));
                RaisePropertyChanged(nameof(YPosition));
                SaveRequest(queue);
            }
        }

        public Task CreateMovementTask(int interval, ConcurrentQueue<IBall> queue)
        {
            stop = false;
            return Run(interval, queue);
        }

        private async Task Run(int interval, ConcurrentQueue<IBall> queue)
        {
            while (!stop)
            {
                stopwatch.Reset();
                stopwatch.Start();
                if (!stop)
                {
                    Move(((interval - stopwatch.ElapsedMilliseconds) / 16), queue);
                }
                stopwatch.Stop();
                
                await Task.Delay((int)(interval - stopwatch.ElapsedMilliseconds));
            }
        }
        public void Stop()
        {
            stop = true;
        }

        public void SaveRequest(ConcurrentQueue<IBall> queue)
        {
            queue.Enqueue(new Ball(XPosition, YPosition, XVelocity, YVelocity, Radius, Weight));
        }

        internal void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
