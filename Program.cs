
//per ciclo while
bool continua = true;
//inventario context
InventarioContext ctx = new InventarioContext();
ctx.Database.EnsureCreated();
//inventario
InventarioService inventario = new InventarioService(ctx);
//file helper
InventarioQuery inventarioQuery = new InventarioQuery(ctx);

//ciclo principale
while(continua)
{
    try
    {
        //scelta: aggiungere, rimuovere, modificare, cercare, report o uscire
        Console.WriteLine("premi 1 per aggiungere un prodotto, 2 per rimuoverlo, 3 per modificarlo, 4 per cercarlo, 5 per un report e 6 per uscire");
        int scelta = int.Parse(Console.ReadLine());
        switch(scelta)
    {
        //aggiungi
        case 1:
        //inserisci dati
        Console.WriteLine("Digita il nome");
        string nom = Console.ReadLine();
        Console.WriteLine("Digita la categoria");
        string cate = Console.ReadLine();
        Console.WriteLine("Digita il prezzo");
        double pre = double.Parse(Console.ReadLine());
        Console.WriteLine("Digita la quantità");
        int qta = int.Parse(Console.ReadLine());

        //chiama Aggiungi()
        if(await inventario.ControllaEsistenza(nom)) Console.WriteLine($"{nom} già presente!");
        else await inventario.Aggiungi(nom, cate, pre, qta);
        break;

        //rimuovi
        case 2:
        //inserisci nome
        Console.WriteLine("Digita il nome del prodotto che vuoi rimuovere");
        string nome = Console.ReadLine();

        //chiama Rimuovi()
        if(await inventario.ControllaEsistenza(nome)) await inventario.Rimuovi(nome);
        else Console.WriteLine($"{nome} non trovato!");
        break;

        //modifica
        case 3:
        //inserisci nome
        Console.WriteLine("Digita il nome del prodotto che vuoi modificare");
        string nome1 = Console.ReadLine();

        //chiama modifica
        if(await inventario.ControllaEsistenza(nome1)) await inventario.Modifica(nome1);
        else Console.WriteLine($"{nome1} non trovato!");
        break;

        //ricerca
        case 4:
        //ricerca per nome
        Console.WriteLine("vuoi applicare ricerca per nome: 1 = si, 2 = no");
        int scelta2 = int.Parse(Console.ReadLine());
        bool perNome = scelta2 == 1;
        //ricerca per categoria
        Console.WriteLine("vuoi applicare ricerca per categoria: 1 = si, 2 = no");
        int scelta3 = int.Parse(Console.ReadLine());
        bool perCat = scelta3 == 1;
        //ricerca per prezzo
        Console.WriteLine("vuoi applicare ricerca per prezzo: 1 = si, 2 = no");
        int scelta4 = int.Parse(Console.ReadLine());
        bool perPrezzo = scelta4 == 1;

        //dichiara dati per filtro
        string nomeR;
        string catR;
        int minR;
        int maxR;

        //se ricerca per nome è stata scelta:
        if(perNome)
            {
                Console.WriteLine("Digita il nome del prodotto che vuoi cercare");
                nomeR = Console.ReadLine();
            }
            else
            {
                nomeR = null;
            }

        //se ricerca per categoria è stata scelta:
        if(perCat)
            {
                Console.WriteLine("Digita la categoria del prodotto che vuoi cercare");
                catR = Console.ReadLine();
            }
            else
            {
                catR = null;
            }

        //se ricerca per prezzo è stata scelta:
        if(perPrezzo)
            {
                Console.WriteLine("Digita il prezzo minimo");
                minR = int.Parse(Console.ReadLine());
                Console.WriteLine("Digita il prezzo massimo");
                maxR = int.Parse(Console.ReadLine());
            }
            else
            {
                minR = 0;
                maxR = 100000;
            }
        //ordine lista
        Console.WriteLine("Premi 1 per ottenere la lista in ordine alfabetico, 2 per ottenerla in ordine crescente di prezzo");
        int ord = int.Parse(Console.ReadLine());
        await inventarioQuery.Ricerca(nomeR, catR, minR, maxR, ord);
        break;

        //report
        case 5:
        await inventarioQuery.Report();
        break;

        //esci
        case 6:
        continua = false;
        Console.WriteLine("Programma terminato");
        break;

        //default
        default:
        Console.WriteLine("Numero non valido");
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



