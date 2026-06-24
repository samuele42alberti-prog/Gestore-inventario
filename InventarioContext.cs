using Microsoft.EntityFrameworkCore;

public class InventarioContext : DbContext
{
    public DbSet<Prodotto> Prodotti { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder opts)
    {
        opts.UseSqlite("Data Source=C:\\Sviluppo\\EserciziCSharp\\Prodotti.db");
    }
}