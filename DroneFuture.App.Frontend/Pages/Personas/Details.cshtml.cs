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
    public class DetailsModel : PageModel
    {
        private static IRepositorioCliente _repoCliente = new RepositorioCliente(new Persistencia.AppContext());
        [BindProperty]
        public PaquetePedido Pedido {get;set;}
        [BindProperty]
        public Cliente Cliente {get;set;}
        [BindProperty]
        public Encargado Encargado {get;set;}
        [BindProperty]
        public Encargado Encargado2 {get;set;}
        

        public void OnGet(int idPedido)
        {
            Pedido = _repoCliente.GetInfoPedido(idPedido);
            
            Cliente = _repoCliente.GetClienteconPedido(idPedido);

            Encargado2 = _repoCliente.GetEncargadoPedido(idPedido);

            if(Encargado2==null){
                Encargado = new Encargado{Nombre = "No", Apellidos = "Asignado"};
            }else{
                Encargado = _repoCliente.GetEncargadoPedido(idPedido);
            }
   
        }

        public IActionResult OnPost(int idPedido)
        {
            Encargado2 = _repoCliente.GetEncargado(Encargado.Id);

            if(Encargado2==null){
                return RedirectToPage("./Employee2");
            }else{
                _repoCliente.AsignarEncargadoPedido(idPedido, Encargado.Id);
            

                return RedirectToPage("./Employee");
            }
            
        }
    }
}
