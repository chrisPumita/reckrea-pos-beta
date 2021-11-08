namespace McSystemOpenBuyProV2
{
    partial class DialogPersonas
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSelected = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.gridDatos = new System.Windows.Forms.DataGridView();
            this.numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codeIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblEncontrados = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cboSelected = new System.Windows.Forms.ComboBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.txtCajaBusqueda = new System.Windows.Forms.TextBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDatos)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(748, 424);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.flowLayoutPanel1);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 84);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(748, 309);
            this.panel3.TabIndex = 50;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnSelected);
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Controls.Add(this.btnEditar);
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(598, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(150, 309);
            this.flowLayoutPanel1.TabIndex = 54;
            // 
            // btnSelected
            // 
            this.btnSelected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(101)))), ((int)(((byte)(1)))));
            this.btnSelected.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelected.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelected.ForeColor = System.Drawing.Color.White;
            this.btnSelected.Image = global::McSystemOpenBuyProV2.Properties.Resources.click;
            this.btnSelected.Location = new System.Drawing.Point(2, 2);
            this.btnSelected.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelected.Name = "btnSelected";
            this.btnSelected.Size = new System.Drawing.Size(140, 70);
            this.btnSelected.TabIndex = 50;
            this.btnSelected.Text = "Seleccionar";
            this.btnSelected.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSelected.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSelected.UseVisualStyleBackColor = false;
            this.btnSelected.Click += new System.EventHandler(this.button5_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(29)))), ((int)(((byte)(88)))));
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(2, 76);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 38);
            this.button2.TabIndex = 53;
            this.button2.Text = "Nuevo";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(29)))), ((int)(((byte)(88)))));
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.Enabled = false;
            this.btnEditar.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(2, 118);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(140, 38);
            this.btnEditar.TabIndex = 52;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.gridDatos);
            this.panel6.Location = new System.Drawing.Point(16, 6);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(576, 297);
            this.panel6.TabIndex = 0;
            // 
            // gridDatos
            // 
            this.gridDatos.AllowUserToAddRows = false;
            this.gridDatos.AllowUserToDeleteRows = false;
            this.gridDatos.AllowUserToResizeColumns = false;
            this.gridDatos.AllowUserToResizeRows = false;
            this.gridDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridDatos.BackgroundColor = System.Drawing.Color.White;
            this.gridDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numero,
            this.codeIn,
            this.Nombre,
            this.Precio,
            this.Estatus});
            this.gridDatos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gridDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDatos.Location = new System.Drawing.Point(0, 0);
            this.gridDatos.Name = "gridDatos";
            this.gridDatos.ReadOnly = true;
            this.gridDatos.Size = new System.Drawing.Size(576, 297);
            this.gridDatos.TabIndex = 57;
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
            // codeIn
            // 
            this.codeIn.FillWeight = 39.5048F;
            this.codeIn.HeaderText = "ID";
            this.codeIn.Name = "codeIn";
            this.codeIn.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nombre.FillWeight = 196.6761F;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Precio
            // 
            this.Precio.FillWeight = 123.3128F;
            this.Precio.HeaderText = "Teléfono";
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            // 
            // Estatus
            // 
            this.Estatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Estatus.FillWeight = 40.50633F;
            this.Estatus.HeaderText = "Estatus";
            this.Estatus.Name = "Estatus";
            this.Estatus.ReadOnly = true;
            this.Estatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Estatus.Width = 67;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(29)))), ((int)(((byte)(88)))));
            this.panel4.Controls.Add(this.lblEncontrados);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 393);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(748, 31);
            this.panel4.TabIndex = 49;
            // 
            // lblEncontrados
            // 
            this.lblEncontrados.AutoSize = true;
            this.lblEncontrados.ForeColor = System.Drawing.Color.White;
            this.lblEncontrados.Location = new System.Drawing.Point(16, 15);
            this.lblEncontrados.Name = "lblEncontrados";
            this.lblEncontrados.Size = new System.Drawing.Size(42, 13);
            this.lblEncontrados.TabIndex = 0;
            this.lblEncontrados.Text = "{found}";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Controls.Add(this.txtCajaBusqueda);
            this.panel2.Controls.Add(this.lblTitulo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(748, 84);
            this.panel2.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.cboSelected);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(538, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(210, 84);
            this.panel5.TabIndex = 41;
            // 
            // cboSelected
            // 
            this.cboSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSelected.AutoCompleteCustomSource.AddRange(new string[] {
            "ALL IN ONE",
            "APPLE",
            "GENERICO",
            "IMPRESORA",
            "LAPTOP",
            "NETBOOK",
            "NOTEBOOK",
            "PANTALLA",
            "PC",
            "PERIFERICO",
            "TABLET",
            "CONSUMIBLE",
            "OTRO",
            "CABLE"});
            this.cboSelected.FormattingEnabled = true;
            this.cboSelected.Items.AddRange(new object[] {
            "Activos",
            "Inactivos",
            "Ver todo"});
            this.cboSelected.Location = new System.Drawing.Point(3, 43);
            this.cboSelected.Name = "cboSelected";
            this.cboSelected.Size = new System.Drawing.Size(195, 21);
            this.cboSelected.TabIndex = 52;
            this.cboSelected.Text = "Filtrar por Categoria...";
            this.cboSelected.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::McSystemOpenBuyProV2.Properties.Resources.search;
            this.pictureBox3.Location = new System.Drawing.Point(12, 38);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 32);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 40;
            this.pictureBox3.TabStop = false;
            // 
            // txtCajaBusqueda
            // 
            this.txtCajaBusqueda.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCajaBusqueda.Location = new System.Drawing.Point(49, 43);
            this.txtCajaBusqueda.Margin = new System.Windows.Forms.Padding(2);
            this.txtCajaBusqueda.Name = "txtCajaBusqueda";
            this.txtCajaBusqueda.Size = new System.Drawing.Size(319, 27);
            this.txtCajaBusqueda.TabIndex = 39;
            this.txtCajaBusqueda.TextChanged += new System.EventHandler(this.txtCajaBusqueda_TextChanged);
            this.txtCajaBusqueda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCajaBusqueda_KeyDown);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Montserrat", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(29)))), ((int)(((byte)(88)))));
            this.lblTitulo.Location = new System.Drawing.Point(11, 9);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(252, 25);
            this.lblTitulo.TabIndex = 38;
            this.lblTitulo.Text = "{View Emp/Clientes}";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(29)))), ((int)(((byte)(88)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(2, 160);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 38);
            this.button1.TabIndex = 54;
            this.button1.Text = "Ver Todos";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DialogPersonas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 424);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogPersonas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registros en el sistema";
            this.Load += new System.EventHandler(this.DialogPersonas_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDatos)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox txtCajaBusqueda;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox cboSelected;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnSelected;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataGridView gridDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estatus;
        private System.Windows.Forms.Label lblEncontrados;
        private System.Windows.Forms.Button button1;

    }
}