 using Newtonsoft.Json;
 public class ProdottiService{
 
  private readonly ILogger<ProdottiService> _logger;
        private readonly string prodottiFilePath = "wwwroot/json/prodotti.json"; // Path del file prodotti
        private readonly string categorieFilePath = "wwwroot/json/categorie.json"; // Path del file categorie

        public ProdottiService(ILogger<ProdottiService> logger)
        {
            _logger = logger;
        }

  // Metodo per leggere i prodotti dal file JSON
 public List<Prodotto> LeggiProdottiDaJson()
    {
        // Legge il contenuto del file prodotti.json
        var jsonData = System.IO.File.ReadAllText(prodottiFilePath);
        // Deserializza il contenuto in una lista di oggetti Prodotto
        return JsonConvert.DeserializeObject<List<Prodotto>>(jsonData) ?? new List<Prodotto>();
    }

    // Metodo per salvare i prodotti nel file JSON
  public void SalvaProdottiSuJson(List<Prodotto> prodotti)
{
    try
    {
        // Serializza la lista di prodotti in formato JSON
        var jsonData = JsonConvert.SerializeObject(prodotti, Formatting.Indented);
        // Scrive il JSON nel file prodotti.json
        System.IO.File.WriteAllText(prodottiFilePath, jsonData);
        _logger.LogInformation("Product list successfully written to JSON.");
    }
    catch (Exception ex)
    {
        _logger.LogError("Error writing to JSON file: {Message}", ex.Message);
    }
}



    // Metodo per leggere le categorie dal file JSON

    public List<string> LeggiCategorieDaJson()
{
    try
    {
        var jsonData = System.IO.File.ReadAllText(categorieFilePath);
        _logger.LogInformation("Categorie JSON loaded: " + jsonData); // Log per il JSON data
        // Deserializza il JSON in una lista di stringhe (categorie)
        return JsonConvert.DeserializeObject<List<string>>(jsonData) ?? new List<string>();
    }
    catch (Exception ex)
    {
        // Registra un messaggio di errore se si verifica un'eccezione durante la lettura
        _logger.LogError("Error reading categorie.json: " + ex.Message);
        return new List<string>(); // Ritorna una lista vuota se c'è un errore
    }
}  

 // Metodo per trovare un prodotto in base al suo ID
    public Prodotto TrovaProdottoPerId(int id)
    {
        // Legge tutti i prodotti dal file JSON
        var prodotti = LeggiProdottiDaJson();
        // Restituisce il prodotto corrispondente all'ID, oppure null se non viene trovato
        return prodotti.FirstOrDefault(p => p.Id == id);
    }

  // Azione per visualizzare la conferma della cancellazione di un prodotto
    public void  CancellaProdotto(int id)
    {
        var prodotti = LeggiProdottiDaJson();
        var prodotto = prodotti.Find(p => p.Id == id); // Cerca il prodotto per ID

      if (prodotto != null)
        {
            // Se il prodotto esiste, lo rimuove dalla lista
            prodotti.Remove(prodotto);

            // Salva la lista aggiornata di prodotti nel file JSON
            SalvaProdottiSuJson(prodotti);
        }
      
    }  

    // Filtraggio per prezzo e paginazione
    public List<Prodotto> FiltraProdotti(int? minPrezzo, int? maxPrezzo)
    {
        var prodotti = LeggiProdottiDaJson();

// Filtra i prodotti con un prezzo maggiore o uguale al prezzo minimo
        if (minPrezzo.HasValue)
        {
            
            prodotti = prodotti.Where(p => p.Prezzo >= minPrezzo.Value).ToList();
        }

        // Filtra i prodotti con un prezzo minore o uguale al prezzo massimo
        if (maxPrezzo.HasValue)
        {
            prodotti = prodotti.Where(p => p.Prezzo <= maxPrezzo.Value).ToList();
        }

        return prodotti;
    }

// Metodo per eseguire la paginazione su una lista di prodotti
    public List<Prodotto> PaginazioneProdotti(List<Prodotto> prodotti, int pageIndex, int numeroProdottiPerPagina)
    {
        // Restituisce i prodotti della pagina corrente in base all'indice di pagina e al numero di prodotti per pagina
        return prodotti.Skip((pageIndex - 1) * numeroProdottiPerPagina).Take(numeroProdottiPerPagina).ToList();
    }


 }     