using System;


namespace DroneFuture.App.Dominio
{
    public class Empresa
    {
        public int Id {get;set;}
        public string Nit {get;set;}
        public string Nombre {get;set;}
        public Encargado pEncargado {get;set;}

        
    }
}