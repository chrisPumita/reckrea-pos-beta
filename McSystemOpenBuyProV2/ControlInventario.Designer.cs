namespace McSystemOpenBuyProV2
{
    partial class ControlInventario
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblEncontrados = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.txtCajaBusqueda = new System.Windows.Forms.TextBox();
            this.cboOrdenar = new System.Windows.Forms.ComboBox();
            this.cboFiltroOpcion = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.gridDatos = new System.Windows.Forms.DataGridView();
            this.numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codeIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoriaCat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marcas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estatus = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.lblEncontrados);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 394);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1100, 56);
            this.panel3.TabIndex = 4;
            // 
            // lblEncontrados
            // 
            this.lblEncontrados.AutoSize = true;
            this.lblEncontrados.Location = new System.Drawing.Point(5, 19);
            this.lblEncontrados.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEncontrados.Name = "lblEncontrados";
            this.lblEncontrados.Size = new System.Drawing.Size(95, 14);
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
            this.panel6.Size = new System.Drawing.Size(1100, 44);
            this.panel6.TabIndex = 5;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::McSystemOpenBuyProV2.Properties.Resources.search;
            this.pictureBox3.Location = new System.Drawing.Point(8, 5);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 32);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // txtCajaBusqueda
            // 
            this.txtCajaBusqueda.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCajaBusqueda.Location = new System.Drawing.Point(55, 5);
            this.txtCajaBusqueda.Margin = new System.Windows.Forms.Padding(2);
            this.txtCajaBusqueda.Name = "txtCajaBusqueda";
            this.txtCajaBusqueda.Size = new System.Drawing.Size(356, 27);
            this.txtCajaBusqueda.TabIndex = 3;
            // 
            // cboOrdenar
            // 
            this.cboOrdenar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboOrdenar.AutoCompleteCustomSource.AddRange(new string[] {
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
            this.cboOrdenar.FormattingEnabled = true;
            this.cboOrdenar.Items.AddRange(new object[] {
            "Precio de Bajo a Alto",
            "Precio de Alto a Bajo",
            "Marcas A-Z",
            "Marcas Z-A",
            "Recién Llegados"});
            this.cboOrdenar.Location = new System.Drawing.Point(3, 3);
            this.cboOrdenar.Name = "cboOrdenar";
            this.cboOrdenar.Size = new System.Drawing.Size(147, 22);
            this.cboOrdenar.TabIndex = 6;
            this.cboOrdenar.Text = "Ordenar por...";
            this.cboOrdenar.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // cboFiltroOpcion
            // 
            this.cboFiltroOpcion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboFiltroOpcion.AutoCompleteCustomSource.AddRange(new string[] {
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
            this.cboFiltroOpcion.FormattingEnabled = true;
            this.cboFiltroOpcion.Items.AddRange(new object[] {
            "Agotados",
            "Disponibles",
            "Con Descuento",
            "Sin Descuento",
            "Todos"});
            this.cboFiltroOpcion.Location = new System.Drawing.Point(3, 31);
            this.cboFiltroOpcion.Name = "cboFiltroOpcion";
            this.cboFiltroOpcion.Size = new System.Drawing.Size(147, 22);
            this.cboFiltroOpcion.TabIndex = 5;
            this.cboFiltroOpcion.Text = "Opciones de filtrado...";
            this.cboFiltroOpcion.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Controls.Add(this.cboOrdenar);
            this.flowLayoutPanel1.Controls.Add(this.cboFiltroOpcion);
            this.flowLayoutPanel1.Controls.Add(this.cboCategoria);
            this.flowLayoutPanel1.Controls.Add(this.button4);
            this.flowLayoutPanel1.Controls.Add(this.btnEliminar);
            this.flowLayoutPanel1.Controls.Add(this.btnEditar);
            this.flowLayoutPanel1.Controls.Add(this.button8);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(936, 44);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(164, 350);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // cboCategoria
            // 
            this.cboCategoria.Anchor = System.Windows.Forms.AnchorStyles.Left;
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
            this.cboCategoria.Items.AddRange(new object[] {
            "Categoria",
            "\tc"});
            this.cboCategoria.Location = new System.Drawing.Point(3, 59);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(147, 22);
            this.cboCategoria.TabIndex = 7;
            this.cboCategoria.Text = "Filtrar por Categoria...";
            this.cboCategoria.SelectedIndexChanged += new System.EventHandler(this.cboCategoria_SelectedIndexChanged);
            // 
            // button4
            // 
            this.button4.AutoSize = true;
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(29)))), ((int)(((byte)(88)))));
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button4.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(101)))), ((int)(((byte)(1)))));
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(101)))), ((int)(((byte)(1)))));
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Image = global::McSystemOpenBuyProV2.Properties.Resources.plus;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button4.Location = new System.Drawing.Point(4, 87);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(146, 58);
            this.button4.TabIndex = 14;
            this.button4.Text = "Nuevo";
            this.button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.AutoSize = true;
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(29)))), ((int)(((byte)(88)))));
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.Enabled = false;
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnEliminar.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(101)))), ((int)(((byte)(1)))));
            this.btnEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(101)))), ((int)(((byte)(1)))));
            this.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Image = global::McSystemOpenBuyProV2.Properties.Resources.close;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEliminar.Location = new System.Drawing.Point(4, 151);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(146, 58);
            this.btnEliminar.TabIndex = 15;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.AutoSize = true;
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(29)))), ((int)(((byte)(88)))));
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.Enabled = false;
            this.btnEditar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnEditar.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(101)))), ((int)(((byte)(1)))));
            this.btnEditar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(101)))), ((int)(((byte)(1)))));
            this.btnEditar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Image = global::McSystemOpenBuyProV2.Properties.Resources.tools_and_utensils1;
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEditar.Location = new System.Drawing.Point(4, 215);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(146, 58);
            this.btnEditar.TabIndex = 16;
            this.btnEditar.Text = "Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // button8
            // 
            this.button8.AutoSize = true;
            this.button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(29)))), ((int)(((byte)(88)))));
            this.button8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button8.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button8.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(101)))), ((int)(((byte)(1)))));
            this.button8.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(101)))), ((int)(((byte)(1)))));
            this.button8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.ForeColor = System.Drawing.Color.White;
            this.button8.Image = global::McSystemOpenBuyProV2.Properties.Resources.print;
            this.button8.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button8.Location = new System.Drawing.Point(4, 279);
            this.button8.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(146, 58);
            this.button8.TabIndex = 17;
            this.button8.Text = "Imprimir";
            this.button8.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.gridDatos);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(936, 350);
            this.panel1.TabIndex = 7;
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
            this.CategoriaCat,
            this.Descripcion,
            this.marcas,
            this.Precio,
            this.Descuento,
            this.stock,
            this.fecha,
            this.Estatus});
            this.gridDatos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gridDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDatos.Location = new System.Drawing.Point(0, 0);
            this.gridDatos.Name = "gridDatos";
            this.gridDatos.ReadOnly = true;
            this.gridDatos.Size = new System.Drawing.Size(936, 350);
            this.gridDatos.TabIndex = 57;
            this.gridDatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDatos_CellContentClick);
            this.gridDatos.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridDatos_CellMouseClick);
            // 
            // numero
            // 
            this.numero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.numero.HeaderText = "#";
            this.numero.Name = "numero";
            this.numero.ReadOnly = true;
            this.numero.Width = 40;
            // 
            // codeIn
            // 
            this.codeIn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.codeIn.HeaderText = "Codigo";
            this.codeIn.Name = "codeIn";
            this.codeIn.ReadOnly = true;
            this.codeIn.Width = 71;
            // 
            // CategoriaCat
            // 
            this.CategoriaCat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CategoriaCat.HeaderText = "Categoria";
            this.CategoriaCat.Name = "CategoriaCat";
            this.CategoriaCat.ReadOnly = true;
            this.CategoriaCat.Width = 85;
            // 
            // Descripcion
            // 
            this.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // marcas
            // 
            this.marcas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.marcas.HeaderText = "Marca";
            this.marcas.Name = "marcas";
            this.marcas.ReadOnly = true;
            this.marcas.Width = 65;
            // 
            // Precio
            // 
            this.Precio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            this.Precio.Width = 67;
            // 
            // Descuento
            // 
            this.Descuento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Descuento.HeaderText = "Descuento";
            this.Descuento.Name = "Descuento";
            this.Descuento.ReadOnly = true;
            this.Descuento.Width = 93;
            // 
            // stock
            // 
            this.stock.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.stock.FillWeight = 40.50633F;
            this.stock.HeaderText = "Stock";
            this.stock.Name = "stock";
            this.stock.ReadOnly = true;
            this.stock.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.stock.Width = 63;
            // 
            // fecha
            // 
            this.fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.fecha.HeaderText = "Alta";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            this.fecha.Width = 54;
            // 
            // Estatus
            // 
            this.Estatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.Estatus.HeaderText = "Estatus";
            this.Estatus.Name = "Estatus";
            this.Estatus.ReadOnly = true;
            this.Estatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Estatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Estatus.Width = 5;
            // 
            // ControlInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel6);
            this.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ControlInventario";
            this.Size = new System.Drawing.Size(1100, 450);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblEncontrados;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox cboFiltroOpcion;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox txtCajaBusqueda;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboOrdenar;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoria;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.DataGridView gridDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoriaCat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn marcas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewImageColumn Estatus;
    }
}
