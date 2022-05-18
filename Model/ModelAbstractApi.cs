using Logic;
using System.Collections;

namespace Model
{
    public abstract class ModelAbstractApi
    {
        public abstract int Width { get; }
        public abstract int Height { get; }

        public abstract IList Start(int ballVal);

        public abstract void StartMoving();

        public abstract void Stop();


        public static ModelAbstractApi CreateModelApi(int Width, int Height)
        {
            return new ModelApi(Width, Height);
        }
    }

    internal class ModelApi : ModelAbstractApi
    {
        private LogicAbstractApi _logicApi;

        public ModelApi(int Width, int Height)
        {
            this.Width = Width;
            this.Height = Height;
            _logicApi = LogicAbstractApi.CreateLogicApi(Width, Height);
        }



        public override int Width
        {
            get;
        }

        public override int Height
        {
            get;
        }

        public override IList Start(int balls) => _logicApi.createBalls(balls);

        public override void StartMoving()
        {
            _logicApi.Start();
        }

        public override void Stop()
        {
            _logicApi.Stop();
        }
    }

}