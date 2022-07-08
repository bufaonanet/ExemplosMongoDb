using ExemplosMongoDb.Models;
using MongoDB.Driver;

namespace ExemplosMongoDb.Context;

public class MongoDbContext
{
    private const string STRING_DE_CONEXAO = "mongodb://root:123@localhost:27017";
    private const string NOME_DA_BASE = "Biblioteca";
    private const string NOME_DA_COLECAO = "Livros";

    private static readonly IMongoClient _client;
    private static readonly IMongoDatabase _database;

    static MongoDbContext()
    {
        _client = new MongoClient(STRING_DE_CONEXAO);
        _database = _client.GetDatabase(NOME_DA_BASE);
    }

    public IMongoClient Client => _client;

    public IMongoCollection<Livro> Livros => _database.GetCollection<Livro>(NOME_DA_COLECAO);
}
