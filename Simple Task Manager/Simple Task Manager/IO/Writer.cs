using Simple_Task_Manager.IO.Contracts;

namespace Simple_Task_Manager.IO
{
    public class Writer : IWriter
    {
        public void Write(string message) => Console.Write(message);

        public void WriteLine(string message) => Console.WriteLine(message);
    }
}
