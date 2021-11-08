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
    public partial class MessageBoxCustom : Form
    {
        public MessageBoxCustom(string titulo, string mje)
        {
            InitializeComponent();
            lblMje.Text = mje;
            lblTitulo.Text = titulo;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
