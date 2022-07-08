using ExemplosMongoDb.Models;
using MongoDB.Driver;

namespace ExemplosMongoDb;

class ManipulandoDocumentosClasse
{
    static void Main(string[] args)
    {
        var livro = CriaLivro();

        Console.WriteLine(livro);

        Task t = InsereDocumento(livro);

        Console.WriteLine("Pressione Enter");
        Console.ReadKey();
    }

    private static async Task InsereDocumento(Livro livro)
    {
        //Acessando servidor MongoDb
        var user = "root";
        var password = "123";
        var host = "localhost:27017";

        string conexao = $"mongodb://{user}:{password}@{host}";

        IMongoClient cliente = new MongoClient(conexao);

        //Acessando bando de dados
        IMongoDatabase banco = cliente.GetDatabase("Biblioteca");

        //Acessando coleção
        IMongoCollection<Livro> colecao = banco.GetCollection<Livro>("Livros");

        //Inserindo documento
        await colecao.InsertOneAsync(livro);

        Console.WriteLine("Livro incluido");
    }

    private static Livro CriaLivro()
    {
        return new Livro()
        {
            Títulos = "Sob a redoma",
            Autor = "Stepahn King,",
            Ano = 2012,
            Pagina = 679,
            Assunto = new()
            {
                {"Ficção Científica" },
                {"Terror" },
                {"Ação" }
            }
        };
    }

}
