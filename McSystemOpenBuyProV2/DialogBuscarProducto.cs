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
    public partial class DialogBuscarProducto : Form
    {
        List<PRODUCTO> _listBDProductos;
        List<CATEGORIAS> _lisCat;
        PRODUCTO _PRODUCTO_SELECT;
        int[] arrayIdsProductos, arrayCategoria;
        public DialogBuscarProducto()
        {
            InitializeComponent();
        }

        private void DialogBuscarProducto_Load(object sender, EventArgs e)
        {
            loadCategoria();
            cargaProductos("  WHERE  `producto`.`status` = 1 ");
        }


        private void loadCategoria()
        {
            cboCategoria.Items.Clear();
            CONSULTA_Inventario consulta = new CONSULTA_Inventario();
            _lisCat = consulta.consultaCategorias();
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
                //Agregamos el o los elementos el en GRID DATA
                for (int i = 0; i < _listBDProductos.Count(); i++)
                {
                    int renglon = gridDatos.Rows.Add();
                    gridDatos.Rows[renglon].Cells[0].Value = i + 1;
                    gridDatos.Rows[renglon].Cells[1].Value = _listBDProductos[i].CodigoInterno;
                    gridDatos.Rows[renglon].Cells[2].Value = _listBDProductos[i].Descripcion;
                    gridDatos.Rows[renglon].Cells[3].Value = "$ " + _listBDProductos[i].PrecioVenta;
                    gridDatos.Rows[renglon].Cells[4].Value = "-$ " + _listBDProductos[i].Descuento;
                    gridDatos.Rows[renglon].Cells[5].Value = _listBDProductos[i].Stock > 0 ? Convert.ToString(_listBDProductos[i].Stock) : "AGOTADO";
                    gridDatos.Rows[renglon].DefaultCellStyle.BackColor = _listBDProductos[i].Stock > 0 ? Color.LightGreen : Color.LightGray;
                    //agregamos el Id delproducto a la lista
                    arrayIdsProductos[i] = _listBDProductos[i].IdProducto;
                }
                lblEncontrados.Text = "Se han encontrado: " + _listBDProductos.Count + " productos";

                if (_listBDProductos.Count == 1)
                {
                    //cargamos el elementos unico
                    //cargaDetallesProducto(_listBDProductos[0]);
                    btnSeleccionar.Text = "Agregar" + _listBDProductos[0].Descripcion;
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

        private bool BuscarEnLista(string valor)
        {
            bool bandera = false;
            gridDatos.Rows.Clear();
            arrayIdsProductos = new int[_listBDProductos.Count];

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
                    gridDatos.Rows[renglon].Cells[4].Value = "-$ " + _listBDProductos[i].Descuento;
                    gridDatos.Rows[renglon].Cells[5].Value = _listBDProductos[i].Stock > 0 ? Convert.ToString(_listBDProductos[i].Stock) : "AGOTADO";
                    gridDatos.Rows[renglon].DefaultCellStyle.BackColor = _listBDProductos[i].Stock > 0 ? Color.LightGreen : Color.LightGray;
                    //agregamos el Id delproducto a la lista
                    arrayIdsProductos[i] = _listBDProductos[i].IdProducto;
                    bandera = true;
                }
            }
            lblEncontrados.Text = "Se han encontrado: " + _listBDProductos.Count + " productos";
            //pr = _listBDProductos.Find(x => x.Descripcion.Contains(valor));
            return bandera;
        }

        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargaProductos(" WHERE  `producto`.`status` = 1 AND categoria_fk = " + arrayCategoria[cboCategoria.SelectedIndex]);
        }

        private void gridDatos_MouseClick(object sender, MouseEventArgs e)
        {
            //identificamos el index del elemento que selecciono
            string codigo = gridDatos.Rows[gridDatos.CurrentRow.Index].Cells[1].Value.ToString();
            _PRODUCTO_SELECT = new PRODUCTO();
            _PRODUCTO_SELECT = _listBDProductos.Find(x => x.CodigoInterno == codigo);

            if (_PRODUCTO_SELECT != null)
            {
                btnSeleccionar.Enabled = true;
                btnSeleccionar.Text = "Agregar " + _PRODUCTO_SELECT.Descripcion;
            }
            else
            {
                btnSeleccionar.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogServicioOrder.PRODUCTO_EXTERNO = null;
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            DialogServicioOrder.PRODUCTO_EXTERNO = _PRODUCTO_SELECT;
            this.Close();
        }

    }
}
