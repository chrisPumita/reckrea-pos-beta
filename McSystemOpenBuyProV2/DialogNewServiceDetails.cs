using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace McSystemOpenBuyProV2
{
    public partial class DialogNewServiceDetails : Form
    {
        EQUIPO _Equipo;
        CLIENTE _Cliente;
        EMPLEADO _Emp;
        List<SERVICIO> _listaServicios = new List<SERVICIO>();
        List<SERVICIO> _tmpSelectedServices = new List<SERVICIO>();
        List<OrdenServicio> _listOrdenes = new List<OrdenServicio>();
        bool _datosFactura = false;
        public static bool _PagoProcesado;

        double _subTotal = 0;
        double _desc = 0;
        double _iva = 0;
        double _total = 0;

        DETAILS_Ticket _ticketPrincipal;

        string _clave;

        public DialogNewServiceDetails(CLIENTE _Cliente, EQUIPO _Equipo, EMPLEADO _Emp)
        {
            this._Cliente = _Cliente;
            this._Emp = _Emp;
            this._Equipo = _Equipo;
            InitializeComponent();
            dateChoose.MinDate = DateTime.Now;
            dateChoose.Value = DateTime.Today.AddDays(3);
            _listaServicios = cargarServicios();
        }

        private List<SERVICIO> cargarServicios()
        {
            List<SERVICIO> _listaServicios = null;
            CONSULTA_Servicio cn = new CONSULTA_Servicio();
            _listaServicios = cn.ConsultaServicios("  WHERE `estatus` = 1 ");
            cboListaServicios.Items.Clear();
            for (int i = 0; i < _listaServicios.Count; i++)
            {
                cboListaServicios.Items.Add("$" + _listaServicios[i].PrecioLista + " -> " + _listaServicios[i].Descripcion + " " + ( _listaServicios[i].Descuento > 0 ? (" " + calculaPorcDesc(_listaServicios[i].PrecioLista,_listaServicios[i].Descuento) + "% OFF") : ""));
            }

            return _listaServicios;
        }

        private double calculaPorcDesc(double total, double desc)
        {
            return Math.Round(((desc * 100) / total),2);
        }

        private void DialogNewServiceDetails_Load(object sender, EventArgs e)
        {
            txtEquipo.Text = _Equipo.CategoriaName + " " + _Equipo.MarcaName + " Mod: " + _Equipo.Modelo + " " + _Equipo.Detalles;
            txtNombreCLiente.Text = _Cliente.Nombre + " " + _Cliente.App + " " + _Cliente.Apm;
            cboHora.SelectedIndex = 0;
            cboMinutos.SelectedIndex = 0;
        }

        private List<SERVICIO> serviciosSeleccionados()
        {
            List<SERVICIO> tmpServicios = new List<SERVICIO>();
            double _suma = 0;
            int contAdd = 0;
            _desc = 0;
            _iva = 0;
            for (int i = 0; i < cboListaServicios.Items.Count; i++)
            {
                if (cboListaServicios.GetSelected(i))
                {
                    tmpServicios.Add(_listaServicios[i]);
                    _suma += tmpServicios[contAdd].PrecioLista;
                    _desc += tmpServicios[contAdd].Descuento;
                    numericTotalPreview.Value = Convert.ToDecimal(_suma);
                    if (_desc > 0)
                    {
                        lblDesc.Visible = true;
                        lblDesc.Text = "Descuento: $" + _desc;
                    }
                    else
                    {
                        lblDesc.Visible = false;
                        lblDesc.Text = "Descuento: $" + _desc;
                    }
                    
                    contAdd++;
                }
                //Recalculado totales
                _subTotal = _suma;
                if (cboFacturar.Checked)
                    _iva = (_subTotal-_desc) * .16;
                _total = _subTotal - _desc + _iva;
                cboFacturar.Text = "FACTURAR ( +$" + (_subTotal - _desc) * .16 + " IVA)";
            }
            return tmpServicios;
        }

        private double calculaIVA()
        {
            double desc = 0;
            double total = 0;
            for (int i = 0; i < _tmpSelectedServices.Count; i++)
            {
                desc = _tmpSelectedServices[i].Descuento;
            }

            total = Convert.ToDouble(numericTotalPreview.Value) - desc;

            return total * 0.16;
        }

        private OrdenServicio validaDatos()
        {
            OrdenServicio newOrder = null;

                //obteniendo los datos generales de la orden de Servicio:
            int idOrdenServicio = 0;
            EQUIPO equipo = _Equipo;
            //DETAILS_Ticket ticket = null;
            string reporte_cliente = txtReporteCliente.Text;
            string diagnositco_tecnico = "Pendiente";
            DateTime fechaIngreso = DateTime.Now;
            int hora = Convert.ToInt32(cboHora.SelectedItem);
            int minutos = Convert.ToInt32(cboMinutos.SelectedItem);
            DateTime fechaEntregaEstimada = dateChoose.Value;
            string sfecha = fechaEntregaEstimada.ToString("yyyy-MM-dd") + " " + hora + ":" + minutos+ ":00";
            //fechaEntregaEstimada.Date.AddDays(hora);
            //fechaEntregaEstimada.Date.AddMinutes(minutos);
            fechaEntregaEstimada = DateTime.Parse(sfecha);
            //DateTime fechaTerminoCancel = null;
            //DateTime FechaEntregaFinal = null;
            string notas = txtNotas.Text;
            int estado_service = 1;
            List<DETAILS_Servicio> listaServicios = getServiciosSelected();

            if (reporte_cliente != "" && notas != "")
            {
                if (listaServicios.Count > 0)
                {
                    //TOdo ok entonces creamos el servicio
                    cboListaServicios.BackColor = Color.White;
                    newOrder = new OrdenServicio();
                    newOrder.Diagnositco_tecnico = diagnositco_tecnico;
                    newOrder.Equipo = equipo;
                    newOrder.Estado_service = estado_service;
                    newOrder.FechaEntregaEstimada = fechaEntregaEstimada;
                    newOrder.FechaIngreso = fechaIngreso;
                    newOrder.IdOrdenServicio = idOrdenServicio;
                    newOrder.ListaServiciosDetails = listaServicios;
                    newOrder.Notas = notas;
                    newOrder.Reporte_cliente = reporte_cliente;
                    newOrder.NotasOcultas = _clave;

                    //grnerando el ticket nuevo 
                    //newOrder.Ticket =
                }
                else
                {
                    MessageBox.Show("Debe agregar un servicio");
                }
            }
            else
                MessageBox.Show("Faltan datos");

            return newOrder;
        }

        private void calcularTotales()
        {
            
        }

        private DETAILS_Ticket generaTicket(List<OrdenServicio> lsOrdenes) 
        {
            return new DETAILS_Ticket(_subTotal, _iva, _desc, _total, lsOrdenes, _Cliente);
        }

        private List<DETAILS_Servicio> getServiciosSelected()
        {
            List<DETAILS_Servicio> tmp_listaServicios = new List<DETAILS_Servicio>();
            for (int i = 0; i < _tmpSelectedServices.Count; i++)
            {
                DETAILS_Servicio tmp_servicio = new DETAILS_Servicio();
                tmp_servicio.Servicio = _tmpSelectedServices[i];
                tmp_servicio.Cantidad = 1;
                tmp_servicio.PrecioVariable = 1;
                tmp_servicio.Subtotal = _tmpSelectedServices[i].PrecioLista - _tmpSelectedServices[i].Descuento;
                tmp_listaServicios.Add(tmp_servicio);
            }
            return tmp_listaServicios;
        }


        private void btnAccion_Click(object sender, EventArgs e)
        {
            _listOrdenes.Clear();
            OrdenServicio newOrder = null;
            newOrder = validaDatos();
           
            if (newOrder != null)
            {
                const string message = "Porfavor confirme la nueva orden de servicio";
                const string caption = "Crear nueva orden de servicio";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);
                // If the no button was pressed ...
                if (result == DialogResult.Yes)
                {
                    _listOrdenes.Add(newOrder);
                    _ticketPrincipal = generaTicket(_listOrdenes);
                  //  _ticketPrincipal = new DETAILS_Ticket(subtotal, iva, desc, total, _detallesCarrito, _Cliente);
                    _ticketPrincipal.Cliente = _Cliente;
                    _ticketPrincipal.ListaOrdenesServicios = _listOrdenes;
                    _ticketPrincipal.Empleado = _Emp;
                    _ticketPrincipal.CodigoTicket = "ORD"+_ticketPrincipal.generaCodigo();
                    if (cboCosto.Checked)
                    {
                        //Modifcamos la suma normal por la que esta en la caja
                        modoficaTotalesTIcket(numericTotalPreview.Value);
                    }
                    _ticketPrincipal.Facturar = cboFacturar.Checked ? 1 : 0;

                    //Abrir link en web
                    //Hacer guardado de la informacio
                   
                    CONSULTA_Ventas ticketVta = new CONSULTA_Ventas();

                    if (ticketVta.guardaActualizaTicket(_ticketPrincipal,1))
                    {
                        int idGuardado = ticketVta.getUltimoID("SERVICIO");
                        _ticketPrincipal.IdTicket = idGuardado;
                        if (ticketVta.agregaDetalles(_ticketPrincipal, "SERVICIO"))
                        {
                            
                            if (_ticketPrincipal.ListaOrdenesServicios != null)
                            {
                                // procedemos a guardar la orden de servicio en general
                                CONSULTA_Servicio servicioDB = new CONSULTA_Servicio();

                                int[] idsServicios = new int[_ticketPrincipal.ListaOrdenesServicios.Count];

                                idsServicios = servicioDB.GetIdsOrderServicios(_ticketPrincipal);
                                if (idsServicios.Count() > 0)
                                {
                                    for (int i = 0; i < _ticketPrincipal.ListaOrdenesServicios.Count; i++)
                                    {
                                        _ticketPrincipal.ListaOrdenesServicios[i].IdOrdenServicio = idsServicios[i];
                                    }

                                    servicioDB.agregaDetalleServicios(_ticketPrincipal);
                                    servicioDB.Cn.Close();

                                    string mensaje = "Se guardado la orden.\r\n ¿Desea agregar MAS DETALLES al Servicio?";
                                    string titulo = "Se genero Orden:" + _ticketPrincipal.CodigoTicket;
                                    var resultado = MessageBox.Show(mensaje, titulo,
                                                                 MessageBoxButtons.YesNo,
                                                                 MessageBoxIcon.Question);
                                    DialogResult ms = new DialogResult();
                                    if (resultado == DialogResult.Yes)
                                    {
                                        OrdenServicio OrdenServ = new OrdenServicio();
                                        OrdenServ = _ticketPrincipal.ListaOrdenesServicios.Count >= 1 ? _ticketPrincipal.ListaOrdenesServicios[0] : null;
                                        OrdenServ.Ticket = new DETAILS_Ticket();
                                        OrdenServ.Ticket = _ticketPrincipal;
                                        OrdenServ.Ticket.CodigoTicket = _ticketPrincipal.CodigoTicket;
                                        if (OrdenServ != null)
                                        {
                                            DialogServicioOrder VentanaOrder = new DialogServicioOrder(OrdenServ,1);
                                            VentanaOrder.ShowDialog();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Obj No instanciado");
                                        }
                                        
                                        //Recargar el servicio
                                    }
                                    else if (resultado == DialogResult.No)
                                    {
                                        System.Diagnostics.Process.Start("https:\\www.mcsystem.com.mx\\servicio\\orderService.php?phoneKey=" + _Cliente.Telefono + "&noOrder=" + _ticketPrincipal.CodigoTicket);
                                        //MessageBox.Show("Se abrira el navegador para porder imprimir la orden de servicio");
                                   
                                    }


                                     this.Close();
                                }
                                else
                                    MessageBox.Show("NO ME REGRESA LA ORDEN ACTUAL");
                            }
                        }
                       
                    }
                    //Procesar la impresion de la orden de servicio
                    else
                    {
                        MessageBox.Show("NO se guardo el ticket de la orden de servicio");
                        this.Close();
                    }
                }
            }
        }

        private void modoficaTotalesTIcket(decimal p)
        {
            double t = Convert.ToDouble(p);
            _ticketPrincipal.Total = t;
            _ticketPrincipal.Descuento = 0;
            _ticketPrincipal.Iva = t + (t * .16);
        }

        private void cboListaServicios_SelectedIndexChanged(object sender, EventArgs e)
        {

            _tmpSelectedServices.Clear();
            int cantSeleccionados = cboListaServicios.SelectedIndices.Count;

            if (cantSeleccionados==1)
                lblSelectService.Text = "Se seleccionó un Servicio";
            else if (cantSeleccionados>1)
                lblSelectService.Text = "Se han seleccionado "+ cantSeleccionados + " servicios";
            else
                lblSelectService.Text = "No se seleccionó ningun Servicio";

            _tmpSelectedServices = serviciosSeleccionados();

            //_ticketPrincipal = generaTicket();
            
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            numericTotalPreview.Enabled = cboCosto.Checked ? true : false;
        }

        private void cboFacturar_CheckedChanged(object sender, EventArgs e)
        {
            //verificar que los datos de facturazion cliente esten completos
            if (cboFacturar.Checked && _Cliente.DatosDiscales != null)
            {
                _datosFactura = true;
            }
            else if (cboFacturar.Checked && _Cliente.DatosDiscales == null)
            {
                //No hay datos fiscales, debe agregarlos
                const string message = "Al parecer el cliente no tiene datos de facturación, \r\n ¿Desea agregarlos ahora? ";
                const string caption = "Sin datos fiscales";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);
                // If the no button was pressed ...
                if (result == DialogResult.Yes)
                {
                    //int accion, CLIENTE cliente, bool facturar
                    DialogCliente box = new DialogCliente(0, _Cliente, cboFacturar.Checked);
                    box.ShowDialog();
                    CONSULTA_Personas con = new CONSULTA_Personas();
                    List<CLIENTE> reloadCliente = new List<CLIENTE>();
                    reloadCliente = con.ConsultaClientes(" WHERE  `cliente`.`idCliente` = " +_Cliente.Id);
                    _Cliente = reloadCliente[0];
                }

                if (cboFacturar.Checked && _Cliente.DatosDiscales != null)
                {
                    _datosFactura = true;
                    cboFacturar.BackColor = Color.Green;
                    cboFacturar.Checked = true;
                }
                else
                {
                    cboFacturar.BackColor = Color.Red;
                    _datosFactura = false;
                }
            }
            else
            {
                cboFacturar.BackColor = Color.Gainsboro;
            }
            
        }

        private void numericTotalPreview_ValueChanged(object sender, EventArgs e)
        {
            cboFacturar.Text = "Facturar ( +$" + calculaIVA() +" IVA)";
            
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            _clave = "";
            if (cboCheckPw.Checked)
            {
                _clave = Microsoft.VisualBasic.Interaction.InputBox(
                        "Si la cuenta tiene contraseña o alaguna clave por favor escribala aqui:", 
                        "Ingrese la clave",
                        "Ingrese clave de sesión"
                    );
            }

            if (!(_clave != ""))
            {
                cboCheckPw.Checked = false;
            }
            checaNotas();
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            checaNotas();
        }

        private void checaNotas()
        {
            string checaNotas = "";
            if (cboCargador.Checked)
                checaNotas += "Deja cargador \r\n";
            if (cboCable.Checked)
                checaNotas += "Deja cable \r\n";
            if (cboCheckPw.Checked)
            {
                checaNotas += "Requiere clave: ";
                for (int i = 0; i < _clave.Length; i++)
                {
                    checaNotas += "*";
                }
                checaNotas += "\r\n";
            }
            if (cboPeriferico.Checked)
                checaNotas += "Deja algun periferico: (especifique)";
            txtNotas.Text = checaNotas;
        }

        private void cboCable_CheckedChanged(object sender, EventArgs e)
        {
            checaNotas();
        }

        private void cboPeriferico_CheckedChanged(object sender, EventArgs e)
        {
            checaNotas();
        }
        
    }
}
