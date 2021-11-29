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
    public partial class Frm_ReporteVtas : Form
    {
        List<DETAILS_Ticket> _listaTickets = new List<DETAILS_Ticket>();
        public Frm_ReporteVtas()
        {
            InitializeComponent();
        }

        private void Frm_ReporteVtas_Load(object sender, EventArgs e)
        {
            DateTime fechaActual = new DateTime();
            fechaActual = DateTime.Today;
            string sql = "  WHERE  `ticket_vta`.`estado` !=0 AND  `ticket_vta`.`fechaHora` >  '" + fechaActual.ToString("yyyy-MM-dd HH:mm:ss") + "'  ORDER BY `ticket_vta`.`fechaHora` DESC  ";
            cargarVentas(sql);
            fechaInicial.MaxDate = DateTime.Today;
            fechaFinal.MaxDate =  DateTime.Today;
            cboPago.SelectedIndex = cboPago.Items.Count-1;
        }

        private void cargarVentas(string sql )
        {
            CONSULTA_Ventas vta = new CONSULTA_Ventas();
            _listaTickets = vta.ConsultaTicket(sql);
            muestraEnGrid(_listaTickets);
        }

        private void cargarVentas()
        {
            CONSULTA_Ventas vta = new CONSULTA_Ventas();
            string sql = " WHERE  `ticket_vta`.`estado` !=0  ORDER BY `ticket_vta`.`fechaHora` DESC ";
            _listaTickets = vta.ConsultaTicket(sql);
            muestraEnGrid(_listaTickets);
        }

        private void muestraEnGrid(List<DETAILS_Ticket> _listaTickets)
        {
            gridDatos.Rows.Clear();

            if (_listaTickets != null)
            {
                double t_subtotal = 0;
                double t_descuento = 0;
                double t_iva = 0;
                double t_total = 0;
                //Agregamos el o los elementos el en GRID DATA
                for (int i = 0; i < _listaTickets.Count(); i++)
                {
                    int renglon = gridDatos.Rows.Add();
                   // gridDatos.Rows[renglon].Cells[0].Value = i + 1;
                    gridDatos.Rows[renglon].Cells[0].Value = _listaTickets[i].IdTicket;
                    gridDatos.Rows[renglon].Cells[1].Value = _listaTickets[i].CodigoTicket;
                    gridDatos.Rows[renglon].Cells[2].Value = _listaTickets[i].FechaHora.ToString("dd MMM yyyy hh:mm tt", CultureInfo.CreateSpecificCulture("es-MX"));
                    gridDatos.Rows[renglon].Cells[3].Value = "$ " + _listaTickets[i].Subtotal;
                    gridDatos.Rows[renglon].Cells[4].Value = "$ " + _listaTickets[i].Descuento;
                    gridDatos.Rows[renglon].Cells[5].Value = "$ " + _listaTickets[i].Iva;
                    gridDatos.Rows[renglon].Cells[6].Value = "$ " + _listaTickets[i].Total;
                    gridDatos.Rows[renglon].Cells[7].Value = _listaTickets[i].Empleado.Nombre + " " + _listaTickets[i].Empleado.App;
                    gridDatos.Rows[renglon].Cells[8].Value = _listaTickets[i].EstatusTicket == 1 ? "PAGADO" : "POR COBRAR";
                    gridDatos.Rows[renglon].Cells[9].Value = defFormaPago(_listaTickets[i].FormaPago);


                    t_subtotal += _listaTickets[i].Subtotal;
                    t_descuento += _listaTickets[i].Descuento;
                    t_iva += _listaTickets[i].Iva;
                    t_total += +_listaTickets[i].Total;


                }
                lblEncontrados.Text = "Se han encontrado: " + _listaTickets.Count + " productos";

                lblSub.Text = "$" + t_subtotal;
                lblDesc.Text = "$" + t_descuento;
                lblIVA.Text = "$" + t_iva;
                lblTotal.Text = "$" + t_total;

                if (_listaTickets.Count == 1)
                {
                    //cargamos el elementos unico
                    //cargaDetallesProducto(_listBDProductos[0]);
                    lblEncontrados.Text = "Un Producto encontrado";
                }
                
            }
        }

        private string defFormaPago(int n)
        {
            string formaPago = "";
            switch (n)
            {
                case 0:
                    formaPago = "EFECTIVO";
                    break;
                case 1:
                    formaPago = "DEBITO";
                    break;
                case 2:
                    formaPago = "CREDITO";
                    break;
                case 3:
                    formaPago = "TRASNFERENCIA";
                    break;
                case 4:
                    formaPago = "CODI";
                    break;
                case 5:
                    formaPago = "MERCADO PAGO";
                    break;
            }

            return formaPago;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime fechaActual = DateTime.Today;
            string sql = "    WHERE  `ticket_vta`.`estado` !=0 AND  `ticket_vta`.`fechaHora` >  '" + fechaActual.ToString("yyyy-MM-dd HH:mm:ss") + "'  ORDER BY `ticket_vta`.`fechaHora` DESC   ";
            cargarVentas(sql);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "  WHERE  `ticket_vta`.`estado` !=2   ORDER BY `ticket_vta`.`fechaHora` DESC  ";
            cargarVentas(sql);
        }

        private void gridDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gridDatos_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                string codigo = gridDatos.Rows[gridDatos.CurrentRow.Index].Cells[0].Value.ToString();
                CONSULTA_Ventas cn = new CONSULTA_Ventas();
                CONSULTA_Servicio serv = new CONSULTA_Servicio();

                List<DETAILS_Servicio> lsServicios = new List<DETAILS_Servicio>();
                List<DETAIL_producto> lsProductos = new List<DETAIL_producto>();

                lsProductos = cn.ConsultaDetallestIcket(Convert.ToInt32(codigo));
                lsServicios = new List<DETAILS_Servicio>();
               
                txtProductos.Clear();
                double total = 0;
                if (lsProductos != null)
                {
                    txtProductos.Text += "_____________PRODUCTOS_____________\r\n";
                    for (int i = 0; i < lsProductos.Count; i++)
                    {
                        txtProductos.Text += "\r\n";
                        txtProductos.Text += lsProductos[i].Cantidad + "   " + (lsProductos[i].Producto.Descripcion.Length < 35 ? lsProductos[i].Producto.Descripcion : lsProductos[i].Producto.Descripcion.Substring(0, 35))
                            + "\r\n" + "@ $" + (lsProductos[i].Producto.PrecioVenta - lsProductos[i].Producto.Descuento) + " c/u x " + lsProductos[i].Cantidad
                            + " Pzs = $" + ((lsProductos[i].Producto.PrecioVenta - lsProductos[i].Producto.Descuento) * lsProductos[i].Cantidad);
                        txtProductos.Text += "\r\n";
                        total += (lsProductos[i].Producto.PrecioVenta - lsProductos[i].Producto.Descuento) * lsProductos[i].Cantidad;
                    }

                    txtProductos.Text += "\r\n========== TOTAL: $ " + total + "  ==========";
                }

               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error, codigo id no valido" + ex);
            }
            
        }

        private void fechaInicial_ValueChanged(object sender, EventArgs e)
        {
            
            fechaFinal.MinDate = fechaInicial.Value;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DateTime FechaInicio = fechaInicial.Value;
            DateTime FechaFin = fechaFinal.Value;
            string filtro = "";

            if (cboPago.SelectedIndex != cboPago.Items.Count-1)
            {
                //Selecciono una forma de pago
                filtro = " AND  `ticket_vta`.`modoPago`  =  " + cboPago.SelectedIndex;
            }
            string sql = "    WHERE  `ticket_vta`.`estado` !=0 AND  `ticket_vta`.`fechaHora` >  '" + FechaInicio.ToString("yyyy-MM-dd 00:00:00") +
                "'  AND  `ticket_vta`.`fechaHora`  <  '" + FechaFin.ToString("yyyy-MM-dd 23:59:59") + "'   "+filtro+"  ORDER BY `ticket_vta`.`fechaHora` DESC   ";
            cargarVentas(sql);
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
