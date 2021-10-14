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
    public class ResultadoModel : PageModel
    {
        private static IRepositorioCliente _repoCliente = new RepositorioCliente(new Persistencia.AppContext());
        [BindProperty]
        public PaquetePedido Pedido {get;set;}
        [BindProperty]
        public PaquetePedido Pedido2 {get;set;}
        [BindProperty]
        public Cliente Cliente {get;set;}
        [BindProperty]
        public EstadoPedido Estado {get;set;}

        public IActionResult OnGet(int idPedido)
        {
            if(!ModelState.IsValid){
                return RedirectToPage("./Consulta");
            }
            
            
            Pedido2 = _repoCliente.GetInfoPedido(idPedido);

            if(Pedido2 == null){
                return RedirectToPage("./Consulta");
            }else{
                Pedido = _repoCliente.GetInfoPedido(idPedido);
                Estado = _repoCliente.GetEstadoPedido(idPedido);
                return Page();
            }
            
        }

        public IActionResult OnPost()
        {
            
            
           Pedido = _repoCliente.UpdatePedido2(Pedido);
            

            return Page();
        }
    }
}
