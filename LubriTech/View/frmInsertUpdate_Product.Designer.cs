namespace LubriTech.View
{
    partial class frmInsertUpdate_Product
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cbState = new System.Windows.Forms.ComboBox();
            this.cbMeasureUnit = new System.Windows.Forms.ComboBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.dgvSuppliers = new System.Windows.Forms.DataGridView();
            this.txtSupplierInfo = new System.Windows.Forms.TextBox();
            this.dgvSelectedSuppliers = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAddSupplier = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuppliers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedSuppliers)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(126, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(369, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "Agregar Producto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(78, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 34);
            this.label2.TabIndex = 1;
            this.label2.Text = "Código";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(78, 277);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(269, 34);
            this.label3.TabIndex = 2;
            this.label3.Text = "Unidad de Medida";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(78, 378);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 34);
            this.label4.TabIndex = 3;
            this.label4.Text = "Precio";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(78, 477);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 34);
            this.label5.TabIndex = 6;
            this.label5.Text = "Estado";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(701, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(158, 34);
            this.label6.TabIndex = 5;
            this.label6.Text = "Proveedor";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(702, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 34);
            this.label7.TabIndex = 4;
            this.label7.Text = "Nombre";
            // 
            // txtCode
            // 
            this.txtCode.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCode.Location = new System.Drawing.Point(84, 212);
            this.txtCode.Margin = new System.Windows.Forms.Padding(3, 3, 8, 8);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(344, 35);
            this.txtCode.TabIndex = 7;
            // 
            // txtPrice
            // 
            this.txtPrice.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.Location = new System.Drawing.Point(84, 412);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(3, 3, 8, 8);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(345, 35);
            this.txtPrice.TabIndex = 9;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(707, 136);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 3, 8, 8);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(394, 35);
            this.txtName.TabIndex = 10;
            // 
            // cbState
            // 
            this.cbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbState.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbState.FormattingEnabled = true;
            this.cbState.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cbState.Location = new System.Drawing.Point(84, 516);
            this.cbState.Margin = new System.Windows.Forms.Padding(5);
            this.cbState.Name = "cbState";
            this.cbState.Size = new System.Drawing.Size(343, 36);
            this.cbState.Sorted = true;
            this.cbState.TabIndex = 12;
            // 
            // cbMeasureUnit
            // 
            this.cbMeasureUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMeasureUnit.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMeasureUnit.FormattingEnabled = true;
            this.cbMeasureUnit.Items.AddRange(new object[] {
            "Unidad",
            "Litro"});
            this.cbMeasureUnit.Location = new System.Drawing.Point(84, 316);
            this.cbMeasureUnit.Margin = new System.Windows.Forms.Padding(5);
            this.cbMeasureUnit.Name = "cbMeasureUnit";
            this.cbMeasureUnit.Size = new System.Drawing.Size(343, 36);
            this.cbMeasureUnit.TabIndex = 13;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(146)))), ((int)(((byte)(69)))));
            this.btnConfirm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirm.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(490, 668);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(176, 49);
            this.btnConfirm.TabIndex = 14;
            this.btnConfirm.Text = "Confirmar";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnBack
            // 
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBack.Image = global::LubriTech.Properties.Resources.Back;
            this.btnBack.Location = new System.Drawing.Point(62, 34);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(58, 48);
            this.btnBack.TabIndex = 15;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // dgvSuppliers
            // 
            this.dgvSuppliers.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.dgvSuppliers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSuppliers.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.dgvSuppliers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvSuppliers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvSuppliers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSuppliers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvSuppliers.GridColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgvSuppliers.Location = new System.Drawing.Point(708, 244);
            this.dgvSuppliers.Name = "dgvSuppliers";
            this.dgvSuppliers.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvSuppliers.RowHeadersVisible = false;
            this.dgvSuppliers.RowHeadersWidth = 51;
            this.dgvSuppliers.RowTemplate.Height = 24;
            this.dgvSuppliers.Size = new System.Drawing.Size(393, 145);
            this.dgvSuppliers.TabIndex = 16;
            this.dgvSuppliers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSuppliers_CellContentClick_1);
            this.dgvSuppliers.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvSuppliers_CellFormatting);
            this.dgvSuppliers.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvSuppliers_RowPrePaint);
            // 
            // txtSupplierInfo
            // 
            this.txtSupplierInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSupplierInfo.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplierInfo.Location = new System.Drawing.Point(865, 203);
            this.txtSupplierInfo.Margin = new System.Windows.Forms.Padding(3, 3, 8, 8);
            this.txtSupplierInfo.Name = "txtSupplierInfo";
            this.txtSupplierInfo.Size = new System.Drawing.Size(236, 35);
            this.txtSupplierInfo.TabIndex = 17;
            this.txtSupplierInfo.TextChanged += new System.EventHandler(this.txtSupplierInfo_TextChanged);
            // 
            // dgvSelectedSuppliers
            // 
            this.dgvSelectedSuppliers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSelectedSuppliers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSelectedSuppliers.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.dgvSelectedSuppliers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvSelectedSuppliers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvSelectedSuppliers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSelectedSuppliers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvSelectedSuppliers.GridColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgvSelectedSuppliers.Location = new System.Drawing.Point(708, 450);
            this.dgvSelectedSuppliers.Name = "dgvSelectedSuppliers";
            this.dgvSelectedSuppliers.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvSelectedSuppliers.RowHeadersVisible = false;
            this.dgvSelectedSuppliers.RowHeadersWidth = 51;
            this.dgvSelectedSuppliers.RowTemplate.Height = 24;
            this.dgvSelectedSuppliers.Size = new System.Drawing.Size(393, 145);
            this.dgvSelectedSuppliers.TabIndex = 18;
            this.dgvSelectedSuppliers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSelectedSuppliers_CellContentClick);
            this.dgvSelectedSuppliers.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvSelectedSuppliers_CellFormatting);
            this.dgvSelectedSuppliers.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvSelectedSuppliers_RowPrePaint);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(703, 408);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(398, 34);
            this.label8.TabIndex = 19;
            this.label8.Text = "Proveedores seleccionados";
            // 
            // btnAddSupplier
            // 
            this.btnAddSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddSupplier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(146)))), ((int)(((byte)(69)))));
            this.btnAddSupplier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddSupplier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddSupplier.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSupplier.ForeColor = System.Drawing.Color.White;
            this.btnAddSupplier.Location = new System.Drawing.Point(790, 612);
            this.btnAddSupplier.Name = "btnAddSupplier";
            this.btnAddSupplier.Size = new System.Drawing.Size(257, 41);
            this.btnAddSupplier.TabIndex = 20;
            this.btnAddSupplier.Text = "Agregar Nuevo Proveedor";
            this.btnAddSupplier.UseVisualStyleBackColor = false;
            this.btnAddSupplier.Click += new System.EventHandler(this.btnAddSupplier_Click);
            // 
            // frmInsertUpdate_Product
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(1143, 788);
            this.Controls.Add(this.btnAddSupplier);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dgvSelectedSuppliers);
            this.Controls.Add(this.txtSupplierInfo);
            this.Controls.Add(this.dgvSuppliers);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.cbMeasureUnit);
            this.Controls.Add(this.cbState);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmInsertUpdate_Product";
            this.Text = "Gestionar Producto";
            this.Load += new System.EventHandler(this.frmInsert_Product_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuppliers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedSuppliers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cbState;
        private System.Windows.Forms.ComboBox cbMeasureUnit;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridView dgvSuppliers;
        private System.Windows.Forms.TextBox txtSupplierInfo;
        private System.Windows.Forms.DataGridView dgvSelectedSuppliers;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAddSupplier;
    }
}