namespace LubriTech.View
{
    partial class frmInsertUpdate_Vehicle
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
            this.lblClientId = new System.Windows.Forms.Label();
            this.lblModel = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblTransmission = new System.Windows.Forms.Label();
            this.lblMileage = new System.Windows.Forms.Label();
            this.lblLicensePlate = new System.Windows.Forms.Label();
            this.lblEngine = new System.Windows.Forms.Label();
            this.tbClientName = new System.Windows.Forms.TextBox();
            this.tbMileage = new System.Windows.Forms.TextBox();
            this.tbLicensePlate = new System.Windows.Forms.TextBox();
            this.tbEngine = new System.Windows.Forms.TextBox();
            this.tbYear = new System.Windows.Forms.TextBox();
            this.cbTransmission = new System.Windows.Forms.ComboBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.dgvClients = new System.Windows.Forms.DataGridView();
            this.tbClientId = new System.Windows.Forms.TextBox();
            this.cbMake = new System.Windows.Forms.ComboBox();
            this.cbModel = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).BeginInit();
            this.SuspendLayout();
            // 
            // lblClientId
            // 
            this.lblClientId.AutoSize = true;
            this.lblClientId.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblClientId.Location = new System.Drawing.Point(60, 97);
            this.lblClientId.Name = "lblClientId";
            this.lblClientId.Size = new System.Drawing.Size(176, 25);
            this.lblClientId.TabIndex = 1;
            this.lblClientId.Text = "Nombre del cliente";
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblModel.Location = new System.Drawing.Point(59, 267);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(78, 25);
            this.lblModel.TabIndex = 2;
            this.lblModel.Text = "Modelo";
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblBrand.Location = new System.Drawing.Point(59, 187);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(66, 25);
            this.lblBrand.TabIndex = 3;
            this.lblBrand.Text = "Marca";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblYear.Location = new System.Drawing.Point(60, 348);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(47, 25);
            this.lblYear.TabIndex = 3;
            this.lblYear.Text = "Año";
            // 
            // lblTransmission
            // 
            this.lblTransmission.AutoSize = true;
            this.lblTransmission.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblTransmission.Location = new System.Drawing.Point(523, 427);
            this.lblTransmission.Name = "lblTransmission";
            this.lblTransmission.Size = new System.Drawing.Size(113, 25);
            this.lblTransmission.TabIndex = 4;
            this.lblTransmission.Text = "Transmisión";
            // 
            // lblMileage
            // 
            this.lblMileage.AutoSize = true;
            this.lblMileage.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblMileage.Location = new System.Drawing.Point(523, 348);
            this.lblMileage.Name = "lblMileage";
            this.lblMileage.Size = new System.Drawing.Size(111, 25);
            this.lblMileage.TabIndex = 5;
            this.lblMileage.Text = "Kilometraje";
            // 
            // lblLicensePlate
            // 
            this.lblLicensePlate.AutoSize = true;
            this.lblLicensePlate.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblLicensePlate.Location = new System.Drawing.Point(523, 267);
            this.lblLicensePlate.Name = "lblLicensePlate";
            this.lblLicensePlate.Size = new System.Drawing.Size(57, 25);
            this.lblLicensePlate.TabIndex = 6;
            this.lblLicensePlate.Text = "Placa";
            // 
            // lblEngine
            // 
            this.lblEngine.AutoSize = true;
            this.lblEngine.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblEngine.Location = new System.Drawing.Point(59, 427);
            this.lblEngine.Name = "lblEngine";
            this.lblEngine.Size = new System.Drawing.Size(133, 25);
            this.lblEngine.TabIndex = 7;
            this.lblEngine.Text = "Tipo de motor";
            // 
            // tbClientName
            // 
            this.tbClientName.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.tbClientName.Location = new System.Drawing.Point(64, 126);
            this.tbClientName.MaxLength = 150;
            this.tbClientName.Name = "tbClientName";
            this.tbClientName.Size = new System.Drawing.Size(268, 33);
            this.tbClientName.TabIndex = 8;
            this.tbClientName.TextChanged += new System.EventHandler(this.txtClientInfo_TextChanged);
            // 
            // tbMileage
            // 
            this.tbMileage.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.tbMileage.Location = new System.Drawing.Point(526, 378);
            this.tbMileage.MaxLength = 6;
            this.tbMileage.Name = "tbMileage";
            this.tbMileage.Size = new System.Drawing.Size(268, 33);
            this.tbMileage.TabIndex = 9;
            this.tbMileage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNumeric_KeyPress);
            // 
            // tbLicensePlate
            // 
            this.tbLicensePlate.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.tbLicensePlate.Location = new System.Drawing.Point(527, 298);
            this.tbLicensePlate.MaxLength = 6;
            this.tbLicensePlate.Name = "tbLicensePlate";
            this.tbLicensePlate.Size = new System.Drawing.Size(268, 33);
            this.tbLicensePlate.TabIndex = 10;
            this.tbLicensePlate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNumeric_KeyPress);
            // 
            // tbEngine
            // 
            this.tbEngine.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.tbEngine.Location = new System.Drawing.Point(64, 458);
            this.tbEngine.MaxLength = 50;
            this.tbEngine.Name = "tbEngine";
            this.tbEngine.Size = new System.Drawing.Size(268, 33);
            this.tbEngine.TabIndex = 12;
            // 
            // tbYear
            // 
            this.tbYear.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.tbYear.Location = new System.Drawing.Point(65, 378);
            this.tbYear.MaxLength = 4;
            this.tbYear.Name = "tbYear";
            this.tbYear.Size = new System.Drawing.Size(268, 33);
            this.tbYear.TabIndex = 13;
            this.tbYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNumeric_KeyPress);
            // 
            // cbTransmission
            // 
            this.cbTransmission.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTransmission.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.cbTransmission.FormattingEnabled = true;
            this.cbTransmission.Items.AddRange(new object[] {
            "Automático",
            "Manual"});
            this.cbTransmission.Location = new System.Drawing.Point(527, 458);
            this.cbTransmission.Name = "cbTransmission";
            this.cbTransmission.Size = new System.Drawing.Size(268, 33);
            this.cbTransmission.TabIndex = 15;
            this.cbTransmission.Tag = "";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(55)))), ((int)(((byte)(111)))));
            this.btnConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnConfirm.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnConfirm.Location = new System.Drawing.Point(64, 547);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(239, 41);
            this.btnConfirm.TabIndex = 3;
            this.btnConfirm.Text = "Confirmar";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // dgvClients
            // 
            this.dgvClients.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.dgvClients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClients.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.dgvClients.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvClients.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClients.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvClients.GridColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgvClients.Location = new System.Drawing.Point(526, 126);
            this.dgvClients.Margin = new System.Windows.Forms.Padding(2);
            this.dgvClients.Name = "dgvClients";
            this.dgvClients.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvClients.RowHeadersVisible = false;
            this.dgvClients.RowHeadersWidth = 51;
            this.dgvClients.RowTemplate.Height = 24;
            this.dgvClients.Size = new System.Drawing.Size(268, 118);
            this.dgvClients.TabIndex = 19;
            this.dgvClients.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClients_CellContentClick_1);
            this.dgvClients.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvClients_CellFormatting);
            // 
            // tbClientId
            // 
            this.tbClientId.Location = new System.Drawing.Point(526, 101);
            this.tbClientId.Name = "tbClientId";
            this.tbClientId.Size = new System.Drawing.Size(268, 20);
            this.tbClientId.TabIndex = 20;
            this.tbClientId.Visible = false;
            // 
            // cbMake
            // 
            this.cbMake.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMake.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.cbMake.FormattingEnabled = true;
            this.cbMake.Location = new System.Drawing.Point(64, 214);
            this.cbMake.Name = "cbMake";
            this.cbMake.Size = new System.Drawing.Size(268, 33);
            this.cbMake.TabIndex = 21;
            this.cbMake.Tag = "";
            // 
            // cbModel
            // 
            this.cbModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbModel.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.cbModel.FormattingEnabled = true;
            this.cbModel.Location = new System.Drawing.Point(64, 296);
            this.cbModel.Name = "cbModel";
            this.cbModel.Size = new System.Drawing.Size(268, 33);
            this.cbModel.TabIndex = 22;
            this.cbModel.Tag = "";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(55)))), ((int)(((byte)(111)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnClose.Location = new System.Drawing.Point(556, 547);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(239, 41);
            this.btnClose.TabIndex = 23;
            this.btnClose.Text = "Cerrar";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // frmInsertUpdate_Vehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(858, 640);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cbModel);
            this.Controls.Add(this.cbMake);
            this.Controls.Add(this.tbClientId);
            this.Controls.Add(this.dgvClients);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.cbTransmission);
            this.Controls.Add(this.tbYear);
            this.Controls.Add(this.tbEngine);
            this.Controls.Add(this.tbLicensePlate);
            this.Controls.Add(this.tbMileage);
            this.Controls.Add(this.tbClientName);
            this.Controls.Add(this.lblEngine);
            this.Controls.Add(this.lblLicensePlate);
            this.Controls.Add(this.lblMileage);
            this.Controls.Add(this.lblTransmission);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblBrand);
            this.Controls.Add(this.lblModel);
            this.Controls.Add(this.lblClientId);
            this.Name = "frmInsertUpdate_Vehicle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dato Maestro Vehículo";
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblClientId;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblTransmission;
        private System.Windows.Forms.Label lblMileage;
        private System.Windows.Forms.Label lblLicensePlate;
        private System.Windows.Forms.Label lblEngine;
        private System.Windows.Forms.TextBox tbClientName;
        private System.Windows.Forms.TextBox tbMileage;
        private System.Windows.Forms.TextBox tbLicensePlate;
        private System.Windows.Forms.TextBox tbEngine;
        private System.Windows.Forms.TextBox tbYear;
        private System.Windows.Forms.ComboBox cbTransmission;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.DataGridView dgvClients;
        private System.Windows.Forms.TextBox tbClientId;
        private System.Windows.Forms.ComboBox cbMake;
        private System.Windows.Forms.ComboBox cbModel;
        private System.Windows.Forms.Button btnClose;
    }
}