using System;

namespace AutofacContainer
{
    public class ServiceWriter : IWriter
    {
        public void Write(string something)
        {
            Console.WriteLine(something + " Service writer");
        }
    }
}