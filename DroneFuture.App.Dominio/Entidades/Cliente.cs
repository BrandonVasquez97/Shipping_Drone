using System;
namespace DroneFuture.App.Dominio
{
    public class Cliente : Persona
    {
        public string DireccionEntrega {get;set;}
        public Encargado pEncargado {get;set;}

        
    }


}