using ExemplosMongoDb.Context;
using ExemplosMongoDb.Models;

namespace ExemplosMongoDb;

public class AcessandoMongoComContexto
{
    static void Main()
    {
        var livro = CriaLivro();

        Console.WriteLine(livro);

        Task t = InsereDocumento(livro);

        Console.WriteLine("Pressione Enter");
        Console.ReadKey();
    }

    private static async Task InsereDocumento(Livro livro)
    {       
        var conexaoBiblioteca = new MongoDbContext();

        await conexaoBiblioteca.Livros.InsertOneAsync(livro);

        Console.WriteLine("Livro incluido");
    }

    private static Livro CriaLivro()
    {
        return new Livro()
        {
            Títulos = "Star Wars Legends",
            Autor = "Timothy Zahn",
            Ano = 2010,
            Pagina = 245,
            Assunto = new()
            {
                {"Ficção Científica" }
            }
        };
    }
}
