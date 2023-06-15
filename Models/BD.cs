using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Dapper;
namespace TP06_CZERNUSZKA_KOZIUPA.Models;

public static class BD{
    private static string _connectionString = @"Server=localhost;DataBase=Elecciones2023;Trusted_Connection=True;";

    public static void AgregarCandidatos(Candidato can){

    }
    public static void EliminarCandidato(int IdCandidato){
        
    }
}