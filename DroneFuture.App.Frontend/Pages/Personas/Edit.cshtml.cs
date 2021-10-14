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
    public class EditModel : PageModel
    {
        private static IRepositorioCliente _repoCliente = new RepositorioCliente(new Persistencia.AppContext());
        [BindProperty]
        public PaquetePedido Pedido {get;set;}
        public Cliente Cliente {get;set;}
        [BindProperty]
        public EstadoPedido Estado {get;set;}
        
        public void OnGet(int idPedido)
        {
            Pedido = _repoCliente.GetInfoPedido(idPedido);
            Estado = _repoCliente.GetEstado(idPedido);

        }

        public IActionResult OnPost()
        {
            
            
           Pedido = _repoCliente.UpdatePedido(Pedido);
           Estado = _repoCliente.UpdateEstado(Estado);
            

            return Page();
        }

        
    }
}
