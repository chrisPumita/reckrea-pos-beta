namespace McSystemOpenBuyProV2
{
    partial class DialogBuscarProducto
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
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.gridDatos = new System.Windows.Forms.DataGridView();
            this.numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codeIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel28 = new System.Windows.Forms.Panel();
            this.btnCLose = new System.Windows.Forms.Button();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.lblEncontrados = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.txtCajaBusqueda = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDatos)).BeginInit();
            this.panel28.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.cboCategoria);
            this.panel1.Controls.Add(this.gridDatos);
            this.panel1.Controls.Add(this.panel28);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(736, 389);
            this.panel1.TabIndex = 0;
            // 
            // cboCategoria
            // 
            this.cboCategoria.AutoCompleteCustomSource.AddRange(new string[] {
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
            this.cboCategoria.FormattingEnabled = true;
            this.cboCategoria.Location = new System.Drawing.Point(73, 34);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(323, 21);
            this.cboCategoria.TabIndex = 5;
            this.cboCategoria.Text = "Filtrar por Categoria...";
            this.cboCategoria.SelectedIndexChanged += new System.EventHandler(this.cboCategoria_SelectedIndexChanged);
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
            this.Descuento,
            this.stock});
            this.gridDatos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gridDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDatos.Location = new System.Drawing.Point(0, 61);
            this.gridDatos.Name = "gridDatos";
            this.gridDatos.ReadOnly = true;
            this.gridDatos.Size = new System.Drawing.Size(736, 280);
            this.gridDatos.TabIndex = 64;
            this.gridDatos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridDatos_MouseClick);
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
            this.codeIn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.codeIn.FillWeight = 26.26375F;
            this.codeIn.HeaderText = "Codigo";
            this.codeIn.Name = "codeIn";
            this.codeIn.ReadOnly = true;
            this.codeIn.Width = 65;
            // 
            // Nombre
            // 
            this.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nombre.FillWeight = 41.88903F;
            this.Nombre.HeaderText = "Descripcion";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Precio
            // 
            this.Precio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Precio.FillWeight = 26.26375F;
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            this.Precio.Width = 62;
            // 
            // Descuento
            // 
            this.Descuento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Descuento.FillWeight = 365.0772F;
            this.Descuento.HeaderText = "Desc";
            this.Descuento.Name = "Descuento";
            this.Descuento.ReadOnly = true;
            this.Descuento.Width = 57;
            // 
            // stock
            // 
            this.stock.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.stock.HeaderText = "Stock";
            this.stock.Name = "stock";
            this.stock.ReadOnly = true;
            this.stock.Width = 60;
            // 
            // panel28
            // 
            this.panel28.BackColor = System.Drawing.Color.White;
            this.panel28.Controls.Add(this.btnCLose);
            this.panel28.Controls.Add(this.btnSeleccionar);
            this.panel28.Controls.Add(this.lblEncontrados);
            this.panel28.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel28.Location = new System.Drawing.Point(0, 341);
            this.panel28.Margin = new System.Windows.Forms.Padding(2);
            this.panel28.Name = "panel28";
            this.panel28.Size = new System.Drawing.Size(736, 48);
            this.panel28.TabIndex = 65;
            // 
            // btnCLose
            // 
            this.btnCLose.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCLose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCLose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCLose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCLose.ForeColor = System.Drawing.Color.White;
            this.btnCLose.Location = new System.Drawing.Point(631, 6);
            this.btnCLose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCLose.Name = "btnCLose";
            this.btnCLose.Size = new System.Drawing.Size(101, 35);
            this.btnCLose.TabIndex = 11;
            this.btnCLose.Text = "Cancelar";
            this.btnCLose.UseVisualStyleBackColor = false;
            this.btnCLose.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSeleccionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(196)))));
            this.btnSeleccionar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeleccionar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(201)))), ((int)(((byte)(60)))));
            this.btnSeleccionar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(104)))), ((int)(((byte)(159)))));
            this.btnSeleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionar.ForeColor = System.Drawing.Color.White;
            this.btnSeleccionar.Location = new System.Drawing.Point(522, 6);
            this.btnSeleccionar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(101, 35);
            this.btnSeleccionar.TabIndex = 10;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.UseVisualStyleBackColor = false;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // lblEncontrados
            // 
            this.lblEncontrados.AutoSize = true;
            this.lblEncontrados.ForeColor = System.Drawing.Color.Black;
            this.lblEncontrados.Location = new System.Drawing.Point(6, 8);
            this.lblEncontrados.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEncontrados.Name = "lblEncontrados";
            this.lblEncontrados.Size = new System.Drawing.Size(85, 13);
            this.lblEncontrados.TabIndex = 3;
            this.lblEncontrados.Text = "No hay artículos";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Controls.Add(this.pictureBox3);
            this.panel6.Controls.Add(this.txtCajaBusqueda);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(736, 61);
            this.panel6.TabIndex = 3;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::McSystemOpenBuyProV2.Properties.Resources.buscando_lupa;
            this.pictureBox3.Location = new System.Drawing.Point(9, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(55, 52);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // txtCajaBusqueda
            // 
            this.txtCajaBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCajaBusqueda.Location = new System.Drawing.Point(73, 5);
            this.txtCajaBusqueda.Margin = new System.Windows.Forms.Padding(2);
            this.txtCajaBusqueda.Name = "txtCajaBusqueda";
            this.txtCajaBusqueda.Size = new System.Drawing.Size(323, 26);
            this.txtCajaBusqueda.TabIndex = 3;
            // 
            // DialogBuscarProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 389);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Name = "DialogBuscarProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Buscar un producto";
            this.Load += new System.EventHandler(this.DialogBuscarProducto_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDatos)).EndInit();
            this.panel28.ResumeLayout(false);
            this.panel28.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.DataGridView gridDatos;
        private System.Windows.Forms.Panel panel28;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.Label lblEncontrados;
        private System.Windows.Forms.Button btnCLose;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn stock;
        public System.Windows.Forms.TextBox txtCajaBusqueda;
    }
}