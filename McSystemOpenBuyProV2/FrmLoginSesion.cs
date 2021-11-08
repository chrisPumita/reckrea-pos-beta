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
    public partial class FrmLoginSesion : Form
    {
        EMPLEADO _emp = new EMPLEADO();
        public FrmLoginSesion()
        {
            InitializeComponent();
            loadSesion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text;
            string pw = txtPw.Text;
            if (user != "" && pw != "")
            {
                _emp = verificaCuenta(user,pw);
                if (_emp != null)
                {
                    Properties.Settings.Default.remember = CboRecuerdame.Checked ? true : false;
                    if (CboRecuerdame.Checked)
                    {
                        Properties.Settings.Default.user = txtUser.Text;
                        Properties.Settings.Default.pw = txtPw.Text;
                    }
                    Properties.Settings.Default.Save();
                    Form1 nuevoFrm = new Form1(this, _emp);
                    nuevoFrm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("La cuenta no existe");
                    txtPw.Clear();
                    txtUser.SelectAll();
                    txtUser.Focus();
                }
            }
            else
                MessageBox.Show("Debe escribir una cuenta");
            
        }

        private EMPLEADO verificaCuenta(string user, string pw)
        {
            CONSULTA_Personas consulta = new CONSULTA_Personas();
            MD5 llave = new MD5();
            pw = llave.CreateMD5(pw);
            List<EMPLEADO> lstEmp = new List<EMPLEADO>();
            string filtro = " WHERE `empleado`.`nick` = '"+user+"' AND `empleado`.`password` = '"+pw+"' ";
            lstEmp = consulta.ConsultaEmpleados(filtro);
            if (lstEmp != null && lstEmp.Count == 1)
            {
                this._emp = lstEmp[0];
                return lstEmp[0];
            }
            return null;
        }

        private void loadSesion()
        {
            if (Properties.Settings.Default.remember)
            {
                txtUser.Text = Properties.Settings.Default.user;
                txtPw.Text = Properties.Settings.Default.pw;
                CboRecuerdame.Checked = true;
                btnEntrar.Focus();
            }
            else
            {
                txtUser.Focus();
            }
        }

        private void CboRecuerdame_CheckedChanged(object sender, EventArgs e)
        {
            
            Properties.Settings.Default.remember = CboRecuerdame.Checked ? true : false;
            if (CboRecuerdame.Checked)
            {
                Properties.Settings.Default.user = txtUser.Text;
                Properties.Settings.Default.pw = txtPw.Text;
            }
            Properties.Settings.Default.Save();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogConexion cn = new DialogConexion();
            cn.ShowDialog();
            CONEXION testDB = new CONEXION();
            if (!testDB.VerifyConnection())
            {
                btnConexion.BackColor = Color.Red;
                btnConexion.Text = "SIN CONEXION";
                imgConected.Image = Properties.Resources.noConexion;
            }
            else
            {
                btnConexion.BackColor = Color.Green;
                btnConexion.Text = "CONECTADO";
                imgConected.Image = Properties.Resources.giphy;
            }
        }

        private void FrmLoginSesion_Load(object sender, EventArgs e)
        {
            CONEXION testDB = new CONEXION();
            if (!testDB.VerifyConnection())
            {
                btnConexion.BackColor = Color.Red;
                btnConexion.Text = "SIN CONEXION";
                imgConected.Image = Properties.Resources.noConexion;
            }
            else
            {
                btnConexion.BackColor = Color.Green;
                btnConexion.Text = "CONECTADO";
                imgConected.Image = Properties.Resources.giphy;
            }
        }

        private void txtPw_MouseClick(object sender, MouseEventArgs e)
        {
            txtPw.SelectAll();
        }

    }
}
