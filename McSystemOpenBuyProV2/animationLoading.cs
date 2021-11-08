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
    public partial class animationLoading : Form
    {
        public animationLoading()
        {
            InitializeComponent();
        }

        private void animationLoading_Load(object sender, EventArgs e)
        {
            miAnimacion.Location = new Point(this.Width/2-miAnimacion.Width/2
                ,this.Height-miAnimacion.Height);
        }
    }
}
