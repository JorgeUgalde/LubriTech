﻿namespace LubriTech.View
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
            this.lblVehicle = new System.Windows.Forms.Label();
            this.lblMake = new System.Windows.Forms.Label();
            this.lblModel = new System.Windows.Forms.Label();
            this.lblMileage = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblBranch = new System.Windows.Forms.Label();
            this.txtMake = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.txtMileage = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblLicensePlate = new System.Windows.Forms.Label();
            this.txtLicensePlate = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblClient = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblVehicle
            // 
            this.lblVehicle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVehicle.AutoSize = true;
            this.lblVehicle.Location = new System.Drawing.Point(480, 146);
            this.lblVehicle.Name = "lblVehicle";
            this.lblVehicle.Size = new System.Drawing.Size(59, 16);
            this.lblVehicle.TabIndex = 2;
            this.lblVehicle.Text = "Vehículo";
            // 
            // lblMake
            // 
            this.lblMake.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMake.AutoSize = true;
            this.lblMake.Location = new System.Drawing.Point(480, 206);
            this.lblMake.Name = "lblMake";
            this.lblMake.Size = new System.Drawing.Size(45, 16);
            this.lblMake.TabIndex = 3;
            this.lblMake.Text = "Marca";
            // 
            // lblModel
            // 
            this.lblModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(480, 232);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(53, 16);
            this.lblModel.TabIndex = 4;
            this.lblModel.Text = "Modelo";
            // 
            // lblMileage
            // 
            this.lblMileage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMileage.AutoSize = true;
            this.lblMileage.Location = new System.Drawing.Point(480, 258);
            this.lblMileage.Name = "lblMileage";
            this.lblMileage.Size = new System.Drawing.Size(74, 16);
            this.lblMileage.TabIndex = 5;
            this.lblMileage.Text = "Kilometraje";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(22, 63);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(45, 16);
            this.lblDate.TabIndex = 8;
            this.lblDate.Text = "Fecha";
            // 
            // lblBranch
            // 
            this.lblBranch.AutoSize = true;
            this.lblBranch.Location = new System.Drawing.Point(22, 37);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(59, 16);
            this.lblBranch.TabIndex = 9;
            this.lblBranch.Text = "Sucursal";
            // 
            // txtMake
            // 
            this.txtMake.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMake.Location = new System.Drawing.Point(568, 203);
            this.txtMake.Name = "txtMake";
            this.txtMake.Size = new System.Drawing.Size(223, 22);
            this.txtMake.TabIndex = 14;
            // 
            // txtModel
            // 
            this.txtModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtModel.Location = new System.Drawing.Point(568, 229);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(223, 22);
            this.txtModel.TabIndex = 15;
            // 
            // txtMileage
            // 
            this.txtMileage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMileage.Location = new System.Drawing.Point(568, 255);
            this.txtMileage.Name = "txtMileage";
            this.txtMileage.Size = new System.Drawing.Size(223, 22);
            this.txtMileage.TabIndex = 16;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(25, 347);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(893, 202);
            this.dataGridView1.TabIndex = 19;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            this.dataGridView1.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView1_DefaultValuesNeeded);
            this.dataGridView1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView1_UserDeletingRow);
            // 
            // txtClientId
            // 
            this.txtClientId.Location = new System.Drawing.Point(120, 177);
            this.txtClientId.Name = "txtClientId";
            this.txtClientId.Size = new System.Drawing.Size(223, 22);
            this.txtClientId.TabIndex = 23;
            // 
            // lblClientId
            // 
            this.lblClientId.AutoSize = true;
            this.lblClientId.Location = new System.Drawing.Point(22, 180);
            this.lblClientId.Name = "lblClientId";
            this.lblClientId.Size = new System.Drawing.Size(85, 16);
            this.lblClientId.TabIndex = 24;
            this.lblClientId.Text = "Identificacion";
            // 
            // lblClientName
            // 
            this.lblClientName.AutoSize = true;
            this.lblClientName.Location = new System.Drawing.Point(22, 206);
            this.lblClientName.Name = "lblClientName";
            this.lblClientName.Size = new System.Drawing.Size(56, 16);
            this.lblClientName.TabIndex = 26;
            this.lblClientName.Text = "Nombre";
            // 
            // txtClientName
            // 
            this.txtClientName.Location = new System.Drawing.Point(120, 203);
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.Size = new System.Drawing.Size(223, 22);
            this.txtClientName.TabIndex = 25;
            // 
            // lblMainPhone
            // 
            this.lblMainPhone.AutoSize = true;
            this.lblMainPhone.Location = new System.Drawing.Point(22, 232);
            this.lblMainPhone.Name = "lblMainPhone";
            this.lblMainPhone.Size = new System.Drawing.Size(112, 16);
            this.lblMainPhone.TabIndex = 27;
            this.lblMainPhone.Text = "Número Teléfono";
            // 
            // lblAddPhone
            // 
            this.lblAddPhone.AutoSize = true;
            this.lblAddPhone.Location = new System.Drawing.Point(22, 258);
            this.lblAddPhone.Name = "lblAddPhone";
            this.lblAddPhone.Size = new System.Drawing.Size(113, 16);
            this.lblAddPhone.TabIndex = 28;
            this.lblAddPhone.Text = "Número adicional";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(22, 284);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(48, 16);
            this.lblEmail.TabIndex = 29;
            this.lblEmail.Text = "Correo";
            // 
            // txtCellphone
            // 
            this.txtCellphone.Location = new System.Drawing.Point(120, 229);
            this.txtCellphone.Name = "txtCellphone";
            this.txtCellphone.Size = new System.Drawing.Size(223, 22);
            this.txtCellphone.TabIndex = 30;
            // 
            // txtCellphone2
            // 
            this.txtCellphone2.Location = new System.Drawing.Point(120, 255);
            this.txtCellphone2.Name = "txtCellphone2";
            this.txtCellphone2.Size = new System.Drawing.Size(223, 22);
            this.txtCellphone2.TabIndex = 31;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(120, 281);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(223, 22);
            this.txtEmail.TabIndex = 32;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(483, 37);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(0, 16);
            this.label7.TabIndex = 33;
            // 
            // lblState
            // 
            this.lblState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(480, 37);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(50, 16);
            this.lblState.TabIndex = 34;
            this.lblState.Text = "Estado";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new System.Drawing.Point(480, 524);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(72, 16);
            this.lblTotalAmount.TabIndex = 36;
            this.lblTotalAmount.Text = "Monto total";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalAmount.Location = new System.Drawing.Point(568, 521);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(223, 22);
            this.txtTotalAmount.TabIndex = 37;
            // 
            // cbState
            // 
            this.cbState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbState.FormattingEnabled = true;
            this.cbState.Location = new System.Drawing.Point(568, 33);
            this.cbState.Name = "cbState";
            this.cbState.Size = new System.Drawing.Size(223, 24);
            this.cbState.TabIndex = 38;
            // 
            // cbBranch
            // 
            this.cbBranch.FormattingEnabled = true;
            this.cbBranch.Location = new System.Drawing.Point(120, 33);
            this.cbBranch.Name = "cbBranch";
            this.cbBranch.Size = new System.Drawing.Size(223, 24);
            this.cbBranch.TabIndex = 39;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(120, 60);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(223, 22);
            this.dateTimePicker.TabIndex = 40;
            // 
            // btnSelectClient
            // 
            this.btnSelectClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(55)))), ((int)(((byte)(111)))));
            this.btnSelectClient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelectClient.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelectClient.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSelectClient.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSelectClient.Location = new System.Drawing.Point(120, 141);
            this.btnSelectClient.Name = "btnSelectClient";
            this.btnSelectClient.Size = new System.Drawing.Size(224, 28);
            this.btnSelectClient.TabIndex = 41;
            this.btnSelectClient.Text = "Seleccionar cliente";
            this.btnSelectClient.UseVisualStyleBackColor = false;
            this.btnSelectClient.Click += new System.EventHandler(this.btnSelectClient_Click);
            // 
            // btnAddVehicle
            // 
            this.btnAddVehicle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddVehicle.Location = new System.Drawing.Point(568, 141);
            this.btnAddVehicle.Name = "btnAddVehicle";
            this.btnAddVehicle.Size = new System.Drawing.Size(224, 28);
            this.btnAddVehicle.TabIndex = 42;
            this.btnAddVehicle.Text = "Seleccionar vehículo";
            this.btnAddVehicle.UseVisualStyleBackColor = true;
            this.btnAddVehicle.Click += new System.EventHandler(this.btnAddVehicle_Click);
            // 
            // lblCurrentMileage
            // 
            this.lblCurrentMileage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentMileage.AutoSize = true;
            this.lblCurrentMileage.Location = new System.Drawing.Point(480, 284);
            this.lblCurrentMileage.Name = "lblCurrentMileage";
            this.lblCurrentMileage.Size = new System.Drawing.Size(111, 16);
            this.lblCurrentMileage.TabIndex = 43;
            this.lblCurrentMileage.Text = "KilometrajeActual";
            // 
            // txtCurrentMileage
            // 
            this.txtCurrentMileage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCurrentMileage.Location = new System.Drawing.Point(568, 281);
            this.txtCurrentMileage.Name = "txtCurrentMileage";
            this.txtCurrentMileage.Size = new System.Drawing.Size(223, 22);
            this.txtCurrentMileage.TabIndex = 44;
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveChanges.Location = new System.Drawing.Point(649, 605);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(131, 28);
            this.btnSaveChanges.TabIndex = 45;
            this.btnSaveChanges.Text = "Aceptar";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Location = new System.Drawing.Point(16, 605);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(131, 28);
            this.btnClose.TabIndex = 46;
            this.btnClose.Text = "Cerrar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblDetails
            // 
            this.lblDetails.AutoSize = true;
            this.lblDetails.Location = new System.Drawing.Point(22, 331);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(57, 16);
            this.lblDetails.TabIndex = 47;
            this.lblDetails.Text = "Detalles";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 579);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(763, 66);
            this.panel1.TabIndex = 48;
            // 
            // lblLicensePlate
            // 
            this.lblLicensePlate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLicensePlate.AutoSize = true;
            this.lblLicensePlate.Location = new System.Drawing.Point(480, 180);
            this.lblLicensePlate.Name = "lblLicensePlate";
            this.lblLicensePlate.Size = new System.Drawing.Size(42, 16);
            this.lblLicensePlate.TabIndex = 49;
            this.lblLicensePlate.Text = "Placa";
            // 
            // txtLicensePlate
            // 
            this.txtLicensePlate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLicensePlate.Location = new System.Drawing.Point(568, 177);
            this.txtLicensePlate.Name = "txtLicensePlate";
            this.txtLicensePlate.Size = new System.Drawing.Size(168, 22);
            this.txtLicensePlate.TabIndex = 50;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 103);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(574, 451);
            this.tabControl1.TabIndex = 51;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(566, 422);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Contenido";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(566, 422);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Observaciones";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Location = new System.Drawing.Point(22, 146);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(48, 16);
            this.lblClient.TabIndex = 1;
            this.lblClient.Text = "Cliente";
            // 
            // frmWorkOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(763, 645);
            this.Controls.Add(this.txtLicensePlate);
            this.Controls.Add(this.lblLicensePlate);
            this.Controls.Add(this.lblDetails);
            this.Controls.Add(this.txtCurrentMileage);
            this.Controls.Add(this.lblCurrentMileage);
            this.Controls.Add(this.btnAddVehicle);
            this.Controls.Add(this.btnSelectClient);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.cbBranch);
            this.Controls.Add(this.cbState);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtCellphone2);
            this.Controls.Add(this.txtCellphone);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblAddPhone);
            this.Controls.Add(this.lblMainPhone);
            this.Controls.Add(this.lblClientName);
            this.Controls.Add(this.txtClientName);
            this.Controls.Add(this.lblClientId);
            this.Controls.Add(this.txtClientId);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtMileage);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.txtMake);
            this.Controls.Add(this.lblBranch);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblMileage);
            this.Controls.Add(this.lblModel);
            this.Controls.Add(this.lblMake);
            this.Controls.Add(this.lblVehicle);
            this.Controls.Add(this.lblClient);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmWorkOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Órdenes de trabajo";
            this.Load += new System.EventHandler(this.frmWorkOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
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
        private System.Windows.Forms.DataGridView dataGridView1;
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblLicensePlate;
        private System.Windows.Forms.TextBox txtLicensePlate;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lblClient;
    }
}