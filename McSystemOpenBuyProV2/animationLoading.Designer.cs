namespace McSystemOpenBuyProV2
{
    partial class animationLoading
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.miAnimacion = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.miAnimacion)).BeginInit();
            this.SuspendLayout();
            // 
            // miAnimacion
            // 
            this.miAnimacion.Image = global::McSystemOpenBuyProV2.Properties.Resources.cargando;
            this.miAnimacion.Location = new System.Drawing.Point(0, -1);
            this.miAnimacion.Name = "miAnimacion";
            this.miAnimacion.Size = new System.Drawing.Size(256, 256);
            this.miAnimacion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.miAnimacion.TabIndex = 0;
            this.miAnimacion.TabStop = false;
            // 
            // animationLoading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 256);
            this.Controls.Add(this.miAnimacion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(256, 256);
            this.Name = "animationLoading";
            this.Opacity = 0.7D;
            this.Text = "animationLoading";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.animationLoading_Load);
            ((System.ComponentModel.ISupportInitialize)(this.miAnimacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox miAnimacion;
    }
}