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
    public partial class Form1 : Form
    {
        //Variables globales
        static Form1 _obj;
        ContainerControl catalogoPanel;
        Form formLogin;
        EMPLEADO _Emp;

        private Timer ti;

        public static Form1 Instance
        {
            get
            {
                if (_obj == null)
                    _obj = new Form1();
                return _obj;
            }
        }

        public Panel pnlContainer1
        {
            get { return ContainerPrincipal; }
            set { ContainerPrincipal = value; }
        }


        public Form1()
        {
            ti = new Timer();
            ti.Tick += new EventHandler(eventoTimer);
            InitializeComponent();
            ti.Enabled = true;
        }

        public Form1(Form formLogin, EMPLEADO Emp)
        {
            this.formLogin = formLogin;
            this._Emp = Emp;
            ti = new Timer();
            ti.Tick += new EventHandler(eventoTimer);
            InitializeComponent();
            ti.Enabled = true;
        }

        private void eventoTimer(object ob, EventArgs evt)
        {
            DateTime hoy = DateTime.Now;
            int nmes = Convert.ToInt32(hoy.ToString("MM"));
            string Mes = "";
            switch (nmes)
            {
                case 1:
                    Mes = "Ene";
                    break;
                case 2:
                    Mes = "Feb";
                    break;
                case 3:
                    Mes = "Mar";
                    break;
                case 4:
                    Mes = "Abr";
                    break;
                case 5:
                    Mes = "May";
                    break;
                case 6:
                    Mes = "Jun";
                    break;
                case 7:
                    Mes = "Jul";
                    break;
                case 8:
                    Mes = "Ago";
                    break;
                case 9:
                    Mes = "Sep";
                    break;
                case 10:
                    Mes = "Oct";
                    break;
                case 11:
                    Mes = "Nov";
                    break;
                case 12:
                    Mes = "Dic";
                    break;
                default:
                    break;
            }
            lblHoraHoy.Text = hoy.ToString("dd ") + " de "+ Mes + hoy.ToString(" yyyy  hh:mm tt");
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //ContainerPrincipal
            _obj = this;
            ControlPanelVenta pc = new ControlPanelVenta(_Emp);
            pc.Dock = DockStyle.Fill;
            ContainerPrincipal.Controls.Add(pc);
            cargaSesion();
            
        }

        private void cargaSesion()
        {
            string welcome = _Emp.Sexo == 1 ? "Bienvenida " : "Bienvenido ";
            lblCuentaName.Text = (_Emp.TipoCuenta == 0 ? "Administrador":"Vendedor") +" "+ welcome + _Emp.Nombre + " " + _Emp.App;
            lblNombreHi.Text = _Emp.Nombre + "!";
            if (_Emp.TipoCuenta != 0)
            {
                //deshabilitar opciones de administrador
                btnInventario.Visible = false;
                tripProductosVerInventario.Visible = false;
                ToolAdmin.Visible = false;
                toolReports.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ContainerPrincipal.Controls["ControlPanelVenta"].BringToFront();
            
        }

        // FUNCIONES ESTATICAS Y PUBLICAS

        public void MensajePaneInfo(string mje, string cant)
        {
            MessageBox.Show("Vengo desde el Form1");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (!Form1.Instance.ContainerPrincipal.Controls.ContainsKey("ControlCatalogo"))
            {
                catalogoPanel = new ControlCatalogo();
                catalogoPanel.Dock = DockStyle.Fill;
                Form1.Instance.ContainerPrincipal.Controls.Add(catalogoPanel);
            }
            Form1.Instance.ContainerPrincipal.Controls["ControlCatalogo"].BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!Form1.Instance.ContainerPrincipal.Controls.ContainsKey("ControlServicio"))
            {
                catalogoPanel = new ControlServicio(_Emp);
                catalogoPanel.Dock = DockStyle.Fill;
                Form1.Instance.ContainerPrincipal.Controls.Add(catalogoPanel);
            }
            Form1.Instance.ContainerPrincipal.Controls["ControlServicio"].BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!Form1.Instance.ContainerPrincipal.Controls.ContainsKey("ControlInventario"))
            {
                catalogoPanel = new ControlInventario();
                catalogoPanel.Dock = DockStyle.Fill;
                Form1.Instance.ContainerPrincipal.Controls.Add(catalogoPanel);
            }
            Form1.Instance.ContainerPrincipal.Controls["ControlInventario"].BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void agregarProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogProducto productos = new DialogProducto(1);
            productos.ShowDialog();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            DialogPersonas people = new DialogPersonas(1,0,_Emp);
            people.ShowDialog();
        }

        private void verInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Form1.Instance.ContainerPrincipal.Controls.ContainsKey("ControlInventario"))
            {
                catalogoPanel = new ControlInventario();
                catalogoPanel.Dock = DockStyle.Fill;
                Form1.Instance.ContainerPrincipal.Controls.Add(catalogoPanel);
            }
            Form1.Instance.ContainerPrincipal.Controls["ControlInventario"].BringToFront();
        }

        private void agregarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogPersonas people = new DialogPersonas(1,0,_Emp);
            people.ShowDialog();
        }

        private void agregarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogPersonas people = new DialogPersonas(0,0,_Emp);
            people.ShowDialog();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                    MessageBox.Show("MOSTRANDO FORM AYUDA");
            }
        }

        private void configuracionDeSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogConfiguracion conf = new DialogConfiguracion();
            conf.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogServicio dialogS = new DialogServicio();
            dialogS.ShowDialog();
        }

        private void nuevoServicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogPersonas selectCliente = new DialogPersonas(1, 2, this._Emp);
            selectCliente.ShowDialog();
        }

        private void buscarServicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Form1.Instance.ContainerPrincipal.Controls.ContainsKey("ControlServicio"))
            {
                catalogoPanel = new ControlServicio(_Emp);
                catalogoPanel.Dock = DockStyle.Fill;
                Form1.Instance.ContainerPrincipal.Controls.Add(catalogoPanel);
            }
            Form1.Instance.ContainerPrincipal.Controls["ControlServicio"].BringToFront();
        }

        private void cajaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        //{
        //    const string message = "¿Esta seguro que desea salir de la aplicación?";
        //    const string caption = "Salir del sistema";
        //    var result = MessageBox.Show(message, caption,
        //                                 MessageBoxButtons.YesNo,
        //                                 MessageBoxIcon.Question);
        //     If the no button was pressed ...
        //    if (result == DialogResult.Yes)
        //    {
        //        Application.Exit();
        //    }
        //}

        private void reportesDeVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_ReporteVtas ventas = new Frm_ReporteVtas();
            ventas.Show();

        }

        private void serviciosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogServicio servicio = new DialogServicio();
            servicio.ShowDialog();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

    }
}
