namespace McSystemOpenBuyProV2
{
    partial class ControlCatalogo
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
            this.components = new System.ComponentModel.Container();
            this.panelDetalles = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.lblCopiado = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.imgNew = new System.Windows.Forms.PictureBox();
            this.lblId = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCodeIn = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.panel10 = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.lblEncontrados = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.txtCajaBusqueda = new System.Windows.Forms.TextBox();
            this.panel11 = new System.Windows.Forms.Panel();
            this.gridDatos = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codeIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Exis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelDetalles.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgNew)).BeginInit();
            this.panel10.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // panelDetalles
            // 
            this.panelDetalles.BackColor = System.Drawing.Color.LightGray;
            this.panelDetalles.Controls.Add(this.panel7);
            this.panelDetalles.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelDetalles.Location = new System.Drawing.Point(728, 0);
            this.panelDetalles.Margin = new System.Windows.Forms.Padding(2);
            this.panelDetalles.Name = "panelDetalles";
            this.panelDetalles.Size = new System.Drawing.Size(452, 450);
            this.panelDetalles.TabIndex = 4;
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.Controls.Add(this.panel9);
            this.panel7.Location = new System.Drawing.Point(17, 10);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(420, 427);
            this.panel7.TabIndex = 4;
            // 
            // panel9
            // 
            this.panel9.AutoSize = true;
            this.panel9.Controls.Add(this.label3);
            this.panel9.Controls.Add(this.lblBarcode);
            this.panel9.Controls.Add(this.lblCopiado);
            this.panel9.Controls.Add(this.txtDesc);
            this.panel9.Controls.Add(this.imgNew);
            this.panel9.Controls.Add(this.lblId);
            this.panel9.Controls.Add(this.label1);
            this.panel9.Controls.Add(this.lblCodeIn);
            this.panel9.Controls.Add(this.label2);
            this.panel9.Controls.Add(this.button3);
            this.panel9.Controls.Add(this.panel10);
            this.panel9.Controls.Add(this.lblPrecio);
            this.panel9.Controls.Add(this.lblDescuento);
            this.panel9.Controls.Add(this.lblStock);
            this.panel9.Controls.Add(this.label8);
            this.panel9.Controls.Add(this.label9);
            this.panel9.Controls.Add(this.label10);
            this.panel9.Location = new System.Drawing.Point(11, 15);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(405, 399);
            this.panel9.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Montserrat", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(84, 124);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 25);
            this.label3.TabIndex = 41;
            this.label3.Text = "CODIGO:";
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Font = new System.Drawing.Font("Montserrat", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBarcode.Location = new System.Drawing.Point(196, 124);
            this.lblBarcode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(79, 25);
            this.lblBarcode.TabIndex = 40;
            this.lblBarcode.Text = "{code}";
            // 
            // lblCopiado
            // 
            this.lblCopiado.AutoSize = true;
            this.lblCopiado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(101)))), ((int)(((byte)(1)))));
            this.lblCopiado.Location = new System.Drawing.Point(158, 320);
            this.lblCopiado.Name = "lblCopiado";
            this.lblCopiado.Size = new System.Drawing.Size(85, 13);
            this.lblCopiado.TabIndex = 39;
            this.lblCopiado.Text = "Codigo Copiado!";
            this.lblCopiado.Visible = false;
            // 
            // txtDesc
            // 
            this.txtDesc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDesc.Font = new System.Drawing.Font("Montserrat", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc.Location = new System.Drawing.Point(42, 45);
            this.txtDesc.Margin = new System.Windows.Forms.Padding(2);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ReadOnly = true;
            this.txtDesc.Size = new System.Drawing.Size(313, 68);
            this.txtDesc.TabIndex = 29;
            this.txtDesc.Text = "{Cliente Mostrador}";
            this.txtDesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // imgNew
            // 
            this.imgNew.Image = global::McSystemOpenBuyProV2.Properties.Resources.new64;
            this.imgNew.Location = new System.Drawing.Point(338, 3);
            this.imgNew.Name = "imgNew";
            this.imgNew.Size = new System.Drawing.Size(64, 64);
            this.imgNew.TabIndex = 38;
            this.imgNew.TabStop = false;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(314, 369);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(80, 13);
            this.lblId.TabIndex = 37;
            this.lblId.Text = "{idIdentificable}";
            this.lblId.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 158);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 25);
            this.label1.TabIndex = 36;
            this.label1.Text = "Codigo Interno:";
            // 
            // lblCodeIn
            // 
            this.lblCodeIn.AutoSize = true;
            this.lblCodeIn.Font = new System.Drawing.Font("Montserrat", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodeIn.Location = new System.Drawing.Point(196, 158);
            this.lblCodeIn.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCodeIn.Name = "lblCodeIn";
            this.lblCodeIn.Size = new System.Drawing.Size(79, 25);
            this.lblCodeIn.TabIndex = 35;
            this.lblCodeIn.Text = "{code}";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Montserrat", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(29)))), ((int)(((byte)(88)))));
            this.label2.Location = new System.Drawing.Point(63, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(263, 25);
            this.label2.TabIndex = 34;
            this.label2.Text = "Detalles del Producto";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(29)))), ((int)(((byte)(88)))));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(59, 313);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 27);
            this.button3.TabIndex = 33;
            this.button3.Text = "Copiar Código";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(29)))), ((int)(((byte)(88)))));
            this.panel10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel10.Controls.Add(this.lblTotal);
            this.panel10.Controls.Add(this.label15);
            this.panel10.Location = new System.Drawing.Point(68, 261);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(287, 38);
            this.panel10.TabIndex = 20;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.White;
            this.lblTotal.Location = new System.Drawing.Point(182, 9);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(74, 19);
            this.lblTotal.TabIndex = 20;
            this.lblTotal.Text = "{00.00}";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(19, 9);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(159, 19);
            this.label15.TabIndex = 19;
            this.label15.Text = "PRECIO FINAL: $";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Montserrat", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.Location = new System.Drawing.Point(196, 208);
            this.lblPrecio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(88, 25);
            this.lblPrecio.TabIndex = 19;
            this.lblPrecio.Text = "{00.00}";
            // 
            // lblDescuento
            // 
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.Font = new System.Drawing.Font("Montserrat", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescuento.Location = new System.Drawing.Point(196, 233);
            this.lblDescuento.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(88, 25);
            this.lblDescuento.TabIndex = 18;
            this.lblDescuento.Text = "{00.00}";
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Font = new System.Drawing.Font("Montserrat", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStock.Location = new System.Drawing.Point(196, 183);
            this.lblStock.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(108, 25);
            this.lblStock.TabIndex = 17;
            this.lblStock.Text = "{no Pzas}";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Montserrat", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(107, 208);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 25);
            this.label8.TabIndex = 16;
            this.label8.Text = "Precio:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Montserrat", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(58, 233);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 25);
            this.label9.TabIndex = 15;
            this.label9.Text = "Descuento:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Montserrat", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(54, 183);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(138, 25);
            this.label10.TabIndex = 14;
            this.label10.Text = "Existencias:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel11);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(728, 450);
            this.panel2.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.lblEncontrados);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 394);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(728, 56);
            this.panel3.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(29)))), ((int)(((byte)(88)))));
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(614, 8);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 35);
            this.button2.TabIndex = 10;
            this.button2.Text = "Ver Todo";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblEncontrados
            // 
            this.lblEncontrados.AutoSize = true;
            this.lblEncontrados.Location = new System.Drawing.Point(5, 19);
            this.lblEncontrados.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEncontrados.Name = "lblEncontrados";
            this.lblEncontrados.Size = new System.Drawing.Size(85, 13);
            this.lblEncontrados.TabIndex = 3;
            this.lblEncontrados.Text = "No hay artículos";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Controls.Add(this.cboCategoria);
            this.panel6.Controls.Add(this.pictureBox3);
            this.panel6.Controls.Add(this.txtCajaBusqueda);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(728, 61);
            this.panel6.TabIndex = 2;
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
            this.cboCategoria.Location = new System.Drawing.Point(55, 36);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(323, 21);
            this.cboCategoria.TabIndex = 5;
            this.cboCategoria.Text = "Filtrar por Categoria...";
            this.cboCategoria.SelectedIndexChanged += new System.EventHandler(this.cboCategoria_SelectedIndexChanged);
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
            this.txtCajaBusqueda.Size = new System.Drawing.Size(323, 27);
            this.txtCajaBusqueda.TabIndex = 3;
            this.txtCajaBusqueda.TextChanged += new System.EventHandler(this.txtCajaBusqueda_TextChanged);
            this.txtCajaBusqueda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCajaBusqueda_KeyDown);
            this.txtCajaBusqueda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCajaBusqueda_KeyPress);
            // 
            // panel11
            // 
            this.panel11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel11.Controls.Add(this.gridDatos);
            this.panel11.Location = new System.Drawing.Point(8, 70);
            this.panel11.Margin = new System.Windows.Forms.Padding(2);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(714, 320);
            this.panel11.TabIndex = 1;
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
            this.nom,
            this.Precio,
            this.Exis});
            this.gridDatos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gridDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDatos.Location = new System.Drawing.Point(0, 0);
            this.gridDatos.Name = "gridDatos";
            this.gridDatos.ReadOnly = true;
            this.gridDatos.Size = new System.Drawing.Size(714, 320);
            this.gridDatos.TabIndex = 56;
            this.gridDatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDatos_CellContentClick);
            this.gridDatos.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridDatos_CellMouseClick);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
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
            this.codeIn.HeaderText = "Codigo";
            this.codeIn.Name = "codeIn";
            this.codeIn.ReadOnly = true;
            this.codeIn.Width = 65;
            // 
            // nom
            // 
            this.nom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nom.HeaderText = "Nombre";
            this.nom.Name = "nom";
            this.nom.ReadOnly = true;
            // 
            // Precio
            // 
            this.Precio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            this.Precio.Width = 62;
            // 
            // Exis
            // 
            this.Exis.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Exis.HeaderText = "Existencia";
            this.Exis.Name = "Exis";
            this.Exis.ReadOnly = true;
            this.Exis.Width = 80;
            // 
            // ControlCatalogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelDetalles);
            this.Name = "ControlCatalogo";
            this.Size = new System.Drawing.Size(1180, 450);
            this.Load += new System.EventHandler(this.ControlCatalogo_Load);
            this.panelDetalles.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgNew)).EndInit();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDetalles;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblEncontrados;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox txtCajaBusqueda;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCodeIn;
        private System.Windows.Forms.DataGridView gridDatos;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.PictureBox imgNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatus;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblCopiado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nom;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Exis;

    }
}
