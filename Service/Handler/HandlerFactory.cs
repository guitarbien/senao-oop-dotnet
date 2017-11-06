using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Service.Handler
{
    public static class HandlerFactory
    {
        private static readonly Dictionary<string, string> HandlerDictionary;

        static HandlerFactory()
        {
            string jsonString = File.ReadAllText("handler_mapping.json");
            HandlerDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);
        }

        public static IHandler Create(string handlerType)
        {
            return (IHandler) Activator.CreateInstance(
                Type.GetType("senao-oop-dotnet.Handler." + HandlerDictionary[handlerType]));
        }
    }
}