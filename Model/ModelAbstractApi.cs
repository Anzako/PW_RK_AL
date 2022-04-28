using Logic;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;
using WindowsBase_Core.STW;

namespace Model
{
    public abstract class ModelAbstractApi
    {
        public abstract int width { get; }
        public abstract int height { get; }

        public abstract int speed { get; }
        public abstract List<Ellipse> ellipseCollection { get; }

        public LogicApi logicApi;
        public abstract void CreateEllipses(int numberOfElipses);
        public abstract void Move();

        //public abstract ModelAbstractApi CreateModelApi(int Speed, int Weight, int Height)
        //{
            //return new ModelApi(Speed, Weight, Height);
        //}
    }

    internal class ModelApi : ModelAbstractApi 
    {
        public ModelApi(int Width, int Height, int Speed)
        {   
            width = Width;
            height = Height;    
            speed = Speed;
            logicApi = LogicApi.CreateLogicApi(Speed, Width, Height);
            Canvas = new Canvas();
            Canvas.HorizontalAlignment = HorizontalAlignment.Left;
            Canvas.VerticalAlignment = VerticalAlignment.Top;
            Canvas.Width = width;
            Canvas.Height = height;
        }

        public override int width { get; }

        public override int height { get; }

        public override List<Ellipse> ellipseCollection { get; }

        public override int speed { get; }
        public Canvas Canvas { get; set; }

        public override void CreateEllipses(int numberOfElipses)
        {
            logicApi.createBalls(numberOfElipses);
            for (int i = 0; i < logicApi.getAmountOfBalls(); i++)
            {
                Ellipse ellipse = new Ellipse { Width = 4, Height = 4, Fill = Brushes.Black };
                //przepisac do dotnetstandard2.0
                Canvas.SetLeft(ellipse, logicApi.getBallFromListXVAlue(i));
                Canvas.SetTop(ellipse, logicApi.getBallFromListYValue(i));
                ellipseCollection.Add(ellipse);
                Canvas.Children.Add(ellipse);
            }
        }

        public override ModelAbstractApi CreateModelApi(int Speed, int Weight, int Height)
        {
            throw new NotImplementedException();
        }

        public override void Move()
        {
            throw new NotImplementedException();
        }
    }
}