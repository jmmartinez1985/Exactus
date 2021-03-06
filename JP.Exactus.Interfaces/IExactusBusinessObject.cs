﻿using JP.Exactus.Data.ViewModelExactus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JP.Exactus.Interfaces
{
    public interface IExactusBusinessObject
    {
        bool ValidaUsuario(string usuario, string contraseña);
        List<BodegaViewModel> ObtenerBodega(string usuario, string contraseña);

        List<ClienteViewModel> ObtenerClientePorNombre(string usuario, string contraseña,string Nombre);

        List<ClienteViewModel> ObtenerClientePorRuc(string usuario, string contraseña,string RucCedula);

        List<ArticuloViewModel> ObtenerArticulo(string usuario, string contraseña,string bodega, string articulo, string descripcion, string clasificacion1, string clasificacion2, string clasificacion3, string clasificacion4, string clasificacion5, string clasificacion6, string cliente);

        List<ConsecutivosViewModel> BuscarConsecutivo(string usuario, string contraseñaa);
        string GrabarPedido(string usuario, string contraseña, PedidoParametrosViewModel Pedido, List<PedidoLineaParametrosViewModel> ListaPedidoLineas);

        void EliminarLinea(string usuario, string contraseña,  List<PedidoLineaParametrosViewModel> PedidoLineaParametros);
        void InsertarLineaNueva(string usuario, string contraseña,  List<PedidoLineaParametrosViewModel> PedidoLineaParametros);
        void EliminarPedidoCompleto(string usuario, string contraseña,  PedidoParametrosViewModel PedidoParametros);

        List<ClasificacionViewModel> ObtenerClasificacion(string usuario, string contraseña, string agrupacion);

        List<TopPedidoViewModel> BuscarUltimosPedidos(string usuario, string contraseña);
    }
}
