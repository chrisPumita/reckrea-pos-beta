using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Net.Mail;
using System.Net;

namespace McSystemOpenBuyProV2
{
    public partial class DialogConexion : Form
    {
        public DialogConexion()
        {
            InitializeComponent();
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
            }
            catch (Exception e)
            {
                txtStatus.Text = "No conexion :(";
                txtStatus.ForeColor = Color.Red;
            }
            cn.Cn.Close();
            return valueState;
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

        private void DialogConexion_Load(object sender, EventArgs e)
        {
            loadDataConexion();
            tryConecion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.hostDB = txtHost.Text;
            Properties.Settings.Default.port = Convert.ToInt32(txtPort.Text);
            Properties.Settings.Default.userDB = txtUserName.Text;
            Properties.Settings.Default.pwDB = txtPw.Text;
            Properties.Settings.Default.nameDB = txtDBName.Text;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();


            loadDataConexion();
            if(tryConecion())
                MessageBox.Show("Conexion establecida");
            else
                MessageBox.Show("Error en la conexion");
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*DEFINICIONES PATA SMTP*/
            // Replace sender@example.com with your "From" address. 
            // This address must be verified with Amazon SES.
            String FROM = "jennifer@mcsystem.com.mx";
            String FROMNAME = "McSYSTEM";

            // Replace recipient@example.com with a "To" address. If your account 
            // is still in the sandbox, this address must be verified.

            String TO = txtMail.Text;

            if (txtMail.Text.Equals(""))
            {
                TO = "christian.floppy@gmail.com";
            }

            // Replace smtp_username with your Amazon SES SMTP user name.
            String SMTP_USERNAME = "jennifer@mcsystem.com.mx";

            // Replace smtp_password with your Amazon SES SMTP user name.
            String SMTP_PASSWORD = "gs2daY6ft6zSjjj";

            // (Optional) the name of a configuration set to use for this message.
            // If you comment out this line, you also need to remove or comment out
            // the "X-SES-CONFIGURATION-SET" header below.
            String CONFIGSET = "ConfigSet";

            // If you're using Amazon SES in a region other than EE.UU. Oeste (Oregón), 
            // replace email-smtp.us-west-2.amazonaws.com with the Amazon SES SMTP  
            // endpoint in the appropriate AWS Region.
            String HOST = "mcsystem.com.mx";

            // The port you will connect to on the Amazon SES SMTP endpoint. We
            // are choosing port 587 because we will use STARTTLS to encrypt
            // the connection.
            int PORT = 587;

            // The subject line of the email
            String SUBJECT =
                " - Nueva Orden de Servicio Generada. test (SMTP interface accessed using C#)";

            // The body of the email
            String BODY =
                "<h1>Prueba de Envio de Correo</h1>" +
                "<p>eSTE CORREO FUE ENVIADO DESDE EL SISTEMA DE  MCSYSTEM " +
                "<a href='https://www.mcsystem.com.mx/contacto.html'>Contáctanos</a>  POST FROM SMTP interface " +
                "using the .NET System.Net.Mail library.</p>";

            // Create and build a new MailMessage object
            MailMessage message = new MailMessage();
            message.IsBodyHtml = true;
            message.From = new MailAddress(FROM, FROMNAME);
            message.To.Add(new MailAddress(TO));
            message.Subject = SUBJECT;
            message.Body = BODY;
            // Comment or delete the next line if you are not using a configuration set
            message.Headers.Add("X-SES-CONFIGURATION-SET", CONFIGSET);

            using (var client = new System.Net.Mail.SmtpClient(HOST, PORT))
            {
                // Pass SMTP credentials
                client.Credentials =
                    new NetworkCredential(SMTP_USERNAME, SMTP_PASSWORD);

                // Enable SSL encryption
                client.EnableSsl = true;

                // Try to send the message. Show status in console.
                try
                {
                    MessageBox.Show("Attempting to send email...");
                    client.Send(message);
                    MessageBox.Show("Email sent!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The email was not sent.");
                    MessageBox.Show("Error message: " + ex.Message);
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtMail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPw_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPort_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDBName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHost_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
