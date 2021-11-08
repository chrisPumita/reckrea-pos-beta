using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace McSystemOpenBuyProV2
{
    class IMPRESORA
    {
        DETAILS_Ticket _ticketPrincipal;
        List<DETAIL_producto> listaCarrito = new List<DETAIL_producto>();
        List<OrdenServicio> _listaOrdenes = new List<OrdenServicio>();
        Font _fontdetalle = new Font("Consolas", 8, FontStyle.Regular, GraphicsUnit.Point);
        Font _fontTOTAL = new Font("Consolas", 8, FontStyle.Bold, GraphicsUnit.Point);
        Font font = new Font("Arial", 8, FontStyle.Regular, GraphicsUnit.Point);
        Font fontBlack = new Font("Arial", 8, FontStyle.Bold, GraphicsUnit.Point);
        Font fontCursive = new Font("Arial", 7, FontStyle.Italic, GraphicsUnit.Point);
        int ancho = Convert.ToInt32(Convert.ToDouble(Properties.Settings.Default.printerWidth) * 3.779527559055);
        int y = 20;
        int marginLeft = 0;
        int interlineado = 12;
        Image img = Properties.Resources.logoMcSystem;
        int _tipoPago;


        public DETAILS_Ticket TicketPrincipal
        {
            get { return _ticketPrincipal; }
            set { _ticketPrincipal = value; }
        }

        public void imprimir(DETAILS_Ticket _ticketPrincipal, PrintPageEventArgs e, string cambio, int tipoPago)
        {
            int enters = 0;

            string texto = "";
            int numLines = 0;
            string formaPago = " ** ";
            this._tipoPago = tipoPago;
            switch (_ticketPrincipal.FormaPago)
            {
                case 0:
                    formaPago += "EFECTIVO ";
                    break;
                case 1:
                    formaPago += "DEBITO   ";
                    break;
                case 2:
                    formaPago += "CREDITO  ";
                    break;
                case 3:
                    formaPago += "TRANS.   ";
                    break;
                case 4:
                    formaPago += "CODI     ";
                    break;
                case 5:
                    formaPago += "M.Pago  ";
                    break;
                default:
                    break;
            }

            this._ticketPrincipal = _ticketPrincipal;
            this.listaCarrito = _ticketPrincipal.ListaDetalles;
            this._listaOrdenes = TicketPrincipal.ListaOrdenesServicios;


            //Colocar el icono predefinido
            e.Graphics.DrawImage(img, new Rectangle(interlineado, y += interlineado, (180), 43));
            y += (interlineado*3);
            //e.Graphics.DrawString(Properties.Settings.Default.NombreEmpresa + "\n\r" + Properties.Settings.Default.Direccion1, font, Brushes.Black, new RectangleF(10, y += interlineado, ancho, interlineado));
            e.Graphics.DrawString(Properties.Settings.Default.Direccion1, font, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
            e.Graphics.DrawString(Properties.Settings.Default.Direccion2, font, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
            e.Graphics.DrawString(Properties.Settings.Default.Direccion3, font, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
            
            e.Graphics.DrawString("", _fontdetalle, Brushes.Black, new RectangleF(10, y += interlineado, ancho, interlineado));

            switch (_tipoPago)
            {
                case 1:
                    e.Graphics.DrawString("**** TICKET DE VENTA ****", font, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
                    e.Graphics.DrawString("", font, Brushes.BlueViolet, new RectangleF(10, y += interlineado, ancho, interlineado));
                    e.Graphics.DrawString("Cliente: " + _ticketPrincipal.Cliente.Nombre + " " + _ticketPrincipal.Cliente.App + " " + _ticketPrincipal.Cliente.Apm.Substring(0, 1) + ".", font, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
                    e.Graphics.DrawString("No." + _ticketPrincipal.CodigoTicket + " \t", font, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
                    e.Graphics.DrawString(_ticketPrincipal.FechaHora.ToString("yyyy-MM-dd HH:mm:ss"), font, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
                    e.Graphics.DrawString("", _fontdetalle, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
                    e.Graphics.DrawString("Descripcion      Cant     $Uni    $Tot", font, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
                    e.Graphics.DrawString("-------------------------------------------", _fontdetalle, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
                    for (int i = 0; i < listaCarrito.Count; i++)
                    {
                        e.Graphics.DrawString(  arreglaNombre(listaCarrito[i].Producto.Descripcion, 30), _fontdetalle, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
                        e.Graphics.DrawString(arreglaCantidad(listaCarrito[i].Cantidad) + "x $" + arreglaPrecio(listaCarrito[i].Producto.PrecioVenta) + " --> $" + arreglaPrecio(listaCarrito[i].Producto.PrecioVenta * listaCarrito[i].Cantidad), _fontdetalle, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
                        if (listaCarrito[i].Producto.Descuento > 0)
                        {
                            e.Graphics.DrawString("Usted ahorra: $" + (listaCarrito[i].Cantidad * listaCarrito[i].Producto.Descuento) + " subtotal: $" + arreglaPrecio(listaCarrito[i].Subtotal), fontCursive, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
                        }
                        e.Graphics.DrawString("", _fontdetalle, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
                    }
                    e.Graphics.DrawString("\t     Subtotal: $" + _ticketPrincipal.Subtotal.ToString("N2"), _fontdetalle, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
                    if (_ticketPrincipal.Descuento > 0)
                        e.Graphics.DrawString("\t        -Desc: $" + _ticketPrincipal.Descuento.ToString("N2"), _fontdetalle, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
                    if(_ticketPrincipal.Iva > 0)
                        e.Graphics.DrawString("\t          IVA: $" + _ticketPrincipal.Iva.ToString("N2"), _fontdetalle, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
                    e.Graphics.DrawString("\t        TOTAL: $" + (_ticketPrincipal.Total + _ticketPrincipal.Iva).ToString("N2"), _fontTOTAL, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));

                    e.Graphics.DrawString(formaPago + "CAMBIO: $" + cambio, _fontTOTAL, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
                    e.Graphics.DrawString("___________________________________________", font, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
                    e.Graphics.DrawString("Artculos: " + _ticketPrincipal.CantidadProductos, font, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
                    break;
                case 2:
                    e.Graphics.DrawString("**** ORDEN DE SERVICIO ****", font, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
                    e.Graphics.DrawString("", font, Brushes.BlueViolet, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
                    e.Graphics.DrawString("Cliente: " + _ticketPrincipal.Cliente.Nombre + " " + _ticketPrincipal.Cliente.App + " " + _ticketPrincipal.Cliente.Apm.Substring(0, 1) + ".", font, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
                    e.Graphics.DrawString("No." + _ticketPrincipal.CodigoTicket + " \t", font, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
                    e.Graphics.DrawString(_ticketPrincipal.FechaHora.ToString("yyyy-MM-dd HH:mm:ss"), font, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));

                    e.Graphics.DrawString("", _fontdetalle, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
                    e.Graphics.DrawString("Codigo  Cant  Descripcion   $Uni    $Tot", font, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
                    e.Graphics.DrawString("-------------------------------------------", _fontdetalle, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
                    for (int i = 0; i < _listaOrdenes.Count; i++)
                    {
                        for (int j = 0; j < _listaOrdenes[i].ListaServiciosDetails.Count; j++)
                        {
                            e.Graphics.DrawString(arreglaNombre(_listaOrdenes[i].ListaServiciosDetails[j].Servicio.CodigoInterno, 20) + " " + arreglaCantidad(_listaOrdenes[i].ListaServiciosDetails[j].Cantidad) + " " + arreglaNombre(_listaOrdenes[i].ListaServiciosDetails[j].Servicio.Descripcion, 20), _fontdetalle, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
                            e.Graphics.DrawString("@ $" + arreglaPrecio(_listaOrdenes[i].ListaServiciosDetails[j].Servicio.PrecioLista) + "--> $" + arreglaPrecio(_listaOrdenes[i].ListaServiciosDetails[j].Servicio.PrecioLista * _listaOrdenes[i].ListaServiciosDetails[j].Cantidad), _fontdetalle, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));

                            if (_listaOrdenes[i].ListaServiciosDetails[j].Servicio.Descuento > 0)
                            {
                                e.Graphics.DrawString("Usted ahorra: $" + (_listaOrdenes[i].ListaServiciosDetails[j].Cantidad * _listaOrdenes[i].ListaServiciosDetails[j].Servicio.Descuento) + " subtotal: $" + arreglaPrecio(_listaOrdenes[i].ListaServiciosDetails[j].Subtotal), fontCursive, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
                            }
                            e.Graphics.DrawString("", _fontdetalle, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
          
                        }

                        e.Graphics.DrawString("Ingreso: " + _ticketPrincipal.ListaOrdenesServicios[i].FechaIngreso.ToString("yyyy-MM-dd HH:mm:ss"), font, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
                        e.Graphics.DrawString("Entrega: " + _ticketPrincipal.ListaOrdenesServicios[i].FechaEntregaEstimada.ToString("yyyy-MM-dd HH:mm:ss"), font, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
                        e.Graphics.DrawString("_____REPORTE DEL CLIENTE____", font, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
                        texto = _ticketPrincipal.ListaOrdenesServicios[i].Reporte_cliente;
                        numLines = texto.Split('\n').Length;
                           e.Graphics.DrawString(_ticketPrincipal.ListaOrdenesServicios[i].Reporte_cliente, font, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado * numLines));
                        interlineado = interlineado * numLines;
                        e.Graphics.DrawString("****", _fontdetalle, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
                        interlineado = 12;
                        
                        
                        e.Graphics.DrawString("_____________NOTAS___________", font, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
                         texto = _ticketPrincipal.ListaOrdenesServicios[i].Notas;
                        numLines = texto.Split('\n').Length;
                        e.Graphics.DrawString(texto, font, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
                       
                        e.Graphics.DrawString(_ticketPrincipal.ListaOrdenesServicios[i].Reporte_cliente, font, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado * numLines));
                        interlineado = interlineado * numLines;
                        e.Graphics.DrawString("****", _fontdetalle, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
                        interlineado = 12;
                        
                        string edoServicio = "";
                        switch (_ticketPrincipal.ListaOrdenesServicios[i].Estado_service)
                        {
                            //0.Cancelado, 1 En servicio,2 En espera de entrega, 3, entregado	
                            case 0:
                                edoServicio = "CANCELADO";
                                break;
                            case 1:
                                edoServicio = "EN SERVICIO";
                                break;
                            case 2:
                                edoServicio = "LISTO PARA ENTREGAR";
                                break;
                            case 3:
                                edoServicio = "ENTREGADO";
                                break;
                        }
                        e.Graphics.DrawString("ESTADO:" + edoServicio, font, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
                        e.Graphics.DrawString("-------------------------------------------", _fontdetalle, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
                        e.Graphics.DrawString("", _fontdetalle, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
                    }
                    e.Graphics.DrawString("\t     Subtotal: $" + _ticketPrincipal.Subtotal.ToString("N2"), _fontdetalle, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
                    if (_ticketPrincipal.Descuento > 0)
                        e.Graphics.DrawString("\t        -Desc: $" + _ticketPrincipal.Descuento.ToString("N2"), _fontdetalle, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
                    if(_ticketPrincipal.Iva > 0)
                        e.Graphics.DrawString("\t          IVA: $" + _ticketPrincipal.Iva.ToString("N2"), _fontdetalle, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
                    e.Graphics.DrawString("\t        TOTAL: $" + (_ticketPrincipal.Total + _ticketPrincipal.Iva).ToString("N2"), _fontTOTAL, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));

                    e.Graphics.DrawString(formaPago + "CAMBIO: $" + cambio, _fontTOTAL, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
                    e.Graphics.DrawString("___________________________________________", font, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
                    e.Graphics.DrawString("Servicios: " + _ticketPrincipal.CantidadServicios, font, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
                    
                    break;
                default:
                    break;
            }


            e.Graphics.DrawString("Le atendio: " + _ticketPrincipal.Empleado.Nombre + " " + _ticketPrincipal.Empleado.App, _fontdetalle, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
            e.Graphics.DrawString(Properties.Settings.Default.Mensaje1, font, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
            e.Graphics.DrawString("-------------------------------------------", font, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
            e.Graphics.DrawString(Properties.Settings.Default.Mensaje2, fontCursive, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
            e.Graphics.DrawString(Properties.Settings.Default.Mensaje3, fontCursive, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
            e.Graphics.DrawString("-------------------------------------------", font, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
            e.Graphics.DrawString("", _fontdetalle, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
            
        }

        private string arreglaCantidad(double valor)
        {
            // 4 espacios para la Cantidad
            string tmpCant = Convert.ToString(valor);
            if (valor < 999)
                while (tmpCant.Length < 3)
                    tmpCant += " ";
            return tmpCant;
        }

        private string arreglaPrecio(double valor)
        {
            // 4 espacios para la Cantidad
            string tmpCant = Convert.ToString(valor);
            if (valor < 99999999)
                while (tmpCant.Length < 8)
                    tmpCant += " ";
            return tmpCant;
        }

        private string arreglaNombre(string valor, int limite)
        {
            // 4 espacios para la Cantidad
            string tmpCant = "";
            int limiteLetras = limite;
            if (valor.Count() > limiteLetras)
            { //la letra excede entonces cortamos la letra
                for (int i = 0; i < limiteLetras; i++)
                {
                    tmpCant += valor.Substring(i, 1);
                }
            }
            else //el nombre es menor, agregamos espacios
            {
                tmpCant += valor;
                for (int i = tmpCant.Count(); i < limiteLetras; i++)
                {
                    tmpCant += " ";
                }
            }
            return tmpCant;
        }
    }
}
