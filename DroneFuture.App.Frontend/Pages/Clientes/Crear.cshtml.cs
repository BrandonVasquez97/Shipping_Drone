using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DroneFuture.App.Persistencia.AppRepositorios;
using DroneFuture.App.Dominio;

namespace DroneFuture.App.Frontend.Pages
{
    public class CrearModel : PageModel
    {
        private static IRepositorioCliente _repoCliente = new RepositorioCliente(new Persistencia.AppContext());
        [BindProperty]
        public PaquetePedido Pedido {get;set;}
        [BindProperty]
        public Cliente Cliente {get;set;}
        [BindProperty]
        public EstadoPedido Estado {get;set;}

        
        public void OnGet()
        {
            Cliente = new Cliente();
            

        }

        public IActionResult OnPost()
        {
            Cliente = _repoCliente.AddCliente(Cliente);

            var estado = new EstadoPedido
            {
                TemperaturaZona = "--",
                EstadoDron = "--",
                EstadoEmpaque = "--",
                TiempoLlegada = 25
            };
            _repoCliente.AddEstado(estado);

            var pedido = new PaquetePedido
            {
                EstadoFinalizacion = "Pendiente",
                Satisfaccion = "No registrada",
                pCliente = Cliente,
                pEstado = estado
                
            };
            _repoCliente.AddPedido(pedido);
            

            return RedirectToPage("./Creado");
        }
    }
}
