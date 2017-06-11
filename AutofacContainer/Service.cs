using System;

namespace AutofacContainer
{
    public class Service
    {
        private readonly IReader _reaader;
        private readonly IWriter _writer;

        public Service(IReader reaader, IWriter writer)
        {
            _reaader = reaader;
            _writer = writer;
        }

        public void Read()
        {
            Console.WriteLine(_reaader.Read());
        }

        public void Write()
        {
            _writer.Write("message from service");
        }
    }
}