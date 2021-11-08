using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McSystemOpenBuyProV2
{
    public class DETAIL_producto
    {
        int idMovDetalleProducto;

        public int IdMovDetalleProducto
        {
            get { return idMovDetalleProducto; }
            set { idMovDetalleProducto = value; }
        }

        double cantidad = 0;

        public double Cantidad
        {
            get { return cantidad; }
            set { cantidad += value; }
        }
        PRODUCTO producto;

        public PRODUCTO Producto
        {
            get { return producto; }
            set { producto = value; }
        }

        double subtotal;

        public double Subtotal
        {
            get { return (Producto.PrecioVenta - Producto.Descuento) * Cantidad; }
            set { subtotal = (Producto.PrecioVenta - Producto.Descuento) * Cantidad; }
        }

        public DETAIL_producto(double cantidad, PRODUCTO p)
        {
            this.Cantidad = cantidad;
            this.Producto = p;
        }

        public DETAIL_producto()
        {
            // TODO: Complete member initialization
        }

    }
}


    //class DETAIL_producto : PRODUCTO
    //{
    //    int Cantidad;

    //    public int Cantidad
    //    {
    //        get { return Cantidad; }
    //        set { Cantidad = value; }
    //    }
    //    PRODUCTO producto;

    //    public PRODUCTO Producto
    //    {
    //        get { return producto; }
    //        set { producto = value; }
    //    }

    //    double Subtotal;

    //    public double Subtotal
    //    {
    //        get { return (Producto.PrecioVenta - Producto.Descuento) * Cantidad; }
    //        set { Subtotal = (Producto.PrecioVenta - Producto.Descuento) * Cantidad; }
    //    }

    //    DETAIL_producto(int idProducto, string Descripcion, string CodigoInterno, string codigoBarra, int DiasGarantia,
    //        double precioCompra, double precioVenta, double Descuento, double stock, DateTime fechaCaptura, int status,
    //        int categoria_fk, int marca_fk, int proveedor_fk, int Cantidad)
    //        : base(idProducto, Descripcion,CodigoInterno,codigoBarra,DiasGarantia,precioCompra,precioVenta,Descuento,stock,
    //        fechaCaptura,status,categoria_fk,marca_fk,proveedor_fk)
    //    {
    //        this.Cantidad = Cantidad;
    //    }

    //}