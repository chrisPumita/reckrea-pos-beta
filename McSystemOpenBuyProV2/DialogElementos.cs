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
    public partial class DialogElementos : Form
    {
        int elemento, accion;
        List<CATEGORIAS> listaDBCat;
        List<MARCA> listaDBMarca;
        List<PROVEEDOR> listaDBProveedor;
        int idSeleccinado, indexSeleccionado;

        public DialogElementos(int elemento, int accion)
        {
            this.elemento = elemento;
            this.accion = accion;
            InitializeComponent();
            loadElemento(elemento);
            loadDatos(elemento);
        }

        private void loadElemento(int e)
        {
            btnAccion.Text = accion == 1 ? "Agregar" : "Actualizar";
            lblTitulo.Text = accion == 1 ? "Agregar " : "Actualizar ";
            switch (e)
            {
                case 0:
                    lblOpc.Text = "Escriba el Nombre de la categria:";
                    lblTitulo.Text += "Categoria";
                    break;
                case 1:
                    lblOpc.Text = "Escriba el Nombre del proveedor";
                    lblTitulo.Text += "Proveedor";
                    break;
                case 2:
                    lblOpc.Text = "Escriba el Nombre de la Marca:";
                    lblTitulo.Text += "Marca";
                    break;
            }
        }

        private void loadDatos(int e)
        {
            gridDatos.Rows.Clear();
            switch (e)
            {
                case 0:
                    this.listaDBCat = new List<CATEGORIAS>();
                    CONSULTA_Inventario consulta = new CONSULTA_Inventario();
                    this.listaDBCat = consulta.consultaCategorias();
                    lblNum.Text = "Registros: " + Convert.ToString(listaDBCat.Count());
                    //Cargar datos de la BD y agregarlas al GRID DATA
                    for (int i = 0; i < listaDBCat.Count(); i++)
                    {
                        int renglon = gridDatos.Rows.Add();
                        gridDatos.Rows[renglon].Cells[0].Value = i + 1;
                        gridDatos.Rows[renglon].Cells[1].Value = listaDBCat[i].Nombre;
                        gridDatos.Rows[renglon].Cells[2].Value = listaDBCat[i].Estatus == 1 ? Properties.Resources.onBlue : Properties.Resources.offRed;
                        imgStatus.Image = listaDBCat[i].Estatus == 1 ? Properties.Resources.onBlue : Properties.Resources.offRed;
                    }
                    break;
                case 1: //proveedor
                    this.listaDBProveedor = new List<PROVEEDOR>();
                    CONSULTA_Inventario consulta1 = new CONSULTA_Inventario();
                    this.listaDBProveedor = consulta1.consultaProveedores();
                    lblNum.Text = "Registros: " + Convert.ToString(listaDBProveedor.Count());
                    //Cargar datos de la BD y agregarlas al GRID DATA
                    for (int i = 0; i < listaDBProveedor.Count(); i++)
                    {
                        int renglon = gridDatos.Rows.Add();
                        gridDatos.Rows[renglon].Cells[0].Value = i + 1;
                        gridDatos.Rows[renglon].Cells[1].Value = listaDBProveedor[i].Nombre;
                        gridDatos.Rows[renglon].Cells[2].Value = listaDBProveedor[i].Estatus == 1 ? Properties.Resources.onBlue : Properties.Resources.offRed;
                        imgStatus.Image = listaDBProveedor[i].Estatus == 1 ? Properties.Resources.onBlue : Properties.Resources.offRed;
                    }
                    break;
                case 2: // Marca
                    this.listaDBMarca = new List<MARCA>();
                    CONSULTA_Inventario consulta2 = new CONSULTA_Inventario();
                    this.listaDBMarca = consulta2.consultaMarcas();
                    lblNum.Text = "Registros: " + Convert.ToString(listaDBMarca.Count());
                    //Cargar datos de la BD y agregarlas al GRID DATA
                    for (int i = 0; i < listaDBMarca.Count(); i++)
                    {
                        int renglon = gridDatos.Rows.Add();
                        gridDatos.Rows[renglon].Cells[0].Value = i + 1;
                        gridDatos.Rows[renglon].Cells[1].Value = listaDBMarca[i].Nombre;
                        //  gridDatos.Rows[renglon].Cells[2].Value = listaDBMarca[i].Estatus == 1 ? "ACTIVO" : "INACTIVO";
                        gridDatos.Rows[renglon].Cells[2].Value = listaDBMarca[i].Estatus == 1 ? Properties.Resources.onBlue : Properties.Resources.offRed;
                        imgStatus.Image = listaDBMarca[i].Estatus == 1 ? Properties.Resources.onBlue : Properties.Resources.offRed;
                    }
                    break;
            }


        }

        private void agregarElemento()
        {
            //evualuo que elemento vot a agrear
            switch (elemento)
            {
                case 0:
                    //construir el obj
                    if (validaDatos())
                    {
                        CONSULTA_Inventario consulta = new CONSULTA_Inventario();
                        CATEGORIAS obj = new CATEGORIAS(0, txtNombre.Text, cboStatus.Checked ? 1 : 0);
                        if (!consulta.AddUpdateCategoria(obj, 1))
                            MessageBox.Show("EL ELEMENTO NO SE PUDO ALMACENAR");
                    }
                    else
                        MessageBox.Show("Escriba el Nombre de la Categoria");
                    break;
                case 1: //proveedores
                    if (validaDatos())
                    {
                        CONSULTA_Inventario consulta = new CONSULTA_Inventario();
                        PROVEEDOR obj = new PROVEEDOR(0, txtNombre.Text, cboStatus.Checked ? 1 : 0);
                        if (!consulta.AddUpdateProveedores(obj, 1))
                            MessageBox.Show("EL ELEMENTO NO SE PUDO ALMACENAR PROVEEDOR");
                    }
                    else
                        MessageBox.Show("Escriba el Nombre del proveedor");
                    break;
                case 2:
                    if (validaDatos())
                    {
                        CONSULTA_Inventario consulta = new CONSULTA_Inventario();
                        MARCA obj = new MARCA(0, txtNombre.Text, cboStatus.Checked ? 1 : 0);
                        if (!consulta.AddUpdateMarca(obj, 1))
                            MessageBox.Show("EL ELEMENTO MARCA NO SE PUDO ALMACENAR");
                    }
                    else
                        MessageBox.Show("Escriba el Nombre del la Marca");
                    break;
            }
            loadDatos(elemento);
        }

        private void editarElemento()
        {
            switch (elemento)
            {
                case 0:
                    //construir el obj
                    if (validaDatos())
                    {
                        CONSULTA_Inventario consulta = new CONSULTA_Inventario();

                        CATEGORIAS obj = new CATEGORIAS(listaDBCat[indexSeleccionado].IdCategoria, txtNombre.Text, cboStatus.Checked ? 1 : 0);
                        if (!consulta.AddUpdateCategoria(obj, 0))
                            MessageBox.Show("EL ELEMENTO NO SE PUDO ACTUALIZAR");
                    }
                    else
                        MessageBox.Show("Debe escribir datos");
                    break;
                case 1: // proveedor
                    if (validaDatos())
                    {
                        CONSULTA_Inventario consulta = new CONSULTA_Inventario();
                        PROVEEDOR obj = new PROVEEDOR(listaDBProveedor[indexSeleccionado].IdProveedor, txtNombre.Text, cboStatus.Checked ? 1 : 0);
                        if (!consulta.AddUpdateProveedores(obj, 0))
                            MessageBox.Show("EL ELEMENTO NO SE PUDO ACTUALIZAR EL PROVEEDOR");
                    }
                    else
                        MessageBox.Show("Debe escribir datos del proveedor");
                    break;
                case 2:
                    if (validaDatos())
                    {
                        CONSULTA_Inventario consulta = new CONSULTA_Inventario();
                        MARCA obj = new MARCA(listaDBMarca[indexSeleccionado].IdMarca, txtNombre.Text, cboStatus.Checked ? 1 : 0);
                        if (!consulta.AddUpdateMarca(obj, 0))
                            MessageBox.Show("NO SE PUDO ACTUALIZAR LA MARCA");
                    }
                    else
                        MessageBox.Show("Debe escribir datos de la Marca");
                    break;
            }
            loadDatos(elemento);
        }

        private bool validaDatos()
        {
            return txtNombre.Text.Length > 0 ? true : false;
        }

        private void btnAccion_Click(object sender, EventArgs e)
        {
            // DEPENDIENDO ACCION A GUARDAR O ACTUALZIAR
            if (accion == 1) agregarElemento();
            else editarElemento();
            txtNombre.Focus();
            txtNombre.SelectAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtNombre.Focus();
            cboStatus.Checked = true;
            accion = 1;
            loadElemento(elemento);
        }


        private void gridDatos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Dandole clic a cualquier elemento del GRIDDATA
            int eSelected = gridDatos.CurrentRow.Index;
            if (eSelected < gridDatos.RowCount)
            {
                accion = 0;
                int id;
                loadElemento(elemento); // voy a actualziar
                //evualuo que elemento vot a agrear
                switch (elemento)
                {
                    case 0: // Categoria
                        id = listaDBCat[eSelected].IdCategoria;
                        idSeleccinado = id; //Guardo copia del ID del elemento a editar
                        indexSeleccionado = eSelected;
                        cboStatus.Checked = listaDBCat[eSelected].Estatus == 1 ? true : false;
                        imgStatus.Image = listaDBCat[eSelected].Estatus == 1 ? Properties.Resources.onBlue : Properties.Resources.offRed;
                        txtNombre.Text = listaDBCat[eSelected].Nombre;
                        break;
                    case 1: // proveedor
                        id = listaDBProveedor[eSelected].IdProveedor;
                        idSeleccinado = id; //Guardo copia del ID del elemento a editar
                        indexSeleccionado = eSelected;
                        cboStatus.Checked = listaDBProveedor[eSelected].Estatus == 1 ? true : false;
                        imgStatus.Image = listaDBProveedor[eSelected].Estatus == 1 ? Properties.Resources.onBlue : Properties.Resources.offRed;
                        txtNombre.Text = listaDBProveedor[eSelected].Nombre;
                        break;
                    case 2: // Marca
                        id = listaDBMarca[eSelected].IdMarca;
                        idSeleccinado = id; //Guardo copia del ID del elemento a editar
                        indexSeleccionado = eSelected;
                        cboStatus.Checked = listaDBMarca[eSelected].Estatus == 1 ? true : false;
                        imgStatus.Image = listaDBMarca[eSelected].Estatus == 1 ? Properties.Resources.onBlue : Properties.Resources.offRed;
                        txtNombre.Text = listaDBMarca[eSelected].Nombre;
                        break;
                }
                txtNombre.Focus();
                txtNombre.SelectAll();
            }
        }

        private void DialogElementos_Load(object sender, EventArgs e)
        {

        }

        private void gridDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}