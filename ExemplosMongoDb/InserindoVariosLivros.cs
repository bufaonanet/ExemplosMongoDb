using ExemplosMongoDb.Context;
using ExemplosMongoDb.Models;

namespace ExemplosMongoDb;

public class InserindoVariosLivros
{
    static void Main()
    {
        Task T =  InsereLivros();

        Console.WriteLine("\nPressione Enter");
        Console.ReadKey();       
    }

    private static async Task InsereLivros()
    {
        List<Livro> livros = new()
        {
            Livro.CriaLivro("A Dança com os Dragões", "George R R Martin", 2011, 934, "Fantasia, Ação"),
            Livro.CriaLivro("A Tormenta das Espadas", "George R R Martin", 2006, 1276, "Fantasia, Ação"),
            Livro.CriaLivro("Memórias Póstumas de Brás Cubas", "Machado de Assis", 1915, 267, "Literatura Brasileira"),
            Livro.CriaLivro("Star Trek Portal do Tempo", "Crispin A C", 2002, 321, "Fantasia, Ação"),
            Livro.CriaLivro("Star Trek Enigmas", "Dedopolus Tim", 2006, 195, "Ficção Científica, Ação"),
            Livro.CriaLivro("Emília no Pais da Gramática", "Monteiro Lobato", 1936, 230, "Infantil, Literatura Brasileira, Didático"),
            Livro.CriaLivro("Chapelzinho Amarelo", "Chico Buarque", 2008, 123, "Infantil, Literatura Brasileira"),
            Livro.CriaLivro("20000 Léguas Submarinas", "Julio Verne", 1894, 256, "Ficção Científica, Ação"),
            Livro.CriaLivro("Primeiros Passos na Matemática", "Mantin Ibanez", 2014, 190, "Didático, Infantil"),
            Livro.CriaLivro("Saúde e Sabor", "Yeomans Matthew", 2012, 245, "Culinária, Didático"),
            Livro.CriaLivro("Goldfinger", "Iam Fleming", 1956, 267, "Espionagem, Ação"),
            Livro.CriaLivro("Da Rússia com Amor", "Iam Fleming", 1966, 245, "Espionagem, Ação"),
            Livro.CriaLivro("O Senhor dos Aneis", "J R R Token", 1948, 1956, "Fantasia, Ação")
        };

        var conexaoBiblioteca = new MongoDbContext();

        await conexaoBiblioteca.Livros.InsertManyAsync(livros);

        Console.WriteLine("Livros incluidos");
    }    
}