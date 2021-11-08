using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McSystemOpenBuyProV2
{
    public class PRODUCTO
    {
        int idProducto;

        public int IdProducto
        {
            get { return idProducto; }
            set { idProducto = value; }
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
        string codigoBarra;

        public string CodigoBarra
        {
            get { return codigoBarra; }
            set { codigoBarra = value; }
        }
        int diasGarantia;

        public int DiasGarantia
        {
            get { return diasGarantia; }
            set { diasGarantia = value; }
        }
        double precioCompra;

        public double PrecioCompra
        {
            get { return precioCompra; }
            set { precioCompra = value; }
        }
        double precioVenta;

        public double PrecioVenta
        {
            get { return precioVenta; }
            set { precioVenta = value; }
        }
        double descuento;

        public double Descuento
        {
            get { return descuento; }
            set { descuento = value; }
        }
        double stock;

        public double Stock
        {
            get { return stock; }
            set { stock = value; }
        }
        DateTime fechaCaptura;

        public DateTime FechaCaptura
        {
            get { return fechaCaptura; }
            set { fechaCaptura = value; }
        }
        int status;

        public int Status
        {
            get { return status; }
            set { status = value; }
        }
        int categoria_fk;

        public int Categoria_fk
        {
            get { return categoria_fk; }
            set { categoria_fk = value; }
        }
        int marca_fk;

        public int Marca_fk
        {
            get { return marca_fk; }
            set { marca_fk = value; }
        }
        int proveedor_fk;

        public int Proveedor_fk
        {
            get { return proveedor_fk; }
            set { proveedor_fk = value; }
        }

        public PRODUCTO(int idProducto, string descripcion, string codigoInterno, string codigoBarra, int diasGarantia,
            double precioCompra, double precioVenta, double descuento, double stock, DateTime fechaCaptura, int status, 
            int categoria_fk, int marca_fk, int proveedor_fk) 
        {
            this.IdProducto = idProducto;
            this.Descripcion = descripcion;
            this.CodigoInterno = codigoInterno;
            this.CodigoBarra = codigoBarra;
            this.DiasGarantia = diasGarantia;
            this.PrecioCompra = precioCompra;
            this.PrecioVenta = precioVenta;
            this.Descuento = descuento;
            this.Stock = stock;
            this.FechaCaptura = fechaCaptura;
            this.Status = status;
            this.Categoria_fk = categoria_fk;
            this.Marca_fk = marca_fk;
            this.Proveedor_fk = proveedor_fk;
        }

        public PRODUCTO()
        {
            // TODO: Complete member initialization
        }

    }
}
