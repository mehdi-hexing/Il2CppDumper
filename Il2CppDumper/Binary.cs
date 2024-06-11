using System;
using System.IO;
using System.Collections.Generic;

public class Binary
{
    private BinaryReader reader;

    public Binary(Stream stream)
    {
        reader = new BinaryReader(stream);
    }

    public void ExtractData()
    {
        Console.WriteLine("File Length: " + reader.BaseStream.Length);

        // فراخوانی متد برای استخراج فانکشن‌ها
        var functions = ExtractFunctions();
        foreach (var func in functions)
        {
            Console.WriteLine($"Function: {func}");
        }
    }

    private List<string> ExtractFunctions()
    {
        List<string> functions = new List<string>();

        // بازگشت به ابتدای فایل
        reader.BaseStream.Seek(0, SeekOrigin.Begin);

        while (reader.BaseStream.Position < reader.BaseStream.Length)
        {
            var pos = reader.BaseStream.Position;
            byte[] buffer = reader.ReadBytes(4);

            // جستجو و شناسایی فانکشن‌ها (این مثال بسیار ساده است)
            // بررسی اینکه آیا چهار بایت با الگوی خاصی شروع می‌شود
            if (buffer[0] == 0x55 && buffer[1] == 0x48 && buffer[2] == 0x89 && buffer[3] == 0xE5)
            {
                functions.Add($"Function at offset 0x{pos:X}");
            }
        }

        return functions;
    }
}
