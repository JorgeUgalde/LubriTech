namespace LubriTech.View
{
    partial class frmWorkOrder
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblVehicle = new System.Windows.Forms.Label();
            this.lblMake = new System.Windows.Forms.Label();
            this.lblModel = new System.Windows.Forms.Label();
            this.lblMileage = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblBranch = new System.Windows.Forms.Label();
            this.txtMake = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.txtMileage = new System.Windows.Forms.TextBox();
            this.txtClientId = new System.Windows.Forms.TextBox();
            this.lblClientId = new System.Windows.Forms.Label();
            this.lblClientName = new System.Windows.Forms.Label();
            this.txtClientName = new System.Windows.Forms.TextBox();
            this.lblMainPhone = new System.Windows.Forms.Label();
            this.lblAddPhone = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtCellphone = new System.Windows.Forms.TextBox();
            this.txtCellphone2 = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.cbState = new System.Windows.Forms.ComboBox();
            this.cbBranch = new System.Windows.Forms.ComboBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.btnSelectClient = new System.Windows.Forms.Button();
            this.btnAddVehicle = new System.Windows.Forms.Button();
            this.lblCurrentMileage = new System.Windows.Forms.Label();
            this.txtCurrentMileage = new System.Windows.Forms.TextBox();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblDetails = new System.Windows.Forms.Label();
            this.lblLicensePlate = new System.Windows.Forms.Label();
            this.txtLicensePlate = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnAddWorkOrderLine = new System.Windows.Forms.Button();
            this.btnSelectItem = new System.Windows.Forms.Button();
            this.dgvWorkOrderDetails = new System.Windows.Forms.DataGridView();
            this.lbLineAmount = new System.Windows.Forms.Label();
            this.lbQuantiy = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbItemCode = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.txtItemCode = new System.Windows.Forms.TextBox();
            this.txtLineAmount = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblClient = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvObservation = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkOrderDetails)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObservation)).BeginInit();
            this.SuspendLayout();
            // 
            // lblVehicle
            // 
            this.lblVehicle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVehicle.AutoSize = true;
            this.lblVehicle.Location = new System.Drawing.Point(351, 27);
            this.lblVehicle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVehicle.Name = "lblVehicle";
            this.lblVehicle.Size = new System.Drawing.Size(50, 13);
            this.lblVehicle.TabIndex = 2;
            this.lblVehicle.Text = "Vehículo";
            // 
            // lblMake
            // 
            this.lblMake.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMake.AutoSize = true;
            this.lblMake.Location = new System.Drawing.Point(351, 76);
            this.lblMake.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMake.Name = "lblMake";
            this.lblMake.Size = new System.Drawing.Size(37, 13);
            this.lblMake.TabIndex = 3;
            this.lblMake.Text = "Marca";
            // 
            // lblModel
            // 
            this.lblModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(351, 97);
            this.lblModel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(42, 13);
            this.lblModel.TabIndex = 4;
            this.lblModel.Text = "Modelo";
            // 
            // lblMileage
            // 
            this.lblMileage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMileage.AutoSize = true;
            this.lblMileage.Location = new System.Drawing.Point(351, 118);
            this.lblMileage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMileage.Name = "lblMileage";
            this.lblMileage.Size = new System.Drawing.Size(58, 13);
            this.lblMileage.TabIndex = 5;
            this.lblMileage.Text = "Kilometraje";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(16, 51);
            this.lblDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(37, 13);
            this.lblDate.TabIndex = 8;
            this.lblDate.Text = "Fecha";
            // 
            // lblBranch
            // 
            this.lblBranch.AutoSize = true;
            this.lblBranch.Location = new System.Drawing.Point(16, 30);
            this.lblBranch.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(48, 13);
            this.lblBranch.TabIndex = 9;
            this.lblBranch.Text = "Sucursal";
            // 
            // txtMake
            // 
            this.txtMake.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMake.Location = new System.Drawing.Point(444, 72);
            this.txtMake.Margin = new System.Windows.Forms.Padding(2);
            this.txtMake.Name = "txtMake";
            this.txtMake.Size = new System.Drawing.Size(168, 20);
            this.txtMake.TabIndex = 14;
            // 
            // txtModel
            // 
            this.txtModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtModel.Location = new System.Drawing.Point(444, 93);
            this.txtModel.Margin = new System.Windows.Forms.Padding(2);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(168, 20);
            this.txtModel.TabIndex = 15;
            // 
            // txtMileage
            // 
            this.txtMileage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMileage.Location = new System.Drawing.Point(444, 115);
            this.txtMileage.Margin = new System.Windows.Forms.Padding(2);
            this.txtMileage.Name = "txtMileage";
            this.txtMileage.Size = new System.Drawing.Size(168, 20);
            this.txtMileage.TabIndex = 16;
            // 
            // txtClientId
            // 
            this.txtClientId.Location = new System.Drawing.Point(141, 51);
            this.txtClientId.Margin = new System.Windows.Forms.Padding(2);
            this.txtClientId.Name = "txtClientId";
            this.txtClientId.Size = new System.Drawing.Size(205, 20);
            this.txtClientId.TabIndex = 23;
            // 
            // lblClientId
            // 
            this.lblClientId.AutoSize = true;
            this.lblClientId.Location = new System.Drawing.Point(41, 55);
            this.lblClientId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblClientId.Name = "lblClientId";
            this.lblClientId.Size = new System.Drawing.Size(70, 13);
            this.lblClientId.TabIndex = 24;
            this.lblClientId.Text = "Identificacion";
            // 
            // lblClientName
            // 
            this.lblClientName.AutoSize = true;
            this.lblClientName.Location = new System.Drawing.Point(41, 76);
            this.lblClientName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblClientName.Name = "lblClientName";
            this.lblClientName.Size = new System.Drawing.Size(44, 13);
            this.lblClientName.TabIndex = 26;
            this.lblClientName.Text = "Nombre";
            // 
            // txtClientName
            // 
            this.txtClientName.Location = new System.Drawing.Point(142, 76);
            this.txtClientName.Margin = new System.Windows.Forms.Padding(2);
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.Size = new System.Drawing.Size(205, 20);
            this.txtClientName.TabIndex = 25;
            // 
            // lblMainPhone
            // 
            this.lblMainPhone.AutoSize = true;
            this.lblMainPhone.Location = new System.Drawing.Point(41, 97);
            this.lblMainPhone.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMainPhone.Name = "lblMainPhone";
            this.lblMainPhone.Size = new System.Drawing.Size(89, 13);
            this.lblMainPhone.TabIndex = 27;
            this.lblMainPhone.Text = "Número Teléfono";
            // 
            // lblAddPhone
            // 
            this.lblAddPhone.AutoSize = true;
            this.lblAddPhone.Location = new System.Drawing.Point(41, 118);
            this.lblAddPhone.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAddPhone.Name = "lblAddPhone";
            this.lblAddPhone.Size = new System.Drawing.Size(89, 13);
            this.lblAddPhone.TabIndex = 28;
            this.lblAddPhone.Text = "Número adicional";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(41, 139);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(38, 13);
            this.lblEmail.TabIndex = 29;
            this.lblEmail.Text = "Correo";
            // 
            // txtCellphone
            // 
            this.txtCellphone.Location = new System.Drawing.Point(141, 115);
            this.txtCellphone.Margin = new System.Windows.Forms.Padding(2);
            this.txtCellphone.Name = "txtCellphone";
            this.txtCellphone.Size = new System.Drawing.Size(168, 20);
            this.txtCellphone.TabIndex = 30;
            // 
            // txtCellphone2
            // 
            this.txtCellphone2.Location = new System.Drawing.Point(141, 137);
            this.txtCellphone2.Margin = new System.Windows.Forms.Padding(2);
            this.txtCellphone2.Name = "txtCellphone2";
            this.txtCellphone2.Size = new System.Drawing.Size(168, 20);
            this.txtCellphone2.TabIndex = 31;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(141, 158);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(168, 20);
            this.txtEmail.TabIndex = 32;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(433, 30);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(0, 13);
            this.label7.TabIndex = 33;
            // 
            // lblState
            // 
            this.lblState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(476, 30);
            this.lblState.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(40, 13);
            this.lblState.TabIndex = 34;
            this.lblState.Text = "Estado";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new System.Drawing.Point(418, 429);
            this.lblTotalAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(60, 13);
            this.lblTotalAmount.TabIndex = 36;
            this.lblTotalAmount.Text = "Monto total";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalAmount.Location = new System.Drawing.Point(510, 426);
            this.txtTotalAmount.Margin = new System.Windows.Forms.Padding(2);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(168, 20);
            this.txtTotalAmount.TabIndex = 37;
            // 
            // cbState
            // 
            this.cbState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbState.FormattingEnabled = true;
            this.cbState.Location = new System.Drawing.Point(544, 27);
            this.cbState.Margin = new System.Windows.Forms.Padding(2);
            this.cbState.Name = "cbState";
            this.cbState.Size = new System.Drawing.Size(130, 21);
            this.cbState.TabIndex = 38;
            // 
            // cbBranch
            // 
            this.cbBranch.FormattingEnabled = true;
            this.cbBranch.Location = new System.Drawing.Point(90, 27);
            this.cbBranch.Margin = new System.Windows.Forms.Padding(2);
            this.cbBranch.Name = "cbBranch";
            this.cbBranch.Size = new System.Drawing.Size(240, 21);
            this.cbBranch.TabIndex = 39;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(90, 49);
            this.dateTimePicker.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(240, 20);
            this.dateTimePicker.TabIndex = 40;
            // 
            // btnSelectClient
            // 
            this.btnSelectClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(55)))), ((int)(((byte)(111)))));
            this.btnSelectClient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelectClient.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelectClient.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSelectClient.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSelectClient.Location = new System.Drawing.Point(141, 22);
            this.btnSelectClient.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelectClient.Name = "btnSelectClient";
            this.btnSelectClient.Size = new System.Drawing.Size(168, 23);
            this.btnSelectClient.TabIndex = 41;
            this.btnSelectClient.Text = "Seleccionar cliente";
            this.btnSelectClient.UseVisualStyleBackColor = false;
            this.btnSelectClient.Click += new System.EventHandler(this.btnSelectClient_Click);
            // 
            // btnAddVehicle
            // 
            this.btnAddVehicle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddVehicle.Location = new System.Drawing.Point(444, 22);
            this.btnAddVehicle.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddVehicle.Name = "btnAddVehicle";
            this.btnAddVehicle.Size = new System.Drawing.Size(168, 23);
            this.btnAddVehicle.TabIndex = 42;
            this.btnAddVehicle.Text = "Seleccionar vehículo";
            this.btnAddVehicle.UseVisualStyleBackColor = true;
            this.btnAddVehicle.Click += new System.EventHandler(this.btnAddVehicle_Click);
            // 
            // lblCurrentMileage
            // 
            this.lblCurrentMileage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentMileage.AutoSize = true;
            this.lblCurrentMileage.Location = new System.Drawing.Point(351, 139);
            this.lblCurrentMileage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCurrentMileage.Name = "lblCurrentMileage";
            this.lblCurrentMileage.Size = new System.Drawing.Size(91, 13);
            this.lblCurrentMileage.TabIndex = 43;
            this.lblCurrentMileage.Text = "Kilometraje Actual";
            // 
            // txtCurrentMileage
            // 
            this.txtCurrentMileage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCurrentMileage.Location = new System.Drawing.Point(444, 136);
            this.txtCurrentMileage.Margin = new System.Windows.Forms.Padding(2);
            this.txtCurrentMileage.Name = "txtCurrentMileage";
            this.txtCurrentMileage.Size = new System.Drawing.Size(168, 20);
            this.txtCurrentMileage.TabIndex = 44;
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveChanges.Location = new System.Drawing.Point(9, 608);
            this.btnSaveChanges.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(98, 23);
            this.btnSaveChanges.TabIndex = 45;
            this.btnSaveChanges.Text = "Aceptar";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Location = new System.Drawing.Point(610, 608);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(98, 23);
            this.btnClose.TabIndex = 46;
            this.btnClose.Text = "Cancelar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblDetails
            // 
            this.lblDetails.AutoSize = true;
            this.lblDetails.Location = new System.Drawing.Point(12, 206);
            this.lblDetails.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(45, 13);
            this.lblDetails.TabIndex = 47;
            this.lblDetails.Text = "Detalles";
            // 
            // lblLicensePlate
            // 
            this.lblLicensePlate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLicensePlate.AutoSize = true;
            this.lblLicensePlate.Location = new System.Drawing.Point(351, 55);
            this.lblLicensePlate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLicensePlate.Name = "lblLicensePlate";
            this.lblLicensePlate.Size = new System.Drawing.Size(34, 13);
            this.lblLicensePlate.TabIndex = 49;
            this.lblLicensePlate.Text = "Placa";
            // 
            // txtLicensePlate
            // 
            this.txtLicensePlate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLicensePlate.Location = new System.Drawing.Point(444, 51);
            this.txtLicensePlate.Margin = new System.Windows.Forms.Padding(2);
            this.txtLicensePlate.Name = "txtLicensePlate";
            this.txtLicensePlate.Size = new System.Drawing.Size(168, 20);
            this.txtLicensePlate.TabIndex = 50;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(9, 84);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(703, 511);
            this.tabControl1.TabIndex = 51;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.btnAddWorkOrderLine);
            this.tabPage1.Controls.Add(this.btnSelectItem);
            this.tabPage1.Controls.Add(this.dgvWorkOrderDetails);
            this.tabPage1.Controls.Add(this.lbLineAmount);
            this.tabPage1.Controls.Add(this.lbQuantiy);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.lbItemCode);
            this.tabPage1.Controls.Add(this.txtItemName);
            this.tabPage1.Controls.Add(this.txtItemCode);
            this.tabPage1.Controls.Add(this.txtLineAmount);
            this.tabPage1.Controls.Add(this.txtQuantity);
            this.tabPage1.Controls.Add(this.lblDetails);
            this.tabPage1.Controls.Add(this.txtLicensePlate);
            this.tabPage1.Controls.Add(this.txtCurrentMileage);
            this.tabPage1.Controls.Add(this.txtTotalAmount);
            this.tabPage1.Controls.Add(this.lblClient);
            this.tabPage1.Controls.Add(this.lblTotalAmount);
            this.tabPage1.Controls.Add(this.lblLicensePlate);
            this.tabPage1.Controls.Add(this.lblClientId);
            this.tabPage1.Controls.Add(this.btnAddVehicle);
            this.tabPage1.Controls.Add(this.lblCurrentMileage);
            this.tabPage1.Controls.Add(this.lblClientName);
            this.tabPage1.Controls.Add(this.lblMainPhone);
            this.tabPage1.Controls.Add(this.lblAddPhone);
            this.tabPage1.Controls.Add(this.lblEmail);
            this.tabPage1.Controls.Add(this.txtMileage);
            this.tabPage1.Controls.Add(this.btnSelectClient);
            this.tabPage1.Controls.Add(this.txtModel);
            this.tabPage1.Controls.Add(this.txtClientId);
            this.tabPage1.Controls.Add(this.txtMake);
            this.tabPage1.Controls.Add(this.txtClientName);
            this.tabPage1.Controls.Add(this.txtCellphone);
            this.tabPage1.Controls.Add(this.txtCellphone2);
            this.tabPage1.Controls.Add(this.txtEmail);
            this.tabPage1.Controls.Add(this.lblVehicle);
            this.tabPage1.Controls.Add(this.lblMake);
            this.tabPage1.Controls.Add(this.lblModel);
            this.tabPage1.Controls.Add(this.lblMileage);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(695, 485);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Contenido";
            // 
            // btnAddWorkOrderLine
            // 
            this.btnAddWorkOrderLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddWorkOrderLine.Location = new System.Drawing.Point(588, 244);
            this.btnAddWorkOrderLine.Name = "btnAddWorkOrderLine";
            this.btnAddWorkOrderLine.Size = new System.Drawing.Size(92, 23);
            this.btnAddWorkOrderLine.TabIndex = 60;
            this.btnAddWorkOrderLine.Text = "Agregar detalle";
            this.btnAddWorkOrderLine.UseVisualStyleBackColor = true;
            this.btnAddWorkOrderLine.Click += new System.EventHandler(this.btnAddWorkOrderLine_Click);
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
            this.btnSelectItem.Location = new System.Drawing.Point(285, 234);
            this.btnSelectItem.Name = "btnSelectItem";
            this.btnSelectItem.Size = new System.Drawing.Size(32, 29);
            this.btnSelectItem.TabIndex = 59;
            this.btnSelectItem.UseVisualStyleBackColor = false;
            this.btnSelectItem.Click += new System.EventHandler(this.btnSelectItem_Click);
            // 
            // dgvWorkOrderDetails
            // 
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(238)))), ((int)(((byte)(254)))));
            this.dgvWorkOrderDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle21;
            this.dgvWorkOrderDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvWorkOrderDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvWorkOrderDetails.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvWorkOrderDetails.BackgroundColor = System.Drawing.Color.White;
            this.dgvWorkOrderDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvWorkOrderDetails.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dgvWorkOrderDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(38)))), ((int)(((byte)(77)))));
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWorkOrderDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.dgvWorkOrderDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWorkOrderDetails.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvWorkOrderDetails.DefaultCellStyle = dataGridViewCellStyle23;
            this.dgvWorkOrderDetails.GridColor = System.Drawing.Color.White;
            this.dgvWorkOrderDetails.Location = new System.Drawing.Point(15, 279);
            this.dgvWorkOrderDetails.Name = "dgvWorkOrderDetails";
            this.dgvWorkOrderDetails.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWorkOrderDetails.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.dgvWorkOrderDetails.RowHeadersVisible = false;
            this.dgvWorkOrderDetails.RowHeadersWidth = 51;
            this.dgvWorkOrderDetails.Size = new System.Drawing.Size(665, 138);
            this.dgvWorkOrderDetails.TabIndex = 52;
            this.dgvWorkOrderDetails.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvWorkOrderDetails_CellMouseClick);
            // 
            // lbLineAmount
            // 
            this.lbLineAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLineAmount.AutoSize = true;
            this.lbLineAmount.Location = new System.Drawing.Point(322, 249);
            this.lbLineAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbLineAmount.Name = "lbLineAmount";
            this.lbLineAmount.Size = new System.Drawing.Size(37, 13);
            this.lbLineAmount.TabIndex = 58;
            this.lbLineAmount.Text = "Monto";
            // 
            // lbQuantiy
            // 
            this.lbQuantiy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbQuantiy.AutoSize = true;
            this.lbQuantiy.Location = new System.Drawing.Point(322, 229);
            this.lbQuantiy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbQuantiy.Name = "lbQuantiy";
            this.lbQuantiy.Size = new System.Drawing.Size(49, 13);
            this.lbQuantiy.TabIndex = 57;
            this.lbQuantiy.Text = "Cantidad";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 249);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 56;
            this.label1.Text = "Nombre Artículo";
            // 
            // lbItemCode
            // 
            this.lbItemCode.AutoSize = true;
            this.lbItemCode.Location = new System.Drawing.Point(12, 229);
            this.lbItemCode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbItemCode.Name = "lbItemCode";
            this.lbItemCode.Size = new System.Drawing.Size(80, 13);
            this.lbItemCode.TabIndex = 55;
            this.lbItemCode.Text = "Código Artículo";
            // 
            // txtItemName
            // 
            this.txtItemName.Enabled = false;
            this.txtItemName.Location = new System.Drawing.Point(112, 246);
            this.txtItemName.Margin = new System.Windows.Forms.Padding(2);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(168, 20);
            this.txtItemName.TabIndex = 54;
            // 
            // txtItemCode
            // 
            this.txtItemCode.Location = new System.Drawing.Point(112, 222);
            this.txtItemCode.Margin = new System.Windows.Forms.Padding(2);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(168, 20);
            this.txtItemCode.TabIndex = 53;
            this.txtItemCode.Leave += new System.EventHandler(this.txtItemCode_Leave);
            // 
            // txtLineAmount
            // 
            this.txtLineAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLineAmount.Location = new System.Drawing.Point(415, 246);
            this.txtLineAmount.Margin = new System.Windows.Forms.Padding(2);
            this.txtLineAmount.Name = "txtLineAmount";
            this.txtLineAmount.Size = new System.Drawing.Size(168, 20);
            this.txtLineAmount.TabIndex = 52;
            this.txtLineAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNumeric_KeyPress);
            // 
            // txtQuantity
            // 
            this.txtQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuantity.Location = new System.Drawing.Point(415, 222);
            this.txtQuantity.Margin = new System.Windows.Forms.Padding(2);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(168, 20);
            this.txtQuantity.TabIndex = 51;
            this.txtQuantity.TextChanged += new System.EventHandler(this.txtQuantity_TextChanged);
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNumeric_KeyPress);
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Location = new System.Drawing.Point(41, 27);
            this.lblClient.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(39, 13);
            this.lblClient.TabIndex = 1;
            this.lblClient.Text = "Cliente";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvObservation);
            this.tabPage2.Controls.Add(this.btnAdd);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(695, 485);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Observaciones";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvObservation
            // 
            this.dgvObservation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvObservation.Location = new System.Drawing.Point(-1, 26);
            this.dgvObservation.Name = "dgvObservation";
            this.dgvObservation.Size = new System.Drawing.Size(696, 414);
            this.dgvObservation.TabIndex = 1;
            this.dgvObservation.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvObservation_CellMouseDoubleClick_1);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(571, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(122, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Añadir Observacion";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(483, 566);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 52;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmWorkOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(723, 600);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.cbBranch);
            this.Controls.Add(this.cbState);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblBranch);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmWorkOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Órdenes de trabajo";
            this.Load += new System.EventHandler(this.frmWorkOrder_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkOrderDetails)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvObservation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblVehicle;
        private System.Windows.Forms.Label lblMake;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.Label lblMileage;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblBranch;
        private System.Windows.Forms.TextBox txtMake;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.TextBox txtMileage;
        private System.Windows.Forms.TextBox txtClientId;
        private System.Windows.Forms.Label lblClientId;
        private System.Windows.Forms.Label lblClientName;
        private System.Windows.Forms.TextBox txtClientName;
        private System.Windows.Forms.Label lblMainPhone;
        private System.Windows.Forms.Label lblAddPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtCellphone;
        private System.Windows.Forms.TextBox txtCellphone2;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.ComboBox cbState;
        private System.Windows.Forms.ComboBox cbBranch;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button btnSelectClient;
        private System.Windows.Forms.Button btnAddVehicle;
        private System.Windows.Forms.Label lblCurrentMileage;
        private System.Windows.Forms.TextBox txtCurrentMileage;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.Label lblLicensePlate;
        private System.Windows.Forms.TextBox txtLicensePlate;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.TextBox txtItemCode;
        private System.Windows.Forms.TextBox txtLineAmount;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label lbLineAmount;
        private System.Windows.Forms.Label lbQuantiy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbItemCode;
        private System.Windows.Forms.DataGridView dgvWorkOrderDetails;
        private System.Windows.Forms.Button btnSelectItem;
        private System.Windows.Forms.Button btnAddWorkOrderLine;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvObservation;
        private System.Windows.Forms.Button button1;
    }
}