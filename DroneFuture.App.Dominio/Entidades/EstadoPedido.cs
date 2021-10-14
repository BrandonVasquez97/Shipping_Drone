using System;
namespace DroneFuture.App.Dominio
{
    public class EstadoPedido
    {
        public int Id {get;set;}
        public string TemperaturaZona {get;set;}
        public string EstadoDron {get;set;}
        public string EstadoEmpaque {get;set;}
        public int TiempoLlegada {get;set;}
    }
}