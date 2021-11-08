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
    public partial class DialogServicio : Form
    {
        List<SERVICIO> _listaServicios = new List<SERVICIO>();
        int _Accion = 1;

        SERVICIO servSelected = null;

        public DialogServicio()
        {
            InitializeComponent();
        //    txtCodeIn.Text = generaCodigo();
            _listaServicios = cargarServicios();
            limpiar();
        }


        private void cargaDatosServicio(SERVICIO servicio)
        {
            txtId.Text = Convert.ToString(servicio.IdServicio);
            cboStatus.Checked = servicio.Estatus == 1 ? true : false;
            txtDesc.Text = servicio.Descripcion;
            txtCodeIn.Text = servicio.CodigoInterno;
            //dias de la garantia
            try
            {
                int dias = Convert.ToInt32(servicio.DiasGarantia);
                switch (dias)
                {
                    case 7:
                        rbn7.Checked = true;
                        break;
                    case 15:
                        rbn15.Checked = true;
                        break;
                    case 30:
                        rbn30.Checked = true;
                        break;
                    default:
                        rbnn.Checked = true;
                        numericSpiner.Value = Convert.ToDecimal(dias);
                        break;
                }
            }
            catch (Exception)
            {
                rbnNA.Checked = true;
            }

            numericPrecio.Value = Convert.ToDecimal(servicio.PrecioLista);
            numericDescuento.Value = Convert.ToDecimal(servicio.Descuento);
        }

        private List<SERVICIO> cargarServicios()
        {
            List<SERVICIO> _listaServicios = null;
            CONSULTA_Servicio cn = new CONSULTA_Servicio();
            _listaServicios = cn.ConsultaServicios("");
            cboListaServicios.Items.Clear();
            for (int i = 0; i < _listaServicios.Count; i++)
            {
                cboListaServicios.Items.Add(_listaServicios[i].Descripcion);
            }
            
            return _listaServicios;
        }


        private string generaCodigo()
        {
            Random obj = new Random();
            string sCadena = "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int longitud = sCadena.Length;
            char cletra;
            int nlongitud = 4;
            string sNuevacadena = string.Empty;
            for (int i = 0; i < nlongitud; i++)
            {
                cletra = sCadena[obj.Next(longitud)];
                sNuevacadena += cletra.ToString();
            }

            DateTime hf = DateTime.Now;
            string year = hf.ToString("yyyy");
            int month = Convert.ToInt32(hf.ToString("MM"));
            string m = "";
            switch (month)
            {
                case 1:
                    m = "EN";
                    break;
                case 2:
                    m = "FE";
                    break;
                case 3:
                    m = "MA";
                    break;
                case 4:
                    m = "AB";
                    break;
                case 5:
                    m = "MY";
                    break;
                case 6:
                    m = "JU";
                    break;
                case 7:
                    m = "JL";
                    break;
                case 8:
                    m = "AG";
                    break;
                case 9:
                    m = "SE";
                    break;
                case 10:
                    m = "OC";
                    break;
                case 11:
                    m = "NO";
                    break;
                case 12:
                    m = "DI";
                    break;
                default:
                    m = "JC";
                    break;
            }
            string codeH = hf.ToString("dd") + m + year.Substring(2, 2);
            return "S"+codeH + sNuevacadena;
        }

        private void limpiar()
        {
            _Accion = 1;
            txtDesc.Clear();
            txtId.Text = "AUTO";
            rbnNA.Checked = true;
            txtCodeIn.Text = generaCodigo();
            numericPrecio.Value = 0;
            numericDescuento.Value = 0;
            cboStatus.Checked = true;
            lblTitulo.Text = "Agregar Nuevo Servicio";
            btnAccion.Text = "Agregar";
        }

        private SERVICIO verificaDatos()
        {
            SERVICIO tmpServ = null;
            int estatus = cboStatus.Checked ? 1 : 0;
            string desc = txtDesc.Text;
            string codigo = txtCodeIn.Text;
            int diasGarantia;
            //Obteniengo garantia
            if (rbnNA.Checked) diasGarantia = 0;
            else if (rbn7.Checked) diasGarantia = 7;
            else if (rbn15.Checked) diasGarantia = 15;
            else if (rbn30.Checked) diasGarantia = 30;
            else diasGarantia = Convert.ToInt32(numericSpiner.Value);

            double precioLista = Convert.ToDouble(numericPrecio.Value);
            double descuento = Convert.ToDouble(numericDescuento.Value);

            if (desc == "" && codigo == "")
            {
                MessageBox.Show("Los campos no deben quedar vacios");
                return null;
            }

            if (descuento > precioLista)
            {
                MessageBox.Show("Descuento sobrepasa el costo de venta");
                return null;
            }
            tmpServ = new SERVICIO();
            tmpServ.IdServicio = _Accion == 1 ? 0 : servSelected.IdServicio;
            tmpServ.Descripcion = desc;
            tmpServ.Estatus = estatus;
            tmpServ.CodigoInterno = codigo;
            tmpServ.DiasGarantia = diasGarantia;
            tmpServ.PrecioLista = precioLista;
            tmpServ.Descuento = descuento;
            return tmpServ;
        }

        private void cboListaServicios_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Accion = 0;
            servSelected = new SERVICIO();
            servSelected = _listaServicios[cboListaServicios.SelectedIndex];
            cargaDatosServicio(_listaServicios[cboListaServicios.SelectedIndex]);
            lblTitulo.Text = "Editar: " + _listaServicios[cboListaServicios.SelectedIndex].Descripcion;
            btnAccion.Text = "Actualizar";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpiar();
            _Accion = 1;
            txtDesc.Focus();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtCodeIn.Text = generaCodigo();
        }

        private void btnAccion_Click(object sender, EventArgs e)
        {
            SERVICIO servObj = null;
            servObj = verificaDatos();
            if (servObj != null)
            {
                CONSULTA_Servicio con = new CONSULTA_Servicio();
                    //Vamos a agregar/editar el Servicio
                if (con.AddUpdateServicio(servObj, _Accion))
                {
                    _listaServicios = cargarServicios();
                    MessageBox.Show("Se " + (_Accion == 1 ? " agregó ": "editó ") + " el Servicio");
                    limpiar();
                }
                else
                    MessageBox.Show("ERROR ACCION");
                
            }
            
        }

        private void DialogServicio_Load(object sender, EventArgs e)
        {

        }


    }
}
