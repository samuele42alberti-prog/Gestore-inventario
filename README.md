# Gestore Inventario

Applicazione console in C# per la gestione di un inventario prodotti, con persistenza su database SQLite tramite Entity Framework Core.

## Funzionalità

- **Aggiunta** prodotti con nome, categoria, prezzo e quantità
- **Rimozione** prodotti per nome
- **Modifica** di nome, categoria, prezzo o quantità
- **Ricerca** con filtri combinati (nome, categoria, fascia di prezzo) e ordinamento
- **Report** con valore totale dell'inventario e lista prodotti sotto scorta

## Tecnologie

- C# / .NET 10
- Entity Framework Core con SQLite
- LINQ per query e filtri
- Async/Await per operazioni asincrone sul database
- Principi OOP: classi, interfacce, separazione delle responsabilità

## Struttura del progetto

| File | Responsabilità |
|------|---------------|
| `Prodotto.cs` | Modello dati |
| `Inventario.cs` | Interfaccia con le operazioni CRUD |
| `InventarioService.cs` | Implementazione CRUD (aggiunta, rimozione, modifica) |
| `FileHelper.cs` | Ricerca e report |
| `InventarioContext.cs` | Configurazione Entity Framework Core |
| `Program.cs` | Entry point e interfaccia utente console |

## Requisiti

- .NET 10 SDK
- Pacchetto NuGet: `Microsoft.EntityFrameworkCore.Sqlite`

## Esecuzione

```bash
dotnet run
```

Il database viene creato automaticamente al primo avvio.
