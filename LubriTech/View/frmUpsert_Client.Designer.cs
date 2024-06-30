namespace LubriTech.View
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.lblID.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(13, 63);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(99, 20);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "Identificación";
            // 
            // lblNumPrincipal
            // 
            this.lblNumPrincipal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblNumPrincipal.AutoSize = true;
            this.lblNumPrincipal.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumPrincipal.Location = new System.Drawing.Point(463, 61);
            this.lblNumPrincipal.Name = "lblNumPrincipal";
            this.lblNumPrincipal.Size = new System.Drawing.Size(128, 20);
            this.lblNumPrincipal.TabIndex = 1;
            this.lblNumPrincipal.Text = "Teléfono Principal";
            // 
            // lblAddresse
            // 
            this.lblAddresse.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblAddresse.AutoSize = true;
            this.lblAddresse.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddresse.Location = new System.Drawing.Point(463, 137);
            this.lblAddresse.Name = "lblAddresse";
            this.lblAddresse.Size = new System.Drawing.Size(72, 20);
            this.lblAddresse.TabIndex = 2;
            this.lblAddresse.Text = "Dirección";
            // 
            // lblFullName
            // 
            this.lblFullName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullName.Location = new System.Drawing.Point(13, 99);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(134, 20);
            this.lblFullName.TabIndex = 3;
            this.lblFullName.Text = "Nombre Completo";
            // 
            // lblAdditionalNum
            // 
            this.lblAdditionalNum.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblAdditionalNum.AutoSize = true;
            this.lblAdditionalNum.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdditionalNum.Location = new System.Drawing.Point(463, 97);
            this.lblAdditionalNum.Name = "lblAdditionalNum";
            this.lblAdditionalNum.Size = new System.Drawing.Size(134, 20);
            this.lblAdditionalNum.TabIndex = 4;
            this.lblAdditionalNum.Text = "Teléfono Adicional";
            // 
            // lblEmail
            // 
            this.lblEmail.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(11, 140);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(132, 20);
            this.lblEmail.TabIndex = 5;
            this.lblEmail.Text = "Correo Electrónico";
            // 
            // txtID
            // 
            this.txtID.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtID.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(183, 60);
            this.txtID.MaxLength = 30;
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(205, 27);
            this.txtID.TabIndex = 6;
            // 
            // txtMainPhone
            // 
            this.txtMainPhone.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtMainPhone.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMainPhone.Location = new System.Drawing.Point(610, 60);
            this.txtMainPhone.MaxLength = 11;
            this.txtMainPhone.Name = "txtMainPhone";
            this.txtMainPhone.Size = new System.Drawing.Size(205, 27);
            this.txtMainPhone.TabIndex = 7;
            this.txtMainPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMainPhone_KeyPress);
            // 
            // txtFullName
            // 
            this.txtFullName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtFullName.BackColor = System.Drawing.SystemColors.Window;
            this.txtFullName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFullName.Location = new System.Drawing.Point(183, 96);
            this.txtFullName.MaxLength = 150;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(261, 27);
            this.txtFullName.TabIndex = 10;
            // 
            // txtAdditionalPhone
            // 
            this.txtAdditionalPhone.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtAdditionalPhone.BackColor = System.Drawing.SystemColors.Window;
            this.txtAdditionalPhone.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdditionalPhone.Location = new System.Drawing.Point(610, 96);
            this.txtAdditionalPhone.MaxLength = 11;
            this.txtAdditionalPhone.Name = "txtAdditionalPhone";
            this.txtAdditionalPhone.Size = new System.Drawing.Size(205, 27);
            this.txtAdditionalPhone.TabIndex = 11;
            this.txtAdditionalPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAdditionalPhone_KeyPress);
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtEmail.BackColor = System.Drawing.SystemColors.Window;
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(181, 135);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(261, 27);
            this.txtEmail.TabIndex = 12;
            // 
            // lblVehicleList
            // 
            this.lblVehicleList.AutoSize = true;
            this.lblVehicleList.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVehicleList.Location = new System.Drawing.Point(17, 249);
            this.lblVehicleList.Name = "lblVehicleList";
            this.lblVehicleList.Size = new System.Drawing.Size(129, 20);
            this.lblVehicleList.TabIndex = 14;
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
            this.btnAddVehicle.Location = new System.Drawing.Point(674, 624);
            this.btnAddVehicle.Name = "btnAddVehicle";
            this.btnAddVehicle.Size = new System.Drawing.Size(144, 34);
            this.btnAddVehicle.TabIndex = 16;
            this.btnAddVehicle.Text = "Guardar Vehículo";
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
            this.btnAddClient.Location = new System.Drawing.Point(22, 624);
            this.btnAddClient.Name = "btnAddClient";
            this.btnAddClient.Size = new System.Drawing.Size(141, 34);
            this.btnAddClient.TabIndex = 17;
            this.btnAddClient.Text = "Aceptar";
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
            this.btnClose.Location = new System.Drawing.Point(187, 624);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(141, 34);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Cancelar";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cbState
            // 
            this.cbState.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbState.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbState.FormattingEnabled = true;
            this.cbState.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cbState.Location = new System.Drawing.Point(181, 174);
            this.cbState.Name = "cbState";
            this.cbState.Size = new System.Drawing.Size(205, 28);
            this.cbState.TabIndex = 19;
            // 
            // lblState
            // 
            this.lblState.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblState.AutoSize = true;
            this.lblState.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblState.Location = new System.Drawing.Point(11, 177);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(54, 20);
            this.lblState.TabIndex = 20;
            this.lblState.Text = "Estado";
            // 
            // dgvVehicles
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvVehicles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVehicles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVehicles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVehicles.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvVehicles.BackgroundColor = System.Drawing.Color.White;
            this.dgvVehicles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvVehicles.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dgvVehicles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(38)))), ((int)(((byte)(77)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVehicles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvVehicles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVehicles.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(238)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVehicles.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvVehicles.GridColor = System.Drawing.Color.White;
            this.dgvVehicles.Location = new System.Drawing.Point(20, 270);
            this.dgvVehicles.Name = "dgvVehicles";
            this.dgvVehicles.ReadOnly = true;
            this.dgvVehicles.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(38)))), ((int)(((byte)(77)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVehicles.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvVehicles.RowHeadersVisible = false;
            this.dgvVehicles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVehicles.Size = new System.Drawing.Size(798, 333);
            this.dgvVehicles.TabIndex = 23;
            this.dgvVehicles.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvVehicles_CellMouseDoubleClick);
            // 
            // txtAddresse
            // 
            this.txtAddresse.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtAddresse.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddresse.Location = new System.Drawing.Point(610, 139);
            this.txtAddresse.MaxLength = 150;
            this.txtAddresse.Name = "txtAddresse";
            this.txtAddresse.Size = new System.Drawing.Size(207, 93);
            this.txtAddresse.TabIndex = 24;
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
            this.panelCB.Controls.Add(this.lblAddresse);
            this.panelCB.Controls.Add(this.lblAdditionalNum);
            this.panelCB.Controls.Add(this.lblNumPrincipal);
            this.panelCB.Controls.Add(this.lblState);
            this.panelCB.Controls.Add(this.cbState);
            this.panelCB.Controls.Add(this.lblEmail);
            this.panelCB.Controls.Add(this.txtEmail);
            this.panelCB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCB.Location = new System.Drawing.Point(0, 0);
            this.panelCB.Name = "panelCB";
            this.panelCB.Size = new System.Drawing.Size(840, 670);
            this.panelCB.TabIndex = 26;
            // 
            // frmUpsert_Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(840, 670);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.txtAddresse);
            this.Controls.Add(this.dgvVehicles);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddClient);
            this.Controls.Add(this.btnAddVehicle);
            this.Controls.Add(this.lblVehicleList);
            this.Controls.Add(this.txtAdditionalPhone);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.txtMainPhone);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.lblID);
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
            this.PerformLayout();

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
    }
}