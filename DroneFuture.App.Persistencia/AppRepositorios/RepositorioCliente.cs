using System;
using System.Collections.Generic;
using System.Linq;
using DroneFuture.App.Dominio;
using Microsoft.EntityFrameworkCore;
using DroneFuture.App.Persistencia.AppRepositorios;

namespace DroneFuture.App.Persistencia.AppRepositorios 
{
    public class RepositorioCliente : IRepositorioCliente
    {
        private readonly AppContext _appContext;
        /// <param name="appContext"></param>//
        public RepositorioCliente(AppContext appContext)
        {
            _appContext = appContext;
        }

        Cliente IRepositorioCliente.AddCliente(Cliente cliente)
        {
            var clienteAdicionado = _appContext.Clientes.Add(cliente);
            _appContext.SaveChanges();
            return clienteAdicionado.Entity;
        }

        Encargado IRepositorioCliente.AddEncargado(Encargado encargado)
        {
            var encargadoAdicionado = _appContext.Encargados.Add(encargado);
            _appContext.SaveChanges();
            return encargadoAdicionado.Entity;
        }

        PaquetePedido IRepositorioCliente.AddPedido(PaquetePedido pedido)
        {
            var pedidoNuevo = _appContext.PaquetePedidos.Add(pedido);
            _appContext.SaveChanges();
            return pedidoNuevo.Entity;
        }

        Encargado IRepositorioCliente.AsignarEncargadoPedido(int idPedido, int idEncargado)
        {
            var pedidoEncontrado = _appContext.PaquetePedidos.FirstOrDefault(p => p.Id == idPedido);
            if(pedidoEncontrado != null){
                var encargadoEncontrado = _appContext.Encargados.FirstOrDefault(m => m.Id == idEncargado);
                if(encargadoEncontrado != null){
                    pedidoEncontrado.pEncargado = encargadoEncontrado;
                    _appContext.SaveChanges();
                }
                return encargadoEncontrado;
            }
            return null;
        }

        Encargado IRepositorioCliente.AsignarEncargadoCliente(int idCliente, int idEncargado)
        {
            var clienteEncontrado = _appContext.Clientes.FirstOrDefault(c => c.Id == idCliente);
            if(clienteEncontrado != null){
                var encargadoEncontrado = _appContext.Encargados.FirstOrDefault(d => d.Id == idEncargado);
                if(encargadoEncontrado != null){
                    clienteEncontrado.pEncargado = encargadoEncontrado;
                    _appContext.SaveChanges();
                }
                return encargadoEncontrado;
            }
            return null;
        }

        EstadoPedido IRepositorioCliente.AddEstado(EstadoPedido estado)
        {
            var estadoAdicionado = _appContext.EstadoPedidos.Add(estado);
            _appContext.SaveChanges();
            return estadoAdicionado.Entity;
        }

        EstadoPedido IRepositorioCliente.AsignarEstado(int idPedido, int idEstado)
        {
            var pedidoEncontrado = _appContext.PaquetePedidos.FirstOrDefault(p => p.Id == idPedido);
            if(pedidoEncontrado != null){
                var estadoEncontrado = _appContext.EstadoPedidos.FirstOrDefault(m => m.Id == idEstado);
                if(estadoEncontrado != null){
                    pedidoEncontrado.pEstado = estadoEncontrado;
                    _appContext.SaveChanges();
                }
                return estadoEncontrado;
            }
            return null;
        }

        IEnumerable<PaquetePedido> IRepositorioCliente.GetAllPedidos()
        {
            return _appContext.PaquetePedidos;
            _appContext.SaveChanges();
        }

        public PaquetePedido GetInfoPedido(int idPedido)
        {
            return _appContext.PaquetePedidos.FirstOrDefault(s => s.Id == idPedido);
        }

        public Cliente GetClienteconPedido(int idPedido)
        {
            var pedido = _appContext.PaquetePedidos.Where(d => d.Id == idPedido).Include(d => d.pCliente).FirstOrDefault();
            return pedido.pCliente;
        }

        public PaquetePedido UpdatePedido(PaquetePedido pedidoActualizado)
        {
            var pedido = _appContext.PaquetePedidos.FirstOrDefault(r => r.Id == pedidoActualizado.Id);
            if(pedido!=null){
                pedido.EstadoFinalizacion = pedidoActualizado.EstadoFinalizacion;
                pedido.Satisfaccion = pedidoActualizado.Satisfaccion;
                _appContext.SaveChanges();
            }
            return pedido;
        }

        public PaquetePedido UpdatePedido2(PaquetePedido pedidoActualizado)
        {
            var pedido = _appContext.PaquetePedidos.FirstOrDefault(r => r.Id == pedidoActualizado.Id);
            if(pedido!=null){
                pedido.Satisfaccion = pedidoActualizado.Satisfaccion;
                _appContext.SaveChanges();
            }
            return pedido;
        }

        public EstadoPedido GetEstado(int idEstado)
        {
            return _appContext.EstadoPedidos.FirstOrDefault(c => c.Id == idEstado);
        }

        public EstadoPedido UpdateEstado(EstadoPedido estadoActualizado)
        {
            var estado = _appContext.EstadoPedidos.FirstOrDefault(d => d.Id == estadoActualizado.Id);
            if(estado!=null){
                estado.TemperaturaZona = estadoActualizado.TemperaturaZona;
                estado.EstadoDron = estadoActualizado.EstadoDron;
                estado.EstadoEmpaque = estadoActualizado.EstadoEmpaque;
                estado.TiempoLlegada = estadoActualizado.TiempoLlegada;
                _appContext.SaveChanges();
            }
            return estado;
        }

        void IRepositorioCliente.DeletePedido(int idPedido)
        {
            var pedidoEncontrado = _appContext.PaquetePedidos.FirstOrDefault(p => p.Id == idPedido);
            var estadoEncontrado = _appContext.EstadoPedidos.FirstOrDefault(c => c.Id == idPedido);
            var pedidoEncontrado2 = _appContext.PaquetePedidos.Where(d => d.Id == idPedido).Include(d => d.pCliente).FirstOrDefault();
        
            if(pedidoEncontrado == null){
                return;
            }
            _appContext.PaquetePedidos.Remove(pedidoEncontrado);
            _appContext.EstadoPedidos.Remove(estadoEncontrado);
            _appContext.Clientes.Remove(pedidoEncontrado2.pCliente);
            _appContext.SaveChanges();

        }

        void IRepositorioCliente.DeleteCliente(int idPedido)
        {
            var pedidoEncontrado = _appContext.PaquetePedidos.Where(d => d.Id == idPedido).Include(d => d.pCliente).FirstOrDefault();
            if(pedidoEncontrado == null){
                return;
            }
            _appContext.Clientes.Remove(pedidoEncontrado.pCliente);
            _appContext.SaveChanges();
        }

        public EstadoPedido GetEstadoPedido(int idPedido)
        {
            var pedido = _appContext.PaquetePedidos.Where(d => d.Id == idPedido).Include(d => d.pEstado).FirstOrDefault();
            return pedido.pEstado;
        }

        public Encargado GetEncargadoPedido(int idPedido)
        {
            var pedido = _appContext.PaquetePedidos.Where(d => d.Id == idPedido).Include(d => d.pEncargado).FirstOrDefault();
            return pedido.pEncargado;
        }

        public Encargado GetEncargado(int idEncargado)
        {
            var encargado = _appContext.Encargados.FirstOrDefault(c => c.Id == idEncargado);
            return encargado;
        }
    }
}