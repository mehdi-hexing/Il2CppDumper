using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 1)
        {
            Console.WriteLine("Usage: Il2CppDumper <binary file>");
            return;
        }

        var binaryFile = args[0];
        var binary = new Binary(new MemoryStream(File.ReadAllBytes(binaryFile)));

        // فراخوانی متد برای پردازش داده‌های باینری
        binary.ExtractData();
    }
}
