using System;
namespace DroneFuture.App.Dominio
{
    public class PaquetePedido
    {
        public int Id {get;set;}
        public string EstadoFinalizacion {get;set;}
        public string Satisfaccion {get;set;}
        public Cliente pCliente {get;set;}
        public Encargado pEncargado {get;set;}
        public EstadoPedido pEstado {get;set;}

        
    }
}