using System.Diagnostics;

namespace Library
{
    public class Worker
    {
        public static void Do()
        {
            Debug.WriteLine($"{nameof(Worker)}.{nameof(Do)}() called.");
        }
    }
}
