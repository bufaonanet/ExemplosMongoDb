using ExemplosMongoDb.Context;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ExemplosMongoDb;

public class ListandoLivrosFiltrados
{
    static void Main()
    {
        _ = MainAsync();

        Console.WriteLine("\nPressione Enter");
        Console.ReadKey();
    }

    private static async Task MainAsync()
    {
        var conexaoBiblioteca = new MongoDbContext();

        Console.WriteLine("Listando Todos os Livros");
        var filtro = new BsonDocument();
        var livros = await conexaoBiblioteca.Livros.Find(filtro).ToListAsync();
        foreach (var livro in livros)
        {
            Console.WriteLine(livro.ToJson());
        }

        Console.WriteLine();
        Console.WriteLine(" **********************************************");
        Console.WriteLine();
        Console.WriteLine("Listando Livros Autor = Machado de Assis");
        filtro = new BsonDocument()
        {
            {"Autor", "Machado de Assis" }
        };
        livros = await conexaoBiblioteca.Livros.Find(filtro).ToListAsync();
        foreach (var livro in livros)
        {
            Console.WriteLine(livro.ToJson());
        }

        Console.WriteLine("Finda da Listagem de Livros");
    }

}

