using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using UrsinhosCarinhosos.Models;

namespace UrsinhosCarinhosos.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUrsiService_ursiService;

    public HomeController(ILogger<HomeController> logger, IUrsiService ursiService)
    {
        _logger = logger;
        _ursiService= ursiService;
    }

    public IActionResult Index(string tipo)
    {
        var ursi = ursiSevice.GetUrsinhoDto();
        ViewData[ "filter"] = string.IsNullOrEmpty(tipo)? "all" : tipo;
        return View(ursi);
    }

    public IActionResult Privacy()
    {
        var ursi = ursiService.GetDetaielUrsinho(Numero);
        return View(ursinho);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
     public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id 
            ?? HttpContext.TraceIndentfier });
    }
}
