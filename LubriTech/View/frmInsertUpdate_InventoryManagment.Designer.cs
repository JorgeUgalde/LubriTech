namespace LubriTech.View
{
    partial class frmInsertUpdate_InventoryManagment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbBranch = new System.Windows.Forms.ComboBox();
            this.cbDocumentType = new System.Windows.Forms.ComboBox();
            this.tbTotalAmount = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblDocumentType = new System.Windows.Forms.Label();
            this.lblBranch = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lblSupplierId = new System.Windows.Forms.Label();
            this.tbSupplierName = new System.Windows.Forms.TextBox();
            this.tbSupplierId = new System.Windows.Forms.TextBox();
            this.cbState = new System.Windows.Forms.ComboBox();
            this.lblState = new System.Windows.Forms.Label();
            this.dgvDetailLines = new System.Windows.Forms.DataGridView();
            this.btnSelectSupplier = new System.Windows.Forms.Button();
            this.lblSupplierName = new System.Windows.Forms.Label();
            this.btnAddDetailLine = new System.Windows.Forms.Button();
            this.lblItemName = new System.Windows.Forms.Label();
            this.tbItemName = new System.Windows.Forms.TextBox();
            this.btnSelectItem = new System.Windows.Forms.Button();
            this.tbItemCode = new System.Windows.Forms.TextBox();
            this.lblItem = new System.Windows.Forms.Label();
            this.tbQuantity = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.tbAmount = new System.Windows.Forms.TextBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblDetailLine = new System.Windows.Forms.Label();
            this.lblInventoryManagment = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailLines)).BeginInit();
            this.SuspendLayout();
            // 
            // cbBranch
            // 
            this.cbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBranch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBranch.FormattingEnabled = true;
            this.cbBranch.Location = new System.Drawing.Point(110, 113);
            this.cbBranch.Name = "cbBranch";
            this.cbBranch.Size = new System.Drawing.Size(296, 29);
            this.cbBranch.TabIndex = 41;
            this.cbBranch.Tag = "";
            // 
            // cbDocumentType
            // 
            this.cbDocumentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDocumentType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDocumentType.FormattingEnabled = true;
            this.cbDocumentType.Items.AddRange(new object[] {
            "Compra",
            "Entrada",
            "Salida"});
            this.cbDocumentType.Location = new System.Drawing.Point(110, 150);
            this.cbDocumentType.Name = "cbDocumentType";
            this.cbDocumentType.Size = new System.Drawing.Size(130, 29);
            this.cbDocumentType.TabIndex = 39;
            this.cbDocumentType.Tag = "";
            // 
            // tbTotalAmount
            // 
            this.tbTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTotalAmount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTotalAmount.Location = new System.Drawing.Point(682, 609);
            this.tbTotalAmount.MaxLength = 9;
            this.tbTotalAmount.Name = "tbTotalAmount";
            this.tbTotalAmount.Size = new System.Drawing.Size(206, 29);
            this.tbTotalAmount.TabIndex = 30;
            this.tbTotalAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNumeric_KeyPress);
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(54, 81);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(50, 21);
            this.lblDate.TabIndex = 40;
            this.lblDate.Text = "Fecha";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(584, 612);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(92, 21);
            this.lblTotalAmount.TabIndex = 38;
            this.lblTotalAmount.Text = "Monto Total";
            // 
            // lblDocumentType
            // 
            this.lblDocumentType.AutoSize = true;
            this.lblDocumentType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocumentType.Location = new System.Drawing.Point(64, 153);
            this.lblDocumentType.Name = "lblDocumentType";
            this.lblDocumentType.Size = new System.Drawing.Size(40, 21);
            this.lblDocumentType.TabIndex = 32;
            this.lblDocumentType.Text = "Tipo";
            // 
            // lblBranch
            // 
            this.lblBranch.AutoSize = true;
            this.lblBranch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBranch.Location = new System.Drawing.Point(35, 116);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(69, 21);
            this.lblBranch.TabIndex = 31;
            this.lblBranch.Text = "Sucursal";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(55)))), ((int)(((byte)(111)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnClose.Location = new System.Drawing.Point(747, 646);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(141, 34);
            this.btnClose.TabIndex = 46;
            this.btnClose.Text = "Cancelar";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(55)))), ((int)(((byte)(111)))));
            this.btnConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnConfirm.Location = new System.Drawing.Point(52, 646);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(141, 34);
            this.btnConfirm.TabIndex = 45;
            this.btnConfirm.Text = "Aceptar";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // lblSupplierId
            // 
            this.lblSupplierId.AutoSize = true;
            this.lblSupplierId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplierId.Location = new System.Drawing.Point(426, 80);
            this.lblSupplierId.Name = "lblSupplierId";
            this.lblSupplierId.Size = new System.Drawing.Size(178, 21);
            this.lblSupplierId.TabIndex = 29;
            this.lblSupplierId.Text = "Identificación Proveedor";
            // 
            // tbSupplierName
            // 
            this.tbSupplierName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSupplierName.Location = new System.Drawing.Point(610, 112);
            this.tbSupplierName.MaxLength = 150;
            this.tbSupplierName.Name = "tbSupplierName";
            this.tbSupplierName.Size = new System.Drawing.Size(240, 29);
            this.tbSupplierName.TabIndex = 35;
            // 
            // tbSupplierId
            // 
            this.tbSupplierId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSupplierId.Location = new System.Drawing.Point(610, 77);
            this.tbSupplierId.MaxLength = 150;
            this.tbSupplierId.Name = "tbSupplierId";
            this.tbSupplierId.Size = new System.Drawing.Size(240, 29);
            this.tbSupplierId.TabIndex = 47;
            this.tbSupplierId.TextChanged += new System.EventHandler(this.tbSupplierId_TextChanged);
            // 
            // cbState
            // 
            this.cbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbState.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbState.FormattingEnabled = true;
            this.cbState.Items.AddRange(new object[] {
            "Activo",
            "Inactivo",
            "Finalizado"});
            this.cbState.Location = new System.Drawing.Point(610, 150);
            this.cbState.Name = "cbState";
            this.cbState.Size = new System.Drawing.Size(130, 29);
            this.cbState.TabIndex = 49;
            this.cbState.Tag = "";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblState.Location = new System.Drawing.Point(548, 150);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(56, 21);
            this.lblState.TabIndex = 48;
            this.lblState.Text = "Estado";
            // 
            // dgvDetailLines
            // 
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle25.BackColor = System.Drawing.Color.White;
            this.dgvDetailLines.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle25;
            this.dgvDetailLines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetailLines.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetailLines.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDetailLines.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetailLines.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetailLines.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dgvDetailLines.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(38)))), ((int)(((byte)(77)))));
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            dataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(38)))), ((int)(((byte)(77)))));
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetailLines.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle26;
            this.dgvDetailLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetailLines.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            dataGridViewCellStyle27.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(238)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetailLines.DefaultCellStyle = dataGridViewCellStyle27;
            this.dgvDetailLines.GridColor = System.Drawing.Color.White;
            this.dgvDetailLines.Location = new System.Drawing.Point(39, 306);
            this.dgvDetailLines.Name = "dgvDetailLines";
            this.dgvDetailLines.ReadOnly = true;
            this.dgvDetailLines.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(38)))), ((int)(((byte)(77)))));
            dataGridViewCellStyle28.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            dataGridViewCellStyle28.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle28.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(38)))), ((int)(((byte)(77)))));
            dataGridViewCellStyle28.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetailLines.RowHeadersDefaultCellStyle = dataGridViewCellStyle28;
            this.dgvDetailLines.RowHeadersVisible = false;
            this.dgvDetailLines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetailLines.Size = new System.Drawing.Size(849, 297);
            this.dgvDetailLines.TabIndex = 56;
            this.dgvDetailLines.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDetailLines_CellMouseDoubleClick);
            // 
            // btnSelectSupplier
            // 
            this.btnSelectSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectSupplier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(55)))), ((int)(((byte)(111)))));
            this.btnSelectSupplier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelectSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelectSupplier.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnSelectSupplier.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSelectSupplier.Image = global::LubriTech.Properties.Resources.searchClient;
            this.btnSelectSupplier.Location = new System.Drawing.Point(856, 77);
            this.btnSelectSupplier.Name = "btnSelectSupplier";
            this.btnSelectSupplier.Size = new System.Drawing.Size(32, 29);
            this.btnSelectSupplier.TabIndex = 37;
            this.btnSelectSupplier.UseVisualStyleBackColor = false;
            this.btnSelectSupplier.Click += new System.EventHandler(this.btnSelectSupplier_Click);
            // 
            // lblSupplierName
            // 
            this.lblSupplierName.AutoSize = true;
            this.lblSupplierName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplierName.Location = new System.Drawing.Point(460, 115);
            this.lblSupplierName.Name = "lblSupplierName";
            this.lblSupplierName.Size = new System.Drawing.Size(144, 21);
            this.lblSupplierName.TabIndex = 65;
            this.lblSupplierName.Text = "Nombre Proveedor";
            // 
            // btnAddDetailLine
            // 
            this.btnAddDetailLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddDetailLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(55)))), ((int)(((byte)(111)))));
            this.btnAddDetailLine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddDetailLine.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddDetailLine.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddDetailLine.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddDetailLine.Location = new System.Drawing.Point(747, 269);
            this.btnAddDetailLine.Name = "btnAddDetailLine";
            this.btnAddDetailLine.Size = new System.Drawing.Size(141, 30);
            this.btnAddDetailLine.TabIndex = 66;
            this.btnAddDetailLine.Text = "Agregar detalle";
            this.btnAddDetailLine.UseVisualStyleBackColor = false;
            this.btnAddDetailLine.Click += new System.EventHandler(this.btnAddDetailLine_Click);
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemName.Location = new System.Drawing.Point(35, 274);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(126, 21);
            this.lblItemName.TabIndex = 71;
            this.lblItemName.Text = "Nombre Artículo";
            // 
            // tbItemName
            // 
            this.tbItemName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbItemName.Location = new System.Drawing.Point(167, 271);
            this.tbItemName.MaxLength = 150;
            this.tbItemName.Name = "tbItemName";
            this.tbItemName.Size = new System.Drawing.Size(205, 29);
            this.tbItemName.TabIndex = 70;
            this.tbItemName.TextChanged += new System.EventHandler(this.tbItemName_TextChanged);
            // 
            // btnSelectItem
            // 
            this.btnSelectItem.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSelectItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(55)))), ((int)(((byte)(111)))));
            this.btnSelectItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelectItem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelectItem.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnSelectItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSelectItem.Image = global::LubriTech.Properties.Resources.searchClient;
            this.btnSelectItem.Location = new System.Drawing.Point(378, 236);
            this.btnSelectItem.Name = "btnSelectItem";
            this.btnSelectItem.Size = new System.Drawing.Size(32, 29);
            this.btnSelectItem.TabIndex = 69;
            this.btnSelectItem.UseVisualStyleBackColor = false;
            this.btnSelectItem.Click += new System.EventHandler(this.btnSelectItem_Click);
            // 
            // tbItemCode
            // 
            this.tbItemCode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbItemCode.Location = new System.Drawing.Point(167, 236);
            this.tbItemCode.MaxLength = 150;
            this.tbItemCode.Name = "tbItemCode";
            this.tbItemCode.Size = new System.Drawing.Size(205, 29);
            this.tbItemCode.TabIndex = 68;
            this.tbItemCode.TextChanged += new System.EventHandler(this.tbItemCode_TextChanged);
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem.Location = new System.Drawing.Point(43, 239);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(118, 21);
            this.lblItem.TabIndex = 67;
            this.lblItem.Text = "Código Artículo";
            // 
            // tbQuantity
            // 
            this.tbQuantity.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbQuantity.Location = new System.Drawing.Point(535, 235);
            this.tbQuantity.MaxLength = 9;
            this.tbQuantity.Name = "tbQuantity";
            this.tbQuantity.Size = new System.Drawing.Size(205, 29);
            this.tbQuantity.TabIndex = 74;
            this.tbQuantity.TextChanged += new System.EventHandler(this.tbQuantity_TextChanged);
            this.tbQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNumeric_KeyPress);
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.Location = new System.Drawing.Point(458, 238);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(72, 21);
            this.lblQuantity.TabIndex = 75;
            this.lblQuantity.Text = "Cantidad";
            // 
            // tbAmount
            // 
            this.tbAmount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAmount.Location = new System.Drawing.Point(535, 270);
            this.tbAmount.MaxLength = 9;
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.Size = new System.Drawing.Size(205, 29);
            this.tbAmount.TabIndex = 72;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(474, 273);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(56, 21);
            this.lblAmount.TabIndex = 73;
            this.lblAmount.Text = "Monto";
            // 
            // lblDetailLine
            // 
            this.lblDetailLine.AutoSize = true;
            this.lblDetailLine.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetailLine.Location = new System.Drawing.Point(35, 201);
            this.lblDetailLine.Name = "lblDetailLine";
            this.lblDetailLine.Size = new System.Drawing.Size(110, 21);
            this.lblDetailLine.TabIndex = 76;
            this.lblDetailLine.Text = "Línea Detalle";
            // 
            // lblInventoryManagment
            // 
            this.lblInventoryManagment.AutoSize = true;
            this.lblInventoryManagment.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInventoryManagment.Location = new System.Drawing.Point(35, 42);
            this.lblInventoryManagment.Name = "lblInventoryManagment";
            this.lblInventoryManagment.Size = new System.Drawing.Size(151, 21);
            this.lblInventoryManagment.TabIndex = 77;
            this.lblInventoryManagment.Text = "Gestión Inventario";
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpDate.Location = new System.Drawing.Point(110, 76);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(296, 29);
            this.dtpDate.TabIndex = 78;
            // 
            // frmInsertUpdate_InventoryManagment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(929, 699);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblInventoryManagment);
            this.Controls.Add(this.lblDetailLine);
            this.Controls.Add(this.tbQuantity);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.tbAmount);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblItemName);
            this.Controls.Add(this.tbItemName);
            this.Controls.Add(this.btnSelectItem);
            this.Controls.Add(this.tbItemCode);
            this.Controls.Add(this.lblItem);
            this.Controls.Add(this.btnAddDetailLine);
            this.Controls.Add(this.lblSupplierName);
            this.Controls.Add(this.dgvDetailLines);
            this.Controls.Add(this.cbState);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.tbSupplierId);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnSelectSupplier);
            this.Controls.Add(this.cbBranch);
            this.Controls.Add(this.cbDocumentType);
            this.Controls.Add(this.tbTotalAmount);
            this.Controls.Add(this.tbSupplierName);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.lblDocumentType);
            this.Controls.Add(this.lblBranch);
            this.Controls.Add(this.lblSupplierId);
            this.Name = "frmInsertUpdate_InventoryManagment";
            this.Text = "Gestión Inventario";
            this.Load += new System.EventHandler(this.frmInsertUpdateInventoryManagment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailLines)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbBranch;
        private System.Windows.Forms.ComboBox cbDocumentType;
        private System.Windows.Forms.TextBox tbTotalAmount;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblDocumentType;
        private System.Windows.Forms.Label lblBranch;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label lblSupplierId;
        private System.Windows.Forms.TextBox tbSupplierName;
        private System.Windows.Forms.Button btnSelectSupplier;
        private System.Windows.Forms.TextBox tbSupplierId;
        private System.Windows.Forms.ComboBox cbState;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.DataGridView dgvDetailLines;
        private System.Windows.Forms.Label lblSupplierName;
        private System.Windows.Forms.Button btnAddDetailLine;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.TextBox tbItemName;
        private System.Windows.Forms.Button btnSelectItem;
        private System.Windows.Forms.TextBox tbItemCode;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.TextBox tbQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox tbAmount;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblDetailLine;
        private System.Windows.Forms.Label lblInventoryManagment;
        private System.Windows.Forms.DateTimePicker dtpDate;
    }
}