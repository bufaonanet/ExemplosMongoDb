using ExemplosMongoDb.Context;
using ExemplosMongoDb.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ExemplosMongoDb;

public class ListandoLivros
{
    static void Main()
    {
        _ = MainAsync();       

        Console.WriteLine("\nPressione Enter");
        Console.ReadKey();
    }

    private static async Task MainAsync()
    {
        Console.WriteLine("Listando Livros");

        var conexaoBiblioteca = new MongoDbContext();

        var livros = await conexaoBiblioteca.Livros.Find(new BsonDocument()).ToListAsync();

        foreach (var livro in livros)
        {
            Console.WriteLine(livro.ToJson());
        }

        Console.WriteLine("Finda da Lista");
    }

}

