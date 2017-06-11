using System;

namespace AutofacContainer
{
    public class Service2
    {
        private IReader _reader;
        private IWriter _writer;
        public void Read(IReader read)
        {
            _reader = read;
            Console.WriteLine("Setup reader");
        }

        public void Write(IWriter write)
        {
            _writer = write;
            Console.WriteLine("Setup writer");
        }

        public void TryRead()
        {
            Console.WriteLine(_reader.Read());
        }

        public void TryWrite()
        {
            _writer.Write("message from service 2");
        }
    }
}