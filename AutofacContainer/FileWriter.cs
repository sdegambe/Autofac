using System;

namespace AutofacContainer
{
    public class FileWriter : IWriter
    {
        public void Write(string something)
        {
            Console.WriteLine(something + " File writer");
        }
    }
}