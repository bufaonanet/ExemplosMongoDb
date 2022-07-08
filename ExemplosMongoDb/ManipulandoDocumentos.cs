using MongoDB.Bson;
using MongoDB.Driver;

namespace ExemplosMongoDb;

class ManipulandoDocumentos
{
    static void Main(string[] args)
    {
        BsonDocument documento = CriaDocumento();

        Console.WriteLine(documento);

        Task t = InsereDocumento(documento);        

        Console.WriteLine("Pressione Enter");
        Console.ReadKey();
    }

    private static async Task InsereDocumento(BsonDocument documento)
    {
        //Acessando servidor MongoDb
        var user = "root";
        var password = "123";
        var host = "localhost:27017";

        string conexao = $"mongodb://{user}:{password}@{host}";

        IMongoClient servidor = new MongoClient(conexao);      

        //Acessando bando de dados
        IMongoDatabase banco = servidor.GetDatabase("Biblioteca");

        //Acessando coleção
        IMongoCollection<BsonDocument> colecao = banco.GetCollection<BsonDocument>("Livros");

        //Inserindo documento
        await colecao.InsertOneAsync(documento);

        Console.WriteLine("Documento incluido");
    }

    private static BsonDocument CriaDocumento()
    {
        var doc = new BsonDocument
        {
            { "Títulos","Guerra dos Tronos"}
        };
        doc.Add("Autor", "George R R Martin");
        doc.Add("Ano", 1999);
        doc.Add("Página", 856);

        var assunto = new BsonArray();
        assunto.Add("Fantasia");
        assunto.Add("Ação");

        doc.Add("Assunto", assunto);
        return doc;
    }
}
