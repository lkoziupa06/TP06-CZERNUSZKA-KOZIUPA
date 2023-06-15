using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP06_CZERNUSZKA_KOZIUPA.Models;

namespace TP06_CZERNUSZKA_KOZIUPA.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.ListarPartidos = BD.ListarPartidos();
        return View();
    }
    public IActionResult VerDetallePartido(int IdPartido){
        ViewBag.Detalles = BD.VerInfoPartido(IdPartido);
        ViewBag.Candidatos = BD.ListarCandidatos(IdPartido);    
        return View("DetallePartido"+IdPartido);
    }
    public IActionResult VerDetalleCandidato(int IdCandidato){
        ViewBag.DetalleCandidato = BD.VerInfoCandidato(IdCandidato);
        return View("DetalleCandidato"+IdCandidato);
    }
    public IActionResult AgregarCandidato(int idPartido, Candidato can){
        ViewBag.IdPartido = idPartido;
        BD.AgregarCandidatos(can);
        return View("FormularioAdd");
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
