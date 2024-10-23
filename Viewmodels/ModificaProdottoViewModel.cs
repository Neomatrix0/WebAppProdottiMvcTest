public class ModificaProdottoViewModel
{
    // Questa proprietà rappresenta l'oggetto "Prodotto" che verrà modificato nel form di modifica
    public Prodotto Prodotto { get; set; }
    
    //  Questa proprietà poteva essere utilizzata per fornire una lista di categorie 
    // selezionabili nel form. È commentata perché al momento non è necessaria o non utilizzata.
    public List<string> Categorie { get; set; }
}
