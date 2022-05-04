using System;
using System.Windows.Threading;

namespace Logic
{

    public abstract class TimerApi
    {
        public abstract event EventHandler Tick;
        public abstract TimeSpan Interval { get; set; }
        public abstract void Start();
        public abstract void Stop();
        public static TimerApi CreateBallTimer()
        {
            return new BallTimer();
        }
    }
    internal class BallTimer : TimerApi
    {
        private readonly DispatcherTimer timer;

        public BallTimer()
        {
            timer = new DispatcherTimer();
        }

        public override TimeSpan Interval { get => timer.Interval; set => timer.Interval = value; }

        public override event EventHandler Tick { add => timer.Tick += value; remove => timer.Tick -= value; }
        public override void Start()
        {
            timer.Start();
        }

        public override void Stop()
        {
            timer.Stop();
        }
    }
}
