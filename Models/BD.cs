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
        string sql = "INSERT INTO Candidatos(IdPartido, Apellido, Nombre, FechaNacimiento, Foto, Postulacion) VALUES (@IdPartido, @Apellido, @Nombre, @FechaNacimiento, @Foto, @Postulacion) ";
        using (SqlConnection BD = new SqlConnection(_connectionString)){
            BD.Execute(sql, new {can});
        }
    }
    public static void EliminarCandidato(int IdCandidato){
        string sql = "DELETE FROM Candidatos WHERE IdCandidato = @pIdCandidato";
        using(SqlConnection BD = new SqlConnection(_connectionString)){
            BD.Execute(sql, new {pIdCandidato = IdCandidato});
        }
    }
    public static Partido VerInfoPartido(int idPartido){
        Partido partidoBuscado = null;
        using (SqlConnection BD = new SqlConnection(_connectionString)){
            string sql = "SELECT * FROM Partidos WHERE IdPartido = @pIdPartido";
            partidoBuscado = BD.QueryFirstOrDefault<Partido>(sql, new{pIdPartido = idPartido});
        }
        return partidoBuscado;
    }
    public static Candidato VerInfoCandidato(int IdCandidato){
        Candidato candidatoBuscado = null;
        using (SqlConnection BD = new SqlConnection(_connectionString)){
            string sql = "SELECT * FROM Candidatos WHERE IdCandidato = @pIdCandidato";
            candidatoBuscado = BD.QueryFirstOrDefault<Candidato>(sql, new{pIdCandidato = IdCandidato});
        }
        return candidatoBuscado;
    }
    public static List<Partido> ListarPartidos(){
        List<Partido> listaPartidos = null;
        using(SqlConnection BD = new SqlConnection(_connectionString)){
            string sql = "SELECT * FROM Partidos";
            listaPartidos = BD.Query<Partido>(sql).ToList();
        }
        return listaPartidos;
    }
        public static List<Candidato> ListarCandidatos(int IdPartido){
        List<Candidato> listaCandidatos = null;
        using(SqlConnection BD = new SqlConnection(_connectionString)){
            string sql = "SELECT * FROM Candidatos WHERE IdPartido = @pIdPartido";
            listaCandidatos = BD.Query<Candidato>(sql, new{pIdPartido = IdPartido}).ToList();
        }
        return listaCandidatos;
    }
}