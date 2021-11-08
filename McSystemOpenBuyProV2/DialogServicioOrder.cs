using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace McSystemOpenBuyProV2
{
    public partial class DialogServicioOrder : Form
    {
        OrdenServicio _ORDEN_ = new OrdenServicio();
        List<SERVICIO> _allServicesM;
        DETAILS_Ticket _TicketGral;
        List<DETAILS_Servicio> _serviciosSolicitados;
        List<DETAIL_producto> _ProductosSolicitados;
        DETAILS_Servicio _ServicioPorAgregar;
        DETAILS_Servicio _SERV_AGREGADO_SELECT;
        SERVICIO _tmpServicioAgregar;
        CLIENTE _Cliente;
        EMPLEADO _Emp;
        EQUIPO _Equipo; 

        internal static PRODUCTO PRODUCTO_EXTERNO;


        double _TOTAL_Serv = 0;
        double _TOTAL_Pro = 0;
        

        int[] arrayIdsProductos;
        string _tmpOrderServiceNumer = null;

        public DialogServicioOrder(OrdenServicio orden, int tab)
        {
            CONSULTA_Servicio serv = new CONSULTA_Servicio();
            this._ORDEN_ = serv.ConsultaOrdenServicioDetalles(orden.Ticket.CodigoTicket);
            this._tmpOrderServiceNumer = orden.Ticket.CodigoTicket;
            InitializeComponent();
            tabServicio.SelectedIndex = tab;
        }

        private void DialogServicioOrder_Load(object sender, EventArgs e)
        {
            
            cargarDatosOrden(_ORDEN_);
            _allServicesM = cargaServicios(_ORDEN_);
            _ProductosSolicitados = cargaProductos(_ORDEN_);
            _serviciosSolicitados =  cargaMisServicios(_ORDEN_);
            if (_serviciosSolicitados != null)
            {
                cargaTotalesServicios(_serviciosSolicitados);
                cargaServiciosPanel1(_serviciosSolicitados, _allServicesM);
            }

            if (_ProductosSolicitados != null)
            {
                cargaTotalesProductos(_ProductosSolicitados);
            }
            
        }

        private void cargaTotalesProductos(List<DETAIL_producto> _listBDProductos)
        {
            
            if (_listBDProductos != null)
            {
                double subtotal = 0;
                double descuento = 0;
                double total = 0;
                arrayIdsProductos = new int[_listBDProductos.Count];
                //Agregamos el o los elementos el en GRID DATA
                gridProductos.Rows.Clear();
                for (int i = 0; i < _listBDProductos.Count(); i++)
                {
                    int renglon = gridProductos.Rows.Add();
                    gridProductos.Rows[renglon].Cells[0].Value = _listBDProductos[i].Cantidad;
                    gridProductos.Rows[renglon].Cells[1].Value = _listBDProductos[i].IdMovDetalleProducto;
                    gridProductos.Rows[renglon].Cells[2].Value = "" + _listBDProductos[i].Producto.Descripcion;
                    gridProductos.Rows[renglon].Cells[3].Value = "$ " + _listBDProductos[i].Producto.PrecioVenta;
                    gridProductos.Rows[renglon].Cells[4].Value = "$ " + _listBDProductos[i].Producto.Descuento;
                    gridProductos.Rows[renglon].Cells[5].Value = "$ " + _listBDProductos[i].Subtotal;
                    //agregamos el Id delproducto a la lista

                    subtotal +=  _listBDProductos[i].Producto.PrecioVenta;
                    descuento += _listBDProductos[i].Producto.Descuento;
                    
                }

                total += subtotal - descuento;
                lblProductosAgregados.Text = "Se han encontrado: " + _listBDProductos.Count + " productos";

                if (_listBDProductos.Count == 1)
                {
                    lblProductosAgregados.Text = "Un Producto encontrado";
                }
                txtProductos.Clear();
                txtProductos.Text += "RESUMEN PRODUCTOS\r\n";
                txtProductos.Text += "=======================\r\n\r\n";

                txtProductos.Text += _listBDProductos.Count +  " productos agregados\r\n";
                txtProductos.Text += "=======================\r\n\r\n";
                txtProductos.Text += "\tSubtotal: $" + subtotal + "\r\n";
                txtProductos.Text += "\t-Descuentos: $" + descuento + "\r\n";
                txtProductos.Text += "\tTOTAL: $" + total + "\r\n";

                txtProductos.Text += "=======================\r\n";
                _TOTAL_Pro = total;
                lblTotalProductos.Text = "$" + total;
                cargaTotales();
            }
        }

        private List<DETAIL_producto> cargaProductos(OrdenServicio _ORDEN_)
        {
            List<DETAIL_producto> lsProductos = new List<DETAIL_producto>();
            CONSULTA_Ventas vta = new CONSULTA_Ventas();
            lsProductos = vta.ConsultaDetallestIcket(_ORDEN_.Ticket.IdTicket);
            return lsProductos;
        }

        private void cargaTotalesServicios(List<DETAILS_Servicio> _serviciosSolicitados)
        {
            txtListaServiciosTotal.Clear();
            txtListaServiciosTotal.Text = "RESUMEN SERVICIOS\r\n";
            txtListaServiciosTotal.Text += "=================\r\n";
            txtListaServiciosTotal.Text += "Servicios Solicitados: " + _serviciosSolicitados.Count+ " \r\n";
            double sumatoria = 0;
            foreach (var item in _serviciosSolicitados)
            {
                txtListaServiciosTotal.Text += item.Cantidad +" x ["+ item.Servicio.CodigoInterno + "] "+ item.Servicio.Descripcion+"\r\n";
                txtListaServiciosTotal.Text += item.Detalles.Length > 0 ? item.Detalles + "\r\n" : "";
                txtListaServiciosTotal.Text += "\t@ $"+ item.CostoU + " x " + item.Cantidad + " =  $ "+(item.CostoU*item.Cantidad)+" \r\n";
                txtListaServiciosTotal.Text += item.Desc > 0 ? "\tDESCUENTO:  -$" + item.Desc + " \r\n\t TOTAL: $ " + item.Subtotal + " \r\n" : "\tTOTAL: $ " + item.Subtotal + "\r\n";
                txtListaServiciosTotal.Text += "\r\n";
                sumatoria += item.Subtotal;
            }
            txtListaServiciosTotal.Text += "========> TOTAL: $ " + sumatoria + "\r\n";
            _TOTAL_Serv = sumatoria;
            lblTotalServicios.Text = "$" + _TOTAL_Serv;
            cargaTotales();
        }

        public void cargaTotales()
        {
            double total = _TOTAL_Pro + _TOTAL_Serv;
            lblSubtotalServicio.Text = "$" + _TOTAL_Serv;
            lblTotalProductos.Text = "$" + _TOTAL_Pro;
            lblSubtotalServicio.Text = "$" + (_TOTAL_Pro+_TOTAL_Serv);
            lblIVAServicio.Text = "$" + _ORDEN_.Ticket.Iva;
            lblTotalSevPro.Text = "$"+ (total + _ORDEN_.Ticket.Iva);
            cboIVA.Checked = _ORDEN_.Ticket.Facturar == 1 ? true : false;
            tabServ.Text = "Servicios Solicitados  $" + _TOTAL_Serv +" - ";
            tabProd.Text = "Productos Solicitados $" + _TOTAL_Pro + " - ";
        }
  
        /// //////////////////
        private void cargaServiciosPanel1(List<DETAILS_Servicio> _serviciosSolicitados, List<SERVICIO> _allServicesM)
        {
            cboMyServicios.Items.Clear();
            cboListaServicios.Items.Clear();
            for (int i = 0; i < _allServicesM.Count; i++)
            {
                SERVICIO tmpSer = new SERVICIO();
                DETAILS_Servicio tmpServSelect;
                tmpServSelect = _serviciosSolicitados.Find(x => x.Servicio.IdServicio == _allServicesM[i].IdServicio);
                if (tmpServSelect != null)
                    cboMyServicios.Items.Add(tmpServSelect.Servicio.Descripcion).ToString();
                else
                    cboListaServicios.Items.Add(_allServicesM[i].Descripcion).ToString();
            }

            if (_serviciosSolicitados.Count > 0)
            {
                cboMyServicios.SelectedIndex = cboMyServicios.Items.Count - 1;
            }
        }

        private List<SERVICIO> cargaServicios(OrdenServicio _ORDEN_)
        {
            CONSULTA_Servicio servDB = new CONSULTA_Servicio();
            string consul = "";
            if (_ORDEN_!= null)
            {
                consul = "";
            }
            return servDB.ConsultaServicios(consul + " ");
        }

        private List<DETAILS_Servicio> cargaMisServicios(OrdenServicio _ORDEN_)
        {
            CONSULTA_Servicio servDB = new CONSULTA_Servicio();
            return servDB.ConsultaMisServicios(_ORDEN_.IdOrdenServicio);
        }



        private void cargarDatosOrden(OrdenServicio _ORDEN_)
        {
            //Reload la orden de servicio
            CONSULTA_Servicio serv = new CONSULTA_Servicio();
            _ORDEN_ = serv.ConsultaOrdenServicioDetalles(_ORDEN_.Ticket.CodigoTicket);
            if (_ORDEN_ != null)
            {
                _TicketGral = _ORDEN_.Ticket;
                _Emp = _ORDEN_.Ticket.Empleado;
                _Cliente = _ORDEN_.Ticket.Cliente;
                _Equipo = _ORDEN_.Equipo;
                lblId.Text = "FOLIO: "+ _ORDEN_.IdOrdenServicio;
                //LLenando la informacion obtenida de la bd
                lblOrderNumer.Text = _ORDEN_.Ticket.CodigoTicket;
                mostrardetallesTIcket(_TicketGral);
                mostrarEmpleado(_Emp);
                mortrarCliente(_Cliente);
                mostrarEquipo(_Equipo);
                mostrarDetallesOrder(_ORDEN_);
            }
            else
            {
                MessageBox.Show("Error al buscar la orden de servicio");
            }
            
        }

        private void mostrarDetallesOrder(OrdenServicio _ORDEN_)
        {
            ToolTip toolTip1 = new ToolTip();  
            toolTip1.ShowAlways = true;  
            
            switch (_ORDEN_.Estado_service)
            {
                case 0:
                    imageStado.Image = Properties.Resources.progress_bar_cancel;
                    toolTip1.SetToolTip(imageStado, "Servicio Cancelado");  
                    break;
                case 1:
                    imageStado.Image = Properties.Resources.progress_bar_service;
                    toolTip1.SetToolTip(imageStado, "En Servicio");  
                    break;
                case 2:
                    imageStado.Image = Properties.Resources.progress_bar_espera;
                    toolTip1.SetToolTip(imageStado, "Servicio Terminado y \n\r Equipo Listo Para Entrega");  
                    break;
                case 3:
                    imageStado.Image = Properties.Resources.progress_bar_entregado;
                    toolTip1.SetToolTip(imageStado, "Equipo Entregado con exito");  
                    break;
                case 4:
                    imageStado.Image = Properties.Resources.progress_bar_cotizacion;
                    toolTip1.SetToolTip(imageStado, "Servicio Cotizado, a espera de que el cliente acepte el costo");  
                    break;
                case 5:
                    imageStado.Image = Properties.Resources.progress_bar_garantia;
                    toolTip1.SetToolTip(imageStado, "Servicio En Garantia");  
                    break;
                case 6:
                    imageStado.Image = Properties.Resources.progress_bar_Almacen;
                    toolTip1.SetToolTip(imageStado, "El equipo se ha almacenado");  
                    break;
                case 7:
                    imageStado.Image = Properties.Resources.progress_bar_noEspc;
                    toolTip1.SetToolTip(imageStado, "Servicio con estado no identificado");  
                    break;
                default:
                    imageStado.Image = Properties.Resources.progress_bar_noEspc;
                    break;
            }
            txtParteTecnico.Text = _ORDEN_.Diagnositco_tecnico;

            txtFechaEntregaEstimada.Text = _ORDEN_.FechaEntregaEstimada.ToString("dd MMM yyyy hh:mm tt", CultureInfo.CreateSpecificCulture("es-MX"));

        }

        private void mostrarEquipo(EQUIPO _Equipo)
        {
            txtEquipo.Text = _Equipo.MarcaName + " " + _Equipo.Detalles;
        }

        private void mostrardetallesTIcket(DETAILS_Ticket _ticket)
        {
            lblFolio.Text = "ID Ticket: " + _ticket.IdTicket;
            lblTotalServicio.Text = "$"+ _ticket.Total;
            txtFechaRecibe.Text = _ORDEN_.FechaIngreso.ToString("dd MMM yyyy hh:mm tt", CultureInfo.CreateSpecificCulture("es-MX"));
            txtFechaEntregaEstimada.Text = _ORDEN_.FechaEntregaEstimada.ToString("dd MMM yyyy hh:mm tt", CultureInfo.CreateSpecificCulture("es-MX"));
            switch (_ORDEN_.Estado_service)
            {
                case 0:
                    txtDetalles.Text = "Canceladoo el dia: " +_ORDEN_.FechaTerminoCancel.ToString("dd MMM yyyy hh:mm tt", CultureInfo.CreateSpecificCulture("es-MX"));
                    break;

                case 1:
                    txtDetalles.Text = "En servicio, se registro el dia "+_ORDEN_.FechaIngreso.ToString("dd MMM yyyy hh:mm tt", CultureInfo.CreateSpecificCulture("es-MX"));
                    txtDetalles.Text += " El equipo lleva " + TimeSpan.FromTicks((DateTime.Now - _ORDEN_.FechaIngreso).Ticks).Days + " días en servicio";
                    break;

                case 2:
                    txtDetalles.Text = "Listo para entregarse desde el "  + _ORDEN_.FechaTerminoCancel.ToString("dd MMM yyyy hh:mm tt", CultureInfo.CreateSpecificCulture("es-MX"));
                    txtDetalles.Text += "\r\nLleva " + TimeSpan.FromTicks((DateTime.Now - _ORDEN_.FechaTerminoCancel).Ticks).Days + "  dias de espera.";
                    break;

                case 3:
                    txtDetalles.Text = "El servicio se entrego  el dia " + _ORDEN_.FechaEntregaFinal1.ToString("dd MMM yyyy hh:mm tt", CultureInfo.CreateSpecificCulture("es-MX"));
                    break;


                case 4:
                    txtDetalles.Text = "Esperando que el cliente acepte la cotizacion";
                    break;


                case 5:
                    txtDetalles.Text = "Equipo debuelto por garantia";
                    break;

                case 6:
                    txtDetalles.Text = "El equipo se tuvo que almacenar por los dias transcurridos desde el termino.";
                    break;
                default:
                    txtDetalles.Text = "Detalle no especificado";
                    break;
            }

            
            txtNotas.Text=_ORDEN_.Reporte_cliente +" \r\n" + _ORDEN_.Notas +" \r\n" + _ORDEN_.NotasOcultas;

            txtFallaClienteBitacora.Text = _ORDEN_.Reporte_cliente;
            txtParteTecnico.Text = _ORDEN_.Diagnositco_tecnico;
            txtNotasBitacora.Text = _ORDEN_.Notas + " \r\n" + _ORDEN_.NotasOcultas;
        }

        private void mostrarEmpleado(EMPLEADO emp)
        {
            txtNombreEmpleado.Text = emp.Nombre+ " " + emp.App + " " + emp.Apm;
            
        }

        private void mortrarCliente(CLIENTE cliente)
        {
            txtNombreCliente.Text = cliente.Nombre + " " + cliente.App + " " + cliente.Apm;
            txtTelefonoCliente.Text = cliente.Telefono;
            txtCorreoCliente.Text = cliente.Correo;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string message = "Se va a CANCELAR el servicio y terminar el servicio. ¿Esta seguro?";
            string caption = "Cancelar Servicio " +_ORDEN_.Ticket.CodigoTicket;
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);
            // If the no button was pressed ...
            if (result == DialogResult.Yes)
            {
                CONSULTA_Servicio cn = new CONSULTA_Servicio();
                if (cn.ActualizaEstadoOrdenServicio(_ORDEN_, 0))
                {
                    MessageBox.Show("Se CANCELADO el servicio" + _ORDEN_.IdOrdenServicio);
                }
             
            }
            cargarDatosOrden(_ORDEN_);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string message = "Desea Terminar el servicio ¿Esta seguro?";
            string caption = "Terminar Servicio #" + _ORDEN_.Ticket.CodigoTicket;
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);
            // If the no button was pressed ...
            if (result == DialogResult.Yes)
            {
                CONSULTA_Servicio cn = new CONSULTA_Servicio();
                _ORDEN_.FechaTerminoCancel = DateTime.Now;
                _ORDEN_.Estado_service = 2;
                if (cn.ActualizaEstadoOrdenServicio(_ORDEN_, 2))
                {
                    MessageBox.Show("Servicio terminado, se ha avisado al cliente "+_ORDEN_.Ticket.Cliente.Nombre+" "+_ORDEN_.Ticket.Cliente.App+". \r\nGracias");
                }
                //Recargar el servicio
            }

            cargarDatosOrden(_ORDEN_);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DialogCliente editaCliente = new DialogCliente(_Cliente, true);
            editaCliente.ShowDialog();
            cargarDatosOrden(_ORDEN_);
        }

        private void btnTerminar2_Click(object sender, EventArgs e)
        {
            string message = "Desea Terminar el servicio ¿Esta seguro?";
            string caption = "Terminar Servicio #" + _ORDEN_.Ticket.CodigoTicket;
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);
            // If the no button was pressed ...
            if (result == DialogResult.Yes)
            {
                CONSULTA_Servicio cn = new CONSULTA_Servicio();
                _ORDEN_.FechaTerminoCancel = DateTime.Now;
                _ORDEN_.Estado_service = 2;
                if (cn.ActualizaEstadoOrdenServicio(_ORDEN_, 2))
                {
                    MessageBox.Show("Servicio terminado, se ha avisado al cliente " + _ORDEN_.Ticket.Cliente.Nombre + " " + _ORDEN_.Ticket.Cliente.App + ".");
                }
                //Recargar el servicio
            }

            cargarDatosOrden(_ORDEN_);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string message = "Esta a punto de entregar el servicio, ¿Esta seguro?";
            string caption = "Entregar Equipo de Orden #" + _ORDEN_.Ticket.CodigoTicket;
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);
            // If the no button was pressed ...
            if (result == DialogResult.Yes)
            {
                CONSULTA_Servicio cn = new CONSULTA_Servicio();
                _ORDEN_.FechaEntregaFinal1 = DateTime.Now;
                _ORDEN_.Estado_service = 3;
                if (cn.ActualizaEstadoOrdenServicio(_ORDEN_, 3))
                {
                    MessageBox.Show("Servicio Entregado, porfavor entregue el equipo a " + _ORDEN_.Ticket.Cliente.Nombre + " " + _ORDEN_.Ticket.Cliente.App + ".\r\n Gracias");
                }
                //Recargar el servicio
            }

            cargarDatosOrden(_ORDEN_);
        }

        private void button6_Click(object sender, EventArgs e)
        {

            if (cboListaServicios.SelectedIndex>=0)
            {
                string serviceSelected = cboListaServicios.SelectedItem.ToString();
                _ServicioPorAgregar = new DETAILS_Servicio();
                _ServicioPorAgregar.Servicio = _allServicesM.Find(x => x.Descripcion.Contains(serviceSelected));
                _ServicioPorAgregar.Cantidad = 1;
                _ServicioPorAgregar.CostoU = _ServicioPorAgregar.Servicio.PrecioLista;
                _ServicioPorAgregar.Desc = _ServicioPorAgregar.Servicio.Descuento;
                _ServicioPorAgregar.Subtotal = (_ServicioPorAgregar.Servicio.PrecioLista - _ServicioPorAgregar.Servicio.Descuento) * _ServicioPorAgregar.Cantidad;
                if (_ServicioPorAgregar != null)
                {
                    string message = "Desea agregar: " + _ServicioPorAgregar.Servicio.Descripcion + " a la Orden de Servicio\r\nSe aumentara un costo de: $" +_ServicioPorAgregar.Servicio.PrecioLista;
                    string caption = "Agregar Servicios a la Orden " + _ORDEN_.Ticket.CodigoTicket;
                    var result = MessageBox.Show(message, caption,
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question);
                    // If the no button was pressed ...
                    if (result == DialogResult.Yes)
                    {
                        CONSULTA_Servicio cn = new CONSULTA_Servicio();
                        if (cn.agregaUnDetalleServicio(_ServicioPorAgregar,_ORDEN_.IdOrdenServicio))
                        {
                            actualizaTicket();
                        }
                        //Recargar el servicio
                    }
                    cargaTodo();
                }
                
            }
            else
            {
                MessageBox.Show("Debe seleccionar un servicio para agregarlo");
            }
        }

        /// <summary>
        /// ///////////////////////////////////ACTUALIZAR LOS SALDOS DEL SERVICIO AGREGASO
        /// </summary>
        private void actualizaTicket()
        {
            _allServicesM = cargaServicios(_ORDEN_);
            _serviciosSolicitados = cargaMisServicios(_ORDEN_);
            _ProductosSolicitados = cargaProductos(_ORDEN_);
            double subtotal = _TOTAL_Pro + _TOTAL_Serv;

            _ORDEN_.Ticket.ListaDetalles = _ProductosSolicitados;
            _ORDEN_.ListaServiciosDetails = _serviciosSolicitados;
            ////////////////////// REHACER SUMAS
            double desc = _serviciosSolicitados.Sum(item => item.Desc) + _ProductosSolicitados.Sum(item => item.Producto.Descuento);
            double total = _serviciosSolicitados.Sum(item => item.Subtotal) + _ProductosSolicitados.Sum(item => item.Subtotal);
            _ORDEN_.Ticket.Total = total;
            _ORDEN_.Ticket.Descuento = desc;
            _ORDEN_.Ticket.Subtotal = total - desc;


            if (cboIVA.Checked)
            {
                _ORDEN_.Ticket.Facturar = 1;
                _ORDEN_.Ticket.Iva = total * .16;
                _ORDEN_.Ticket.Total += _ORDEN_.Ticket.Iva;
            }
            else
            {
                _ORDEN_.Ticket.Facturar = 0;
                _ORDEN_.Ticket.Iva = 0;
            }

            _TicketGral = _ORDEN_.Ticket;


            ///Ya teniendo los nuevos valores. actualizamos los valores
            if (!actualizaDatosTicket(_TicketGral))
            {
                MessageBox.Show("Ocurrio un error al procesar los nuevos valores");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (cboMyServicios.SelectedIndex >= 0)
            {
                DETAILS_Servicio tmpSerEliminar = _serviciosSolicitados.Find(x => x.Servicio.Descripcion.Contains(cboMyServicios.SelectedItem.ToString()));
                ///Preguntar por eleminar
                string message = "¿Desea eliminar permanentemente " + tmpSerEliminar.Servicio.Descripcion + " de la Orden de Servicio?\r\nEsta opcion es irreversible, pero puede agregarla posteriormente si cometio un error";
                string caption = "Eliminar un Servicios de la Orden " + _ORDEN_.Ticket.CodigoTicket;
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);
                // If the no button was pressed ...
                if (result == DialogResult.Yes)
                {
                    CONSULTA_Servicio cn = new CONSULTA_Servicio();
                    if (cn.BorraMovOrder(tmpSerEliminar.IdDetalle_serv,1))
                    {
                        actualizaTicket();
                    }
                    //Recargar el servicio
                }
                cargaTodo();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un servicio para quitarlo");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https:\\www.mcsystem.com.mx\\servicio\\orderService.php?phoneKey=" + _Cliente.Telefono + "&noOrder=" + _TicketGral.CodigoTicket);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabServicio.SelectedIndex = 3;
        }

        private void cboMyServicios_SelectedIndexChanged(object sender, EventArgs e)
        {
            verDetalles(cboMyServicios.SelectedItem.ToString());
        }

        private void verDetalles(string aux)
        {
            DETAILS_Servicio servicioSelect = new DETAILS_Servicio();
            SERVICIO sv = new SERVICIO();
            servicioSelect = _serviciosSolicitados.Find(x => x.Servicio.Descripcion.Contains(aux));
            if (servicioSelect != null)
            {
                _SERV_AGREGADO_SELECT = servicioSelect;
                txtServSol.Text = servicioSelect.Servicio.Descripcion;
                txtDetallesSol.Text = servicioSelect.Detalles;
                numCant.Value = Convert.ToDecimal(servicioSelect.Cantidad);
                numCoste.Value = Convert.ToDecimal(servicioSelect.CostoU);
                txtTotal.Text = "$"+ servicioSelect.Subtotal;
            }
        }

        private void cboListaServicios_SelectedIndexChanged(object sender, EventArgs e)
        {
            verServicioNuevo(cboListaServicios.SelectedItem.ToString());
        }

        private void verServicioNuevo(string index)
        {
            SERVICIO sv = new SERVICIO();

            DETAILS_Servicio _ServicioPorAgregar;
            _tmpServicioAgregar = new SERVICIO();
            _tmpServicioAgregar = _allServicesM.Find(x=>x.Descripcion.Contains(index));

            txtNewSerAdd.Text = _tmpServicioAgregar.Descripcion;
            txtPrecioLista.Text = "$" + _tmpServicioAgregar.PrecioLista;

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            _SERV_AGREGADO_SELECT.Cantidad = Convert.ToDouble(numCant.Value);
            _SERV_AGREGADO_SELECT.Detalles = txtDetallesSol.Text;
            _SERV_AGREGADO_SELECT.Subtotal = Convert.ToDouble(numCant.Value * numCoste.Value);
            _SERV_AGREGADO_SELECT.CostoU = Convert.ToDouble(numCoste.Value);
            _SERV_AGREGADO_SELECT.Desc = 0;
            _SERV_AGREGADO_SELECT.PrecioVariable = 1;
            _SERV_AGREGADO_SELECT.CostoU = _SERV_AGREGADO_SELECT.Subtotal / _SERV_AGREGADO_SELECT.Cantidad;

            //Editamos el servicio
            cambiaPrecioDetalleServicio(_SERV_AGREGADO_SELECT);
            actualizaTicket();
            cargaTodo();
        }

        private bool actualizaDatosTicket(DETAILS_Ticket _TicketGral)
        {
            CONSULTA_Ventas vta = new CONSULTA_Ventas();
            return vta.guardaActualizaTicket(_TicketGral,0);
        }

        private void cambiaPrecioDetalleServicio(DETAILS_Servicio _SERV_AGREGADO_SELECT)
        {
            CONSULTA_Servicio ser = new CONSULTA_Servicio();
            if (ser.UpdateDetallesServicio(_SERV_AGREGADO_SELECT))
            {
                MessageBox.Show("Se ha modificado los valores del servicio \r\n CODIGO SERVICIO: " + _SERV_AGREGADO_SELECT.IdDetalle_serv);
            }
        }


        private void cargaTodo()
        {
            cargarDatosOrden(_ORDEN_);
            _allServicesM = cargaServicios(_ORDEN_);
            _serviciosSolicitados = cargaMisServicios(_ORDEN_);
            _ProductosSolicitados = cargaProductos(_ORDEN_);
            if (_serviciosSolicitados != null)
            {
                cargaTotalesServicios(_serviciosSolicitados);
                cargaServiciosPanel1(_serviciosSolicitados, _allServicesM);
            }

            if (_serviciosSolicitados != null)
            {
                cargaTotalesProductos(_ProductosSolicitados);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DialogCRUD_Equipo equipo = new DialogCRUD_Equipo(0,_Equipo.IdEquipo);
            equipo.ShowDialog();
        }

        private void txtBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string codigo = txtBusqueda.Text;
                DETAIL_producto tmpProducto = new DETAIL_producto();
                tmpProducto = BuscaProducto(codigo);
                if (tmpProducto != null)
                {
                    //Verificamos si ya tenemos productos agregados

                    //yA SE ECNONTRO EL PRODUCTO, VAMOS A PREGUNTAR SI LO AGREGAMOS Y EN DONDE
                    string message = "Esta a punto de AGREGAR un nuevo producto " + tmpProducto.Producto.Descripcion;
                    string caption = "Agregar Productos a la Orden " + _ORDEN_.Ticket.CodigoTicket;
                    var result = MessageBox.Show(message, caption,
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question);
                    // If the no button was pressed ...
                    if (result == DialogResult.Yes)
                    {
                        CONSULTA_Ventas vta = new CONSULTA_Ventas();
                        vta.updateDetallesVta(tmpProducto, 1, _ORDEN_.Ticket.IdTicket);
                        actualizaTicket();
                    }
                    cargaTodo();
                }
                else
                { 
                    MessageBox.Show("NO EXISTE EL PRODUCTO");
                }
                txtBusqueda.SelectAll();
                txtBusqueda.Focus();
            }


        }

        private DETAIL_producto BuscaProducto(string codigo)
        {
            CONSULTA_Inventario dbPro = new CONSULTA_Inventario();
            DETAIL_producto tmpProducto = new DETAIL_producto();
            PRODUCTO pro = new PRODUCTO();
            pro = dbPro.buscarProducto(codigo);
            if (pro != null)
            {
                tmpProducto.Producto = pro;
                tmpProducto.Cantidad = 1;
                tmpProducto.Subtotal = (tmpProducto.Cantidad * pro.PrecioVenta) - pro.Descuento;
            }
            return tmpProducto;
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            int movPro = Convert.ToInt32(gridProductos.Rows[gridProductos.CurrentRow.Index].Cells[1].Value.ToString());

            DETAIL_producto proAux = new DETAIL_producto();
            proAux = _ProductosSolicitados.Find(x => x.IdMovDetalleProducto == movPro);

            if (proAux != null)
            {
                string message = "Va a eliminar un producto ya agregado y cotizado, ¿Esta seguro?";
                string caption = "Quitar producto de Orden " + _ORDEN_.Ticket.CodigoTicket;
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);
                // If the no button was pressed ...
                if (result == DialogResult.Yes)
                {
                    CONSULTA_Ventas vta = new CONSULTA_Ventas();
                    if (vta.eliminaDetalleVenta(movPro))
                    {
                        actualizaTicket();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error al momeno de actualziar");
                    }
                }
                cargaTodo();
            }
        }

        private void gridProductos_MouseClick(object sender, MouseEventArgs e)
        {
            string nombre;
            try
            {
                nombre = gridProductos.Rows[gridProductos.CurrentRow.Index].Cells[2].Value.ToString();
                btnDeleteAll.Text = "Quitar " + nombre;
                btnDeleteAll.Enabled = true;
                
            }
            catch (Exception)
            {
                btnDeleteAll.Enabled = false;
                MessageBox.Show("Seleccione un producto");
            }
           
        }

        private void button9_Click(object sender, EventArgs e)
        {
            PRODUCTO_EXTERNO = new PRODUCTO();
            DialogBuscarProducto p = new DialogBuscarProducto();
            p.ShowDialog();

            if (PRODUCTO_EXTERNO != null)
            {
                try
                {
                    string codigo = PRODUCTO_EXTERNO.CodigoInterno;
                    DETAIL_producto tmpProducto = new DETAIL_producto();
                    tmpProducto = BuscaProducto(codigo);
                    if (tmpProducto != null)
                    {
                        //Verificamos si ya tenemos productos agregados

                        //yA SE ECNONTRO EL PRODUCTO, VAMOS A PREGUNTAR SI LO AGREGAMOS Y EN DONDE
                        string message = "Esta a punto de AGREGAR un nuevo producto " + tmpProducto.Producto.Descripcion;
                        string caption = "Agregar Productos a la Orden " + _ORDEN_.Ticket.CodigoTicket;
                        var result = MessageBox.Show(message, caption,
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);
                        // If the no button was pressed ...
                        if (result == DialogResult.Yes)
                        {
                            CONSULTA_Ventas vta = new CONSULTA_Ventas();
                            vta.updateDetallesVta(tmpProducto, 1, _ORDEN_.Ticket.IdTicket);
                            actualizaTicket();
                        }
                        cargaTodo();
                    }
                    else
                    {
                        MessageBox.Show("NO EXISTE EL PRODUCTO");
                    }
                    txtBusqueda.SelectAll();
                    txtBusqueda.Focus();
                }
                catch (Exception)
                {

                }
            }
            
           
        }

        private void cboIVA_CheckedChanged(object sender, EventArgs e)
        {
            bool valor = cboIVA.Checked;
            string message = "Confirme que desea agregar factura.\r\nRevise que los datos del cliente incluyan la direccion fiscal para facturar.";
            string caption = "Facturar Orden " + _ORDEN_.Ticket.CodigoTicket;
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);
            // If the no button was pressed ...
            if (result == DialogResult.Yes)
            {
                actualizaTicket();
                cargaTodo();
            }
            else
            {
                cboIVA.Checked = valor;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            _ORDEN_.Diagnositco_tecnico = txtParteTecnico.Text;

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }
    }
}
