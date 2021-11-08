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
    public partial class DialogConfiguracion : Form
    {

        string[] _printers;
        public DialogConfiguracion()
        {
            InitializeComponent();
        }

        private void DialogConfiguracion_Load(object sender, EventArgs e)
        {
            cargaDatos();
            loadDataConexion();
            tryConecion();
            
        }

        private void cargaDatos()
        {
            txtMje1.Text = Properties.Settings.Default.Mensaje1;
            txtMje2.Text = Properties.Settings.Default.Mensaje2;
            txtMje3.Text = Properties.Settings.Default.Mensaje3;
            numericMM.Value = Properties.Settings.Default.printerWidth;

            txtEmpresa.Text = Properties.Settings.Default.NombreEmpresa;
            txtDir1.Text = Properties.Settings.Default.Direccion1;
            txtDir2.Text = Properties.Settings.Default.Direccion2;
            txtDir3.Text = Properties.Settings.Default.Direccion3;

            txtTel.Text = Properties.Settings.Default.telefono;
            txtMail.Text = Properties.Settings.Default.correo;
            txtWeb.Text = Properties.Settings.Default.website;



            int printersCount = System.Drawing.Printing.PrinterSettings.InstalledPrinters.Count;
            _printers = new string[printersCount];
            int i = 0; ;
            foreach (string strPrinter in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                _printers[i] = strPrinter;

                cboPrinters.Items.Add(strPrinter);
                // La impresora es igual, entonces seleccionamos 
                if (Properties.Settings.Default.printerTicket == strPrinter)
                    cboPrinters.SelectedIndex = i;
                i++;
            }
        }

        private void loadDataConexion()
        {
            string host = Properties.Settings.Default.hostDB;
            string puerto = Convert.ToString(Properties.Settings.Default.port);
            string userBD = Properties.Settings.Default.userDB;
            string pw = Properties.Settings.Default.pwDB;
            string DataBaseName = Properties.Settings.Default.nameDB;

            txtHost.Text = host;
            txtPort.Text = puerto;
            txtUserName.Text = userBD;
            txtPw.Text = pw;
            txtDBName.Text = DataBaseName;
        }

        private bool tryConecion()
        {
            CONEXION cn = new CONEXION();
            bool valueState = false;
            try
            {
                cn.Cn.Open();
                valueState = true;
                txtStatus.Text = "Conectado :)";
                txtStatus.ForeColor = Color.Green;
                imgConected.Image = Properties.Resources.giphy;
            }
            catch (Exception e)
            {
                txtStatus.Text = "No conexion :(";
                txtStatus.ForeColor = Color.Red;
                imgConected.Image = Properties.Resources.noConexion;
            }
            cn.Cn.Close();
            return valueState;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.hostDB = txtHost.Text;
            Properties.Settings.Default.port = Convert.ToInt32(txtPort.Text);
            Properties.Settings.Default.userDB = txtUserName.Text;
            Properties.Settings.Default.pwDB = txtPw.Text;
            Properties.Settings.Default.nameDB = txtDBName.Text;
            Properties.Settings.Default.Save();

            loadDataConexion();
            if (tryConecion())
                MessageBox.Show("Conexion establecida");
            else
                MessageBox.Show("Error en la conexion");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Mensaje1 = txtMje1.Text;
            Properties.Settings.Default.Mensaje2 = txtMje2.Text;
            Properties.Settings.Default.Mensaje3 = txtMje3.Text;
            Properties.Settings.Default.printerWidth = numericMM.Value;
            Properties.Settings.Default.printerTicket = cboPrinters.SelectedItem.ToString();
            Properties.Settings.Default.Save();
            MessageBox.Show("Se guardaron los datos de impresión");
            cargaDatos();
        }

        private void btnAccion_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.NombreEmpresa = txtEmpresa.Text;
            Properties.Settings.Default.Direccion1 = txtDir1.Text;
            Properties.Settings.Default.Direccion2 = txtDir2.Text;
            Properties.Settings.Default.Direccion3 = txtDir3.Text;

            Properties.Settings.Default.telefono = txtTel.Text;
            Properties.Settings.Default.correo = txtMail.Text;
            Properties.Settings.Default.website = txtWeb.Text;
            Properties.Settings.Default.Save();
            MessageBox.Show("Se guardaron los datos generales");
            cargaDatos();
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }
    }
}
