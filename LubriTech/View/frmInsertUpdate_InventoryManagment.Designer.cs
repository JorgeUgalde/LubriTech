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
            this.cbBranch = new System.Windows.Forms.ComboBox();
            this.cbDocumentType = new System.Windows.Forms.ComboBox();
            this.tbDate = new System.Windows.Forms.TextBox();
            this.tbTotalAmount = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblDocumentType = new System.Windows.Forms.Label();
            this.lblBranch = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lblSupplierId = new System.Windows.Forms.Label();
            this.tbSupplierName = new System.Windows.Forms.TextBox();
            this.btnSelectSupplier = new System.Windows.Forms.Button();
            this.tbSupplierId = new System.Windows.Forms.TextBox();
            this.cbState = new System.Windows.Forms.ComboBox();
            this.lblState = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbBranch
            // 
            this.cbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBranch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBranch.FormattingEnabled = true;
            this.cbBranch.Location = new System.Drawing.Point(169, 227);
            this.cbBranch.Name = "cbBranch";
            this.cbBranch.Size = new System.Drawing.Size(240, 29);
            this.cbBranch.TabIndex = 41;
            this.cbBranch.Tag = "";
            // 
            // cbDocumentType
            // 
            this.cbDocumentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDocumentType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDocumentType.FormattingEnabled = true;
            this.cbDocumentType.Items.AddRange(new object[] {
            "Compra"});
            this.cbDocumentType.Location = new System.Drawing.Point(169, 133);
            this.cbDocumentType.Name = "cbDocumentType";
            this.cbDocumentType.Size = new System.Drawing.Size(205, 29);
            this.cbDocumentType.TabIndex = 39;
            this.cbDocumentType.Tag = "";
            // 
            // tbDate
            // 
            this.tbDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDate.Location = new System.Drawing.Point(169, 40);
            this.tbDate.MaxLength = 10;
            this.tbDate.Name = "tbDate";
            this.tbDate.Size = new System.Drawing.Size(205, 29);
            this.tbDate.TabIndex = 28;
            // 
            // tbTotalAmount
            // 
            this.tbTotalAmount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTotalAmount.Location = new System.Drawing.Point(169, 87);
            this.tbTotalAmount.MaxLength = 9;
            this.tbTotalAmount.Name = "tbTotalAmount";
            this.tbTotalAmount.Size = new System.Drawing.Size(205, 29);
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
            this.lblDate.Location = new System.Drawing.Point(40, 43);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(50, 21);
            this.lblDate.TabIndex = 40;
            this.lblDate.Text = "Fecha";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(40, 90);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(92, 21);
            this.lblTotalAmount.TabIndex = 38;
            this.lblTotalAmount.Text = "Monto Total";
            // 
            // lblDocumentType
            // 
            this.lblDocumentType.AutoSize = true;
            this.lblDocumentType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocumentType.Location = new System.Drawing.Point(40, 136);
            this.lblDocumentType.Name = "lblDocumentType";
            this.lblDocumentType.Size = new System.Drawing.Size(123, 21);
            this.lblDocumentType.TabIndex = 32;
            this.lblDocumentType.Text = "Tipo documento";
            // 
            // lblBranch
            // 
            this.lblBranch.AutoSize = true;
            this.lblBranch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBranch.Location = new System.Drawing.Point(40, 230);
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
            this.btnClose.Location = new System.Drawing.Point(306, 351);
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
            this.btnConfirm.Location = new System.Drawing.Point(44, 351);
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
            this.lblSupplierId.Location = new System.Drawing.Point(40, 276);
            this.lblSupplierId.Name = "lblSupplierId";
            this.lblSupplierId.Size = new System.Drawing.Size(82, 21);
            this.lblSupplierId.TabIndex = 29;
            this.lblSupplierId.Text = "Proveedor";
            // 
            // tbSupplierName
            // 
            this.tbSupplierName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSupplierName.Location = new System.Drawing.Point(169, 273);
            this.tbSupplierName.MaxLength = 150;
            this.tbSupplierName.Name = "tbSupplierName";
            this.tbSupplierName.Size = new System.Drawing.Size(240, 29);
            this.tbSupplierName.TabIndex = 35;
            // 
            // btnSelectSupplier
            // 
            this.btnSelectSupplier.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSelectSupplier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(55)))), ((int)(((byte)(111)))));
            this.btnSelectSupplier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelectSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelectSupplier.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnSelectSupplier.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSelectSupplier.Image = global::LubriTech.Properties.Resources.searchClient;
            this.btnSelectSupplier.Location = new System.Drawing.Point(415, 273);
            this.btnSelectSupplier.Name = "btnSelectSupplier";
            this.btnSelectSupplier.Size = new System.Drawing.Size(32, 29);
            this.btnSelectSupplier.TabIndex = 37;
            this.btnSelectSupplier.UseVisualStyleBackColor = false;
            this.btnSelectSupplier.Click += new System.EventHandler(this.btnSelectSupplier_Click);
            // 
            // tbSupplierId
            // 
            this.tbSupplierId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSupplierId.Location = new System.Drawing.Point(169, 273);
            this.tbSupplierId.MaxLength = 150;
            this.tbSupplierId.Name = "tbSupplierId";
            this.tbSupplierId.Size = new System.Drawing.Size(240, 29);
            this.tbSupplierId.TabIndex = 47;
            // 
            // cbState
            // 
            this.cbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbState.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbState.FormattingEnabled = true;
            this.cbState.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cbState.Location = new System.Drawing.Point(169, 179);
            this.cbState.Name = "cbState";
            this.cbState.Size = new System.Drawing.Size(205, 29);
            this.cbState.TabIndex = 49;
            this.cbState.Tag = "";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblState.Location = new System.Drawing.Point(40, 182);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(56, 21);
            this.lblState.TabIndex = 48;
            this.lblState.Text = "Estado";
            // 
            // frmInsertUpdate_InventoryManagment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 418);
            this.Controls.Add(this.cbState);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.tbSupplierId);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnSelectSupplier);
            this.Controls.Add(this.cbBranch);
            this.Controls.Add(this.cbDocumentType);
            this.Controls.Add(this.tbDate);
            this.Controls.Add(this.tbTotalAmount);
            this.Controls.Add(this.tbSupplierName);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.lblDocumentType);
            this.Controls.Add(this.lblBranch);
            this.Controls.Add(this.lblSupplierId);
            this.Name = "frmInsertUpdate_InventoryManagment";
            this.Text = "frmInsertUpdate_InventoryManagment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbBranch;
        private System.Windows.Forms.ComboBox cbDocumentType;
        private System.Windows.Forms.TextBox tbDate;
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
    }
}