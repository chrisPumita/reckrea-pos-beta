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
    public partial class DialogCRUD_Equipo : Form
    {
        int[] categoria, proveedor, marca;
        List<CATEGORIAS> listaCat = new List<CATEGORIAS>();
        List<MARCA> listaMar = new List<MARCA>();

        EQUIPO _equipo = null;
        CLIENTE _cliente;
        int _Accion;

        public DialogCRUD_Equipo(int accion, int idEquipo)
        {
            this._Accion = accion;
            CONSULTA_Servicio order = new CONSULTA_Servicio();
            _equipo = new EQUIPO();
            _equipo = order.ConsultaEquipo(idEquipo);
            InitializeComponent();
            verficaAccion(accion);
            cargaDatos(_equipo);
        }

        public DialogCRUD_Equipo(int accion, CLIENTE c)
        {
            this._Accion = accion;
            this._cliente = c;
            InitializeComponent();
            verficaAccion(accion);
        }

        public DialogCRUD_Equipo(int accion, CLIENTE c, EQUIPO e)
        {
            this._Accion = accion;
            this._cliente= c;
            this._equipo = e;
            InitializeComponent();
            verficaAccion(accion);
            lblTitulo.Text = "Actualziar datos de " + _equipo.Detalles;
            btnAccion.Text = "Actualizar";
            
            cargaDatos(_equipo);
        }

        private void cargaDatos(EQUIPO p)
        {
            txtId.Text = Convert.ToString(p.IdEquipo);
            //elegir el elemento por medio de la lista de arrays del areglo
            for (int i = 0; i < categoria.Count(); i++)
                if (p.IdCategoriaFk == categoria[i])
                    cboCategoria.SelectedIndex = i;

            for (int i = 0; i < marca.Count(); i++)
                if (p.IdMarcaFk == marca[i])
                    CBOMarca.SelectedIndex = i;

            txtModelo.Text = p.Modelo;
            txtSerie.Text = p.No_serie;
            cboStatus.Checked = p.Estado == 1 ? true : false;
            txtDetalles.Text = p.Detalles;
            txtFecha.Text = p.FechaRegistro.ToString("dd-MM-yyyy HH:mm:ss");
            btnAccion.Text = "Actualizar";

        }


        private void verficaAccion(int a)
        {
            //independientemente de la accion vamos a cargar los valores de las listas desplegables
            cargarListas();
            if (a == 0)//Va a editar
            {
                lblTitulo.Text = "Editar Equipo";
                btnAccion.Text = "Guardar";
            }
            else
            {
                lblTitulo.Text = "Agregar Nuevo Equipo";
                btnAccion.Text = "Agregar";
                txtFecha.Text = DateTime.Now.ToString("dd-MM-yyyy");
            }
        }

        private void cargarListas()
        {
            cboCategoria.Items.Clear();
            CBOMarca.Items.Clear();
            CONSULTA_Inventario consulta = new CONSULTA_Inventario();
            listaCat = consulta.consultaCategorias();
            listaMar = consulta.consultaMarcas();

            if (listaCat != null)
            {
                categoria = new int[listaCat.Count];
                for (int i = 0; i < listaCat.Count; i++)
                {
                    if (listaCat[i].Estatus != 0) // va para todas
                    {
                        categoria[i] = listaCat[i].IdCategoria;
                        cboCategoria.Items.Add(listaCat[i].Nombre);
                    }
                }
            }

            if (listaMar != null)
            {
                marca = new int[listaMar.Count];
                for (int i = 0; i < listaMar.Count; i++)
                {
                    if (listaMar[i].Estatus != 0) // va para todas
                    {
                        marca[i] = listaMar[i].IdMarca;
                        CBOMarca.Items.Add(listaMar[i].Nombre);
                    }
                }
            }
        }


        private EQUIPO verificaDatos()
        {
            EQUIPO tmpBuildObj = null;

            int id = _Accion == 1 ? 0 : _equipo.IdEquipo;
            int idClienteFK = _cliente.Id;
            int idCategoriaFk  = -1;
            int idMarcaFk = -1;
            string modelo = txtModelo.Text;
            string no_serie = txtSerie.Text != "" ? txtSerie.Text : "";

            DateTime fechaRegistro = _Accion == 1 ? DateTime.Today : _equipo.FechaRegistro;

            string detalles = txtDetalles.Text;
            int estado = cboStatus.Checked ? 1 : 0 ;

            if (modelo != "" && detalles != "")
            {
                try { idCategoriaFk = listaCat[cboCategoria.SelectedIndex].IdCategoria; }
                catch (Exception)
                {
                    MessageBox.Show("Debe elejir una categoria");
                    return null;
                }

                try { idMarcaFk = listaMar[CBOMarca.SelectedIndex].IdMarca; }
                catch (Exception)
                {
                    MessageBox.Show("Debe elejir una marca");
                    return null;
                }

                // construimos el obje tmpBuil
                tmpBuildObj = new EQUIPO();
                tmpBuildObj.IdEquipo = id;
                tmpBuildObj.IdClienteFk = idClienteFK;
                tmpBuildObj.IdCategoriaFk = idCategoriaFk;
                tmpBuildObj.IdMarcaFk = idMarcaFk;
                tmpBuildObj.Modelo = modelo;
                tmpBuildObj.No_serie = no_serie;
                tmpBuildObj.FechaRegistro = fechaRegistro;
                tmpBuildObj.Detalles = detalles;
                tmpBuildObj.Estado = estado;
            }
            return tmpBuildObj;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogElementos addCategoria = new DialogElementos(0, 1);
            addCategoria.ShowDialog();
            //regrescar
            cargarListas();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogElementos addCategoria = new DialogElementos(2, 1);
            addCategoria.ShowDialog();
            cargarListas();
        }

        private void btnAccion_Click(object sender, EventArgs e)
        {
            EQUIPO tmpEquipo = verificaDatos();
            if (tmpEquipo != null)
            {
                CONSULTA_Servicio consulta = new CONSULTA_Servicio();
                if (_Accion == 1) // vamos a agregar{
                {
                    if (consulta.AddUpdateEquipo(tmpEquipo, _Accion))
                        MessageBox.Show("Se ha agregado un Equipo a " + _cliente.Nombre + " " + _cliente.App);
                }
                else // vamos a actualziar
                {
                    if (consulta.AddUpdateEquipo(tmpEquipo, _Accion))
                        MessageBox.Show("Se ha editado el Equipo de " + _cliente.Nombre + " " + _cliente.App);
                }
                this.Close();
            }
            else
                MessageBox.Show("Faltan datos por llenar");
        }

        private void DialogCRUD_Equipo_Load(object sender, EventArgs e)
        {

        }

    }
}
