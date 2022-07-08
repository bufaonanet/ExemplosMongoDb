namespace ExemplosMongoDb;

internal class ProgramAsync
{
    static void Main(string[] args)
    {
        Task task = MainASync(args);
        Console.WriteLine("Pressione Enter");
        Console.ReadKey();
    }

    private static async Task MainASync(string[] args)
    {
        Console.WriteLine("Esperando 10 segundos de forma assíncrona...");
        await Task.Delay(10000);
        Console.WriteLine("Esperei 10 segundos!");
    }
}
