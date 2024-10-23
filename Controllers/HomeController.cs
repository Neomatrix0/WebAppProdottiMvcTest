/*

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.IO;

public class HomeController : Controller
{
    private readonly string prodottiFilePath = "wwwroot/json/prodotti.json";

    // Metodo per leggere i prodotti dal file JSON
    private List<Prodotto> LeggiProdottiDaJson()
    {
        var jsonData = System.IO.File.ReadAllText(prodottiFilePath);
        return JsonConvert.DeserializeObject<List<Prodotto>>(jsonData) ?? new List<Prodotto>();
    }

     public IActionResult Privacy()
    {
        return View();
    }

     public IActionResult Contatti()
    {
        return View();
    }

    public IActionResult Index()
    {
        // Carica i prodotti dal file JSON
        var prodotti = LeggiProdottiDaJson();

        // Estrai 5 prodotti casuali da mostrare nel carosello
        var randomProdotti = prodotti.OrderBy(x => Guid.NewGuid()).Take(5).ToList();

        // Crea il ViewModel con i prodotti casuali
        var viewModel = new IndexViewModel
        {
            RandomProdotti = randomProdotti
        };

        return View(viewModel); // Passa il ViewModel alla vista
    }
}

*/


using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.IO;

public class HomeController : Controller
{
    private readonly string prodottiFilePath = "wwwroot/json/prodotti.json";

    // Metodo per leggere i prodotti dal file JSON
    private List<Prodotto> LeggiProdottiDaJson()
    {
        var jsonData = System.IO.File.ReadAllText(prodottiFilePath);
        return JsonConvert.DeserializeObject<List<Prodotto>>(jsonData) ?? new List<Prodotto>();
    }

    // Azione per la pagina Privacy
    public IActionResult Privacy()
    {
        return View();
    }

    // Azione per la pagina Contatti
    public IActionResult Contatti()
    {
        return View();
    }

    // Azione per la pagina Index (Home)
    public IActionResult Index()
    {
        // Carica i prodotti dal file JSON
        var prodotti = LeggiProdottiDaJson();

        // Estrai 5 prodotti casuali da mostrare nel carosello
        var randomProdotti = prodotti.OrderBy(x => Guid.NewGuid()).Take(5).ToList();

        // Crea il ViewModel con i prodotti casuali
        var viewModel = new IndexViewModel
        {
            RandomProdotti = randomProdotti
        };

        return View(viewModel); // Passa il ViewModel alla vista
    }
}
