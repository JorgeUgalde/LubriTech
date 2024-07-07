﻿namespace LubriTech.View
{
    partial class frmUpsert_Client
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblID = new System.Windows.Forms.Label();
            this.lblNumPrincipal = new System.Windows.Forms.Label();
            this.lblAddresse = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblAdditionalNum = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtMainPhone = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtAdditionalPhone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblVehicleList = new System.Windows.Forms.Label();
            this.btnAddVehicle = new System.Windows.Forms.Button();
            this.btnAddClient = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.cbState = new System.Windows.Forms.ComboBox();
            this.lblState = new System.Windows.Forms.Label();
            this.dgvVehicles = new System.Windows.Forms.DataGridView();
            this.txtAddresse = new System.Windows.Forms.RichTextBox();
            this.panel = new System.Windows.Forms.Panel();
            this.lblForm = new System.Windows.Forms.Label();
            this.pbMaximize = new System.Windows.Forms.PictureBox();
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.panelCB = new System.Windows.Forms.Panel();
            this.cbPriceList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicles)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMaximize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            this.panelCB.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblID
            // 
            this.lblID.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(24, 56);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(102, 21);
            this.lblID.TabIndex = 25;
            this.lblID.Text = "Identificación";
            // 
            // lblNumPrincipal
            // 
            this.lblNumPrincipal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblNumPrincipal.AutoSize = true;
            this.lblNumPrincipal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumPrincipal.Location = new System.Drawing.Point(462, 56);
            this.lblNumPrincipal.Name = "lblNumPrincipal";
            this.lblNumPrincipal.Size = new System.Drawing.Size(132, 21);
            this.lblNumPrincipal.TabIndex = 30;
            this.lblNumPrincipal.Text = "Teléfono Principal";
            // 
            // lblAddresse
            // 
            this.lblAddresse.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblAddresse.AutoSize = true;
            this.lblAddresse.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddresse.Location = new System.Drawing.Point(462, 137);
            this.lblAddresse.Name = "lblAddresse";
            this.lblAddresse.Size = new System.Drawing.Size(75, 21);
            this.lblAddresse.TabIndex = 32;
            this.lblAddresse.Text = "Dirección";
            // 
            // lblFullName
            // 
            this.lblFullName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullName.Location = new System.Drawing.Point(24, 96);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(140, 21);
            this.lblFullName.TabIndex = 26;
            this.lblFullName.Text = "Nombre Completo";
            // 
            // lblAdditionalNum
            // 
            this.lblAdditionalNum.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblAdditionalNum.AutoSize = true;
            this.lblAdditionalNum.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdditionalNum.Location = new System.Drawing.Point(462, 97);
            this.lblAdditionalNum.Name = "lblAdditionalNum";
            this.lblAdditionalNum.Size = new System.Drawing.Size(136, 21);
            this.lblAdditionalNum.TabIndex = 31;
            this.lblAdditionalNum.Text = "Teléfono Adicional";
            // 
            // lblEmail
            // 
            this.lblEmail.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(24, 136);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(138, 21);
            this.lblEmail.TabIndex = 27;
            this.lblEmail.Text = "Correo Electrónico";
            // 
            // txtID
            // 
            this.txtID.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(170, 53);
            this.txtID.MaxLength = 30;
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(205, 29);
            this.txtID.TabIndex = 1;
            // 
            // txtMainPhone
            // 
            this.txtMainPhone.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtMainPhone.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMainPhone.Location = new System.Drawing.Point(604, 53);
            this.txtMainPhone.MaxLength = 11;
            this.txtMainPhone.Name = "txtMainPhone";
            this.txtMainPhone.Size = new System.Drawing.Size(207, 29);
            this.txtMainPhone.TabIndex = 6;
            this.txtMainPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMainPhone_KeyPress);
            // 
            // txtFullName
            // 
            this.txtFullName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtFullName.BackColor = System.Drawing.SystemColors.Window;
            this.txtFullName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFullName.Location = new System.Drawing.Point(170, 94);
            this.txtFullName.MaxLength = 150;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(261, 29);
            this.txtFullName.TabIndex = 2;
            // 
            // txtAdditionalPhone
            // 
            this.txtAdditionalPhone.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtAdditionalPhone.BackColor = System.Drawing.SystemColors.Window;
            this.txtAdditionalPhone.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdditionalPhone.Location = new System.Drawing.Point(604, 94);
            this.txtAdditionalPhone.MaxLength = 11;
            this.txtAdditionalPhone.Name = "txtAdditionalPhone";
            this.txtAdditionalPhone.Size = new System.Drawing.Size(207, 29);
            this.txtAdditionalPhone.TabIndex = 7;
            this.txtAdditionalPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAdditionalPhone_KeyPress);
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtEmail.BackColor = System.Drawing.SystemColors.Window;
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(170, 134);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(261, 29);
            this.txtEmail.TabIndex = 3;
            // 
            // lblVehicleList
            // 
            this.lblVehicleList.AutoSize = true;
            this.lblVehicleList.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVehicleList.Location = new System.Drawing.Point(24, 291);
            this.lblVehicleList.Name = "lblVehicleList";
            this.lblVehicleList.Size = new System.Drawing.Size(129, 20);
            this.lblVehicleList.TabIndex = 33;
            this.lblVehicleList.Text = "Lista de Vehículos";
            // 
            // btnAddVehicle
            // 
            this.btnAddVehicle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddVehicle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(55)))), ((int)(((byte)(111)))));
            this.btnAddVehicle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddVehicle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddVehicle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddVehicle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddVehicle.Location = new System.Drawing.Point(170, 283);
            this.btnAddVehicle.Name = "btnAddVehicle";
            this.btnAddVehicle.Size = new System.Drawing.Size(144, 34);
            this.btnAddVehicle.TabIndex = 9;
            this.btnAddVehicle.Text = "Agregar Vehículo";
            this.btnAddVehicle.UseVisualStyleBackColor = false;
            this.btnAddVehicle.Click += new System.EventHandler(this.btnAddVehicle_Click);
            // 
            // btnAddClient
            // 
            this.btnAddClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(55)))), ((int)(((byte)(111)))));
            this.btnAddClient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddClient.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddClient.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddClient.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddClient.Location = new System.Drawing.Point(28, 611);
            this.btnAddClient.Name = "btnAddClient";
            this.btnAddClient.Size = new System.Drawing.Size(141, 34);
            this.btnAddClient.TabIndex = 11;
            this.btnAddClient.Text = "Confirmar";
            this.btnAddClient.UseVisualStyleBackColor = false;
            this.btnAddClient.Click += new System.EventHandler(this.btnAddClient_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(55)))), ((int)(((byte)(111)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnClose.Location = new System.Drawing.Point(670, 611);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(141, 34);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Cancelar";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cbState
            // 
            this.cbState.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbState.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbState.FormattingEnabled = true;
            this.cbState.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cbState.Location = new System.Drawing.Point(170, 176);
            this.cbState.Name = "cbState";
            this.cbState.Size = new System.Drawing.Size(205, 29);
            this.cbState.TabIndex = 4;
            // 
            // lblState
            // 
            this.lblState.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblState.AutoSize = true;
            this.lblState.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblState.Location = new System.Drawing.Point(24, 179);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(56, 21);
            this.lblState.TabIndex = 28;
            this.lblState.Text = "Estado";
            // 
            // dgvVehicles
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.dgvVehicles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvVehicles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVehicles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVehicles.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvVehicles.BackgroundColor = System.Drawing.Color.White;
            this.dgvVehicles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvVehicles.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dgvVehicles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(38)))), ((int)(((byte)(77)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVehicles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvVehicles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVehicles.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(238)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVehicles.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvVehicles.GridColor = System.Drawing.Color.White;
            this.dgvVehicles.Location = new System.Drawing.Point(28, 323);
            this.dgvVehicles.Name = "dgvVehicles";
            this.dgvVehicles.ReadOnly = true;
            this.dgvVehicles.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(38)))), ((int)(((byte)(77)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVehicles.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvVehicles.RowHeadersVisible = false;
            this.dgvVehicles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVehicles.Size = new System.Drawing.Size(783, 265);
            this.dgvVehicles.TabIndex = 10;
            this.dgvVehicles.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvVehicles_CellMouseDoubleClick);
            // 
            // txtAddresse
            // 
            this.txtAddresse.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtAddresse.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddresse.Location = new System.Drawing.Point(604, 134);
            this.txtAddresse.MaxLength = 150;
            this.txtAddresse.Name = "txtAddresse";
            this.txtAddresse.Size = new System.Drawing.Size(207, 93);
            this.txtAddresse.TabIndex = 8;
            this.txtAddresse.Text = "";
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(38)))), ((int)(((byte)(77)))));
            this.panel.Controls.Add(this.lblForm);
            this.panel.Controls.Add(this.pbMaximize);
            this.panel.Controls.Add(this.pbClose);
            this.panel.Location = new System.Drawing.Point(-2, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(843, 36);
            this.panel.TabIndex = 25;
            this.panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            // 
            // lblForm
            // 
            this.lblForm.AutoSize = true;
            this.lblForm.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForm.ForeColor = System.Drawing.Color.White;
            this.lblForm.Location = new System.Drawing.Point(9, 9);
            this.lblForm.Name = "lblForm";
            this.lblForm.Size = new System.Drawing.Size(165, 21);
            this.lblForm.TabIndex = 27;
            this.lblForm.Text = "Dato Maestro Cliente";
            // 
            // pbMaximize
            // 
            this.pbMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbMaximize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbMaximize.Image = global::LubriTech.Properties.Resources.maximize;
            this.pbMaximize.Location = new System.Drawing.Point(774, 6);
            this.pbMaximize.Name = "pbMaximize";
            this.pbMaximize.Size = new System.Drawing.Size(30, 30);
            this.pbMaximize.TabIndex = 8;
            this.pbMaximize.TabStop = false;
            this.pbMaximize.Click += new System.EventHandler(this.pbMaximize_Click);
            // 
            // pbClose
            // 
            this.pbClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbClose.Image = global::LubriTech.Properties.Resources.closeIco2;
            this.pbClose.Location = new System.Drawing.Point(810, 6);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(30, 30);
            this.pbClose.TabIndex = 7;
            this.pbClose.TabStop = false;
            this.pbClose.Click += new System.EventHandler(this.pbClose_Click);
            // 
            // panelCB
            // 
            this.panelCB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelCB.Controls.Add(this.cbPriceList);
            this.panelCB.Controls.Add(this.txtFullName);
            this.panelCB.Controls.Add(this.txtAddresse);
            this.panelCB.Controls.Add(this.label1);
            this.panelCB.Controls.Add(this.txtAdditionalPhone);
            this.panelCB.Controls.Add(this.txtID);
            this.panelCB.Controls.Add(this.txtMainPhone);
            this.panelCB.Controls.Add(this.lblFullName);
            this.panelCB.Controls.Add(this.btnAddVehicle);
            this.panelCB.Controls.Add(this.lblID);
            this.panelCB.Controls.Add(this.btnClose);
            this.panelCB.Controls.Add(this.dgvVehicles);
            this.panelCB.Controls.Add(this.btnAddClient);
            this.panelCB.Controls.Add(this.lblAddresse);
            this.panelCB.Controls.Add(this.lblAdditionalNum);
            this.panelCB.Controls.Add(this.lblNumPrincipal);
            this.panelCB.Controls.Add(this.lblState);
            this.panelCB.Controls.Add(this.cbState);
            this.panelCB.Controls.Add(this.lblEmail);
            this.panelCB.Controls.Add(this.lblVehicleList);
            this.panelCB.Controls.Add(this.txtEmail);
            this.panelCB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCB.Location = new System.Drawing.Point(0, 0);
            this.panelCB.Name = "panelCB";
            this.panelCB.Size = new System.Drawing.Size(840, 670);
            this.panelCB.TabIndex = 26;
            // 
            // cbPriceList
            // 
            this.cbPriceList.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbPriceList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPriceList.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPriceList.FormattingEnabled = true;
            this.cbPriceList.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cbPriceList.Location = new System.Drawing.Point(170, 219);
            this.cbPriceList.Name = "cbPriceList";
            this.cbPriceList.Size = new System.Drawing.Size(205, 29);
            this.cbPriceList.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 21);
            this.label1.TabIndex = 29;
            this.label1.Text = "Lista de precios";
            // 
            // frmUpsert_Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(840, 670);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.panelCB);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmUpsert_Client";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dato maestro cliente";
            this.Load += new System.EventHandler(this.frmUpsert_Client_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicles)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMaximize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            this.panelCB.ResumeLayout(false);
            this.panelCB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblNumPrincipal;
        private System.Windows.Forms.Label lblAddresse;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblAdditionalNum;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtMainPhone;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtAdditionalPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblVehicleList;
        private System.Windows.Forms.Button btnAddVehicle;
        private System.Windows.Forms.Button btnAddClient;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cbState;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.DataGridView dgvVehicles;
        private System.Windows.Forms.RichTextBox txtAddresse;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.PictureBox pbMaximize;
        private System.Windows.Forms.PictureBox pbClose;
        private System.Windows.Forms.Label lblForm;
        private System.Windows.Forms.Panel panelCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbPriceList;
    }
}