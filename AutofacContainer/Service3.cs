using System;

namespace AutofacContainer
{
    public class Service3
    {
        public IWriter Writer { get; set; }
        public IReader Reader { get; set; }

        public void Read()
        {
            Console.WriteLine(Reader.Read());
        }

        public void Write()
        {
            Writer.Write("message from service 3");
        }
    }
}