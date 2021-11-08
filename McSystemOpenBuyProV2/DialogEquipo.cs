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
    public partial class DialogEquipo : Form
    {
        CLIENTE _cliente;
        EMPLEADO _Emp;
        List<EQUIPO> _listaEquipos = new List<EQUIPO>();

        List<CATEGORIAS> _listaCat = new List<CATEGORIAS>();
        List<MARCA> _listMar = new List<MARCA>();
        int _EquipoSelected;

        //FORMS
        DialogPersonas _DIalogFormCliente;
        public DialogEquipo(CLIENTE cliente, DialogPersonas clienteBack, EMPLEADO _Emp)
        {
            this._Emp = _Emp;
            this._DIalogFormCliente = clienteBack;
            this._cliente = cliente;
            InitializeComponent();
        }

        private void DialogEquipo_Load(object sender, EventArgs e)
        {
            _DIalogFormCliente.Hide();
            lblTitulo.Text = "Seleccione el Equipo de " + _cliente.Nombre;
            loadCategoria();
            cargaEquipos(_cliente.Id);
            
        }

        private void loadCategoria()
        {
            CONSULTA_Inventario consulta = new CONSULTA_Inventario();
            _listaCat = consulta.consultaCategorias();
            _listMar = consulta.consultaMarcas();
        }

        private string getNameCategoria(int id)
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

        private void cargaEquipos(int id)
        {
            CONSULTA_Servicio service = new CONSULTA_Servicio();
            string consulta = " WHERE idCliente_fk =  " + id + " ";
            _listaEquipos = service.ConsultaEquipos(consulta);
            if (_listaEquipos.Count >0)
            {
                //Llenamos la tabla de los equipos disponibles
                cargarListaGrid(_listaEquipos);
                btnSelected.Enabled = true;
                btnEditar.Enabled = true;
            }
            else
            {
                btnSelected.Enabled = false;
                btnEditar.Enabled = false;
            }
            lblEncontrados.Text = "Equipos encontrados: " + _listaEquipos.Count();
        }

        private void cargarListaGrid(List<EQUIPO> tmpList)
        {
            gridDatos.Rows.Clear();
            if (tmpList != null)
            {
                //Agregamos el o los elementos el en GRID DATA
                for (int i = 0; i < tmpList.Count(); i++)
                {
                    //agrego el dato faltaante a los datos
                    tmpList[i].CategoriaName = getNameCategoria(tmpList[i].IdCategoriaFk);
                    tmpList[i].MarcaName = getNameMarca(tmpList[i].IdMarcaFk);
                    int renglon = gridDatos.Rows.Add();
                    gridDatos.Rows[renglon].Cells[0].Value = i + 1;
                    gridDatos.Rows[renglon].Cells[1].Value = tmpList[i].IdEquipo;
                    gridDatos.Rows[renglon].Cells[2].Value = tmpList[i].CategoriaName;
                    gridDatos.Rows[renglon].Cells[3].Value = tmpList[i].MarcaName;
                    gridDatos.Rows[renglon].Cells[4].Value = tmpList[i].Modelo;
                    gridDatos.Rows[renglon].Cells[5].Value = tmpList[i].No_serie;
                    gridDatos.Rows[renglon].Cells[6].Value = tmpList[i].FechaRegistro.ToString("dd-MM-yyyy HH:mm:ss");
                    gridDatos.Rows[renglon].Cells[7].Value = tmpList[i].Detalles;
                }
                lblEncontrados.Text = "Se han encontrado: " + tmpList.Count + " productos";
                if (tmpList.Count == 1)
                {
                    lblEncontrados.Text = "Un Producto encontrado";
                }
            }
        }

        private EQUIPO buscaEquipoList(int idGrid)
        {
            EQUIPO tmpOnj = null;
            for (int i = 0; i < _listaEquipos.Count; i++)
            {
                if (_listaEquipos[i].IdEquipo == idGrid)
                {
                    btnEditar.Enabled = false;
                    tmpOnj = _listaEquipos[i];
                    _EquipoSelected = i;
                    break;
                }
            }
            return tmpOnj;
        }


        private void button6_Click(object sender, EventArgs e)
        {
            _DIalogFormCliente.Close();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogCRUD_Equipo equipo = new DialogCRUD_Equipo(1,_cliente);
            equipo.ShowDialog();
            loadCategoria();
            cargaEquipos(_cliente.Id);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            DialogCRUD_Equipo equipo = new DialogCRUD_Equipo(0, _cliente, _listaEquipos[_EquipoSelected]);
            equipo.ShowDialog();
            loadCategoria();
            cargaEquipos(_cliente.Id);
        }

        private void gridDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int idGrid = Convert.ToInt32(gridDatos.Rows[gridDatos.CurrentRow.Index].Cells[1].Value);
            if (buscaEquipoList(idGrid) != null)
            {
                btnSelected.Enabled = true;
                btnEditar.Enabled = true;
            }
            else
            {
                btnSelected.Enabled = false;
                btnEditar.Enabled = false;
            }
        }

        private void gridDatos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int idGrid = Convert.ToInt32(gridDatos.Rows[gridDatos.CurrentRow.Index].Cells[1].Value);
            if (buscaEquipoList(idGrid) != null)
            {
                btnSelected.Enabled = true;
                btnEditar.Enabled = true;
            }
            else
            {
                btnSelected.Enabled = false;
                btnEditar.Enabled = false;
            }
        }

        private void btnSelected_Click(object sender, EventArgs e)
        {
            this.Hide();
            DialogNewServiceDetails detalles = new DialogNewServiceDetails(_cliente, _listaEquipos[_EquipoSelected],_Emp);
            detalles.ShowDialog();
            
        }
    }
}
