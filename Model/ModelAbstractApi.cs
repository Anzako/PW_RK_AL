using Logic;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;
using System;

namespace Model
{
    public abstract class ModelAbstractApi
    {
        public abstract int width { get; }
        public abstract int height { get; }

        public abstract int speed { get; }
        public abstract List<Ellipse> ellipseCollection { get; }

        public abstract Canvas Canvas { get; set; }

        public abstract void CreateEllipses(int numberOfElipses);

        public static ModelAbstractApi CreateModelApi(int Width, int Height, int Speed)
        {
            return new ModelApi(Width, Height, Speed);
        }

        public abstract void Move();
    }

    internal class ModelApi : ModelAbstractApi
    {
        private LogicApi _logicApi;

        public ModelApi(int Width, int Height, int Speed)
        {
            width = Width;
            height = Height;
            speed = Speed;
            ellipseCollection = new List<Ellipse>();
            _logicApi = LogicApi.CreateLogicApi(Speed, Width, Height);
            Canvas = new Canvas();
            Canvas.HorizontalAlignment = HorizontalAlignment.Left;
            Canvas.VerticalAlignment = VerticalAlignment.Top;
            Canvas.Width = width;
            Canvas.Height = height;
            //_logicApi.Update += (sender, args) => Move();
        }

        public override int width { get; }

        public override int height { get; }

        public override List<Ellipse> ellipseCollection { get; }

        public override int speed { get; }
        public override Canvas Canvas { get; set; }

        public override void CreateEllipses(int numberOfElipses)
        {
            _logicApi.createBalls(numberOfElipses);
            for (int i = 0; i < _logicApi.getAmountOfBalls(); i++)
            {
                Ellipse ellipse = new Ellipse { Width = _logicApi.getBallFromListXVAlue(i), Height = _logicApi.getBallFromListYValue(i), Fill = Brushes.Black};
                Canvas.SetLeft(ellipse, _logicApi.getBallFromListXVAlue(i));
                Canvas.SetTop(ellipse, _logicApi.getBallFromListYValue(i));
                ellipseCollection.Add(ellipse);
                Canvas.Children.Add(ellipse);
            }
        }

        public override void Move()
        {
            for (int i = 0; i < _logicApi.getAmountOfBalls(); i++)
            {
                Canvas.SetLeft(ellipseCollection[i], _logicApi.getBallFromListXVAlue(i));
                Canvas.SetTop(ellipseCollection[i], _logicApi.getBallFromListYValue(i));
            }
            for (int i = _logicApi.getAmountOfBalls(); i < ellipseCollection.Count; i++)
            {
                Canvas.Children.Remove(ellipseCollection[ellipseCollection.Count - 1]);
                ellipseCollection.Remove(ellipseCollection[ellipseCollection.Count - 1]);
            }
        }
    }
}