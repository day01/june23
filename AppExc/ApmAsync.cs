using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace AppExc1;

public class ApmAsync
{
    private void GenerateDummyFile(string filename, char pattern, int sizeOfFile)
    {
        const int blockSize = 1024 * 8;
        var data = new byte[blockSize];
        using var crypto = RandomNumberGenerator.Create();
        using var stream = File.OpenWrite(filename);
        for (var i = 0; i < 1024 * sizeOfFile; i++)
        {
            switch (pattern)
            {
                case 'A':
                    data = data.Select(x => (byte) (x + 1)).ToArray();
                    break;
                case 'B':
                    data = data.Select(x => (byte) (x + 2)).ToArray();
                    break;
                default:
                    crypto.GetBytes(data);
                    break;
            }

            crypto.GetBytes(data);
            stream.Write(data, 0, data.Length);
        }
    }

    private string GenAndReadFile(string filename, char pattern, int sizeOfFile, byte[] key)
    {
        var sw = new Stopwatch();
        var swCalc = new Stopwatch();
        sw.Start();
        GenerateDummyFile(filename, pattern, sizeOfFile);
        sw.Stop();

        var result = File.ReadAllBytesAsync(filename);
        Console.WriteLine("File read");

        swCalc.Start();
        HMACSHA512.HashData(key, result.Result);
        Console.WriteLine("Hash calculated");
        swCalc.Stop();

        return $"{Encoding.UTF8.GetString(key)} {sw.Elapsed.TotalSeconds}s {swCalc.Elapsed.TotalSeconds}s";
    }

    public Task<string> CalculateSha(string filename, char pattern, int sizeOfFile, byte[] key)
    {
        return Task.Run(() => GenAndReadFile(filename, pattern, sizeOfFile, key));
    }
}