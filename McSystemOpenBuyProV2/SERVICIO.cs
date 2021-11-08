using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McSystemOpenBuyProV2
{
    public class SERVICIO
    {
        int idServicio;

        public int IdServicio
        {
            get { return idServicio; }
            set { idServicio = value; }
        }
        string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        string codigoInterno;

        public string CodigoInterno
        {
            get { return codigoInterno; }
            set { codigoInterno = value; }
        }
        int diasGarantia;

        public int DiasGarantia
        {
            get { return diasGarantia; }
            set { diasGarantia = value; }
        }
        double precioLista;

        public double PrecioLista
        {
            get { return precioLista; }
            set { precioLista = value; }
        }
        double descuento;

        public double Descuento
        {
            get { return descuento; }
            set { descuento = value; }
        }
        int estatus;

        public int Estatus
        {
            get { return estatus; }
            set { estatus = value; }
        }

        public SERVICIO(int idServicio,string descripcion,string codigoInterno,int diasGarantia,double precioLista,double descuento,int estatus)
        {
            this.idServicio = idServicio;
            this.descripcion = descripcion;
            this.codigoInterno = codigoInterno;
            this.diasGarantia = diasGarantia;
            this.precioLista = precioLista;
            this.descuento = descuento;
            this.estatus = estatus;
        }

        public SERVICIO()
        {
            // TODO: Complete member initialization
        }
    }
}
