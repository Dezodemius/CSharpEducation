using System.Diagnostics;
using System.IO.Pipes;
using Microsoft.Build.Logging;
using MyLogger;
using Newtonsoft.Json;

namespace Lesson1
{
  /// <summary>
  /// Главный класс программы.
  /// </summary>
  public static class Program
  {
    /// <summary>
    /// Точка входа.
    /// </summary>
    /// <param name="args">Аргументы командной строки.</param>
    public static void Main(string[] args)
    {
      Console.WriteLine($"{new TimeSpan(0, 0, 0, 4, 4412411)}");
      return;
     var buildProcessStartInfo = new ProcessStartInfo("dotnet.exe")
      {
          Arguments = @"build E:\Projects\TelegramBots\TelegramBots.sln -l:BasicFileLogger,E:\Projects\CSharpEducation\Lesson1\bin\Debug\net7.0\Lesson1.dll",
      };
      var buildProcess = new Process();
      buildProcess.StartInfo = buildProcessStartInfo;
      buildProcess.Start();
      var server = new NamedPipeClientStream(".", "kek");
      
      server.Connect();
      using (var reader = new StreamReader(server))
      {
        string line;
        while (server.CanRead && (line = reader.ReadLine()) != null)
        {
          Console.WriteLine(line);
        }
      }
      var pipeClient = new NamedPipeClientStream(".", "kek");
      pipeClient.Connect();
      using (var reader = new BinaryReader(pipeClient))
      {
        var beaReader = new BuildEventArgsReader(reader, 7);
        while (reader.PeekChar() > -1)
        {
          Console.WriteLine(JsonConvert.SerializeObject(beaReader.Read()));
        }
      }
      buildProcess.WaitForExit();
    }
  }
}