namespace Lesson2;

public static class Program
{
  public static void Main(string[] args)
  {
    Console.WriteLine(Names.Egor);
    Console.WriteLine(Names.Vasiliy);
    Console.WriteLine(Names.Andrei);
    Console.WriteLine(Names.Roman);
  }
}
internal enum Sign
{
    Cross,
    Nought,
}

internal static class Names
{
  public static readonly int Egor = 0;
  public static readonly int Vasiliy = 1;
  public static readonly int Andrei = 2;
  public static readonly int Roman = 3;
}
