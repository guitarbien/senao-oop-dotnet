namespace Service.Handler
{
    public static class HandlerFactory
    {
        public static IHandler Create(string handlerType)
        {
            if (handlerType == "file")
            {
                return new FileHandler();
            }

            if (handlerType == "zip")
            {
                return new FileHandler();
            }

            if (handlerType == "encode")
            {
                return new FileHandler();
            }

            if (handlerType == "directory")
            {
                return new FileHandler();
            }

            return new FileHandler();
        }
    }
}