using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using UrsinhosCarinhosos.Models;
using UrsinhosCarinhosos.Services;
namespace UrsinhosCarinhosos.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUrsosService _ursosService;

    public HomeController(ILogger<HomeController> logger, IUrsosService ursosService)
    {
        _logger = logger;
        _ursosService = ursosService;
    }


    public IActionResult Index(string personagem)
    {
        var perso = _ursosService.GetUrsoDto();
        ViewData["filter"] = string.IsNullOrEmpty(personagem) ? "all" : personagem;
        return View(perso);
    }

        public IActionResult Details(int Numero)
    {
        var personagens = _ursosService.GetDetailedPersonagem(Numero);
        return View(personagens);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id 
        ?? HttpContext.TraceIdentifier });
    }
}
