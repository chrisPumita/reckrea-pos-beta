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
    public partial class DialogPersonas : Form
    {
        int _Accion;
        int _Operacion; //para nada 0 , 1 para venta , 2 Servicio
        List<CLIENTE> _listClientesDB;
        List<EMPLEADO> _listEmpleadosDB;
        int _indexSelected;
        EMPLEADO _Emp;

        public DialogPersonas(int accion, int operacion, EMPLEADO _Emp)
        {
            this._Emp = _Emp;
            this._Operacion = operacion;
            this._Accion = accion;
            InitializeComponent();
            IniciarLoad(_Accion);
        }

        private void IniciarLoad(int accion)
        {
            if (accion ==1){
                //Acciones para Clientes
                lblTitulo.Text = "Mostrando los Clientes";
                if (_Operacion == 1)
                {
                    lblTitulo.Text = "Elija Cliente para facturar";
                }
                else if (_Operacion == 2)
                {
                    lblTitulo.Text = "Elija Cliente para Servicio";
                }
                else
                    btnSelected.Visible = false;
                
                string filtro = " WHERE  `cliente`.`estatus` = 1  ";
                mostrarClientes(filtro);
            }
            else if (accion == 0)
            {
                btnSelected.Visible = false;
                txtCajaBusqueda.Visible = false;
                lblTitulo.Text = "Mostrar Empleados";
                string filtro = "  ";
                mostrarEmpleados(filtro);
                //accines para Empleados
            }
        }
        private void filtroBusqueda(List<CLIENTE> listaCLientes)
        {
            gridDatos.Rows.Clear();
            if (_listClientesDB != null)
            {
                //Agregamos el o los elementos el en GRID DATA
                for (int i = 0; i < listaCLientes.Count(); i++)
                {
                    if (listaCLientes[i].Id != 1)
                    {
                        int renglon = gridDatos.Rows.Add();
                        gridDatos.Rows[renglon].Cells[0].Value = i + 1;
                        gridDatos.Rows[renglon].Cells[1].Value = listaCLientes[i].Id;
                        gridDatos.Rows[renglon].Cells[2].Value = listaCLientes[i].Nombre + " " + listaCLientes[i].App + " " + listaCLientes[i].Apm;
                        gridDatos.Rows[renglon].Cells[3].Value = listaCLientes[i].Telefono;
                        gridDatos.Rows[renglon].Cells[4].Value = listaCLientes[i].Estatus > 0 ? "ACTIVO" : "INACTIVO";
                    }

                }
                lblEncontrados.Text = "Se han encontrado: " + listaCLientes.Count + " clientes";

                if (_listClientesDB.Count == 1)
                {
                    //cargamos el elementos unico
                    _indexSelected = listaCLientes[0].Id;
                    lblEncontrados.Text = "Un Producto encontrado";
                }
            }
        }

        private void mostrarClientes(string filtro)
        {
            CONSULTA_Personas listarClientes = new CONSULTA_Personas();
            _listClientesDB = new List<CLIENTE>();
            _listClientesDB = listarClientes.ConsultaClientes(filtro);
            btnEditar.Enabled = false;
            //rellenar el grid
            gridDatos.Rows.Clear();
            if (_listClientesDB != null)
            {
                //Agregamos el o los elementos el en GRID DATA
                for (int i = 0; i < _listClientesDB.Count(); i++)
                {
                    if (_listClientesDB[i].Id != 1)
                    {
                        int renglon = gridDatos.Rows.Add();
                        gridDatos.Rows[renglon].Cells[0].Value = i + 1;
                        gridDatos.Rows[renglon].Cells[1].Value = _listClientesDB[i].Id;
                        gridDatos.Rows[renglon].Cells[2].Value = _listClientesDB[i].Nombre + " " + _listClientesDB[i].App + " " + _listClientesDB[i].Apm;
                        gridDatos.Rows[renglon].Cells[3].Value = _listClientesDB[i].Telefono;
                        gridDatos.Rows[renglon].Cells[4].Value = _listClientesDB[i].Estatus > 0 ? "ACTIVO" : "INACTIVO";
                    }
                    
                }
                lblEncontrados.Text = "Se han encontrado: " + _listClientesDB.Count + " clientes";

                if (_listClientesDB.Count == 1)
                {
                    //cargamos el elementos unico
                    _indexSelected = _listClientesDB[0].Id;
                    lblEncontrados.Text = "Un Producto encontrado";
                }
                AutoCompleteStringCollection data = new AutoCompleteStringCollection();
                for (int i = 0; i < _listClientesDB.Count; i++)
                    data.Add(_listClientesDB[i].Nombre);

                txtCajaBusqueda.AutoCompleteCustomSource = data;
                txtCajaBusqueda.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtCajaBusqueda.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
        }

        private CLIENTE buscaClienteList(int id)
        {
            CLIENTE tmpCliente = null;
            for (int i = 0; i < _listClientesDB.Count; i++)
            {
                if (_listClientesDB[i].Id == id)
                {
                    btnEditar.Enabled = false;
                    tmpCliente = _listClientesDB[i];
                    _indexSelected = i;
                    break;
                }
            }
            return tmpCliente;
        }

        private List<CLIENTE> buscaClienteList(string value)
        {
            List<CLIENTE> tmpListCliente = new List<CLIENTE>();
            for (int i = 0; i < _listClientesDB.Count; i++)
            {
                if (_listClientesDB[i].Nombre.Contains(value) || _listClientesDB[i].App.Contains(value) || _listClientesDB[i].Apm.Contains(value))
                {
                    btnEditar.Enabled = false;
                    tmpListCliente.Add(_listClientesDB[i]);
                }
            }
            return tmpListCliente;
        }

        private EMPLEADO buscaEmpleadoList(int id)
        {
            EMPLEADO tmpEmp = null;
            for (int i = 0; i < _listEmpleadosDB.Count; i++)
            {
                if (_listEmpleadosDB[i].Id == id)
                {
                    btnEditar.Enabled = false;
                    tmpEmp = _listEmpleadosDB[i];
                    _indexSelected = i;
                    break;
                }
            }
            return tmpEmp;
        }

        private void mostrarEmpleados(string filtro)
        {
            CONSULTA_Personas listarEmpleados = new CONSULTA_Personas();
            _listEmpleadosDB = new List<EMPLEADO>();
            _listEmpleadosDB = listarEmpleados.ConsultaEmpleados(filtro);
            btnEditar.Enabled = false;
            //rellenar el grid
            gridDatos.Rows.Clear();
            if (_listEmpleadosDB != null)
            {
                //Agregamos el o los elementos el en GRID DATA
                for (int i = 0; i < _listEmpleadosDB.Count(); i++)
                {
                        int renglon = gridDatos.Rows.Add();
                        gridDatos.Rows[renglon].Cells[0].Value = i + 1;
                        gridDatos.Rows[renglon].Cells[1].Value = _listEmpleadosDB[i].Id;
                        gridDatos.Rows[renglon].Cells[2].Value = _listEmpleadosDB[i].Nombre + " " + _listEmpleadosDB[i].App + " " + _listEmpleadosDB[i].Apm;
                        gridDatos.Rows[renglon].Cells[3].Value = _listEmpleadosDB[i].Telefono;
                        gridDatos.Rows[renglon].Cells[4].Value = _listEmpleadosDB[i].Estatus > 0 ? "ACTIVO" : "INACTIVO";
                }
                lblEncontrados.Text = "Se han encontrado: " + _listEmpleadosDB.Count + " empleados";

                if (_listEmpleadosDB.Count == 1)
                {
                    //cargamos el elementos unico
                    _indexSelected = _listEmpleadosDB[0].Id;
                    btnEditar.Enabled = true;
                    lblEncontrados.Text = "Un Empleado encontrado";
                }
                AutoCompleteStringCollection data = new AutoCompleteStringCollection();
                for (int i = 0; i < _listEmpleadosDB.Count; i++)
                    data.Add(_listEmpleadosDB[i].Nombre);

                txtCajaBusqueda.AutoCompleteCustomSource = data;
                txtCajaBusqueda.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtCajaBusqueda.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
        }

        private void gridDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //obtenerl el id del elemento
            //identificamos el index del elemento que selecciono
            if (_Accion == 1)
            {
                //Acciones para Clientes
                int idGrid = Convert.ToInt32(gridDatos.Rows[gridDatos.CurrentRow.Index].Cells[1].Value);
                if (buscaClienteList(idGrid) != null)
                    btnEditar.Enabled = true;
                else
                    btnEditar.Enabled = false;
               
            }
            else if (_Accion == 0)
            {
                
                int idGrid = Convert.ToInt32(gridDatos.Rows[gridDatos.CurrentRow.Index].Cells[1].Value);
                if (buscaEmpleadoList(idGrid) != null)
                    btnEditar.Enabled = true;
                else
                    btnEditar.Enabled = false;
            }

            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //int accion, CLIENTE Cliente, bool Facturar
            if (_Accion == 1)
            {
                DialogCliente editaCliente = new DialogCliente(0, _listClientesDB[_indexSelected], false);
                editaCliente.ShowDialog();
                string filtro = " WHERE  `cliente`.`estatus` = 1  ";
                mostrarClientes(filtro);
            }
            else
            {
                DIalogEmpleado editaEmp = new DIalogEmpleado(0, _listEmpleadosDB[_indexSelected]);
                editaEmp.ShowDialog();
                string filtro = "  ";
                mostrarEmpleados(filtro);
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_Accion == 1)
            {
                DialogCliente editaCliente = new DialogCliente(1);
                editaCliente.ShowDialog();
                //   (SELECT MAX(id_dato) FROM PAGAR b WHERE a.usuario_id=b.usuario_id) 
              //  string filtro = " WHERE  `cliente`.`estatus` = 1  ORDER BY idCliente DESC LIMIT 1; ";

                string filtro = " WHERE  `cliente`.`idCliente` =   (SELECT MAX(idCliente) FROM cliente )  ";
                mostrarClientes(filtro);
            }
            else {
                DIalogEmpleado addNewEmp = new DIalogEmpleado(1);
                addNewEmp.ShowDialog();
                string filtro = "   ";
                mostrarEmpleados(filtro);
            }

        }

        private void gridDatos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Accion == 1)
            {
                //Acciones para Clientes
                int idGrid = Convert.ToInt32(gridDatos.Rows[gridDatos.CurrentRow.Index].Cells[1].Value);
                if (buscaClienteList(idGrid) != null)
                    btnEditar.Enabled = true;
                else
                    btnEditar.Enabled = false;
            }
            else if (_Accion == 0)
            {
                int idGrid = Convert.ToInt32(gridDatos.Rows[gridDatos.CurrentRow.Index].Cells[1].Value);
                if (buscaEmpleadoList(idGrid) != null)
                    btnEditar.Enabled = true;
                else
                    btnEditar.Enabled = false;
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (_Accion == 1)
            {
                //Acciones para Clientes
                int idGrid = Convert.ToInt32(gridDatos.Rows[gridDatos.CurrentRow.Index].Cells[1].Value);
                CLIENTE tmpCliente = buscaClienteList(idGrid);
                if (tmpCliente != null)
                {
                    btnSelected.Enabled = true;
                    if (_Operacion== 1)
                    {
                        try
                        {
                            ControlPanelVenta.IdClienteSeleccionado = idGrid;
                        }
                        catch (Exception)
                        {

                        }
                    }
                    else if (_Operacion == 2)
                    {
                        //Abrimos el panel de nuevo Servicio
                        this.Hide();
                        DialogEquipo equipos = new DialogEquipo(tmpCliente,this,_Emp);
                        equipos.ShowDialog();
                    }
                    
                    
                }
                else
                {
                    btnSelected.Enabled = false;
                }
            }
            else if (_Accion == 0)
            {
                lblTitulo.Text = "Mostrar Empleados";
                //accines para Empleados
            }
            this.Close();
            
        }

        private void txtCajaBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Buscar en lista al Cliente
                buscaClienteList(txtCajaBusqueda.Text);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Accion == 1)
            {
                //Filtrar Clientes
                int caso;
                string filtro = "";
                caso = cboSelected.SelectedIndex;
                switch (caso)
                {
                    case 0:
                        filtro = " WHERE  `cliente`.`estatus` = 1  ";
                        break;
                    case 1:
                        filtro = " WHERE  `cliente`.`estatus` = 0  ";
                        break;
                    default:
                        break;
                }
                mostrarClientes(filtro);
            }
            else
            {
                //Filtrar empleados
                int caso;
                string filtro = "";
                caso = cboSelected.SelectedIndex;
                switch (caso)
                {
                    case 0:
                        filtro = " WHERE  `empleado`.`estatus` = 1  ";
                        break;
                    case 1:
                        filtro = " WHERE  `empleado`.`estatus` = 0  ";
                        break;
                    default:
                        break;
                }
                mostrarEmpleados(filtro);
            }
        }

        private void txtCajaBusqueda_TextChanged(object sender, EventArgs e)
        {
            //Buscar en lista al Cliente
            List<CLIENTE> listaC = buscaClienteList(txtCajaBusqueda.Text);
            if (listaC != null)
                filtroBusqueda(listaC);
        }

        private void DialogPersonas_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            IniciarLoad(_Accion);
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }
    }
}
