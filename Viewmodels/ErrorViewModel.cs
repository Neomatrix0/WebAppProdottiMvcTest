namespace WebAppProdottiMvcTest.Models;
// ViewModel per la gestione degli errori
public class ErrorViewModel
{
     // Proprietà per memorizzare l'ID della richiesta (RequestId), utile per tracciare richieste specifiche nel caso di errori.
    public string? RequestId { get; set; }

// Proprietà che restituisce un valore booleano che indica se visualizzare o meno l'ID della richiesta.
 // Ritorna true solo se RequestId non è null o vuoto.
    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
