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
    public partial class DialogCliente : Form
    {
        int _Accion;
        bool _facturar;
        bool _datosFacturaExistentes = false;
        CLIENTE _Cliente;
        DIRECCION_FISCAL _DatosFiscales;

        //Accion 1 agregar, 0 editar
        public DialogCliente(int accion)
        {
            InitializeComponent();
            this._Accion = accion;
            verificaAccion();
        }

        public DialogCliente(CLIENTE cl, bool upadate)
        {
            InitializeComponent();
            CONSULTA_Personas cliente = new CONSULTA_Personas();
            List<CLIENTE> lsCliente = new List<CLIENTE>();
            lsCliente = cliente.ConsultaClientes(" WHERE  `cliente`.`idCliente`  = " + cl.Id);
            if (lsCliente.Count == 1)
            {
                _Cliente = lsCliente[0];
            }
            verificaAccion();
        }


        public DialogCliente(int accion, CLIENTE cliente, bool facturar)
        {
            InitializeComponent();
            this._Cliente = cliente;
            this._Accion = accion;
            this._facturar = facturar;
            if (cliente.DatosDiscales != null)
            {
                this._DatosFiscales = cliente.DatosDiscales;
                _datosFacturaExistentes = true;
            }
            verificaAccion();
        }

        public DialogCliente(int accion, bool facturar)
        {
            InitializeComponent();
            this._Accion = accion;
            this._facturar = facturar;
            verificaAccion();
        }

        private void verificaAccion()
        {
            if (_Accion == 1)
            {
                reset();
            }
            else
            {
                lblTitulo.Text = "Editar datos del Cliente: " + _Cliente.Nombre+ " " + _Cliente.App +" "+_Cliente.Apm;
                txtCodeIn.Text = Convert.ToString(_Cliente.Id);
                txtNombre.Text = _Cliente.Nombre;
                txtApm.Text = _Cliente.Apm;
                txtApp.Text = _Cliente.App;
                txtTel.Text = _Cliente.Telefono;
                txtEmail.Text = _Cliente.Correo;
                cboStatus.Checked = Convert.ToInt32(_Cliente.Estatus) == 1 ? true : false;
                if (_Cliente.DatosDiscales != null)
                {
                    txtRazon.Text = _Cliente.DatosDiscales.Razon;
                    txtCalle.Text = _Cliente.DatosDiscales.Calle;
                    txtNoIn.Text = _Cliente.DatosDiscales.NoInt;
                    txtNumExt.Text = _Cliente.DatosDiscales.NoExt;
                    txtCol.Text = _Cliente.DatosDiscales.Colonia;
                    txtMunicipio.Text = _Cliente.DatosDiscales.Del_mun;
                    txtEntidad.Text = _Cliente.DatosDiscales.Entidad;
                    txtRFC.Text = _Cliente.DatosDiscales.Rfc;
                    _datosFacturaExistentes = true;
                }
                
                btnAccion.Text = "ACTUALIZAR";
            }
        }

        private void reset()
        {
            lblTitulo.Text = "Agregar nuevo Cliente:";
            txtCodeIn.Text = "AUTO";
            txtNombre.Text = "";
            txtApm.Text = "";
            txtApp.Text = "";
            txtTel.Text = "";
            txtEmail.Text = "";
            cboStatus.Checked = true;

            txtRazon.Text = "";
            txtCalle.Text = "";
            txtNoIn.Text = "";
            txtNumExt.Text = "";
            txtCol.Text = "";
            txtMunicipio.Text = "";
            txtEntidad.Text = "";
            txtRFC.Text = "";
            btnAccion.Text = "AGREGAR";
        }

        private CLIENTE verificaDatos()
        {
            CLIENTE tmpClient = null;
            bool isCorrect = false, isCorrectFactura = false;
            string nombre = txtNombre.Text;
            string app = txtApp.Text;
            string apm = txtApm.Text;
            string tel= txtTel.Text;
            string correo = txtEmail.Text;
            int status = cboStatus.Checked ? 1:0;

            string razon = "";
            string calle = "";
            string NoIn = "";
            string NoExt = "";
            string col = "";
            string municipio = "";
            string entidad = "";
            string rfc = "";

            try
            {
                razon = txtRazon.Text;
                calle = txtCalle.Text;
               // NoIn = txtNoIn.Text;
                NoExt = txtNumExt.Text;
                col = txtCol.Text;
                municipio = txtMunicipio.Text;
                entidad = txtEntidad.Text;
                rfc = txtRFC.Text;
                _facturar = true;
            }
            catch (Exception)
            {
                _facturar = false;
            }

            if (_facturar)
            {
                if (razon != "" && calle != "" && NoExt!= "" && col!= "" && municipio!= "" && entidad!= "" && rfc!= "")
                    isCorrectFactura = true;
                if (correo == "")
                    correo = " ";
            }
            if (nombre != "" && app != "" && apm != "" && tel != "")
            {
                isCorrect = true;
            }

            if (isCorrect)
            {
                //podemos construir el objeto
                tmpClient = new CLIENTE();

                tmpClient.Id = _Accion == 1 ? 0 : _Cliente.Id;
                tmpClient.Nombre = nombre;
                tmpClient.App = app;
                tmpClient.Apm = apm;
                tmpClient.Telefono = tel;

                if (correo != "")
                    tmpClient.Correo = correo;

                tmpClient.Estatus = status;

                if (isCorrectFactura)
                {
                    tmpClient.DatosDiscales = new DIRECCION_FISCAL();
                    //_DatosFiscales
                    if (_Accion == 0 && _DatosFiscales != null)
                    {
                        // editara datos de factura ya escritas
                        tmpClient.DatosDiscales.IdDireccion = _DatosFiscales.IdDireccion;
                    }
                    else
                    {
                        tmpClient.DatosDiscales.IdDireccion = 0;
                    }
                    tmpClient.DatosDiscales.Razon = razon;
                    tmpClient.DatosDiscales.Calle = calle;
                    if (NoIn == "")
                        NoIn = "NA";
                    tmpClient.DatosDiscales.NoInt = NoIn;
                    tmpClient.DatosDiscales.NoExt = NoExt;
                    tmpClient.DatosDiscales.Colonia = col;
                    tmpClient.DatosDiscales.Del_mun = municipio;
                    tmpClient.DatosDiscales.Entidad = entidad;
                    tmpClient.DatosDiscales.Rfc = rfc;
                    _DatosFiscales = tmpClient.DatosDiscales;
                }
            }
            return tmpClient;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccion_Click(object sender, EventArgs e)
        {
            string mje = "";
            CLIENTE tmpClient = verificaDatos();
            if (tmpClient != null)
            {
                CONSULTA_Personas consulta = new CONSULTA_Personas();
                if (_Accion == 1) // voy a agregar nuevo Cliente
                {
                    if (consulta.AddUpdateClientes(tmpClient, 1))
                        mje += ("Se ha agregado al Cliente");
                    if (_DatosFiscales != null)
                    {
                        //Ya habia datos fiscales, por lo tanto actualziamos la informacion
                        if (_datosFacturaExistentes)
                        {
                            if (consulta.AddUpdateDatosFiscales(_DatosFiscales, tmpClient, 0))
                                mje += "\r\nSe han modificado los datos de factura";
                        }
                        else
                        {
                            //Obtener el ID del Cliente que registre
                            CONSULTA_Personas tmpConsulta = new CONSULTA_Personas();
                            tmpClient.Id = tmpConsulta.getUltimoID("Cliente");
                            if (consulta.AddUpdateDatosFiscales(_DatosFiscales, tmpClient, 1))
                                mje +="\r\nSe han agregado los datos de factura";
                        }
                    }
                    reset();
                }
                else
                {
                    //Editamos al Cliente
                    if (consulta.AddUpdateClientes(tmpClient, 0))
                        mje += ("Se ha modificado el Cliente");
                    //si ya tenia datos de factura existentes
                    if (_datosFacturaExistentes)
                    {
                        if (_DatosFiscales != null)
                        {
                            //Agregamos tambien los datos de la factura al nuevo Cliente
                            if (consulta.AddUpdateDatosFiscales(_DatosFiscales, tmpClient, 0))
                                mje += "\r\nSe han editado los datos de factura";
                        }
                    }
                    
                    else
                    {
                        //Agregaremos una direccion nueva al cliente ya existente
                        //Agregamos tambien los datos de la factura al nuevo Cliente
                        if (consulta.AddUpdateDatosFiscales(_DatosFiscales, tmpClient, 1))
                            mje += "\r\nSe le ha agregado los datos de factura";
                    }
                    MessageBox.Show(mje);
                    this.Close();
                }
            }// fin if 
            else
            {
                MessageBox.Show("DATOS INCOMPLETOS");
            }
            this.Close();
        }

        private void DialogCliente_Load(object sender, EventArgs e)
        {

        } // fin funcion

        
    }
}
