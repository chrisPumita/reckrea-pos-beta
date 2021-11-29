using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace McSystemOpenBuyProV2
{
    public partial class ControlPanelVenta : UserControl
    {
        List<PRODUCTO> _listBDProductos;
        List<DETAIL_producto> _detallesCarrito;
        List<PRODUCTO> tmpList = new List<PRODUCTO>();
        DETAILS_Ticket _ticketPrincipal;
        CLIENTE _Cliente;
        EMPLEADO _Empleado;
        public static int IdClienteSeleccionado;
        public static bool _PagoProcesado;
        public static double _Cambio;
        

        public ControlPanelVenta(EMPLEADO emp)
        {
            this._Empleado = emp;
            InitializeComponent();
            reset();
            string filtro = " WHERE `cliente`.`idCliente` = 1";
            BuscaCliente(filtro);

        }

        private void reset()
        {
            btnCobrar.Enabled = false;
            btnRemove.Enabled = false;
            btnDeleteAll.Enabled = false;
            btnCobrar.BackColor = Color.Gray;
            btnDeleteAll.BackColor = Color.Gray;
            btnRemove.BackColor = Color.Gray;
            //Form1.Instance.lbltitulo.Text = "TOTAL";
            //Form1.Instance.txtTotal.Text = "$00.00";
            _listBDProductos = cargaProductos();
            txtBusqueda.Focus();
        }

        private void unlook()
        {
            btnCobrar.Enabled = true;
            btnRemove.Enabled = true;
            btnDeleteAll.Enabled = true;
            btnDeleteAll.BackColor = Color.FromArgb(192, 0, 0);
            btnRemove.BackColor = Color.FromArgb(255, 101, 1);
            btnCobrar.BackColor = Color.Green;
        }

        private List<PRODUCTO> cargaProductos()
        {
            CONSULTA_Inventario cn = new CONSULTA_Inventario();
            List<PRODUCTO> listTmp = cn.consultaProducto(" WHERE `producto`.`status` = 1 ");
            return listTmp;
        }

        private List<PRODUCTO> BuscaEnLista(string valor)
        {
            List<PRODUCTO> tmpProductos = new List<PRODUCTO>();
            //Agregamos el o los elementos el en GRID DATA
            //MessageBox.Show("BUSCANDO: "+ valor);
            for (int i = 0; i < _listBDProductos.Count(); i++)
            {
                if (_listBDProductos[i].CodigoInterno == valor)
                {
                    //Buscamor el Producto solo en la BD
                    //agregamos el Id delproducto a la lista
                    tmpProductos.Add(_listBDProductos[i]);
                    break;
                }
                if (_listBDProductos[i].CodigoBarra == valor)
                {
                    //Buscamor el Producto solo en la BD
                    //agregamos el Id delproducto a la lista
                    tmpProductos.Add(_listBDProductos[i]);
                    break;
                }
            }
            return tmpProductos;
        }

        private int buscaEnCarrito(string codigo)
        {
            int i = -1;
            bool found = false;
            if (_detallesCarrito != null)
                if (_detallesCarrito.Count() != 0)
                    for (i = 0; i < _detallesCarrito.Count(); i++)
                    {
                        //Buscamos por codigo interno
                        if (_detallesCarrito[i].Producto.CodigoInterno == codigo)found = true;
                        if (_detallesCarrito[i].Producto.CodigoBarra == codigo)found = true;
                        if (found)break;
                    }
            i = found ? i : -1;
            return i;
        }

        private void cargaCarrito()
        {
            gridDatos.Rows.Clear();
            double cant = 0;
            for (int i = 0; i < _detallesCarrito.Count(); i++)
            {
                int renglon = gridDatos.Rows.Add();
                gridDatos.Rows[renglon].Cells[0].Value = _detallesCarrito[i].Cantidad;
                gridDatos.Rows[renglon].Cells[1].Value = _detallesCarrito[i].Producto.CodigoInterno;
                gridDatos.Rows[renglon].Cells[2].Value = _detallesCarrito[i].Producto.Descripcion;
                gridDatos.Rows[renglon].Cells[3].Value = "$ " + _detallesCarrito[i].Producto.PrecioVenta;
                gridDatos.Rows[renglon].Cells[4].Value = "$ " + _detallesCarrito[i].Cantidad * _detallesCarrito[i].Producto.Descuento;
                gridDatos.Rows[renglon].Cells[5].Value = "$ " + Convert.ToString(_detallesCarrito[i].Subtotal);
                //gridDatos.Rows[renglon].Cells[5].Value = "$ " + _detallesCarrito[i].Cantidad * (_detallesCarrito[i].Producto.PrecioVenta - _detallesCarrito[i].Producto.Descuento);
                cant += _detallesCarrito[i].Cantidad;
            }
            calcularTotales();
        }

        private void calcularTotales()
        {
            double contador = 0;
            
            double subtotal=0, iva=0, desc=0, total=0;
            //Tenemos almenos un calor para calcular
            if (_detallesCarrito != null && _detallesCarrito.Count > 0)
            {
                unlook();
                for (int i = 0; i < _detallesCarrito.Count; i++)
                {
                    subtotal += _detallesCarrito[i].Cantidad * _detallesCarrito[i].Producto.PrecioVenta;
                    desc += _detallesCarrito[i].Cantidad * _detallesCarrito[i].Producto.Descuento;
                    total = subtotal - desc;
                    contador += _detallesCarrito[i].Cantidad;
                    // construimos el obj de Ticket
                }
            }
            else
            {
                reset();
            }

            lblAgregados.Text = contador > 0 ? contador + " artículos agregados" : "No hay artículos";

            if (cboFactura.Checked)
                iva = (total) * 0.16;

                _ticketPrincipal = new DETAILS_Ticket(subtotal, iva, desc, total, _detallesCarrito, _Cliente);
                lblSubtotal.Text = Convert.ToString(subtotal);
                lblIVA.Text = Convert.ToString(iva);
                lblDescuento.Text = Convert.ToString(desc);
                lblTotal.Text = Convert.ToString(total + iva);
                Form1.Instance.lbltitulo.Text = "TOTAL";
                Form1.Instance.txtTotal.Text = "$" + (total+iva);
        }


        private void cargaDatosCliente(CLIENTE _Cliente)
        {
            txtCodeIn.Text = Convert.ToString(_Cliente.Id);
            txtNombre.Text = _Cliente.Nombre +" "+ _Cliente.Apm +" "+_Cliente.App;
            txtTel.Text = _Cliente.Telefono;
            txtEmail.Text = _Cliente.Correo;
            cboDomicilo.Checked = _Cliente.DatosDiscales != null ? true : false;
            
        }

        private void BuscaCliente(string filtro)
        {
            CONSULTA_Personas cn = new CONSULTA_Personas();
            List<CLIENTE> listaCliente = new List<CLIENTE>();
            listaCliente = cn.ConsultaClientes(filtro);
            if (listaCliente.Count == 1)
            {
                this._Cliente = listaCliente[0];
                cargaDatosCliente(listaCliente[0]);
            }
            else
                MessageBox.Show("Cliente no encontrado");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogPersonas people = new DialogPersonas(1,1,_Empleado);
            people.ShowDialog();
            if (IdClienteSeleccionado > 1)
            {
                string filtro = " WHERE `cliente`.`idCliente` = " + IdClienteSeleccionado;
                BuscaCliente(filtro);
            }
        }


        private void button5_Click(object sender, EventArgs e)

        {
            _ticketPrincipal.ListaDetalles = _detallesCarrito;
            _PagoProcesado = false;
            _ticketPrincipal.Cliente = _Cliente;
            if (cboFactura.Checked && _Cliente.DatosDiscales != null &&_Cliente.Id != 1)
            {
                //Cliente con datos incluidos para factura
                _ticketPrincipal.ListaDetalles = _detallesCarrito;
                DialogPago pago = new DialogPago(_ticketPrincipal, cboFactura.Checked, this._Empleado,1);
                pago.ShowDialog();

                if (_PagoProcesado != false)
                {
                    _detallesCarrito.Clear();
                    gridDatos.Rows.Clear();
                    calcularTotales();
                    txtBusqueda.SelectAll();
                    txtBusqueda.Focus();
                    MessageBoxCustom box = new MessageBoxCustom("Su cambio: Gracias", "$" + _Cambio.ToString("N2"));
                    box.ShowDialog();
                    Form1.Instance.lbltitulo.Text = "CAMBIO";
                    Form1.Instance.txtTotal.Text = "$" + _Cambio.ToString("N2");
                }
                
            }
            else if (cboFactura.Checked  && (_Cliente.DatosDiscales == null || _Cliente.Id == 1))
            {
                MessageBox.Show("Debe escribir los datos fiscales para facturación o el Cliente es incorrecto");
            }
            else
            {
                DialogPago pago = new DialogPago(_ticketPrincipal, cboFactura.Checked, _Empleado,1);
                pago.ShowDialog();
                if (_PagoProcesado != false)
                {
                    _detallesCarrito.Clear();
                    gridDatos.Rows.Clear();
                    calcularTotales();
                    txtBusqueda.SelectAll();
                    txtBusqueda.Focus();

                    Form1.Instance.lbltitulo.Text = "CAMBIO";
                    Form1.Instance.txtTotal.Text = "$" + _Cambio.ToString("N2");
                    MessageBoxCustom box = new MessageBoxCustom("Su cambio: Gracias", "$" + _Cambio.ToString("N2"));
                    box.ShowDialog();  
                }
            }
           
        }

        private void txtBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cargaProductos();
                string codigo = txtBusqueda.Text;
                tmpList = BuscaEnLista(codigo);
                if (tmpList != null && tmpList.Count > 0)
                {
                    if (tmpList.Count == 1)
                    {
                        //Buscamos el producto en el carrito, em metodo buscaro en ambos campos
                        int index = buscaEnCarrito(codigo);
                        if (_detallesCarrito != null && _detallesCarrito.Count > 0)
                        {
                            // el carrito ya tiene productos                        
                                // ya existe producto en lista, entonces le sumamos uno
                            if (index!= -1)
                                _detallesCarrito[index].Cantidad = 1;
                            else
                            {
                                //no existe, entonces le agregamos un producto al final
                                DETAIL_producto newProducto = new DETAIL_producto(1, tmpList[0]);
                                _detallesCarrito.Add(newProducto);
                            }
                        }
                        else
                        {
                            _detallesCarrito = new List<DETAIL_producto>();
                            //no existe, entonces le agregamos un producto al final
                            DETAIL_producto newProducto = new DETAIL_producto(1, tmpList[0]);
                            _detallesCarrito.Add(newProducto);
                        }
                        //en ambos casos cargamos la lista de productos
                        cargaCarrito();
                    }
                    else
                        MessageBox.Show("HAY "+tmpList.Count+"REGISTROS DE UN PRODUCTO CON EL MISMO CODIGO");
                }
                else
                    MessageBox.Show("NO EXISTE EL PRODUCTO");
                txtBusqueda.SelectAll();
                txtBusqueda.Focus();
            }
        }

        private void cboFactura_CheckedChanged(object sender, EventArgs e)
        {
            calcularTotales();
        }

        private void txtBusqueda_MouseClick(object sender, MouseEventArgs e)
        {
            txtBusqueda.SelectAll();
            txtBusqueda.Focus();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            _detallesCarrito.Clear();
            gridDatos.Rows.Clear();
            calcularTotales();
            txtBusqueda.SelectAll();
            txtBusqueda.Focus();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            _detallesCarrito.RemoveAt(_detallesCarrito.Count-1);
            cargaCarrito();
            calcularTotales();
            txtBusqueda.SelectAll();
            txtBusqueda.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogCliente addCliente = new DialogCliente(1);
            addCliente.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogCliente box = new DialogCliente(0,_Cliente,cboFactura.Checked);
            box.ShowDialog();
            string filtro = " WHERE `cliente`.`idCliente` = " + _Cliente.Id;
            BuscaCliente(filtro);
        }

        private void txtBuscarCliente_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                try 
	            {	        
		        int idBuscar = Convert.ToInt32(txtBuscarCliente.Text);
                if (idBuscar > 0)
                {
                    string filtro = " WHERE `cliente`.`idCliente` = " + txtBuscarCliente.Text;
                    BuscaCliente(filtro);
                }
                else
                    MessageBox.Show("ID de cliennte no válido, porfabor búsquelo");
                    DialogPersonas people = new DialogPersonas(1,1,_Empleado);
                    people.ShowDialog();
	            }
	            catch (Exception)
	            {
		            MessageBox.Show("Debe escribir un ID valido");
                    txtBuscarCliente.Text = "";
                    txtBuscarCliente.Focus();
	            }
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            string filtro = " WHERE `cliente`.`idCliente` = 1";
            BuscaCliente(filtro);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            cargaProductos();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
