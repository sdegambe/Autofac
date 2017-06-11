using System;
using Autofac.Core;

namespace AutofacContainer
{
    public class Service4 : IDisposer
    {
        private int _counter;
        private readonly IReader _reader;


        public Service4(IReader reader)
        {
            _reader = reader;
            _counter = 0;
        }
        public void Dispose()
        {
            Console.WriteLine("Disposing Service 4");
        }

        public void AddInstanceForDisposal(IDisposable instance)
        {
        }

        public void Read()
        {
            Console.WriteLine(_counter++);
            Console.WriteLine(_reader.Read());
        }
    }
}