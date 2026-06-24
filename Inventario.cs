
public interface IInventario
{
    public Task Aggiungi(string n, string c, double p, int q);
    public Task Rimuovi(string n);
    public Task Modifica(string n);
    public Task<bool> ControllaEsistenza(string n);
}