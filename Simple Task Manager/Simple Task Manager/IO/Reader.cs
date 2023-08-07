using Simple_Task_Manager.IO.Contracts;

namespace Simple_Task_Manager.IO
{
    public class Reader : IReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}
