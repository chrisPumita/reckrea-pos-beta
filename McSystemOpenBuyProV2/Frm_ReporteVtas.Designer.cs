namespace McSystemOpenBuyProV2
{
    partial class Frm_ReporteVtas
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
            this.panel5 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabTickets = new System.Windows.Forms.TabPage();
            this.panel8 = new System.Windows.Forms.Panel();
            this.gridDatos = new System.Windows.Forms.DataGridView();
            this.numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codeIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtotl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IVA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Forma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel7 = new System.Windows.Forms.Panel();
            this.cboPago = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.fechaFinal = new System.Windows.Forms.DateTimePicker();
            this.btnToday = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lblEncontrados = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.fechaInicial = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProductos = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblIVA = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblSub = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabProductos = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabTickets.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDatos)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel4.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1174, 650);
            this.panel1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Black;
            this.panel5.Controls.Add(this.tabControl1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 72);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1174, 557);
            this.panel5.TabIndex = 62;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabTickets);
            this.tabControl1.Controls.Add(this.tabProductos);
            this.tabControl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.ShowToolTips = true;
            this.tabControl1.Size = new System.Drawing.Size(1174, 557);
            this.tabControl1.TabIndex = 57;
            // 
            // tabTickets
            // 
            this.tabTickets.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabTickets.Controls.Add(this.panel8);
            this.tabTickets.Controls.Add(this.panel7);
            this.tabTickets.Controls.Add(this.panel4);
            this.tabTickets.Location = new System.Drawing.Point(4, 22);
            this.tabTickets.Name = "tabTickets";
            this.tabTickets.Padding = new System.Windows.Forms.Padding(3);
            this.tabTickets.Size = new System.Drawing.Size(1166, 531);
            this.tabTickets.TabIndex = 0;
            this.tabTickets.Text = "Ventas por Ticket";
            this.tabTickets.UseVisualStyleBackColor = true;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.DimGray;
            this.panel8.Controls.Add(this.gridDatos);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel8.Location = new System.Drawing.Point(3, 101);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(861, 425);
            this.panel8.TabIndex = 73;
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
            this.fecha,
            this.subtotl,
            this.desc,
            this.IVA,
            this.total,
            this.Vendedor,
            this.edo,
            this.Forma});
            this.gridDatos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gridDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDatos.Location = new System.Drawing.Point(0, 0);
            this.gridDatos.Name = "gridDatos";
            this.gridDatos.ReadOnly = true;
            this.gridDatos.Size = new System.Drawing.Size(861, 425);
            this.gridDatos.TabIndex = 63;
            this.gridDatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDatos_CellContentClick);
            this.gridDatos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridDatos_MouseClick);
            // 
            // numero
            // 
            this.numero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.numero.HeaderText = "ID";
            this.numero.Name = "numero";
            this.numero.ReadOnly = true;
            this.numero.Width = 43;
            // 
            // codeIn
            // 
            this.codeIn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.codeIn.HeaderText = "Codigo";
            this.codeIn.Name = "codeIn";
            this.codeIn.ReadOnly = true;
            this.codeIn.Width = 65;
            // 
            // fecha
            // 
            this.fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fecha.FillWeight = 159.4937F;
            this.fecha.HeaderText = "Fecha";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            // 
            // subtotl
            // 
            this.subtotl.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.subtotl.HeaderText = "$Subtotal";
            this.subtotl.Name = "subtotl";
            this.subtotl.ReadOnly = true;
            this.subtotl.Width = 77;
            // 
            // desc
            // 
            this.desc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.desc.FillWeight = 40.50633F;
            this.desc.HeaderText = "$Descuento";
            this.desc.Name = "desc";
            this.desc.ReadOnly = true;
            this.desc.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.desc.Width = 90;
            // 
            // IVA
            // 
            this.IVA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.IVA.HeaderText = "IVA";
            this.IVA.Name = "IVA";
            this.IVA.ReadOnly = true;
            this.IVA.Width = 49;
            // 
            // total
            // 
            this.total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.total.HeaderText = "$TOTAL";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            this.total.Width = 73;
            // 
            // Vendedor
            // 
            this.Vendedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Vendedor.HeaderText = "Vendedor";
            this.Vendedor.Name = "Vendedor";
            this.Vendedor.ReadOnly = true;
            this.Vendedor.Width = 78;
            // 
            // edo
            // 
            this.edo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.edo.HeaderText = "Estatus";
            this.edo.Name = "edo";
            this.edo.ReadOnly = true;
            this.edo.Width = 67;
            // 
            // Forma
            // 
            this.Forma.HeaderText = "Forma De Pago";
            this.Forma.Name = "Forma";
            this.Forma.ReadOnly = true;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.Controls.Add(this.cboPago);
            this.panel7.Controls.Add(this.button1);
            this.panel7.Controls.Add(this.checkBox2);
            this.panel7.Controls.Add(this.checkBox1);
            this.panel7.Controls.Add(this.label6);
            this.panel7.Controls.Add(this.fechaFinal);
            this.panel7.Controls.Add(this.btnToday);
            this.panel7.Controls.Add(this.button2);
            this.panel7.Controls.Add(this.lblEncontrados);
            this.panel7.Controls.Add(this.label1);
            this.panel7.Controls.Add(this.fechaInicial);
            this.panel7.Controls.Add(this.label2);
            this.panel7.Controls.Add(this.label3);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(3, 3);
            this.panel7.MaximumSize = new System.Drawing.Size(765, 98);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(765, 98);
            this.panel7.TabIndex = 72;
            // 
            // cboPago
            // 
            this.cboPago.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPago.AutoCompleteCustomSource.AddRange(new string[] {
            "Efectivo",
            "Debito",
            "Credito",
            "Transferencia"});
            this.cboPago.FormattingEnabled = true;
            this.cboPago.Items.AddRange(new object[] {
            "Efectivo",
            "Debito",
            "Credito",
            "Transferencia",
            "CODI",
            "MercadoPago",
            "Todos"});
            this.cboPago.Location = new System.Drawing.Point(307, 67);
            this.cboPago.Name = "cboPago";
            this.cboPago.Size = new System.Drawing.Size(175, 21);
            this.cboPago.TabIndex = 77;
            this.cboPago.Text = "Seleccione forma de pago";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(29)))), ((int)(((byte)(88)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(554, 8);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 79);
            this.button1.TabIndex = 76;
            this.button1.Text = "FIltrar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(488, 70);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(69, 17);
            this.checkBox2.TabIndex = 75;
            this.checkBox2.Text = "Servicios";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(488, 40);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(59, 17);
            this.checkBox1.TabIndex = 74;
            this.checkBox1.Text = "Ventas";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(29)))), ((int)(((byte)(88)))));
            this.label6.Location = new System.Drawing.Point(154, 70);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(148, 19);
            this.label6.TabIndex = 72;
            this.label6.Text = "Forma de Pago:";
            // 
            // fechaFinal
            // 
            this.fechaFinal.Location = new System.Drawing.Point(282, 38);
            this.fechaFinal.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.fechaFinal.Name = "fechaFinal";
            this.fechaFinal.Size = new System.Drawing.Size(200, 20);
            this.fechaFinal.TabIndex = 65;
            // 
            // btnToday
            // 
            this.btnToday.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnToday.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnToday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(29)))), ((int)(((byte)(88)))));
            this.btnToday.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToday.ForeColor = System.Drawing.Color.White;
            this.btnToday.Location = new System.Drawing.Point(641, 8);
            this.btnToday.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnToday.Name = "btnToday";
            this.btnToday.Size = new System.Drawing.Size(108, 35);
            this.btnToday.TabIndex = 69;
            this.btnToday.Text = "Hoy";
            this.btnToday.UseVisualStyleBackColor = false;
            this.btnToday.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(29)))), ((int)(((byte)(88)))));
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(641, 53);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 35);
            this.button2.TabIndex = 68;
            this.button2.Text = "Ver Todo";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblEncontrados
            // 
            this.lblEncontrados.AutoSize = true;
            this.lblEncontrados.Location = new System.Drawing.Point(7, 75);
            this.lblEncontrados.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEncontrados.Name = "lblEncontrados";
            this.lblEncontrados.Size = new System.Drawing.Size(85, 13);
            this.lblEncontrados.TabIndex = 70;
            this.lblEncontrados.Text = "No hay artículos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(29)))), ((int)(((byte)(88)))));
            this.label1.Location = new System.Drawing.Point(4, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 19);
            this.label1.TabIndex = 57;
            this.label1.Text = "Tickets de Venta";
            // 
            // fechaInicial
            // 
            this.fechaInicial.Location = new System.Drawing.Point(48, 37);
            this.fechaInicial.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.fechaInicial.Name = "fechaInicial";
            this.fechaInicial.Size = new System.Drawing.Size(200, 20);
            this.fechaInicial.TabIndex = 64;
            this.fechaInicial.ValueChanged += new System.EventHandler(this.fechaInicial_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(29)))), ((int)(((byte)(88)))));
            this.label2.Location = new System.Drawing.Point(6, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 19);
            this.label2.TabIndex = 66;
            this.label2.Text = "del";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(29)))), ((int)(((byte)(88)))));
            this.label3.Location = new System.Drawing.Point(253, 39);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 19);
            this.label3.TabIndex = 67;
            this.label3.Text = "al";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.flowLayoutPanel1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(864, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(297, 523);
            this.panel4.TabIndex = 62;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Black;
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.txtProductos);
            this.flowLayoutPanel1.Controls.Add(this.panel6);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(297, 523);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Montserrat", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(2, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(228, 25);
            this.label4.TabIndex = 57;
            this.label4.Text = "Reporte de Ventas";
            // 
            // txtProductos
            // 
            this.txtProductos.AcceptsReturn = true;
            this.txtProductos.AcceptsTab = true;
            this.txtProductos.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtProductos.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductos.Location = new System.Drawing.Point(3, 28);
            this.txtProductos.Multiline = true;
            this.txtProductos.Name = "txtProductos";
            this.txtProductos.ReadOnly = true;
            this.txtProductos.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtProductos.Size = new System.Drawing.Size(290, 252);
            this.txtProductos.TabIndex = 0;
            this.txtProductos.Text = "SELECCIONE UN ELEMENTO";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Controls.Add(this.lblTotal);
            this.panel6.Controls.Add(this.lblIVA);
            this.panel6.Controls.Add(this.lblDesc);
            this.panel6.Controls.Add(this.lblSub);
            this.panel6.Controls.Add(this.label9);
            this.panel6.Controls.Add(this.label8);
            this.panel6.Controls.Add(this.label7);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Location = new System.Drawing.Point(3, 286);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(289, 220);
            this.panel6.TabIndex = 71;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Montserrat", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(29)))), ((int)(((byte)(88)))));
            this.lblTotal.Location = new System.Drawing.Point(135, 132);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(93, 25);
            this.lblTotal.TabIndex = 65;
            this.lblTotal.Text = "$00.00";
            // 
            // lblIVA
            // 
            this.lblIVA.AutoSize = true;
            this.lblIVA.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIVA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(29)))), ((int)(((byte)(88)))));
            this.lblIVA.Location = new System.Drawing.Point(136, 97);
            this.lblIVA.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIVA.Name = "lblIVA";
            this.lblIVA.Size = new System.Drawing.Size(73, 19);
            this.lblIVA.TabIndex = 64;
            this.lblIVA.Text = "$00.00";
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(29)))), ((int)(((byte)(88)))));
            this.lblDesc.Location = new System.Drawing.Point(136, 61);
            this.lblDesc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(73, 19);
            this.lblDesc.TabIndex = 63;
            this.lblDesc.Text = "$00.00";
            // 
            // lblSub
            // 
            this.lblSub.AutoSize = true;
            this.lblSub.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(29)))), ((int)(((byte)(88)))));
            this.lblSub.Location = new System.Drawing.Point(136, 25);
            this.lblSub.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSub.Name = "lblSub";
            this.lblSub.Size = new System.Drawing.Size(73, 19);
            this.lblSub.TabIndex = 62;
            this.lblSub.Text = "$00.00";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Montserrat", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(29)))), ((int)(((byte)(88)))));
            this.label9.Location = new System.Drawing.Point(37, 132);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 25);
            this.label9.TabIndex = 61;
            this.label9.Text = "TOTAL:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(29)))), ((int)(((byte)(88)))));
            this.label8.Location = new System.Drawing.Point(84, 97);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 19);
            this.label8.TabIndex = 60;
            this.label8.Text = "IVA:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(29)))), ((int)(((byte)(88)))));
            this.label7.Location = new System.Drawing.Point(18, 61);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 19);
            this.label7.TabIndex = 59;
            this.label7.Text = "Descuento:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(29)))), ((int)(((byte)(88)))));
            this.label5.Location = new System.Drawing.Point(38, 25);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 19);
            this.label5.TabIndex = 58;
            this.label5.Text = "Subtotal:";
            // 
            // tabProductos
            // 
            this.tabProductos.Location = new System.Drawing.Point(4, 22);
            this.tabProductos.Name = "tabProductos";
            this.tabProductos.Padding = new System.Windows.Forms.Padding(3);
            this.tabProductos.Size = new System.Drawing.Size(1166, 531);
            this.tabProductos.TabIndex = 1;
            this.tabProductos.Text = "Productos Vendidos";
            this.tabProductos.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lblTitulo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1174, 72);
            this.panel2.TabIndex = 61;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Montserrat", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(29)))), ((int)(((byte)(88)))));
            this.lblTitulo.Location = new System.Drawing.Point(11, 27);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(228, 25);
            this.lblTitulo.TabIndex = 56;
            this.lblTitulo.Text = "Reporte de Ventas";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(29)))), ((int)(((byte)(88)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 629);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1174, 21);
            this.panel3.TabIndex = 60;
            // 
            // Frm_ReporteVtas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 650);
            this.Controls.Add(this.panel1);
            this.Name = "Frm_ReporteVtas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reportes de Ventas";
            this.Load += new System.EventHandler(this.Frm_ReporteVtas_Load);
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabTickets.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDatos)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TabPage tabProductos;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabTickets;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView gridDatos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker fechaFinal;
        private System.Windows.Forms.DateTimePicker fechaInicial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnToday;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtProductos;
        private System.Windows.Forms.Label lblEncontrados;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblIVA;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblSub;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn subtotl;
        private System.Windows.Forms.DataGridViewTextBoxColumn desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn IVA;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn edo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Forma;
        private System.Windows.Forms.ComboBox cboPago;
    }
}