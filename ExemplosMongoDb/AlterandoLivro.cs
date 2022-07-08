using ExemplosMongoDb.Context;
using ExemplosMongoDb.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ExemplosMongoDb;

public class AlterandoLivro
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

        Console.WriteLine("Obter livro 'A Dança com os Dragões' ");

        var construtorFiltro = Builders<Livro>.Filter;
        var filtro = construtorFiltro.Eq(l => l.Títulos, "A Dança com os Dragões");

        var livro = await conexaoBiblioteca.Livros
            .Find(filtro)
            .FirstOrDefaultAsync();

        Console.WriteLine();
        Console.WriteLine("Livro antes da alteração");
        Console.WriteLine(livro.ToJson());

        livro.Ano = 2010;
        livro.Pagina = 900;

        await conexaoBiblioteca.Livros
            .ReplaceOneAsync(filtro, livro);

        livro = await conexaoBiblioteca.Livros
            .Find(filtro)
            .FirstOrDefaultAsync();

        Console.WriteLine();
        Console.WriteLine("Livro alterado");
        Console.WriteLine(livro.ToJson());
    }

}
