using System;
using System.Collections.Generic;
using System.Linq;
using DroneFuture.App.Dominio;
using DroneFuture.App.Persistencia.AppRepositorios;

namespace DroneFuture.App.Persistencia.AppRepositorios
{
    public interface IRepositorioCliente
    {
         IEnumerable<PaquetePedido> GetAllPedidos();
         Cliente AddCliente(Cliente cliente);
         Encargado AddEncargado(Encargado encargado);
         PaquetePedido AddPedido(PaquetePedido pedido);
         Encargado AsignarEncargadoPedido(int idEncargado, int idPedido);
         Encargado AsignarEncargadoCliente(int idEncargado, int idCliente);
         EstadoPedido AddEstado(EstadoPedido estado);
         EstadoPedido AsignarEstado(int idPedido, int idEstado);
         PaquetePedido GetInfoPedido(int idPedido);
         Cliente GetClienteconPedido(int idCliente);
         PaquetePedido UpdatePedido(PaquetePedido pedidoActualizado);
         PaquetePedido UpdatePedido2(PaquetePedido pedidoActualizado);
         EstadoPedido GetEstado(int idEstado);
         EstadoPedido UpdateEstado(EstadoPedido estadoActualizado);
         void DeletePedido(int idPedido);
         void DeleteCliente(int idPedido);
         EstadoPedido GetEstadoPedido(int idPedido);
         Encargado GetEncargadoPedido(int idPedido);
         Encargado GetEncargado(int idEncargado);
    }
}