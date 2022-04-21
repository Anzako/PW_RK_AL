namespace Data
{
    public abstract class DataAbstractApi
    {
        public static DataAbstractApi generateDataAPI()
        {
            return new DataAPI();
        }

        private class DataAPI : DataAbstractApi
        {
            public DataAPI()
            {

            }
        }
    }
}