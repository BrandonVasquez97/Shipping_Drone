using System;
using DroneFuture.App.Dominio;
using DroneFuture.App.Persistencia.AppRepositorios;

namespace DroneFuture.App.Consola
{
    class Program
    {
        private static IRepositorioCliente _repoCliente = new RepositorioCliente(new Persistencia.AppContext());

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //AddCliente();
            AddEncargado();
            //AddEstado();
            //AsignarEncargadoPedido();
            //AsignarEstado();
        }

        private static void AddCliente()
        {

            var cliente = new Cliente
            {
                Nombre = "Maria",
                Apellidos = "Suarez",
                NumeroCelular = "3033535873",
                DireccionEntrega = "Calle 12 #6B-46 Barranquilla, Atlantico"
            };
            _repoCliente.AddCliente(cliente);

            var pedido = new PaquetePedido
            {
                EstadoFinalizacion = "Pendiente",
                Satisfaccion = "No registrada",
                pCliente = cliente
                
            };
            _repoCliente.AddPedido(pedido);
        }

        private static void AddEncargado()
        {
            var encargado = new Encargado
            {
                Nombre = "Juan",
                Apellidos = "Macias",
                NumeroCelular = "3154578585",
                IdEmpleado = 2
            };
            _repoCliente.AddEncargado(encargado);
        }

        private static void AsignarEncargadoPedido()
        {
            var encargado = _repoCliente.AsignarEncargadoPedido(1, 2);
            var encargado2 = _repoCliente.AsignarEncargadoCliente(3, 2); //ver como asignar encargado al cliente tambien
        }

        private static void AddEstado()
        {
            var estado = new EstadoPedido
            {
                TemperaturaZona = "23°C",
                EstadoDron = "Estable",
                EstadoEmpaque = "Intacto",
                TiempoLlegada = 30
            };
            _repoCliente.AddEstado(estado);
        }

        private static void AsignarEstado()
        {
            var estado = _repoCliente.AsignarEstado(1, 1);
        }
    }
}
