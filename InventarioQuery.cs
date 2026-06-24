using Microsoft.EntityFrameworkCore;

public class InventarioQuery
{
    //database
    private readonly InventarioContext ctx;
    public InventarioQuery(InventarioContext  ctx)
    {
        this.ctx = ctx;
    }

    //ricerca
    public async Task Ricerca(string nome, string cat, int min, int max, int ord)
    {
        var ricerca = ctx.Prodotti.AsQueryable();
        if(nome!= null) ricerca = ricerca.Where(p => p.Nome == nome);
        if(cat!=null) ricerca = ricerca.Where(p => p.Categoria == cat);
        ricerca = ricerca.Where(p => p.Prezzo > min && p.Prezzo < max);
        if(ord == 1) ricerca = ricerca.OrderBy( p => p.Nome);
        if(ord == 2) ricerca = ricerca.OrderBy( p => p.Prezzo);
        var risultato = await ricerca.ToListAsync();

        foreach(Prodotto p in risultato)
        {
            Console.WriteLine($"Nome: {p.Nome} - Categoria: {p.Categoria} - Prezzo: {p.Prezzo} - Quantità: {p.Qt}");
        }
    }

    //report
    public async Task Report()
    {
        int totProdotti = await ctx.Prodotti.CountAsync();
        double valoreProdotti = await ctx.Prodotti.SumAsync(p=> p.Prezzo * p.Qt);
        var sottoScorta = await ctx.Prodotti.Where(p => p.Qt < 3).ToListAsync();

        Console.WriteLine($"totale prodotti: {totProdotti} - valore totale: {valoreProdotti}");
        foreach(Prodotto p in sottoScorta)
        {
            Console.WriteLine($"Prodotto sotto scorta: Nome: {p.Nome} - Categoria: {p.Categoria} - Prezzo: {p.Prezzo} - Quantità: {p.Qt}");
        }
    }
}