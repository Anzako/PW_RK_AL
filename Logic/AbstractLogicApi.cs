using Data;

namespace Logic
{
    public abstract class AbstractLogicApi
    {
        private DataAbstractApi _dataAPI;

        public AbstractLogicApi(DataAbstractApi dataAPI = null)
        {
            _dataAPI = (dataAPI == null) ? DataAbstractApi.generateDataAPI() : dataAPI;
        }
        public abstract void generateBall();

    }
}
