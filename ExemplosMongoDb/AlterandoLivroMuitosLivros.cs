using ExemplosMongoDb.Context;
using ExemplosMongoDb.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ExemplosMongoDb;

public class AlterandoLivroMuitosLivros
{
    static void Main()
    {
        _ = AlterandoMuitosLivros();

        Console.WriteLine("\nPressione Enter");
        Console.ReadKey();
    }

    private static async Task AlterandoUmLivro()
    {
        var conexaoBiblioteca = new MongoDbContext();

        Console.WriteLine("Obter livro 'A Dança com os Dragões' ");

        var construtorFiltro = Builders<Livro>.Filter;
        var filtroConsulta = construtorFiltro.Eq(l => l.Títulos, "A Dança com os Dragões");

        var livro = await conexaoBiblioteca.Livros
            .Find(filtroConsulta)
            .FirstOrDefaultAsync();

        Console.WriteLine();
        Console.WriteLine("Livro antes da alteração");
        Console.WriteLine(livro.ToJson());

        var construtorUpdate = Builders<Livro>.Update;
        var condicaoUpdate = construtorUpdate.Set(x => x.Pagina, 966);

        await conexaoBiblioteca.Livros
            .UpdateOneAsync(filtroConsulta, condicaoUpdate);

        livro = await conexaoBiblioteca.Livros
            .Find(filtroConsulta)
            .FirstOrDefaultAsync();

        Console.WriteLine();
        Console.WriteLine("Livro alterado");
        Console.WriteLine(livro.ToJson());
    }

    private static async Task AlterandoMuitosLivros()
    {
        var conexaoBiblioteca = new MongoDbContext();

        Console.WriteLine("Obter livros do autor  'Machado de Assis' ");

        var construtorFiltro = Builders<Livro>.Filter;
        var filtroConsulta = construtorFiltro.Eq(l => l.Autor, "Machado de Assis");

        var livros = await conexaoBiblioteca.Livros
            .Find(filtroConsulta)
            .ToListAsync();

        Console.WriteLine();
        Console.WriteLine("Livro antes da alteração");
        foreach (var livro in livros)
        {
            Console.WriteLine(livro.ToJson());
        }     

        var construtorUpdate = Builders<Livro>.Update;
        var condicaoUpdate = construtorUpdate.Set(x => x.Autor, "M. Assis");

        await conexaoBiblioteca.Livros
            .UpdateManyAsync(filtroConsulta, condicaoUpdate);

        filtroConsulta = construtorFiltro.Eq(l => l.Autor, "M. Assis");
        livros = await conexaoBiblioteca.Livros
            .Find(filtroConsulta)
            .ToListAsync();

        Console.WriteLine();
        Console.WriteLine("Livro após a alteração");
        foreach (var livro in livros)
        {
            Console.WriteLine(livro.ToJson());
        }
    }
}