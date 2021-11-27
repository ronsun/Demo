using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace Library
{
    public class Worker
    {
        public static void Do()
        {
            Debug.WriteLine($"{nameof(Worker)}.{nameof(Do)}() called.");
            var obj = JObject.Parse(@"{""myKey"": ""myValue""}");
            Debug.WriteLine($"data parsed, myKey = {obj["myKey"]}");
        }
    }
}
