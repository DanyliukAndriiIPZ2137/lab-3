namespace Lab3Library
{
    public sealed class DatabaseRespository
    {
        private DatabaseRespository() { }
        private static DatabaseRespository _instance;
        private static readonly object _lock = new object();
        public static DatabaseRespository GetInstance()
        {
            if(_instance == null)
            {
                lock (_lock)
                {
                    if(_instance == null)
                    {
                        _instance = new DatabaseRespository();
                    }
                }
            }
            return _instance;
        }
    }
}