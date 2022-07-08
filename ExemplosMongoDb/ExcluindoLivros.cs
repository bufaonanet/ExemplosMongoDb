using ExemplosMongoDb.Context;
using ExemplosMongoDb.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ExemplosMongoDb;

public class ExcluindoLivros
{
    static void Main()
    {
        _ = Excluindo();

        Console.WriteLine("\nPressione Enter");
        Console.ReadKey();
    }

    private static async Task Excluindo()
    {
        var conexaoBiblioteca = new MongoDbContext();

        Console.WriteLine("Obter livros do autor  'M. Assis' ");

        var construtorFiltro = Builders<Livro>.Filter;
        var filtroConsulta = construtorFiltro.Eq(l => l.Autor, "M. Assis");

        var livros = await conexaoBiblioteca.Livros
            .Find(filtroConsulta)
            .ToListAsync();

        Console.WriteLine();
        Console.WriteLine($"Qtd Livros encontrados:{livros.Count}");
        foreach (var livro in livros)
        {
            Console.WriteLine(livro.ToJson());
        }

        await conexaoBiblioteca.Livros.DeleteManyAsync(filtroConsulta);

        livros = await conexaoBiblioteca.Livros
           .Find(filtroConsulta)
           .ToListAsync();

        Console.WriteLine();
        Console.WriteLine($"Livro após exclusão :{livros.Count}");
    }
}
