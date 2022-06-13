using System;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Data
{
    public abstract class DataAbstractApi
    {
        public static DataAbstractApi CreateApi(int width, int height)
        {
            return new DataApi(width, height);
        }
        public abstract int getBoardWidth();
        public abstract int getBoardHeight();
        public abstract IBall CreateBall();
        public abstract Task CreateLoggingTask(ConcurrentQueue<IBall> logQueue);
        public abstract void AppendObjectToJSONFile(string filename, string newJsonObject);
    }
    internal class DataApi : DataAbstractApi
    {
        private readonly Random random = new Random();
        private readonly Stopwatch stopwatch;
        private Board board;
        private bool newSession;
        private bool stop;
        private readonly string logPath = "Log.json";

        public override Task CreateLoggingTask(ConcurrentQueue<IBall> logQueue)
        {
            stop = false;
            return CallLogger(logQueue);
        }

        internal async Task CallLogger(ConcurrentQueue<IBall> logQueue)
        {
            FileMaker(logPath);
            string diagnostics;
            string date;
            string log;
            while (!stop)
            {
                stopwatch.Reset();
                stopwatch.Start();
                logQueue.TryDequeue(out IBall logObject);
                if (logObject != null)
                {
                    diagnostics = JsonSerializer.Serialize(logObject);
                    date = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff");
                    log = "{" + String.Format("\n\t\"Date\": \"{0}\",\n\t\"Info\":{1}\n", date, diagnostics) + "}";

                    lock (this)
                    {
                        File.AppendAllText(logPath, log);
                    }
                }
                else
                {
                    return;
                }
                stopwatch.Stop();
                await Task.Delay((int)(stopwatch.ElapsedMilliseconds));
            }
        }

        public override void AppendObjectToJSONFile(string filename, string newJsonObject)
        {



            using (StreamWriter sw = new StreamWriter(filename, true))
            {
                sw.WriteLine("[]");
            }

            string content;
            using (StreamReader sr = File.OpenText(filename))
            {
                content = sr.ReadToEnd();
            }

            content = content.TrimEnd();
            content = content.Remove(content.Length - 1, 1);

            if (content.Length == 1)
            {
                content = String.Format("{0}\n{1}\n]\n", content.Trim(), newJsonObject);
            }
            else
            {
                content = String.Format("{0},\n{1}\n]\n", content.Trim(), newJsonObject);
            }

            using (StreamWriter sw = File.CreateText(filename))
            {
                sw.Write(content);
            }
        }

        internal void FileMaker(string filename)
        {
            if (File.Exists(filename) && newSession)
            {
                newSession = false;
                File.Delete(filename);
            }
        }

        public DataApi(int width, int height)
        {
            board = new Board(width, height);
            newSession = true;
            stopwatch = new Stopwatch();
        }
        public override int getBoardWidth()
        {
            return board.Width;
        }

        public override int getBoardHeight()
        {
            return board.Height;
        }

        public override IBall CreateBall()
        {
            int radius = random.Next(20, 40);
            double weight = radius;  
            double X = random.Next(5, getBoardWidth() - radius - 5);
            double Y = random.Next(5, getBoardHeight() - radius - 5);
            double XV = random.Next(-10, 10);
            double YV = random.Next(-10, 10);
            
            Ball ball = new Ball(X, Y, XV, YV, radius, weight);

            return ball;
        }

     
    }
}
