using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace McSystemOpenBuyProV2
{
    public partial class ControlServicio : UserControl
    {
        List<OrdenServicio> _listOrdenesServicios = new List<OrdenServicio>();
        //Guardamos la lista de servicios disponibles
        List<SERVICIO> _listServices = new List<SERVICIO>();
        List<MARCA> _listMarcas = new List<MARCA>();
        OrdenServicio _servicioSelected = null;
        EMPLEADO _Emp;
        public ControlServicio(EMPLEADO _Emp)
        {
            this._Emp = _Emp;
            InitializeComponent();
            actualizaServicios();
        }

        private void actualizaServicios()
        {
            CONSULTA_Inventario marcas = new CONSULTA_Inventario();
            _listMarcas = marcas.consultaMarcas();
            cargaOrdenesServicios("  `orden_serivicio`.`estado_service` <> 0 AND  `orden_serivicio`.`estado_service` <> 3 AND ");
        }


        private void cargaOrdenesServicios(string fil)
        {
            //Metodo encargado de filtrar los servicios traidos de la base de datos
            //Consulta de servicios, para cada equipo
            CONSULTA_Servicio conServ = new CONSULTA_Servicio();
            
            _listOrdenesServicios = conServ.ConsultaServiciosPanel(fil);
            cargarListaGrid(_listOrdenesServicios);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            DialogPersonas selectCliente = new DialogPersonas(1, 2, this._Emp);
            selectCliente.ShowDialog();
            cargaOrdenesServicios("  `orden_serivicio`.`estado_service` <> 0  AND  `orden_serivicio`.`estado_service` <> 3 AND");
        }

        private void cargarListaGrid(List<OrdenServicio> tmpList)
        {
            gridDatos.Rows.Clear();
            if (tmpList != null)
            {
                //Agregamos el o los elementos el en GRID DATA
                for (int i = 0; i < tmpList.Count(); i++)
                {
                    int renglon = gridDatos.Rows.Add();
                    gridDatos.Rows[renglon].Cells[0].Value = tmpList[i].IdOrdenServicio;
                    gridDatos.Rows[renglon].Cells[2].Value = tmpList[i].Ticket.CodigoTicket;
                    gridDatos.Rows[renglon].Cells[3].Value = tmpList[i].Ticket.Cliente.Nombre;
                    gridDatos.Rows[renglon].Cells[4].Value = tmpList[i].Equipo.Detalles;
                    gridDatos.Rows[renglon].Cells[5].Value = tmpList[i].Reporte_cliente;
                    gridDatos.Rows[renglon].Cells[6].Value = tmpList[i].FechaIngreso.ToString("dd MMM yyyy hh:mm tt", CultureInfo.CreateSpecificCulture("es-MX"));

                    switch (tmpList[i].Estado_service)
                    {
                        case 0:
                            //gridDatos.Rows[renglon].Cells[6].Value = "CANCELADO";
                            gridDatos.Rows[renglon].Cells[1].Value =  Properties.Resources.State_cancelado;
                            gridDatos.Rows[renglon].DefaultCellStyle.BackColor = Color.Red;
                            break;
                        case 1:
                            gridDatos.Rows[renglon].DefaultCellStyle.BackColor = Color.LightBlue;
                            gridDatos.Rows[renglon].Cells[1].Value = Properties.Resources.State_onService;
                           // gridDatos.Rows[renglon].Cells[6].Value = "EN SERVICIO";
                            break;
                        case 2:
                         //   gridDatos.Rows[renglon].Cells[6].Value = "LISTO PARA ENTREGA";
                            gridDatos.Rows[renglon].DefaultCellStyle.BackColor = Color.Yellow;
                            gridDatos.Rows[renglon].Cells[1].Value = Properties.Resources.State_listoEntrega;
                            break;
                        case 3:
                           // gridDatos.Rows[renglon].Cells[6].Value = "ENTREGADO";
                            gridDatos.Rows[renglon].DefaultCellStyle.BackColor = Color.Green;
                            gridDatos.Rows[renglon].Cells[1].Value = Properties.Resources.Statel_entregado;
                            break;
                        case 4:
                            //gridDatos.Rows[renglon].Cells[6].Value = "COTIZADO A ESPERA";
                            gridDatos.Rows[renglon].DefaultCellStyle.BackColor = Color.Orange;
                            gridDatos.Rows[renglon].Cells[1].Value = Properties.Resources.State_cotizar;
                            break;
                        case 5:
                            //gridDatos.Rows[renglon].Cells[6].Value = "GARANTIA";
                            gridDatos.Rows[renglon].DefaultCellStyle.BackColor = Color.LightYellow;
                            gridDatos.Rows[renglon].Cells[1].Value = Properties.Resources.State_garantia;
                            break;
                        case 6:
                            //gridDatos.Rows[renglon].Cells[6].Value = "ALMACENADO";
                            gridDatos.Rows[renglon].DefaultCellStyle.BackColor = Color.Gray;
                            gridDatos.Rows[renglon].Cells[1].Value = Properties.Resources.Statel_bodega;
                            break;
                        default:
                            //gridDatos.Rows[renglon].Cells[6].Value = "OTRO";
                            gridDatos.Rows[renglon].DefaultCellStyle.BackColor = Color.White;
                            gridDatos.Rows[renglon].Cells[1].Value = Properties.Resources.State_cancelado;
                            break;
                    }
                    
                }
                lblEncontrados.Text = "Se han encontrado: " + tmpList.Count + " servicios";
                if (tmpList.Count == 1)
                {
                    lblEncontrados.Text = "Un servicio encontrado";
                }
            }
        }

        private void gridDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            actualizaServicios();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogServicioOrder detailsOrder = new DialogServicioOrder(_servicioSelected,0);
            detailsOrder.ShowDialog();
            actualizaServicios();
        }

     
        private void filtro(int opc)
        {
            string sSQL = "  `orden_serivicio`.`estado_service` = ";
            switch (opc)
            {
                case 0:
                    sSQL += " 0 ";
                    sSQL += " AND ";
                    break;
                case 1:
                    sSQL += " 1 ";
                    sSQL += " AND ";
                    break;
                case 2:
                    sSQL += " 2 ";
                    sSQL += " AND ";
                    break;
                case 3:
                    sSQL += " 3 ";
                    sSQL += " AND ";
                    break;
                case 4:
                    sSQL += " 4 ";
                    sSQL += " AND ";
                    break;
                case 5:
                    sSQL += " 5 ";
                    sSQL += " AND ";
                    break;
                case 6:
                    sSQL += " 6 ";
                    sSQL += " AND ";
                    break;
                case 7:
                    sSQL = "   `orden_serivicio`.`fechaIngreso` BETWEEN NOW() - INTERVAL 30 DAY AND NOW()  ";
                    sSQL += " AND ";
                    break;
                case 8:
                    sSQL = "  ";
                    break;
                default:
                    sSQL = "  ";
                    break;
            }

            cargaOrdenesServicios(sSQL);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (_servicioSelected != null)
            {
                btnEntrega.Enabled = true;
                 string message = "Se va a entregar el equipo y terminar el servicio. ¿Esta seguro?";
                 string caption = "Entregar Equipo " + _servicioSelected.Equipo.Detalles;
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);
                // If the no button was pressed ...
                if (result == DialogResult.Yes)
                {
                    CONSULTA_Servicio cn = new CONSULTA_Servicio();
                    if (cn.ActualizaEstadoOrdenServicio(_servicioSelected,3))
                    {
                        MessageBox.Show("Se ha entregado el equipo, Gracias"+_servicioSelected.IdOrdenServicio);
                    }
                    actualizaServicios();
                }
            }
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogServicioOrder detailsOrder = new DialogServicioOrder(_servicioSelected, 3);
            detailsOrder.ShowDialog();
            actualizaServicios();
        }

        private void gridDatos_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //identificamos el index del elemento que selecciono
            string codigo = gridDatos.Rows[gridDatos.CurrentRow.Index].Cells[2].Value.ToString();
            btnEntrega.Enabled = false;
            _servicioSelected = _listOrdenesServicios.Find(x=>x.Ticket.CodigoTicket==codigo);
            if (_servicioSelected != null)
            {
                if (_servicioSelected.Estado_service != 0 && _servicioSelected.Estado_service != 3)
                {
                    btnEntrega.Enabled = true;
                    btnDetalles.Enabled = true;
                }
                else
                {
                    btnEntrega.Enabled = false;
                    btnDetalles.Enabled = true;
                }
            }
            else
            {
            }

        }

        private void gridDatos_MouseClick(object sender, MouseEventArgs e)
        {
            //identificamos el index del elemento que selecciono
            string codigo = gridDatos.Rows[gridDatos.CurrentRow.Index].Cells[2].Value.ToString();
            btnEntrega.Enabled = false;
            _servicioSelected = _listOrdenesServicios.Find(x => x.Ticket.CodigoTicket == codigo);
            if (_servicioSelected != null)
            {
                if (_servicioSelected.Estado_service != 0 && _servicioSelected.Estado_service != 3)
                {
                    btnEntrega.Enabled = true;
                    btnDetalles.Enabled = true;
                }
                else
                {
                    btnEntrega.Enabled = false;
                    btnDetalles.Enabled = true;
                }
            }
            else
            {
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int noOrden = Convert.ToInt32(txtBuscarOrden.Text);
                cargaOrdenesServicios("  `orden_serivicio`.`idOrdenServicio` = '"+noOrden+"' AND ");
            }
            catch (Exception)
            {
                
            }
            
        }

        private void txtBuscarOrden_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
                {
                    e.Handled = false;
                }
                else
                {
                    //el resto de teclas pulsadas se desactivan
                    e.Handled = true;
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            actualizaServicios();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            filtro(1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            filtro(2);
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            filtro(4);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            filtro(5);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            filtro(6);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            filtro(0);
        }
        private void button12_Click(object sender, EventArgs e)
        {
            filtro(100);
        }

        private void txtBuscarOrden_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    int noOrden = Convert.ToInt32(txtBuscarOrden.Text);
                    cargaOrdenesServicios("  `orden_serivicio`.`idOrdenServicio` = '" + noOrden + "' AND ");
                    txtBuscarOrden.Clear();
                }
                catch (Exception)
                {

                }
            }
        }


    }
}
