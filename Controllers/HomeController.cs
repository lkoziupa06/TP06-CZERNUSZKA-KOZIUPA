﻿using System.Diagnostics;
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
        ViewBag.ListaPartidos = BD.ListarPartidos();
        return View();
    }
    public IActionResult VerDetallePartido(int IdPartido){
        ViewBag.Detalles = BD.VerInfoPartido(IdPartido);
        ViewBag.Candidatos = BD.ListarCandidatos(IdPartido);    
        return View("DetallePartido");
    }
    public IActionResult VerDetalleCandidato(int IdCandidato){
        ViewBag.DetalleCandidato = BD.VerInfoCandidato(IdCandidato);
        return View("DetalleCandidato");
    }
    public IActionResult AgregarCandidato(int idPartido){
        ViewBag.IdPartido = idPartido;
        return View("AgregarCandidato");
    }
    [HttpPost]
    public IActionResult GuardarCandidato(Candidato can){
        BD.AgregarCandidatos(can);
        ViewBag.Detalles = BD.VerInfoPartido(can.IdPartido);
        ViewBag.Candidatos = BD.ListarCandidatos(can.IdPartido); 
        return View("DetallePartido");
    }
    public IActionResult EliminarCandidato(int IdCandidato, int IdPartido){
        BD.EliminarCandidato(IdCandidato);
        ViewBag.Detalles = BD.VerInfoPartido(IdPartido);
        ViewBag.Candidatos = BD.ListarCandidatos(IdPartido); 
        return View("DetallePartido");
    }
    public IActionResult Elecciones(){
        return View();
    }
    public IActionResult Creditos(){
        return View();
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
