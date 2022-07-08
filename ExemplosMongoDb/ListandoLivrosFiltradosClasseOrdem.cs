using ExemplosMongoDb.Context;
using ExemplosMongoDb.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ExemplosMongoDb;

public class ListandoLivrosFiltradosClasseOrdem
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

        Console.WriteLine("Listando Livros mais de 100 paginas");

        var construtorFiltro = Builders<Livro>.Filter;
        var filtro = construtorFiltro.Gt(l => l.Pagina, 100);

        var livros = await conexaoBiblioteca.Livros
            .Find(filtro)
            .SortBy(x => x.Títulos)
            .Limit(5)
            .ToListAsync();

        foreach (var livro in livros)
        {
            Console.WriteLine(livro.ToJson());
        }
        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine();
        Console.WriteLine();        
    }
}