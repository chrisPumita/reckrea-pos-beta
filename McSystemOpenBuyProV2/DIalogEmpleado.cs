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
    public partial class DIalogEmpleado : Form
    {
        int _Accion;
        EMPLEADO _Empleado;
        public DIalogEmpleado(int accion, EMPLEADO empleado)
        {
            this._Accion = accion;
            this._Empleado = empleado;
            InitializeComponent();
            cargaDatos();
        }

        public DIalogEmpleado(int accion)
        {
            this._Accion = accion;
            InitializeComponent();
            lblTitulo.Text = "Agregar nuevo usuario";
            btnReset.Enabled = false;
            btnAccion.Text = "Agregar";
            
        }

        private void cargaDatos()
        {
            lblTitulo.Text = "Editar datos de " + _Empleado.Nombre + " " + _Empleado.App + " " + _Empleado.Apm;
            txtId.Text =Convert.ToString(_Empleado.Id);
            txtNombre.Text = _Empleado.Nombre;
            txtApp.Text = _Empleado.App;
            txtApm.Text = _Empleado.Apm;
            txtTel.Text = _Empleado.Telefono;
            txtEmail.Text = _Empleado.Correo;
            txtNick.Text = _Empleado.Nick;
            txtDepartamento.Text = _Empleado.Depto;
            cboTipoCuenta.SelectedIndex = _Empleado.TipoCuenta == 1 ? 1 : 0;
            cboSexo.SelectedIndex = _Empleado.Sexo == 1 ? 1 : 0;
            cboStatus.Checked = _Empleado.Estatus == 1 ? true: false;
            txtFecha.Text = _Empleado.FechaRegistro.ToString("dd-MM-yyyy a las hh:mm:ss");
            btnAccion.Text = "Actualizar";
        }

        private EMPLEADO verificaDatos()
        {
            EMPLEADO ObjEmp = null;
            int id = _Accion == 1 ? 0 : _Empleado.Id;
            string nombre = txtNombre.Text;
            string app = txtApp.Text;
            string apm = txtApm.Text;
            string tel = txtTel.Text;
            string email = txtEmail.Text;
            string nick = txtNick.Text;
            string depto = txtDepartamento.Text;
            int status = cboStatus.Checked ? 1 : 0;
           

            if (nombre != "" && app != "" && apm != "" && tel  != "" && email != "" && nick != "" && depto  != "")
            {
                try
                {
                    int tipoCta = cboTipoCuenta.SelectedIndex;
                    //Cremoa el obj
                    ObjEmp = new EMPLEADO();
                    ObjEmp.Id = id;
                    ObjEmp.Nombre = nombre;
                    ObjEmp.App = app;
                    ObjEmp.Apm = apm;
                    ObjEmp.Telefono = tel;
                    ObjEmp.Correo = email;
                    ObjEmp.Nick = nick;
                    ObjEmp.Depto = depto;
                    ObjEmp.Estatus = status;
                    ObjEmp.Sexo = cboSexo.SelectedIndex == 1 ? 1 : 0;
                    ObjEmp.TipoCuenta = cboTipoCuenta.SelectedIndex;
                    ObjEmp.FechaRegistro = DateTime.Now;
                    MD5 codigo = new MD5();
                    ObjEmp.Password = _Accion == 1 ? codigo.CreateMD5("0000"): _Empleado.Password;
                }
                catch (Exception)
                {
                    MessageBox.Show("Debe elejir un tipo de cuenta");
                }
            }
            
            return ObjEmp;
        }



        private void btnAccion_Click(object sender, EventArgs e)
        {
            EMPLEADO tmpEmp = verificaDatos();
            if (tmpEmp != null)
            {
                CONSULTA_Personas cn = new CONSULTA_Personas();
                if (_Accion == 1)
                    if (cn.AddUpdateEmpleado(tmpEmp, 1))
                        MessageBox.Show("Se ha agregado un nuevo Empleado");
                else
                    //Editamos los datos del Empleado
                    if (cn.AddUpdateEmpleado(tmpEmp, 0))
                        MessageBox.Show("Se ha editado al Empleado");
                this.Close();
            }
            else
                MessageBox.Show("Faltan datos por completar");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            const string message = "¿Esta seguro que desea restablecer la contraseña al usuario?";
            const string caption = "Restablecer Contraseña";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);
            // If the no button was pressed ...
            if (result == DialogResult.Yes)
            {
                EMPLEADO tmpEmp = new EMPLEADO();
                tmpEmp = _Empleado;
                MD5 md5 = new MD5();
                tmpEmp.Password = md5.CreateMD5("0000");
                CONSULTA_Personas cn = new CONSULTA_Personas();
                if (cn.AddUpdateEmpleado(tmpEmp, 0))
                    MessageBox.Show("Se ha restablecido la contraseña");
                this.Close();
            }
        }
    }
}
