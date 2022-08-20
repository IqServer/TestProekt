
internal class Program
{
    delegate int Operation(int x, int y);
    Operation ss = (x, y) => { return x + y; };
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Result(4, 5, (x, y) => { return x * y; });

        Result(4, 5, Sum);
        Result(4, 5, Minus);
    }

    static int Sum(int a, int b)
    {
        return a + b;
    }
    static int Minus(int a, int b)
    {
        return a - b;
    }

    static void Result(int x, int y, Operation operation)
    {
        var result = operation.Invoke(x, y);
        System.Console.WriteLine(result);
    }
}
