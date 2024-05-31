namespace LubriTech.View
{
    partial class frmNewVehicle
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
            this.tbClientId = new System.Windows.Forms.TextBox();
            this.tbMileage = new System.Windows.Forms.TextBox();
            this.tbLicensePlate = new System.Windows.Forms.TextBox();
            this.tbBrand = new System.Windows.Forms.TextBox();
            this.tbEngine = new System.Windows.Forms.TextBox();
            this.tbYear = new System.Windows.Forms.TextBox();
            this.tbModel = new System.Windows.Forms.TextBox();
            this.cbTransmission = new System.Windows.Forms.ComboBox();
            this.btnAddVehicle = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNewVehicle
            // 
            this.lblNewVehicle.AutoSize = true;
            this.lblNewVehicle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.lblNewVehicle.Location = new System.Drawing.Point(120, 77);
            this.lblNewVehicle.Name = "lblNewVehicle";
            this.lblNewVehicle.Size = new System.Drawing.Size(310, 29);
            this.lblNewVehicle.TabIndex = 0;
            this.lblNewVehicle.Text = "Registrar Nuevo Vehículo";
            // 
            // lblClientId
            // 
            this.lblClientId.AutoSize = true;
            this.lblClientId.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblClientId.Location = new System.Drawing.Point(121, 160);
            this.lblClientId.Name = "lblClientId";
            this.lblClientId.Size = new System.Drawing.Size(210, 24);
            this.lblClientId.TabIndex = 1;
            this.lblClientId.Text = "Identificación del cliente";
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblModel.Location = new System.Drawing.Point(121, 240);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(74, 24);
            this.lblModel.TabIndex = 2;
            this.lblModel.Text = "Modelo";
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblBrand.Location = new System.Drawing.Point(599, 160);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(62, 24);
            this.lblBrand.TabIndex = 3;
            this.lblBrand.Text = "Marca";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblYear.Location = new System.Drawing.Point(122, 320);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(45, 24);
            this.lblYear.TabIndex = 3;
            this.lblYear.Text = "Año";
            // 
            // lblTransmission
            // 
            this.lblTransmission.AutoSize = true;
            this.lblTransmission.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblTransmission.Location = new System.Drawing.Point(599, 400);
            this.lblTransmission.Name = "lblTransmission";
            this.lblTransmission.Size = new System.Drawing.Size(113, 24);
            this.lblTransmission.TabIndex = 4;
            this.lblTransmission.Text = "Transmisión";
            // 
            // lblMileage
            // 
            this.lblMileage.AutoSize = true;
            this.lblMileage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblMileage.Location = new System.Drawing.Point(599, 320);
            this.lblMileage.Name = "lblMileage";
            this.lblMileage.Size = new System.Drawing.Size(103, 24);
            this.lblMileage.TabIndex = 5;
            this.lblMileage.Text = "Kilometraje";
            // 
            // lblLicensePlate
            // 
            this.lblLicensePlate.AutoSize = true;
            this.lblLicensePlate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblLicensePlate.Location = new System.Drawing.Point(599, 240);
            this.lblLicensePlate.Name = "lblLicensePlate";
            this.lblLicensePlate.Size = new System.Drawing.Size(56, 24);
            this.lblLicensePlate.TabIndex = 6;
            this.lblLicensePlate.Text = "Placa";
            // 
            // lblEngine
            // 
            this.lblEngine.AutoSize = true;
            this.lblEngine.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblEngine.Location = new System.Drawing.Point(121, 400);
            this.lblEngine.Name = "lblEngine";
            this.lblEngine.Size = new System.Drawing.Size(128, 24);
            this.lblEngine.TabIndex = 7;
            this.lblEngine.Text = "Tipo de motor";
            // 
            // tbClientId
            // 
            this.tbClientId.Location = new System.Drawing.Point(126, 187);
            this.tbClientId.Name = "tbClientId";
            this.tbClientId.Size = new System.Drawing.Size(206, 20);
            this.tbClientId.TabIndex = 8;
            // 
            // tbMileage
            // 
            this.tbMileage.Location = new System.Drawing.Point(602, 347);
            this.tbMileage.Name = "tbMileage";
            this.tbMileage.Size = new System.Drawing.Size(206, 20);
            this.tbMileage.TabIndex = 9;
            // 
            // tbLicensePlate
            // 
            this.tbLicensePlate.Location = new System.Drawing.Point(603, 267);
            this.tbLicensePlate.Name = "tbLicensePlate";
            this.tbLicensePlate.Size = new System.Drawing.Size(206, 20);
            this.tbLicensePlate.TabIndex = 10;
            // 
            // tbBrand
            // 
            this.tbBrand.Location = new System.Drawing.Point(602, 187);
            this.tbBrand.Name = "tbBrand";
            this.tbBrand.Size = new System.Drawing.Size(206, 20);
            this.tbBrand.TabIndex = 11;
            // 
            // tbEngine
            // 
            this.tbEngine.Location = new System.Drawing.Point(125, 427);
            this.tbEngine.Name = "tbEngine";
            this.tbEngine.Size = new System.Drawing.Size(206, 20);
            this.tbEngine.TabIndex = 12;
            // 
            // tbYear
            // 
            this.tbYear.Location = new System.Drawing.Point(126, 347);
            this.tbYear.Name = "tbYear";
            this.tbYear.Size = new System.Drawing.Size(206, 20);
            this.tbYear.TabIndex = 13;
            // 
            // tbModel
            // 
            this.tbModel.Location = new System.Drawing.Point(126, 267);
            this.tbModel.Name = "tbModel";
            this.tbModel.Size = new System.Drawing.Size(206, 20);
            this.tbModel.TabIndex = 14;
            // 
            // cbTransmission
            // 
            this.cbTransmission.FormattingEnabled = true;
            this.cbTransmission.Location = new System.Drawing.Point(603, 427);
            this.cbTransmission.Name = "cbTransmission";
            this.cbTransmission.Size = new System.Drawing.Size(206, 21);
            this.cbTransmission.TabIndex = 15;
            // 
            // btnAddVehicle
            // 
            this.btnAddVehicle.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAddVehicle.BackColor = System.Drawing.Color.ForestGreen;
            this.btnAddVehicle.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAddVehicle.FlatAppearance.BorderSize = 0;
            this.btnAddVehicle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddVehicle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnAddVehicle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddVehicle.Location = new System.Drawing.Point(397, 477);
            this.btnAddVehicle.Name = "btnAddVehicle";
            this.btnAddVehicle.Size = new System.Drawing.Size(138, 30);
            this.btnAddVehicle.TabIndex = 16;
            this.btnAddVehicle.Text = "Agregar";
            this.btnAddVehicle.UseVisualStyleBackColor = false;
            this.btnAddVehicle.Click += new System.EventHandler(this.btnNewVehicle_Click);
            // 
            // btnBack
            // 
            this.btnBack.Image = global::LubriTech.Properties.Resources.Imagen_flecha;
            this.btnBack.Location = new System.Drawing.Point(39, 77);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 29);
            this.btnBack.TabIndex = 17;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // frmNewVehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 559);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnAddVehicle);
            this.Controls.Add(this.cbTransmission);
            this.Controls.Add(this.tbModel);
            this.Controls.Add(this.tbYear);
            this.Controls.Add(this.tbEngine);
            this.Controls.Add(this.tbBrand);
            this.Controls.Add(this.tbLicensePlate);
            this.Controls.Add(this.tbMileage);
            this.Controls.Add(this.tbClientId);
            this.Controls.Add(this.lblEngine);
            this.Controls.Add(this.lblLicensePlate);
            this.Controls.Add(this.lblMileage);
            this.Controls.Add(this.lblTransmission);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblBrand);
            this.Controls.Add(this.lblModel);
            this.Controls.Add(this.lblClientId);
            this.Controls.Add(this.lblNewVehicle);
            this.Name = "frmNewVehicle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmNewVehicle";
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
        private System.Windows.Forms.TextBox tbClientId;
        private System.Windows.Forms.TextBox tbMileage;
        private System.Windows.Forms.TextBox tbLicensePlate;
        private System.Windows.Forms.TextBox tbBrand;
        private System.Windows.Forms.TextBox tbEngine;
        private System.Windows.Forms.TextBox tbYear;
        private System.Windows.Forms.TextBox tbModel;
        private System.Windows.Forms.ComboBox cbTransmission;
        private System.Windows.Forms.Button btnAddVehicle;
        private System.Windows.Forms.Button btnBack;
    }
}