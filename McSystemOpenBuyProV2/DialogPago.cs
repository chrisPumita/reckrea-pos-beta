using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace McSystemOpenBuyProV2
{
    public partial class DialogPago : Form
    {
        DETAILS_Ticket _ticketPrincipal;
        EMPLEADO _emp;
        List<DETAIL_producto> listaCarrito = new List<DETAIL_producto>();
        List<OrdenServicio> listaSevicios = new List<OrdenServicio>();
        bool factura;
        int formaPago;
        double _cambio = 0;
        int _tipoPago;
        string _codigoInicial;

        public DialogPago(DETAILS_Ticket _ticketPrincipal, bool factura, EMPLEADO emp, int tipoPago)
        {
            InitializeComponent();
            this._emp = emp;
            // 1 venta, 2, servicio, 3 abono, 4 retiro, 
            this._tipoPago = tipoPago;
            this._ticketPrincipal = _ticketPrincipal;
            _ticketPrincipal.Empleado = _emp;


            switch (_tipoPago)
            {
                case 1:
                    listaCarrito = this._ticketPrincipal.ListaDetalles;
                    _codigoInicial = "VT";
                    break;
                case 2:
                    listaSevicios = this._ticketPrincipal.ListaOrdenesServicios;
                    _codigoInicial = "ORD";
                    break;
                default:
                    _codigoInicial = "NON";
                    break;
            }
            
            this.factura = factura;
            cboPago.SelectedIndex = 0;
            cargaDetalles();
            ControlPanelVenta._PagoProcesado = false;
        }

        private void cargaDetalles()
        {

            switch (_tipoPago)
            {
                case 1:
                    lblTitulo.Text = "Pagar " + _ticketPrincipal.CantidadProductos + " productos";
                    break;
                case 2:
                    lblTitulo.Text = "Pagar " + _ticketPrincipal.CantidadServicios + " servicio";
                    break;
            }
            
            txtSubtotal.Text = Convert.ToString(_ticketPrincipal.Subtotal);
            txtDesc.Text = Convert.ToString(_ticketPrincipal.Descuento);
            txtIVA.Text = Convert.ToString(_ticketPrincipal.Iva);
            txtTotal.Text = Convert.ToString(_ticketPrincipal.Total+_ticketPrincipal.Iva);
            txtCliente.Text = _ticketPrincipal.Cliente.Nombre + " " + _ticketPrincipal.Cliente.App + " " + _ticketPrincipal.Cliente.Apm;
            txtPago.Text = Convert.ToString(_ticketPrincipal.Total + _ticketPrincipal.Iva);
            txtPago.Focus();
            txtPago.SelectAll();
            

        }

        private bool procesarPago(DETAILS_Ticket _ticketPrincipal, int p)
        {
            //recibimos un Ticket para mandar y procesar la venta.
            CONSULTA_Ventas vta = new CONSULTA_Ventas();
            bool bandera = false;
            //mandamos la infomracion del Ticket
            if (vta.guardaActualizaTicket(_ticketPrincipal, 1))
            {
                //se ha guardado el Ticket
                int idTicket = vta.getUltimoID("VENTA");
                if (idTicket > 0)
                {
                    //asigno el iD al Ticket
                    _ticketPrincipal.IdTicket = idTicket;
                    //Actualiza el stok de los productos que se ingresaon al carrito para ir disinuyendo
                    CONSULTA_Inventario inventario = new CONSULTA_Inventario();
                    //indico una resta en el stock
                    inventario.UpdateStockProductos(_ticketPrincipal,-1);

                    //si hay un Ticket entonces contruimos los Detalles
                    if (vta.agregaDetalles(_ticketPrincipal,"VENTA"))
                    {
                        if (_ticketPrincipal.ListaOrdenesServicios != null)
                        {
                            //la clase de servicio se encargara de meter todos los registros
                            //Obtener los ids de los servicios [TODOS]

                            CONSULTA_Servicio servicioDB = new CONSULTA_Servicio();
                            int[] idsServicios = new int[_ticketPrincipal.ListaOrdenesServicios.Count];
                            idsServicios = servicioDB.GetIdsOrderServicios(_ticketPrincipal);
                            //Le asignamos a cada servicio el id correspondiente
                            for (int i = 0; i < _ticketPrincipal.ListaOrdenesServicios.Count; i++)
                            {
                                _ticketPrincipal.ListaOrdenesServicios[i].IdOrdenServicio = idsServicios[i];
                            }
                            servicioDB.agregaDetalleServicios(_ticketPrincipal);
                            servicioDB.Cn.Close();
                        }
                        bandera = true;
                        // si pago procesado, imprimir Ticket
                        printDocument1 = new PrintDocument();
                        PrinterSettings ps = new PrinterSettings();



                      //  elejir la impresora a donde se va a imprimir
                        ps.DefaultPageSettings.PrinterSettings.PrinterName = Properties.Settings.Default.printerTicket;

                        printDocument1.PrinterSettings = ps;
                        printDocument1.PrintPage += imprimir;
                        printDocument1.Print();
                        ControlPanelVenta._PagoProcesado = true;
                        this.Close();
                    }
                    else
                        MessageBox.Show("Error saved Ticket");

                    //Procesando pago en caja

                }
                else
                {
                    MessageBox.Show("Ticket not found");
                }
            }
            else
                MessageBox.Show("NO se guardo Ticket");
            return bandera;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //Procesar el pago
            //Agregarle los datos adicionales al Ticket
            _ticketPrincipal.FormaPago = formaPago;
            _ticketPrincipal.Facturar = factura ? 1 : 0;
            _ticketPrincipal.NoFactura = 0;
            _ticketPrincipal.EstadoFactura = 0;
            
            _ticketPrincipal.CodigoTicket = _codigoInicial + _ticketPrincipal.generaCodigo() + _ticketPrincipal.IdTicket;
            _ticketPrincipal.EstatusTicket = 1;
            if (!procesarPago(_ticketPrincipal, 0))
                MessageBox.Show("No se pudo procesar el pago");
        }

        

        private void imprimir(object sender, PrintPageEventArgs e)
        {
            IMPRESORA printer = new IMPRESORA();
            printer.imprimir(_ticketPrincipal, e, _cambio.ToString("N2"),_tipoPago);
        }

        private void calculaCambio()
        {
            try
            {
                double pago = Convert.ToDouble(txtPago.Text);
                double cambio = pago - (_ticketPrincipal.Total + _ticketPrincipal.Iva);
                if (pago < _ticketPrincipal.Total)
                {
                    btnPagar.Enabled = false;
                    btnPagar.BackColor = Color.Gray;
                    txtCambio.Text = "0";
                }
                else
                {
                    btnPagar.Enabled = true;
                    btnPagar.BackColor = Color.Green;
                    txtCambio.Text = cambio.ToString("N2");
                }
                _cambio = cambio;
                ControlPanelVenta._Cambio = _cambio;
            }
            catch (Exception)
            {
                txtPago.Text = "0.0";
                txtPago.SelectAll();
            }
        }


        private void txtPago_MouseClick(object sender, MouseEventArgs e)
        {
            txtPago.SelectAll();
        }

        private void txtPago_TextChanged(object sender, EventArgs e)
        {
            calculaCambio();
        }

        private void DialogPago_Load(object sender, EventArgs e)
        {
            txtCambio.Text = "0.0";
            //txtPago.Focus();
            //txtPago.SelectAll();
            _ticketPrincipal.FormaPago = cboPago.SelectedIndex;
        }

        private void cboPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            chekPago();
        }

        private void chekPago()
        {
            _ticketPrincipal.FormaPago = cboPago.SelectedIndex;
            this.formaPago = cboPago.SelectedIndex;
            switch (cboPago.SelectedIndex)
            {
                case 0:
                    ImagenBox.Image = Properties.Resources.money;
                    txtPago.Text = Convert.ToString(_ticketPrincipal.Total + _ticketPrincipal.Iva);
                    txtPago.Focus();
                    txtPago.Enabled = true;
                    calculaCambio();
                    break;
                case 1:
                case 2:
                    ImagenBox.Image = Properties.Resources.payment;
                    txtPago.Text = Convert.ToString(_ticketPrincipal.Total + _ticketPrincipal.Iva);
                    txtPago.Enabled = false;
                    calculaCambio();
                    break;
                case 3:
                    ImagenBox.Image = Properties.Resources.online_banking;
                    txtPago.Text = Convert.ToString(_ticketPrincipal.Total + _ticketPrincipal.Iva);
                    txtPago.Enabled = false;
                    calculaCambio();
                    break;
                case 4:
                case 5:
                    ImagenBox.Image = Properties.Resources.qr_code;
                    txtPago.Text = Convert.ToString(_ticketPrincipal.Total + _ticketPrincipal.Iva);
                    txtPago.Enabled = false;
                    calculaCambio();
                    break;
            }
        }

        private void cboPago_SelectedValueChanged(object sender, EventArgs e)
        {
            chekPago();
        }

        private void txtPago_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Procesar el pago
                //Agregarle los datos adicionales al Ticket
                _ticketPrincipal.FormaPago = formaPago;
                _ticketPrincipal.Facturar = factura ? 1 : 0;
                _ticketPrincipal.NoFactura = 0;
                _ticketPrincipal.EstadoFactura = 0;

                _ticketPrincipal.CodigoTicket = _codigoInicial + _ticketPrincipal.generaCodigo() + _ticketPrincipal.IdTicket;
                _ticketPrincipal.EstatusTicket = 1;
                if (!procesarPago(_ticketPrincipal, 0))
                    MessageBox.Show("No se pudo procesar el pago");
            }
        }
    }
}
