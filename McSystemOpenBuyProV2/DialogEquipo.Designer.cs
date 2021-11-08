namespace McSystemOpenBuyProV2
{
    partial class DialogEquipo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogEquipo));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gridDatos = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSelected = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblEncontrados = new System.Windows.Forms.Label();
            this.numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codeIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Caracteristicas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDatos)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(748, 424);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.gridDatos);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 59);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(598, 334);
            this.panel3.TabIndex = 60;
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
            this.id,
            this.Nombre,
            this.Precio,
            this.Estatus,
            this.codeIn,
            this.fecha,
            this.Caracteristicas});
            this.gridDatos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gridDatos.Location = new System.Drawing.Point(12, 6);
            this.gridDatos.Name = "gridDatos";
            this.gridDatos.ReadOnly = true;
            this.gridDatos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridDatos.Size = new System.Drawing.Size(580, 322);
            this.gridDatos.TabIndex = 59;
            this.gridDatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDatos_CellContentClick);
            this.gridDatos.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridDatos_CellMouseClick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnSelected);
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Controls.Add(this.btnEditar);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(598, 59);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(150, 334);
            this.flowLayoutPanel1.TabIndex = 58;
            // 
            // btnSelected
            // 
            this.btnSelected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(101)))), ((int)(((byte)(1)))));
            this.btnSelected.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelected.Enabled = false;
            this.btnSelected.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelected.ForeColor = System.Drawing.Color.White;
            this.btnSelected.Image = ((System.Drawing.Image)(resources.GetObject("btnSelected.Image")));
            this.btnSelected.Location = new System.Drawing.Point(2, 2);
            this.btnSelected.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelected.Name = "btnSelected";
            this.btnSelected.Size = new System.Drawing.Size(140, 70);
            this.btnSelected.TabIndex = 50;
            this.btnSelected.Text = "Seleccionar";
            this.btnSelected.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSelected.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSelected.UseVisualStyleBackColor = false;
            this.btnSelected.Click += new System.EventHandler(this.btnSelected_Click);
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
            // panel2
            // 
            this.panel2.Controls.Add(this.lblTitulo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(748, 59);
            this.panel2.TabIndex = 51;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Montserrat", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(29)))), ((int)(((byte)(88)))));
            this.lblTitulo.Location = new System.Drawing.Point(14, 20);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(268, 25);
            this.lblTitulo.TabIndex = 36;
            this.lblTitulo.Text = "{Agregar producto a..}";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(29)))), ((int)(((byte)(88)))));
            this.panel4.Controls.Add(this.lblEncontrados);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 393);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(748, 31);
            this.panel4.TabIndex = 50;
            // 
            // lblEncontrados
            // 
            this.lblEncontrados.AutoSize = true;
            this.lblEncontrados.ForeColor = System.Drawing.Color.White;
            this.lblEncontrados.Location = new System.Drawing.Point(16, 9);
            this.lblEncontrados.Name = "lblEncontrados";
            this.lblEncontrados.Size = new System.Drawing.Size(42, 13);
            this.lblEncontrados.TabIndex = 0;
            this.lblEncontrados.Text = "{found}";
            // 
            // numero
            // 
            this.numero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.numero.HeaderText = "#";
            this.numero.Name = "numero";
            this.numero.ReadOnly = true;
            this.numero.Width = 39;
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 41;
            // 
            // Nombre
            // 
            this.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Nombre.FillWeight = 196.6761F;
            this.Nombre.HeaderText = "Categoria";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 77;
            // 
            // Precio
            // 
            this.Precio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Precio.FillWeight = 123.3128F;
            this.Precio.HeaderText = "Marca";
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            this.Precio.Width = 62;
            // 
            // Estatus
            // 
            this.Estatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Estatus.FillWeight = 40.50633F;
            this.Estatus.HeaderText = "Modelo";
            this.Estatus.Name = "Estatus";
            this.Estatus.ReadOnly = true;
            this.Estatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Estatus.Width = 67;
            // 
            // codeIn
            // 
            this.codeIn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.codeIn.FillWeight = 39.5048F;
            this.codeIn.HeaderText = "Serie";
            this.codeIn.Name = "codeIn";
            this.codeIn.ReadOnly = true;
            this.codeIn.Width = 56;
            // 
            // fecha
            // 
            this.fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.fecha.HeaderText = "Alta";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            this.fecha.Width = 50;
            // 
            // Caracteristicas
            // 
            this.Caracteristicas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Caracteristicas.HeaderText = "Caracteristicas";
            this.Caracteristicas.Name = "Caracteristicas";
            this.Caracteristicas.ReadOnly = true;
            // 
            // DialogEquipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(748, 424);
            this.Controls.Add(this.panel1);
            this.Name = "DialogEquipo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Seleccione el Equipo";
            this.Load += new System.EventHandler(this.DialogEquipo_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDatos)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblEncontrados;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView gridDatos;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnSelected;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Caracteristicas;
    }
}