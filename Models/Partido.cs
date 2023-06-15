using System;
using System.Collections.Generic;

namespace TP06_CZERNUSZKA_KOZIUPA.Models;

public class Partido{
    public int IdPartido {get;set;}
    public string Nombre {get;set;}
    public string Logo {get;set;}
    public string SitioWeb {get;set;}
    public DateTime FechaFundacion {get;set;}
    public int CantidadDiputados {get;set;}
    public int CantidadSenadores {get;set;}


    
}