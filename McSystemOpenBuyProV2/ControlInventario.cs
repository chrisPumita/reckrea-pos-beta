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
    public partial class ControlInventario : UserControl
    {
        List<PRODUCTO> _listBDProductos;
        List<CATEGORIAS> _listaCat;
        List<MARCA> _listMar;
        PRODUCTO _productoSelect;

        public ControlInventario()
        {
            InitializeComponent();
            loadCategoria();
            cargaProductos(" ");
        }

        private void loadCategoria()
        {
            cboCategoria.Items.Clear();
            CONSULTA_Inventario consulta = new CONSULTA_Inventario();
            _listaCat = consulta.consultaCategorias();
            _listMar = consulta.consultaMarcas();
            
            if (_listaCat != null)
            {
                int[] categoria = new int[_listaCat.Count];
                
                for (int i = 0; i < _listaCat.Count; i++)
                {
                    if (_listaCat[i].Estatus != 0) // va para todas
                    {
                        categoria[i] = _listaCat[i].IdCategoria;
                        cboCategoria.Items.Add(_listaCat[i].Nombre);
                    }
                }
            }
        }

        private string getNameCategoria (int id)
        {
            string nombre = null;
            for (int i = 0; i < _listaCat.Count; i++)
                if (id == _listaCat[i].IdCategoria)
                    nombre = _listaCat[i].Nombre;
            return nombre;
        }

        private string getNameMarca(int id)
        {
            string nombre = null;
            for (int i = 0; i < _listMar.Count; i++)
                if (id == _listMar[i].IdMarca)
                    nombre = _listMar[i].Nombre;
            return nombre;
        }

        private void cargaProductos(string filtro)
        {
            //creamos la consulta
            CONSULTA_Inventario cn = new CONSULTA_Inventario();
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            _listBDProductos = cn.consultaProducto(filtro);
            //ya tenemos una lista de objetos u obj y decidimos que hacer
            gridDatos.Rows.Clear();
            if (_listBDProductos != null)
            {
                //Agregamos el o los elementos el en GRID DATA
                for (int i = 0; i < _listBDProductos.Count(); i++)
                {
                    int renglon = gridDatos.Rows.Add();
                    gridDatos.Rows[renglon].Cells[0].Value = i + 1;
                    gridDatos.Rows[renglon].Cells[1].Value = _listBDProductos[i].CodigoInterno;
                    gridDatos.Rows[renglon].Cells[2].Value = getNameCategoria(_listBDProductos[i].Categoria_fk);
                    gridDatos.Rows[renglon].Cells[3].Value = _listBDProductos[i].Descripcion;
                    gridDatos.Rows[renglon].Cells[4].Value = getNameMarca(_listBDProductos[i].Marca_fk);
                    gridDatos.Rows[renglon].Cells[5].Value = "$ " + _listBDProductos[i].PrecioVenta.ToString("N2");
                    gridDatos.Rows[renglon].Cells[6].Value = _listBDProductos[i].Descuento > 0 ? "$ " + _listBDProductos[i].Descuento.ToString("N2") : "-";
                    gridDatos.Rows[renglon].Cells[7].Value = _listBDProductos[i].Stock > 0 ? Convert.ToString(_listBDProductos[i].Stock) : "AGOTADO";
                    gridDatos.Rows[renglon].DefaultCellStyle.BackColor = _listBDProductos[i].Stock > 0 ?  Color.LightGreen : Color.LightGray;
                    gridDatos.Rows[renglon].Cells[8].Value = _listBDProductos[i].FechaCaptura.ToString("dd-MM-yyyy HH:mm:ss");
                   gridDatos.Rows[renglon].Cells[9].Value = _listBDProductos[i].Status == 1 ? Properties.Resources.onBlue : Properties.Resources.offRed;
                }
                lblEncontrados.Text = "Se han encontrado: " + _listBDProductos.Count + " productos";

                if (_listBDProductos.Count == 1)
                {
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

        private void cargarListaGrid(List<PRODUCTO> tmpList)
        {
            gridDatos.Rows.Clear();
            if (tmpList != null)
            {
                //Agregamos el o los elementos el en GRID DATA
                for (int i = 0; i < tmpList.Count(); i++)
                {
                    int renglon = gridDatos.Rows.Add();
                    gridDatos.Rows[renglon].Cells[0].Value = i + 1;
                    gridDatos.Rows[renglon].Cells[1].Value = tmpList[i].CodigoInterno;
                    gridDatos.Rows[renglon].Cells[2].Value = getNameCategoria(tmpList[i].Categoria_fk);
                    gridDatos.Rows[renglon].Cells[3].Value = tmpList[i].Descripcion;
                    gridDatos.Rows[renglon].Cells[4].Value = getNameMarca(tmpList[i].Marca_fk);
                    gridDatos.Rows[renglon].Cells[5].Value = "$ " + tmpList[i].PrecioVenta.ToString("N2");
                    gridDatos.Rows[renglon].Cells[6].Value = tmpList[i].Descuento > 0 ? "$ " + tmpList[i].Descuento.ToString("N2") : "-";
                    gridDatos.Rows[renglon].Cells[7].Value = tmpList[i].Stock > 0 ? Convert.ToString(tmpList[i].Stock) : "AGOTADO";
                    gridDatos.Rows[renglon].Cells[8].Value = tmpList[i].FechaCaptura.ToString("dd-MM-yyyy HH:mm:ss");
                    gridDatos.Rows[renglon].Cells[9].Value = tmpList[i].Status == 1 ? Properties.Resources.onBlue : Properties.Resources.offRed;

                }
                lblEncontrados.Text = "Se han encontrado: " + tmpList.Count + " productos";
                if (tmpList.Count == 1)
                {
                    lblEncontrados.Text = "Un Producto encontrado";
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogProducto productos = new DialogProducto(1);
            productos.ShowDialog();
            cargaProductos(" ");
        }

        private void gridDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //identificamos el index del elemento que selecciono
            string codigo = gridDatos.Rows[gridDatos.CurrentRow.Index].Cells[1].Value.ToString();
            btnEliminar.Enabled = false;
            for (int i = 0; i < _listBDProductos.Count; i++)
            {
                if (_listBDProductos[i].CodigoInterno == codigo && _listBDProductos[i].Status != 0)
                {
                    _productoSelect = _listBDProductos[i];
                    btnEditar.Enabled = true;
                    if (_listBDProductos[i].Status != 0)
                        btnEliminar.Enabled = true;
                    break;
                }
            }
        }

        private void gridDatos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string codigo = gridDatos.Rows[gridDatos.CurrentRow.Index].Cells[1].Value.ToString();
            for (int i = 0; i < _listBDProductos.Count; i++)
            {
                if (_listBDProductos[i].CodigoInterno == codigo)
                {
                    _productoSelect = _listBDProductos[i];
                    btnEditar.Enabled = true;
                    btnEliminar.Enabled = true;
                    break;
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Cambiar a inabilitado
            //Mensaje de desabilotar seleccionado
            string message = "¿Esta seguro que desea inhabilitar el producto "+_productoSelect.Descripcion +" ?";
            string caption = "Dar de baja " +_productoSelect.CodigoInterno;
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);
            // If the no button was pressed ...
            if (result == DialogResult.Yes)
            {
                CONSULTA_Inventario consulta = new CONSULTA_Inventario();
                _productoSelect.Status = 0;
                consulta.AddUpdateProductos(_productoSelect,0);
                cargaProductos(" ");
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
 *  Precio de Bajo a Alto
    Precio de Alto a Bajo
    Marcas A-Z
    Marcas Z-A
    Recién Llegados
*/
            int index = cboOrdenar.SelectedIndex;
            switch (index)
            {
                case 0:
                    _listBDProductos = _listBDProductos.OrderBy(x => x.PrecioVenta).ToList();
                    break;
                case 1:
                    _listBDProductos = _listBDProductos.OrderBy(x => x.PrecioVenta).Reverse().ToList();
                    break;
                case 2:
                    _listBDProductos = _listBDProductos.OrderBy(x => x.Descripcion).ToList();
                    break;
                case 3:
                    _listBDProductos = _listBDProductos.OrderBy(x => x.Descripcion).Reverse().ToList();
                    break;
                case 4:
                    _listBDProductos = _listBDProductos.OrderBy(x => x.FechaCaptura).Reverse().ToList();
                    break;
                default:
                    break;
            }
            cargarListaGrid(_listBDProductos);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            DialogProducto editaPro = new DialogProducto(0, _productoSelect);
            editaPro.ShowDialog();
            cargaProductos(" ");
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("AUN NO DISPONIBLE");
        }

        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<PRODUCTO> tmpList = new List<PRODUCTO>();
            int indexSel = cboCategoria.SelectedIndex;
            //FORMA 1
            for (int i = 0; i < _listBDProductos.Count; i++)
            {
                if (_listBDProductos[i].Categoria_fk == _listaCat[indexSel].IdCategoria)
                {
                    tmpList.Add(_listBDProductos[i]);
                }
            }
            // FORMA 2
            foreach (var item in _listBDProductos)
            {
                
            }

           // FORMA 3

            tmpList = tmpList.OrderBy(x => x.Descripcion).ToList();
            cargarListaGrid(tmpList);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
             * Agotados
                Disponibles
                Con Descuento
                Sin Descuento
                Todos
             */
            List<PRODUCTO> tmpList = new List<PRODUCTO>();
            int indexSel = cboFiltroOpcion.SelectedIndex;
            if (indexSel != 4)
                for (int i = 0; i < _listBDProductos.Count; i++)
                {
                    switch (indexSel)
                    {
                        case 0:
                            if (_listBDProductos[i].Stock <= 0)
                                tmpList.Add(_listBDProductos[i]);
                            break;
                        case 1:
                            if (_listBDProductos[i].Stock > 0)
                                tmpList.Add(_listBDProductos[i]);
                            break;
                        case 2:
                            if (_listBDProductos[i].Descuento > 0)
                                tmpList.Add(_listBDProductos[i]);
                            break;
                        case 3:
                            if (_listBDProductos[i].Descuento <= 0)
                                tmpList.Add(_listBDProductos[i]);
                            break;
                        default:
                            break;
                    }
                }
            else
                tmpList = _listBDProductos;
            tmpList = tmpList.OrderBy(x => x.Descripcion).ToList();
            cargarListaGrid(tmpList);

        }

    }
}
