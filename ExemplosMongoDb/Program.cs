namespace ExemplosMongoDb;

internal class Program
{
    static void Main(string[] args)
    {
        MainSync(args);
        Console.WriteLine("Pressione Enter");
        Console.ReadKey();
    }

    private static void MainSync(string[] args)
    {
        Console.WriteLine("Esperando 10 segundos...");
        Thread.Sleep(10000);
        Console.WriteLine("Esperei 10 segundos!");
    }
}
