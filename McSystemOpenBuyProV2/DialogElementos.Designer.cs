namespace McSystemOpenBuyProV2
{
    partial class DialogElementos
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.imgStatus = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblNum = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.CheckBox();
            this.btnAccion = new System.Windows.Forms.Button();
            this.gridDatos = new System.Windows.Forms.DataGridView();
            this.numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estatus = new System.Windows.Forms.DataGridViewImageColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.lblOpc = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgStatus)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.imgStatus);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.cboStatus);
            this.panel1.Controls.Add(this.btnAccion);
            this.panel1.Controls.Add(this.gridDatos);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.lblOpc);
            this.panel1.Controls.Add(this.txtNombre);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(473, 419);
            this.panel1.TabIndex = 0;
            // 
            // imgStatus
            // 
            this.imgStatus.Image = global::McSystemOpenBuyProV2.Properties.Resources.onBlue;
            this.imgStatus.Location = new System.Drawing.Point(427, 121);
            this.imgStatus.Name = "imgStatus";
            this.imgStatus.Size = new System.Drawing.Size(34, 21);
            this.imgStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgStatus.TabIndex = 61;
            this.imgStatus.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(29)))), ((int)(((byte)(88)))));
            this.panel2.Controls.Add(this.lblNum);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 383);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(473, 36);
            this.panel2.TabIndex = 60;
            // 
            // lblNum
            // 
            this.lblNum.AutoSize = true;
            this.lblNum.ForeColor = System.Drawing.Color.White;
            this.lblNum.Location = new System.Drawing.Point(12, 14);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(72, 13);
            this.lblNum.TabIndex = 58;
            this.lblNum.Text = "{Num FOund}";
            // 
            // cboStatus
            // 
            this.cboStatus.AutoSize = true;
            this.cboStatus.Checked = true;
            this.cboStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cboStatus.Location = new System.Drawing.Point(362, 124);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(59, 17);
            this.cboStatus.TabIndex = 59;
            this.cboStatus.Text = "Activar";
            this.cboStatus.UseVisualStyleBackColor = true;
            // 
            // btnAccion
            // 
            this.btnAccion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(29)))), ((int)(((byte)(88)))));
            this.btnAccion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccion.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccion.ForeColor = System.Drawing.Color.White;
            this.btnAccion.Location = new System.Drawing.Point(321, 147);
            this.btnAccion.Margin = new System.Windows.Forms.Padding(2);
            this.btnAccion.Name = "btnAccion";
            this.btnAccion.Size = new System.Drawing.Size(140, 38);
            this.btnAccion.TabIndex = 57;
            this.btnAccion.Text = "{accion}";
            this.btnAccion.UseVisualStyleBackColor = false;
            this.btnAccion.Click += new System.EventHandler(this.btnAccion_Click);
            // 
            // gridDatos
            // 
            this.gridDatos.AllowUserToAddRows = false;
            this.gridDatos.AllowUserToDeleteRows = false;
            this.gridDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridDatos.BackgroundColor = System.Drawing.Color.White;
            this.gridDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numero,
            this.Nombre,
            this.Estatus});
            this.gridDatos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gridDatos.Location = new System.Drawing.Point(11, 216);
            this.gridDatos.Name = "gridDatos";
            this.gridDatos.Size = new System.Drawing.Size(450, 161);
            this.gridDatos.TabIndex = 55;
            this.gridDatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDatos_CellContentClick);
            this.gridDatos.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridDatos_CellMouseClick);
            // 
            // numero
            // 
            this.numero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.numero.HeaderText = "#";
            this.numero.Name = "numero";
            this.numero.ReadOnly = true;
            this.numero.Width = 39;
            // 
            // Nombre
            // 
            this.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nombre.FillWeight = 159.4937F;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Estatus
            // 
            this.Estatus.FillWeight = 40.50633F;
            this.Estatus.HeaderText = "Mostrar";
            this.Estatus.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Estatus.Name = "Estatus";
            this.Estatus.ReadOnly = true;
            this.Estatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Estatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(29)))), ((int)(((byte)(88)))));
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(164, 147);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 38);
            this.button2.TabIndex = 54;
            this.button2.Text = "Nuevo";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblOpc
            // 
            this.lblOpc.AutoSize = true;
            this.lblOpc.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(29)))), ((int)(((byte)(88)))));
            this.lblOpc.Location = new System.Drawing.Point(11, 65);
            this.lblOpc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOpc.Name = "lblOpc";
            this.lblOpc.Size = new System.Drawing.Size(151, 19);
            this.lblOpc.TabIndex = 42;
            this.lblOpc.Text = "{Tiite Elemento}";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(11, 92);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(450, 27);
            this.txtNombre.TabIndex = 41;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Montserrat", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(29)))), ((int)(((byte)(88)))));
            this.lblTitulo.Location = new System.Drawing.Point(118, 9);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(212, 25);
            this.lblTitulo.TabIndex = 40;
            this.lblTitulo.Text = "{ElementoCalled}";
            // 
            // DialogElementos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 419);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogElementos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DialogElementos";
            this.Load += new System.EventHandler(this.DialogElementos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgStatus)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblOpc;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView gridDatos;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnAccion;
        private System.Windows.Forms.Label lblNum;
        private System.Windows.Forms.CheckBox cboStatus;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox imgStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewImageColumn estatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewImageColumn Estatus;
    }
}