using Logic;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;


namespace Model
{
    public abstract class ModelAbstractApi
    {
        public abstract int width { get; }
        public abstract int height { get; }
        public abstract List<Ellipse> ellipseCollection { get; }
        public LogicApi _logicApi;
        public abstract void CreateEllipses(int numberOfElipses);
        public abstract void Move();
    }

    internal class ModelApi : ModelAbstractApi 
    {
        public override int width { get; }

        public override int height { get; }

        public override List<Ellipse> ellipseCollection { get; }

        public override void CreateEllipses(int numberOfElipses)
        {
            _logicApi.createBalls(numberOfElipses);
            for (int i = 0; i < _logicApi.getAmountOfBalls(); i++)
            {
                Ellipse ellipse = new Ellipse { Width = 4, Height = 4, Fill = Brushes.Black };
                Canvas.SetLeft(ellipse, LogicLayer.GetX(i));
                Canvas.SetTop(ellipse, LogicLayer.GetY(i));
                ellipseCollection.Add(ellipse);
                Canvas.Children.Add(ellipse);
            }

        }

        public override void Move()
        {
            throw new NotImplementedException();
        }
    }
}