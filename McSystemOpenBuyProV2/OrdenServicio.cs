using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McSystemOpenBuyProV2
{
    public class OrdenServicio
    {
        int idOrdenServicio;

        public int IdOrdenServicio
        {
            get { return idOrdenServicio; }
            set { idOrdenServicio = value; }
        }
        EQUIPO equipo;

        public EQUIPO Equipo
        {
            get { return equipo; }
            set { equipo = value; }
        }
        DETAILS_Ticket ticket;

        public DETAILS_Ticket Ticket
        {
            get { return ticket; }
            set { ticket = value; }
        }
        string reporte_cliente;

        public string Reporte_cliente
        {
            get { return reporte_cliente; }
            set { reporte_cliente = value; }
        }
        string diagnositco_tecnico;

        public string Diagnositco_tecnico
        {
            get { return diagnositco_tecnico; }
            set { diagnositco_tecnico = value; }
        }
        DateTime fechaIngreso;

        public DateTime FechaIngreso
        {
            get { return fechaIngreso; }
            set { fechaIngreso = value; }
        }
        DateTime fechaEntregaEstimada;

        public DateTime FechaEntregaEstimada
        {
            get { return fechaEntregaEstimada; }
            set { fechaEntregaEstimada = value; }
        }
        DateTime fechaTerminoCancel;

        public DateTime FechaTerminoCancel
        {
            get { return fechaTerminoCancel; }
            set { fechaTerminoCancel = value; }
        }
        DateTime FechaEntregaFinal;

        public DateTime FechaEntregaFinal1
        {
            get { return FechaEntregaFinal; }
            set { FechaEntregaFinal = value; }
        }
        string notas;

        public string Notas
        {
            get { return notas; }
            set { notas = value; }
        }

        string notasOcultas;

        public string NotasOcultas
        {
            get { return notasOcultas; }
            set { notasOcultas = value; }
        }

        int estado_service;

        public int Estado_service
        {
            get { return estado_service; }
            set { estado_service = value; }
        }

        List<DETAILS_Servicio> listaServiciosDetails;

        public List<DETAILS_Servicio> ListaServiciosDetails
        {
            get { return listaServiciosDetails; }
            set { listaServiciosDetails = value; }
        }

    }
}
