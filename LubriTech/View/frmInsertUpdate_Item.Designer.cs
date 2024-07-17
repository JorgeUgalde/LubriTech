namespace LubriTech.View
{
    partial class frmInsertUpdate_Item
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
            this.cbMeasureUnit = new System.Windows.Forms.ComboBox();
            this.cbState = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtFact = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblSellPrice = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tbStock = new System.Windows.Forms.TextBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRecommended = new System.Windows.Forms.TextBox();
            this.panelBorder = new System.Windows.Forms.Panel();
            this.lblForm = new System.Windows.Forms.Label();
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.lblPercentage = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelBorder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            this.SuspendLayout();
            // 
            // cbMeasureUnit
            // 
            this.cbMeasureUnit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbMeasureUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMeasureUnit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMeasureUnit.FormattingEnabled = true;
            this.cbMeasureUnit.Items.AddRange(new object[] {
            "Unidad",
            "Litro",
            "Kilo",
            "Servicio"});
            this.cbMeasureUnit.Location = new System.Drawing.Point(183, 153);
            this.cbMeasureUnit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbMeasureUnit.Name = "cbMeasureUnit";
            this.cbMeasureUnit.Size = new System.Drawing.Size(205, 29);
            this.cbMeasureUnit.TabIndex = 4;
            // 
            // cbState
            // 
            this.cbState.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbState.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbState.FormattingEnabled = true;
            this.cbState.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cbState.Location = new System.Drawing.Point(642, 62);
            this.cbState.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbState.Name = "cbState";
            this.cbState.Size = new System.Drawing.Size(205, 29);
            this.cbState.Sorted = true;
            this.cbState.TabIndex = 5;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(183, 107);
            this.txtName.Margin = new System.Windows.Forms.Padding(2, 2, 6, 6);
            this.txtName.MaxLength = 50;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(205, 29);
            this.txtName.TabIndex = 2;
            // 
            // txtFact
            // 
            this.txtFact.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFact.Location = new System.Drawing.Point(643, 202);
            this.txtFact.Margin = new System.Windows.Forms.Padding(2, 2, 6, 6);
            this.txtFact.MaxLength = 3;
            this.txtFact.Name = "txtFact";
            this.txtFact.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFact.Size = new System.Drawing.Size(183, 29);
            this.txtFact.TabIndex = 8;
            this.txtFact.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSellPrice_KeyPress);
            // 
            // txtCode
            // 
            this.txtCode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCode.Location = new System.Drawing.Point(183, 62);
            this.txtCode.Margin = new System.Windows.Forms.Padding(2, 2, 6, 6);
            this.txtCode.MaxLength = 20;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(205, 29);
            this.txtCode.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(425, 67);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 21);
            this.label5.TabIndex = 78;
            this.label5.Text = "Estado";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(22, 113);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 21);
            this.label7.TabIndex = 70;
            this.label7.Text = "Nombre";
            // 
            // lblSellPrice
            // 
            this.lblSellPrice.AutoSize = true;
            this.lblSellPrice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSellPrice.Location = new System.Drawing.Point(425, 204);
            this.lblSellPrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSellPrice.Name = "lblSellPrice";
            this.lblSellPrice.Size = new System.Drawing.Size(167, 21);
            this.lblSellPrice.TabIndex = 16;
            this.lblSellPrice.Text = "Factor precio de Venta ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 157);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 21);
            this.label3.TabIndex = 39;
            this.label3.Text = "Unidad de Medida";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.Location = new System.Drawing.Point(22, 68);
            this.lblCode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(60, 21);
            this.lblCode.TabIndex = 90;
            this.lblCode.Text = "Código";
            // 
            // cbType
            // 
            this.cbType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(643, 107);
            this.cbType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbType.Name = "cbType";
            this.cbType.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbType.Size = new System.Drawing.Size(205, 29);
            this.cbType.Sorted = true;
            this.cbType.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(425, 111);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 21);
            this.label8.TabIndex = 67;
            this.label8.Text = "Tipo";
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(55)))), ((int)(((byte)(111)))));
            this.btnConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnConfirm.Location = new System.Drawing.Point(26, 264);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(141, 34);
            this.btnConfirm.TabIndex = 10;
            this.btnConfirm.Text = "Confirmar";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click_1);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(55)))), ((int)(((byte)(111)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnClose.Location = new System.Drawing.Point(705, 264);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(141, 34);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Cancelar";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tbStock
            // 
            this.tbStock.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbStock.Location = new System.Drawing.Point(183, 202);
            this.tbStock.Margin = new System.Windows.Forms.Padding(2, 2, 6, 6);
            this.tbStock.MaxLength = 10;
            this.tbStock.Name = "tbStock";
            this.tbStock.Size = new System.Drawing.Size(205, 29);
            this.tbStock.TabIndex = 9;
            this.tbStock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbStock_KeyPress);
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStock.Location = new System.Drawing.Point(22, 204);
            this.lblStock.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(157, 21);
            this.lblStock.TabIndex = 35;
            this.lblStock.Text = "Cantidad en Almacen";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(425, 157);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(218, 21);
            this.label2.TabIndex = 37;
            this.label2.Text = "Recorrido Recomendado (km)";
            // 
            // txtRecommended
            // 
            this.txtRecommended.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecommended.Location = new System.Drawing.Point(643, 153);
            this.txtRecommended.Margin = new System.Windows.Forms.Padding(2, 2, 6, 6);
            this.txtRecommended.MaxLength = 10;
            this.txtRecommended.Name = "txtRecommended";
            this.txtRecommended.Size = new System.Drawing.Size(205, 29);
            this.txtRecommended.TabIndex = 7;
            this.txtRecommended.TextChanged += new System.EventHandler(this.txtRecommended_TextChanged);
            this.txtRecommended.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRecommended_KeyPress);
            // 
            // panelBorder
            // 
            this.panelBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(38)))), ((int)(((byte)(77)))));
            this.panelBorder.Controls.Add(this.lblForm);
            this.panelBorder.Controls.Add(this.pbClose);
            this.panelBorder.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panelBorder.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBorder.Location = new System.Drawing.Point(0, 0);
            this.panelBorder.Name = "panelBorder";
            this.panelBorder.Size = new System.Drawing.Size(875, 36);
            this.panelBorder.TabIndex = 39;
            this.panelBorder.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelBorder_MouseDown);
            // 
            // lblForm
            // 
            this.lblForm.AutoSize = true;
            this.lblForm.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForm.ForeColor = System.Drawing.Color.White;
            this.lblForm.Location = new System.Drawing.Point(12, 6);
            this.lblForm.Name = "lblForm";
            this.lblForm.Size = new System.Drawing.Size(172, 21);
            this.lblForm.TabIndex = 80;
            this.lblForm.Text = "Dato Maestro Artículo";
            // 
            // pbClose
            // 
            this.pbClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbClose.Image = global::LubriTech.Properties.Resources.closeIco2;
            this.pbClose.Location = new System.Drawing.Point(842, 6);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(30, 30);
            this.pbClose.TabIndex = 7;
            this.pbClose.TabStop = false;
            this.pbClose.Click += new System.EventHandler(this.pbClose_Click);
            // 
            // lblPercentage
            // 
            this.lblPercentage.AutoSize = true;
            this.lblPercentage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercentage.Location = new System.Drawing.Point(823, 205);
            this.lblPercentage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPercentage.Name = "lblPercentage";
            this.lblPercentage.Size = new System.Drawing.Size(23, 21);
            this.lblPercentage.TabIndex = 40;
            this.lblPercentage.Text = "%";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(875, 310);
            this.flowLayoutPanel1.TabIndex = 91;
            // 
            // frmInsertUpdate_Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(875, 310);
            this.Controls.Add(this.lblPercentage);
            this.Controls.Add(this.panelBorder);
            this.Controls.Add(this.txtRecommended);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbStock);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbMeasureUnit);
            this.Controls.Add(this.cbState);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtFact);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblSellPrice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "frmInsertUpdate_Item";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion de Artículos";
            this.panelBorder.ResumeLayout(false);
            this.panelBorder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbMeasureUnit;
        private System.Windows.Forms.ComboBox cbState;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtFact;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblSellPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox tbStock;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRecommended;
        private System.Windows.Forms.Panel panelBorder;
        private System.Windows.Forms.Label lblForm;
        private System.Windows.Forms.PictureBox pbClose;
        private System.Windows.Forms.Label lblPercentage;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}