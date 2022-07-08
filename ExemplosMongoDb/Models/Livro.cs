using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ExemplosMongoDb.Models;

public class Livro 
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string Títulos { get; set; }
    public string Autor { get; set; }
    public int Ano { get; set; }
    public int Pagina { get; set; }
    public List<string> Assunto { get; set; } = new List<string>();

    public static Livro CriaLivro(string titulo, string autor, int ano, int paginas, string assuntos)
    {
        var livro = new Livro();
        livro.Títulos = titulo;    
        livro.Autor = autor;    
        livro.Ano = ano;
        livro.Pagina = paginas;              
        livro.Assunto.AddRange(assuntos.Split(','));
        return livro;
    }
}

