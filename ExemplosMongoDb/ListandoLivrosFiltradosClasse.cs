using ExemplosMongoDb.Context;
using ExemplosMongoDb.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ExemplosMongoDb;

public class ListandoLivrosFiltradosClasse
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

        Console.WriteLine("Listando Livros Autor = Machado de Assis");

        var construtorFiltro = Builders<Livro>.Filter;
        var filtro = construtorFiltro.Eq(l => l.Autor, "Machado de Assis");

        var livros = await conexaoBiblioteca.Livros.Find(filtro).ToListAsync();
        foreach (var livro in livros)
        {
            Console.WriteLine(livro.ToJson());
        }
        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("Listando Livros Ano publicacao igual ou maior a 1999 e com mais de 300 paginas");

        construtorFiltro = Builders<Livro>.Filter;
        filtro = construtorFiltro.Gte(l => l.Ano, 1999) &
                 construtorFiltro.Gte(l => l.Pagina, 300);

        livros = await conexaoBiblioteca.Livros.Find(filtro).ToListAsync();
        foreach (var livro in livros)
        {
            Console.WriteLine(livro.ToJson());
        }
        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("Listando Livros de ficção cientifica");

        construtorFiltro = Builders<Livro>.Filter;
        filtro = construtorFiltro.AnyEq(l => l.Assunto, "Ficção Científica");

        livros = await conexaoBiblioteca.Livros.Find(filtro).ToListAsync();
        foreach (var livro in livros)
        {
            Console.WriteLine(livro.ToJson());
        }
        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine();
        Console.WriteLine();

    }

}


