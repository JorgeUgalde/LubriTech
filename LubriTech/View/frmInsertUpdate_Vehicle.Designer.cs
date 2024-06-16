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
            this.lblNewVehicle = new System.Windows.Forms.Label();
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
            this.btnBack = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.dgvClients = new System.Windows.Forms.DataGridView();
            this.tbClientId = new System.Windows.Forms.TextBox();
            this.cbMake = new System.Windows.Forms.ComboBox();
            this.cbModel = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNewVehicle
            // 
            this.lblNewVehicle.AutoSize = true;
            this.lblNewVehicle.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewVehicle.Location = new System.Drawing.Point(94, 28);
            this.lblNewVehicle.Name = "lblNewVehicle";
            this.lblNewVehicle.Size = new System.Drawing.Size(316, 38);
            this.lblNewVehicle.TabIndex = 0;
            this.lblNewVehicle.Text = "Gestionar Vehículo";
            // 
            // lblClientId
            // 
            this.lblClientId.AutoSize = true;
            this.lblClientId.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientId.Location = new System.Drawing.Point(63, 129);
            this.lblClientId.Name = "lblClientId";
            this.lblClientId.Size = new System.Drawing.Size(219, 26);
            this.lblClientId.TabIndex = 1;
            this.lblClientId.Text = "Nombre del cliente";
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModel.Location = new System.Drawing.Point(62, 299);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(90, 26);
            this.lblModel.TabIndex = 2;
            this.lblModel.Text = "Modelo";
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrand.Location = new System.Drawing.Point(62, 219);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(77, 26);
            this.lblBrand.TabIndex = 3;
            this.lblBrand.Text = "Marca";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYear.Location = new System.Drawing.Point(63, 380);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(54, 26);
            this.lblYear.TabIndex = 3;
            this.lblYear.Text = "Año";
            // 
            // lblTransmission
            // 
            this.lblTransmission.AutoSize = true;
            this.lblTransmission.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransmission.Location = new System.Drawing.Point(521, 459);
            this.lblTransmission.Name = "lblTransmission";
            this.lblTransmission.Size = new System.Drawing.Size(142, 26);
            this.lblTransmission.TabIndex = 4;
            this.lblTransmission.Text = "Transmisión";
            // 
            // lblMileage
            // 
            this.lblMileage.AutoSize = true;
            this.lblMileage.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMileage.Location = new System.Drawing.Point(521, 380);
            this.lblMileage.Name = "lblMileage";
            this.lblMileage.Size = new System.Drawing.Size(138, 26);
            this.lblMileage.TabIndex = 5;
            this.lblMileage.Text = "Kilometraje";
            // 
            // lblLicensePlate
            // 
            this.lblLicensePlate.AutoSize = true;
            this.lblLicensePlate.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicensePlate.Location = new System.Drawing.Point(521, 299);
            this.lblLicensePlate.Name = "lblLicensePlate";
            this.lblLicensePlate.Size = new System.Drawing.Size(68, 26);
            this.lblLicensePlate.TabIndex = 6;
            this.lblLicensePlate.Text = "Placa";
            // 
            // lblEngine
            // 
            this.lblEngine.AutoSize = true;
            this.lblEngine.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEngine.Location = new System.Drawing.Point(62, 459);
            this.lblEngine.Name = "lblEngine";
            this.lblEngine.Size = new System.Drawing.Size(167, 26);
            this.lblEngine.TabIndex = 7;
            this.lblEngine.Text = "Tipo de motor";
            // 
            // tbClientName
            // 
            this.tbClientName.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbClientName.Location = new System.Drawing.Point(67, 158);
            this.tbClientName.Name = "tbClientName";
            this.tbClientName.Size = new System.Drawing.Size(268, 30);
            this.tbClientName.TabIndex = 8;
            this.tbClientName.TextChanged += new System.EventHandler(this.txtClientInfo_TextChanged);
            // 
            // tbMileage
            // 
            this.tbMileage.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMileage.Location = new System.Drawing.Point(524, 410);
            this.tbMileage.Name = "tbMileage";
            this.tbMileage.Size = new System.Drawing.Size(268, 30);
            this.tbMileage.TabIndex = 9;
            // 
            // tbLicensePlate
            // 
            this.tbLicensePlate.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLicensePlate.Location = new System.Drawing.Point(525, 330);
            this.tbLicensePlate.Name = "tbLicensePlate";
            this.tbLicensePlate.Size = new System.Drawing.Size(268, 30);
            this.tbLicensePlate.TabIndex = 10;
            // 
            // tbEngine
            // 
            this.tbEngine.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEngine.Location = new System.Drawing.Point(67, 490);
            this.tbEngine.Name = "tbEngine";
            this.tbEngine.Size = new System.Drawing.Size(268, 30);
            this.tbEngine.TabIndex = 12;
            // 
            // tbYear
            // 
            this.tbYear.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbYear.Location = new System.Drawing.Point(68, 410);
            this.tbYear.Name = "tbYear";
            this.tbYear.Size = new System.Drawing.Size(268, 30);
            this.tbYear.TabIndex = 13;
            // 
            // cbTransmission
            // 
            this.cbTransmission.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTransmission.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTransmission.FormattingEnabled = true;
            this.cbTransmission.Items.AddRange(new object[] {
            "Automático",
            "Manual"});
            this.cbTransmission.Location = new System.Drawing.Point(525, 490);
            this.cbTransmission.Name = "cbTransmission";
            this.cbTransmission.Size = new System.Drawing.Size(268, 30);
            this.cbTransmission.TabIndex = 15;
            this.cbTransmission.Tag = "";
            // 
            // btnBack
            // 
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.Image = global::LubriTech.Properties.Resources.Back;
            this.btnBack.Location = new System.Drawing.Point(46, 28);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(44, 39);
            this.btnBack.TabIndex = 17;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(146)))), ((int)(((byte)(69)))));
            this.btnConfirm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirm.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(368, 560);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(132, 40);
            this.btnConfirm.TabIndex = 18;
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
            this.dgvClients.Location = new System.Drawing.Point(524, 158);
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
            this.tbClientId.Location = new System.Drawing.Point(524, 133);
            this.tbClientId.Name = "tbClientId";
            this.tbClientId.Size = new System.Drawing.Size(268, 20);
            this.tbClientId.TabIndex = 20;
            this.tbClientId.Visible = false;
            // 
            // cbMake
            // 
            this.cbMake.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMake.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMake.FormattingEnabled = true;
            this.cbMake.Location = new System.Drawing.Point(67, 246);
            this.cbMake.Name = "cbMake";
            this.cbMake.Size = new System.Drawing.Size(268, 30);
            this.cbMake.TabIndex = 21;
            this.cbMake.Tag = "";
            // 
            // cbModel
            // 
            this.cbModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbModel.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbModel.FormattingEnabled = true;
            this.cbModel.Location = new System.Drawing.Point(67, 328);
            this.cbModel.Name = "cbModel";
            this.cbModel.Size = new System.Drawing.Size(268, 30);
            this.cbModel.TabIndex = 22;
            this.cbModel.Tag = "";
            // 
            // frmInsertUpdate_Vehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(858, 640);
            this.Controls.Add(this.cbModel);
            this.Controls.Add(this.cbMake);
            this.Controls.Add(this.tbClientId);
            this.Controls.Add(this.dgvClients);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnBack);
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
            this.Controls.Add(this.lblNewVehicle);
            this.Name = "frmInsertUpdate_Vehicle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestionar Vehículo";
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNewVehicle;
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
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.DataGridView dgvClients;
        private System.Windows.Forms.TextBox tbClientId;
        private System.Windows.Forms.ComboBox cbMake;
        private System.Windows.Forms.ComboBox cbModel;
    }
}