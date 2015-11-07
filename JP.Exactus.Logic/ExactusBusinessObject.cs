﻿using JP.Exactus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JP.Exactus.Data;
using JP.Exactus.Data.ViewModelExactus;

namespace JP.Exactus.Logic
{
    public class ExactusBusinessObject : IExactusBusinessObject
    {

        private string Schema
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["schema"].ToString(); }
        }
       
        public bool ValidaUsuario(string usuario, string contraseña)
        {
            var exactus = new ExactusData(usuario, contraseña, Schema);
            return exactus.ValidaUsuario();
        }

        public List<BodegaViewModel> ObtenerBodega(string usuario, string contraseña)
        {
            var exactus = new ExactusData(usuario, contraseña, Schema);
            return exactus.ObtenerBodega();
        }

        public List<ClienteViewModel> ObtenerClientePorNombre(string usuario, string contraseña, string Nombre)
        {
            var exactus = new ExactusData(usuario, contraseña, Schema);
            return exactus.ObtenerClientePorNombre(Nombre);
        }

        public List<ClienteViewModel> ObtenerClientePorRuc(string usuario, string contraseña, string RucCedula)
        {
            var exactus = new ExactusData(usuario, contraseña, Schema);
            return exactus.ObtenerClientePorRuc(RucCedula);
        }

        public List<ArticuloViewModel> ObtenerArticulo(string usuario, string contraseña, string bodega, string articulo, string descripcion, string clasificacion1, string clasificacion2, string clasificacion3, string clasificacion4, string clasificacion5, string clasificacion6, string cliente)
        {
            var exactus = new ExactusData(usuario, contraseña, Schema);
            return exactus.ObtenerArticulo(bodega, articulo, descripcion, clasificacion1, clasificacion2, clasificacion3, clasificacion4, clasificacion5, clasificacion6, cliente);
        }

        public List<ConsecutivosViewModel> BuscarConsecutivo(string usuario, string contraseña)
        {
            var exactus = new ExactusData(usuario, contraseña, Schema);
            return exactus.BuscarConsecutivo(usuario);            
        }

        public string GrabarPedido(string usuario, string  contraseña, PedidoParametrosViewModel Pedidos, List<PedidoLineaParametrosViewModel> ListaPedidoLineas)
        {
            
            var exactus = new ExactusData(usuario, contraseña, Schema);
            return exactus.GrabarPedido(Pedidos, ListaPedidoLineas);

        }

        public void EliminarLinea(string usuario, string contraseña, List<PedidoLineaParametrosViewModel> PedidoLineaParametros)
        {
            var exactus = new ExactusData(usuario, contraseña, Schema);
            exactus.EliminarLinea(PedidoLineaParametros);

        }

        public void InsertarLineaNueva(string usuario, string contraseña,  List<PedidoLineaParametrosViewModel> PedidoLineaParametros)
        {
            var exactus = new ExactusData(usuario, contraseña, Schema);
            exactus.InsertarLineaNueva(PedidoLineaParametros);
        }

        public void EliminarPedidoCompleto(string usuario, string contraseña,  PedidoParametrosViewModel PedidoParametros)
        {
            var exactus = new ExactusData(usuario, contraseña, Schema);
            exactus.EliminarPedidoCompleto(PedidoParametros);
        }

        public List<ClasificacionViewModel> ObtenerClasificacion(string usuario, string contraseña, string agrupacion)
        {
            var exactus = new ExactusData(usuario, contraseña, Schema);
            return exactus.ObtenerClasificacion(agrupacion);
            
        }

        public List<TopPedidoViewModel> BuscarUltimosPedidos(string usuario, string contraseña)
        {
            var exactus = new ExactusData(usuario, contraseña,Schema);
            return exactus.BuscarUltimosPedidos(usuario);

        }

    }
}
