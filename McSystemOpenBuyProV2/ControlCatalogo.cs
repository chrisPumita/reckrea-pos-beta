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
    public partial class ControlCatalogo : UserControl
    {

        List<PRODUCTO> _listBDProductos;
        List<CATEGORIAS> _lisCat;
        List<MARCA> _lisMarca; 
        int[] arrayIdsProductos, arrayCategoria, arrayMarca;
        public ControlCatalogo()
        {
            InitializeComponent();
            lblId.Text = "0";
        }

        private void loadCategoria()
        {
            cboCategoria.Items.Clear();
            CONSULTA_Inventario consulta = new CONSULTA_Inventario();
            _lisCat = consulta.consultaCategorias();
            _lisMarca = consulta.consultaMarcas();
            if (_lisCat != null)
            {
                arrayCategoria = new int[_lisCat.Count];
                for (int i = 0; i < _lisCat.Count; i++)
                    if (_lisCat[i].Estatus != 0) // va para todas
                    {
                        arrayCategoria[i] = _lisCat[i].IdCategoria;
                        cboCategoria.Items.Add(_lisCat[i].Nombre);
                    }
            }
        }

        private void cargaProductos(string filtro)
        {
            //creamos la consulta
            CONSULTA_Inventario cn = new CONSULTA_Inventario();
            _listBDProductos = cn.consultaProducto(filtro);
            //ya tenemos una lista de objetos u obj y decidimos que hacer
            gridDatos.Rows.Clear();
            if (_listBDProductos != null)
            {
                arrayIdsProductos = new int[_listBDProductos.Count];
                restablecer();
                //Agregamos el o los elementos el en GRID DATA
                for (int i = 0; i < _listBDProductos.Count(); i++)
                {
                    int renglon = gridDatos.Rows.Add();
                    gridDatos.Rows[renglon].Cells[0].Value = i + 1;
                    gridDatos.Rows[renglon].Cells[1].Value = _listBDProductos[i].CodigoInterno;
                    gridDatos.Rows[renglon].Cells[2].Value = _listBDProductos[i].Descripcion;
                    gridDatos.Rows[renglon].Cells[3].Value = "$ " + _listBDProductos[i].PrecioVenta;
                    gridDatos.Rows[renglon].Cells[4].Value = _listBDProductos[i].Stock > 0 ? Convert.ToString(_listBDProductos[i].Stock) : "AGOTADO";
                    gridDatos.Rows[renglon].DefaultCellStyle.BackColor = _listBDProductos[i].Stock > 0 ? Color.LightGreen : Color.LightGray;
                    //agregamos el Id delproducto a la lista
                    arrayIdsProductos[i] = _listBDProductos[i].IdProducto;
                }
                lblEncontrados.Text = "Se han encontrado: " + _listBDProductos.Count + " productos";

                if (_listBDProductos.Count == 1)
                {
                    //cargamos el elementos unico
                    cargaDetallesProducto(_listBDProductos[0]);
                    lblEncontrados.Text = "Un Producto encontrado";
                }
                AutoCompleteStringCollection data = new AutoCompleteStringCollection();
                for (int i = 0; i < _listBDProductos.Count; i++)
			        data.Add(_listBDProductos[i].Descripcion);

                txtCajaBusqueda.AutoCompleteCustomSource = data;
                txtCajaBusqueda.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtCajaBusqueda.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            
        }

        private void cargaDetallesProducto(PRODUCTO prod)
        {
            //cargamos los Detalles del Producto y los vosualizamos
            string marca = "";
            for (int i = 0; i < _lisMarca.Count; i++)
            {
                if (prod.Marca_fk == _lisMarca[i].IdMarca)
                    marca = ", Marca: " + _lisMarca[i].Nombre;
            }
            txtDesc.Text = prod.Descripcion + marca;
            lblBarcode.Text = prod.CodigoBarra;
            lblCodeIn.Text = prod.CodigoInterno;
            lblStock.Text = prod.Stock > 0 ? Convert.ToString(prod.Stock) : "AGOTADO";
            lblPrecio.Text = "$ " +prod.PrecioVenta;
            lblDescuento.Text = "$" + prod.Descuento;
            lblTotal.Text = "$" + (prod.PrecioVenta-prod.Descuento);
            lblId.Text = Convert.ToString(prod.IdProducto);
            if(diferenciaDias(prod.FechaCaptura) <= 1 ) imgNew.Show(); 
            else imgNew.Hide();
        }

        private PRODUCTO buscaProductoLista(int id)
        {
            int index = 0;
            for (int i = 0; i < _listBDProductos.Count; i++)
            {
                if (_listBDProductos[i].IdProducto == id)
                {
                    index = i;
                    break;
                }
            }
            return _listBDProductos[index];
        }

        private void restablecer()
        {
            txtDesc.Clear();
            lblCodeIn.Text = "";
            lblStock.Text = "";
            lblPrecio.Text = "";
            lblDescuento.Text ="";
            lblTotal.Text = "";
            lblId.Text = "";
            lblBarcode.Text = "";
            imgNew.Hide();
        }

        private bool BuscarEnLista(string valor)
        {
            bool bandera = false;
                gridDatos.Rows.Clear();
                arrayIdsProductos = new int[_listBDProductos.Count];
                restablecer();
                int i;
                //Agregamos el o los elementos el en GRID DATA
                for (i = 0; i < _listBDProductos.Count(); i++)
                {
                    if (_listBDProductos[i].Descripcion.Contains(valor))
	                {
                        int renglon = gridDatos.Rows.Add();
                        gridDatos.Rows[renglon].Cells[0].Value = i + 1;
                        gridDatos.Rows[renglon].Cells[1].Value = _listBDProductos[i].CodigoInterno;
                        gridDatos.Rows[renglon].Cells[2].Value = _listBDProductos[i].Descripcion;
                        gridDatos.Rows[renglon].Cells[3].Value = "$ " + _listBDProductos[i].PrecioVenta;
                        gridDatos.Rows[renglon].Cells[4].Value = _listBDProductos[i].Stock > 0 ? Convert.ToString(_listBDProductos[i].Stock) : "AGOTADO";
                        gridDatos.Rows[renglon].DefaultCellStyle.BackColor = _listBDProductos[i].Stock > 0 ? Color.LightGreen : Color.LightGray;
                        //agregamos el Id delproducto a la lista
                        arrayIdsProductos[i] = _listBDProductos[i].IdProducto;
                        bandera = true;
	                }
                }

                if (_listBDProductos.Count == 1)
                {
                    cargaDetallesProducto(_listBDProductos[i]);
                }

                lblEncontrados.Text = "Se han encontrado: " + _listBDProductos.Count + " productos";
                //pr = _listBDProductos.Find(x => x.Descripcion.Contains(valor));
                return bandera;
        }

        private int diferenciaDias(DateTime fecha)
        {
           // DateTime oldDate = new DateTime(Convert.ToUInt32(fecha.ToString("yyyy")), 1, 20);
            DateTime newDate = DateTime.Now;
            TimeSpan ts = newDate - fecha;
            int differenceInDays = ts.Days;
            return differenceInDays;
        }

        private void ControlCatalogo_Load(object sender, EventArgs e)
        {
            loadCategoria();
            cargaProductos("  WHERE  `producto`.`status` = 1 ");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PRODUCTO p;
            int id =Convert.ToInt32(lblId.Text);
            DialogProducto editaPro = new DialogProducto(0,buscaProductoLista(id));
            editaPro.ShowDialog();
            cargaProductos("");
            if (buscaProductoLista(id) != null)
                cargaDetallesProducto(buscaProductoLista(id));
            else
                MessageBox.Show("Producto no disponible");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            cargaProductos(" WHERE  `producto`.`status` = 1  ");
        }

        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargaProductos(" WHERE  `producto`.`status` = 1 AND categoria_fk = " + arrayCategoria[cboCategoria.SelectedIndex]);
        }

        private void gridDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //identificamos el index del elemento que selecciono
            string codigo = gridDatos.Rows[gridDatos.CurrentRow.Index].Cells[1].Value.ToString();
            for (int i = 0; i < _listBDProductos.Count; i++)
            {
                if (_listBDProductos[i].CodigoInterno == codigo)
                {
                    cargaDetallesProducto(_listBDProductos[i]);
                    break;
                }
            }
        }

        private void gridDatos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //identificamos el index del elemento que selecciono
            string codigo = gridDatos.Rows[gridDatos.CurrentRow.Index].Cells[1].Value.ToString();
            for (int i = 0; i < _listBDProductos.Count; i++)
            {
                if (_listBDProductos[i].CodigoInterno == codigo)
                {
                    cargaDetallesProducto(_listBDProductos[i]);
                    break;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(lblCodeIn.Text, true);
            lblCopiado.Show();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           lblCopiado.Hide();
           timer1.Stop();
        }

        private void txtCajaBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
                if (!BuscarEnLista(txtCajaBusqueda.Text))
                    MessageBox.Show("No se encontraron coincidencias con: \"" +txtCajaBusqueda.Text+"\"");
        }

        private void txtCajaBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!BuscarEnLista(txtCajaBusqueda.Text))
                    MessageBox.Show("No se encontraron coincidencias con: \"" + txtCajaBusqueda.Text + "\"");
            }
        }

        private void txtCajaBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (txtCajaBusqueda.Text != null)
            {
                List<PRODUCTO> tmp_pro = new List<PRODUCTO>();
                foreach (PRODUCTO tmpP in _listBDProductos)
                {
                    if (tmpP.Descripcion.Contains(txtCajaBusqueda.Text))
                    {
                        BuscarEnLista(txtCajaBusqueda.Text);
                    }
                    
                }
               
            }

        }

    }
}
