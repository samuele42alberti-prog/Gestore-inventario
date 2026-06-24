using Microsoft.EntityFrameworkCore;
using System.Linq;

public class InventarioService : IInventario
{
    //database
    private readonly InventarioContext ctx;
    public InventarioService(InventarioContext ctx)
    {
        this.ctx = ctx;
    }

    //aggiungi prodotto
    public async Task Aggiungi(string nome, string cat, double prezzo, int qt)
    {
        var prodotto = new Prodotto(nome, cat, prezzo, qt);
        ctx.Prodotti.Add(prodotto);
        await ctx.SaveChangesAsync();

        Console.WriteLine($"{nome} è stato aggiunto! categoria: {cat}, prezzo: {prezzo}, quantità: {qt}. ID = {prodotto.Id}");
    }
    //controlla esistenza
    public async Task<bool> ControllaEsistenza(string nome)
    {
        var prodotto = await ctx.Prodotti
        .Where( p => p.Nome == nome)
        .FirstOrDefaultAsync();

        return prodotto != null;
    }

    //rimuovi prodotto
    public async Task Rimuovi(string nome)
    {
        var daEliminare = await ctx.Prodotti
        .Where(p => p.Nome == nome)
        .FirstOrDefaultAsync();

        Console.WriteLine($"{daEliminare.Nome} è stato rimosso!");
        ctx.Prodotti.Remove(daEliminare);
        await ctx.SaveChangesAsync();
    }

    //modifica prodotto
    public async Task Modifica(string nome)
    {
        Console.WriteLine("Cosa vuoi modificare? premi 1 per il nome, 2 per la categoria, 3 per il prezzo e 4 per la quantità");
        int scelta = int.Parse(Console.ReadLine());

        try
        {
            switch (scelta)
            {
                //nome
                case 1:
                await ModificaNome(nome);
                break;
                //categoria
                case 2:
                await ModificaCategoria(nome);
                break;
                //prezzo
                case 3:
                await ModificaPrezzo(nome);
                break;
                //quantità
                case 4:
                await ModificaQuantità(nome);
                break;
                default:
                Console.WriteLine("numero non valido");
                break;        
            }
        }
        //formato errato
        catch(FormatException)
        {
            Console.WriteLine("Inserire un numero intero");
        }
        //errore generico
        catch(Exception ex)
        {
            Console.WriteLine($"Errore generico: {ex.Message}");
        }
        //operazione riuscita
        finally
        {
            Console.WriteLine("Operazione completata");
        }
    }

    //modifica nome
    async Task ModificaNome(string nome)
    {
        Console.WriteLine("Digita il nuovo nome");
        string nuovoNome = Console.ReadLine();

        var daModificare = await ctx.Prodotti
        .Where( p => p.Nome == nome)
        .FirstOrDefaultAsync();

        daModificare.Nome = nuovoNome;
        await ctx.SaveChangesAsync();
        Console.WriteLine($"Prodotto modificato: Nome: {daModificare.Nome} - Categoria: {daModificare.Categoria} - Prezzo: {daModificare.Prezzo} - Quantità: {daModificare.Qt}");
    }

    //modifica categoria
    async Task ModificaCategoria(string nome)
    {
        Console.WriteLine("Digita la nuova categoria");
        string cat = Console.ReadLine();
        
        var daModificare = await ctx.Prodotti
        .Where( p => p.Nome == nome)
        .FirstOrDefaultAsync();

        daModificare.Categoria = cat;
        await ctx.SaveChangesAsync();
        Console.WriteLine($"Prodotto modificato: Nome: {daModificare.Nome} - Categoria: {daModificare.Categoria} - Prezzo: {daModificare.Prezzo} - Quantità: {daModificare.Qt}");
    }

    //modifica prezzo
    async Task ModificaPrezzo(string nome)
    {
        Console.WriteLine("Digita il nuovo prezzo");
        double prezzo = double.Parse(Console.ReadLine());
        
        var daModificare = await ctx.Prodotti
        .Where( p => p.Nome == nome)
        .FirstOrDefaultAsync();

        daModificare.Prezzo = prezzo;
        await ctx.SaveChangesAsync();
        Console.WriteLine($"Prodotto modificato: Nome: {daModificare.Nome} - Categoria: {daModificare.Categoria} - Prezzo: {daModificare.Prezzo} - Quantità: {daModificare.Qt}");
    }
    //modifica quantità
    async Task ModificaQuantità(string nome)
    {
        Console.WriteLine("Digita la nuova quantità");
        int qt = int.Parse(Console.ReadLine());
        
        var daModificare = await ctx.Prodotti
        .Where( p => p.Nome == nome)
        .FirstOrDefaultAsync();

        daModificare.Qt = qt;
        await ctx.SaveChangesAsync();
        Console.WriteLine($"Prodotto modificato: Nome: {daModificare.Nome} - Categoria: {daModificare.Categoria} - Prezzo: {daModificare.Prezzo} - Quantità: {daModificare.Qt}");
    }
}