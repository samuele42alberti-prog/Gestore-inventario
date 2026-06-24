public class Prodotto
{
    public int Id { get; set; }
    public string Nome { get; set; } = " ";
    public string Categoria { get; set; } = " ";
    public double Prezzo { get; set; }
    public int Qt { get; set; }

    public Prodotto(string nome, string categoria, double prezzo, int qt)
    {
        Nome = nome;
        Categoria = categoria;
        Prezzo = prezzo;
        Qt = qt;
    }
}