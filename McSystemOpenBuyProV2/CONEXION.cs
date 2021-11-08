using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace McSystemOpenBuyProV2
{
    class CONEXION
    {
        MySqlConnection cn; //PATH (LINK) PARA CONECTAR CON LA DB (A QUIEN)

        public MySqlConnection Cn
        {
            get { return cn; }
            set { cn = value; }
        }

        //static string ip = "mcsystem.com.mx";
        //static string puerto = "3306";
        //static string userBD = "mcsystem_testerD";
        //static string pw = "patitofeo123";
        //static string DataBaseName = "mcsystem_pruebaMC";

        //Actual

        //static string ip = "mcsystem.com.mx";
        //static string puerto = "3306";
        //static string userBD = "mcsystem_testerD";
        //static string pw = "patitofeo123";
        //static string DataBaseName = "mcsystem_pruebaMC";

        static string ip = Properties.Settings.Default.hostDB;
        static string puerto = Convert.ToString(Properties.Settings.Default.port);
        static string userBD = Properties.Settings.Default.userDB;
        static string pw = Properties.Settings.Default.pwDB;
        static string DataBaseName = Properties.Settings.Default.nameDB;


        //static string ip = "localhost";
        //static string puerto = "3306";
        //static string ip2 = "127.0.0.1";
        //static string userBD = "root";
        //static string pw = "";
        //static string DataBaseName = "mcsystem_pruebamc";

        public CONEXION()
        {
            try{
                //Link del enlace con MySQL
                string link = "datasource=" + ip + ";port=" + puerto + ";username=" + userBD + ";Password=" + pw + ";database=" + DataBaseName + ";";
                // Prepara la conexion
                Cn = new MySqlConnection(link);
                Form1.Instance.imgConected.Image = Properties.Resources.giphy;
            }
            catch(Exception ex){
                Form1.Instance.imgConected.Image = Properties.Resources.noConexion;
                 MessageBox.Show("La conexion fallo: " + ex.ToString());
            }
        }

        public bool VerifyConnection()
        {

            CONEXION cnn = new CONEXION();
            try
            {
                cnn.Cn.Open();
                cnn.Cn.Close();
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
