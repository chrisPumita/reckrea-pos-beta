using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McSystemOpenBuyProV2
{
    public class DETAILS_Ticket
    {
        int idTicket;

        public int IdTicket
        {
            get { return idTicket; }
            set { idTicket = value; }
        }

        double subtotal;

        public double Subtotal
        {
            get { return subtotal; }
            set { subtotal = value; }
        }
        double iva;

        public double Iva
        {
            get { return iva; }
            set { iva = value; }
        }
        double descuento;

        public double Descuento
        {
            get { return descuento; }
            set { descuento = value; }
        }
        double total;

        public double Total
        {
            get { return total; }
            set { total = value; }
        }
        List<DETAIL_producto> listaDetalles;

        public List<DETAIL_producto> ListaDetalles
        {
            get { return listaDetalles; }
            set { listaDetalles = value; }
        }

        double cantidadProductos;

        public double CantidadProductos
        {
            get {
                double cant = 0;
                for (int i = 0; i < listaDetalles.Count; i++)
                    cant += ListaDetalles[i].Cantidad;
                cantidadProductos = cant;
                return cantidadProductos; 
            }
            set { cantidadProductos = value;}
        }

        DateTime fechaHora;

        public DateTime FechaHora
        {
            get { return fechaHora; }
            set { fechaHora = value; }
        }

        CLIENTE cliente;

        public CLIENTE Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }

        int formaPago;

        public int FormaPago
        {
            get { return formaPago; }
            set { formaPago = value; }
        }

        EMPLEADO empleado;

        public EMPLEADO Empleado
        {
            get { return empleado; }
            set { empleado = value; }
        }
        int facturar;

        public int Facturar
        {
            get { return facturar; }
            set { facturar = value; }
        }

        int estadoFactura;

        public int EstadoFactura
        {
            get { return estadoFactura; }
            set { estadoFactura = value; }
        }

        int noFactura;

        public int NoFactura
        {
            get { return noFactura; }
            set { noFactura = value; }
        }

        int estatusTicket;

        public int EstatusTicket
        {
            get { return estatusTicket; }
            set { estatusTicket = value; }
        }

        public string generaCodigo()
        {
            Random obj = new Random();
            string sCadena = "1234567890";
            int longitud = sCadena.Length;
            char cletra;
            int nlongitud = 4;
            string sNuevacadena = string.Empty;
            for (int i = 0; i < nlongitud; i++)
            {
                cletra = sCadena[obj.Next(longitud)];
                sNuevacadena += cletra.ToString();
            }

            DateTime hf = DateTime.Now;
            string year = hf.ToString("yyyy");
            int month = Convert.ToInt32(hf.ToString("MM"));
            string m = "";
            switch (month)
            {
                case 1:
                    m = "A";
                    break;
                case 2:
                    m = "B";
                    break;
                case 3:
                    m = "C";
                    break;
                case 4:
                    m = "D";
                    break;
                case 5:
                    m = "F";
                    break;
                case 6:
                    m = "G";
                    break;
                case 7:
                    m = "H";
                    break;
                case 8:
                    m = "X";
                    break;
                case 9:
                    m = "J";
                    break;
                case 10:
                    m = "K";
                    break;
                case 11:
                    m = "L";
                    break;
                case 12:
                    m = "M";
                    break;
                default:
                    m = "N";
                    break;
            }
            return sNuevacadena + hf.ToString("dd") + m + year.Substring(2, 2);
        }

        string codigoTicket;

        public string CodigoTicket
        {
            get { return codigoTicket; }
            set { codigoTicket = value; }
        }

        List<OrdenServicio> listaOrdenesServicios;

        public List<OrdenServicio> ListaOrdenesServicios
        {
            get { return listaOrdenesServicios; }
            set { listaOrdenesServicios = value; }
        }

        double cantidadServicios;

        public double CantidadServicios
        {
            get {
                double cant = 0;
                for (int i = 0; i < listaOrdenesServicios.Count; i++)
                    cant += listaOrdenesServicios[i].ListaServiciosDetails.Count;
                cantidadServicios = cant;
                return cantidadServicios; 
            }
            set { cantidadServicios = value; }
        }

        public DETAILS_Ticket(double subtotal,double iva,double descuento,double total,List<DETAIL_producto> listaDetalles, CLIENTE cliente)
        {
            this.Subtotal = subtotal;
            this.Iva = iva;
            this.Descuento = descuento;
            this.Total = total;
            this.ListaDetalles = listaDetalles;
            this.FechaHora = DateTime.Now;
            this.Cliente = cliente;
        }

        public DETAILS_Ticket(double subtotal, double iva, double descuento, double total, List<OrdenServicio> listaOrdenesServicio, CLIENTE cliente)
        {
            this.Subtotal = subtotal;
            this.Iva = iva;
            this.Descuento = descuento;
            this.Total = total;
            this.ListaOrdenesServicios = listaOrdenesServicio;
            this.FechaHora = DateTime.Now;
            this.Cliente = cliente;
        }

        public DETAILS_Ticket() { }

    }
}
