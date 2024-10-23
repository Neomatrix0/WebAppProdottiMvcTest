//ProdottiViewModel serve per visualizzare una lista di prodotti filtrata e paginata 
//permettendo all'utente di vedere solo una parte del catalogo dei prodotti in base ai filtri applicati (prezzo) e alla pagina corrente

public class ProdottiViewModel
    {


    //  collezione di oggetti Prodotto che rappresenta i prodotti da visualizzare nella vista
        public IEnumerable<Prodotto> Prodotti { get; set; }
        public decimal MinPrezzo { get; set; }
        public decimal MaxPrezzo { get; set; }
        public int NumeroPagine { get; set; }
    }