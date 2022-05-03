using System;

namespace Data
{
    public abstract class DataAbstractApi
    {
        public static DataAbstractApi CreateApi()
        {
            return new DataApi();
        }

        internal class DataApi : DataAbstractApi
        {

        }
    }
}
