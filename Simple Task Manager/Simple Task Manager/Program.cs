using Simple_Task_Manager.Core;
using Simple_Task_Manager.Core.Contracts;

namespace Simple_Task_Manager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}