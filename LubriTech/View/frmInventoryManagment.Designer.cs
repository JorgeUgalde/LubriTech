namespace LubriTech.View
{
    partial class frmInventoryManagment
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.btnAddInventoryManagment = new System.Windows.Forms.Button();
            this.lblInventoryManagmentList = new System.Windows.Forms.Label();
            this.dgvInventoryManagments = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventoryManagments)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(55)))), ((int)(((byte)(111)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(635, 435);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 34);
            this.button1.TabIndex = 15;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(442, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 21);
            this.label1.TabIndex = 14;
            this.label1.Text = "Filtrar por";
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilter.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilter.Location = new System.Drawing.Point(528, 17);
            this.txtFilter.Margin = new System.Windows.Forms.Padding(2);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(248, 29);
            this.txtFilter.TabIndex = 13;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // btnAddInventoryManagment
            // 
            this.btnAddInventoryManagment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddInventoryManagment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(55)))), ((int)(((byte)(111)))));
            this.btnAddInventoryManagment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddInventoryManagment.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddInventoryManagment.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddInventoryManagment.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddInventoryManagment.Location = new System.Drawing.Point(12, 435);
            this.btnAddInventoryManagment.Name = "btnAddInventoryManagment";
            this.btnAddInventoryManagment.Size = new System.Drawing.Size(141, 34);
            this.btnAddInventoryManagment.TabIndex = 12;
            this.btnAddInventoryManagment.Text = "Aceptar";
            this.btnAddInventoryManagment.UseVisualStyleBackColor = false;
            this.btnAddInventoryManagment.Click += new System.EventHandler(this.btnAddInventoryManagment_Click);
            // 
            // lblInventoryManagmentList
            // 
            this.lblInventoryManagmentList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInventoryManagmentList.AutoSize = true;
            this.lblInventoryManagmentList.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInventoryManagmentList.Location = new System.Drawing.Point(14, 25);
            this.lblInventoryManagmentList.Name = "lblInventoryManagmentList";
            this.lblInventoryManagmentList.Size = new System.Drawing.Size(243, 21);
            this.lblInventoryManagmentList.TabIndex = 11;
            this.lblInventoryManagmentList.Text = "Lista de Gestiones de Inventario";
            // 
            // dgvInventoryManagments
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvInventoryManagments.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInventoryManagments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInventoryManagments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInventoryManagments.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvInventoryManagments.BackgroundColor = System.Drawing.Color.White;
            this.dgvInventoryManagments.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvInventoryManagments.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dgvInventoryManagments.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(38)))), ((int)(((byte)(77)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(38)))), ((int)(((byte)(77)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInventoryManagments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInventoryManagments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventoryManagments.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(238)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInventoryManagments.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvInventoryManagments.GridColor = System.Drawing.Color.White;
            this.dgvInventoryManagments.Location = new System.Drawing.Point(18, 56);
            this.dgvInventoryManagments.Name = "dgvInventoryManagments";
            this.dgvInventoryManagments.ReadOnly = true;
            this.dgvInventoryManagments.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(38)))), ((int)(((byte)(77)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(38)))), ((int)(((byte)(77)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInventoryManagments.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvInventoryManagments.RowHeadersVisible = false;
            this.dgvInventoryManagments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInventoryManagments.Size = new System.Drawing.Size(756, 345);
            this.dgvInventoryManagments.TabIndex = 10;
            // 
            // frmInventoryManagment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 486);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.btnAddInventoryManagment);
            this.Controls.Add(this.lblInventoryManagmentList);
            this.Controls.Add(this.dgvInventoryManagments);
            this.Name = "frmInventoryManagment";
            this.Text = "frmInventoryManagment";
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventoryManagments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Button btnAddInventoryManagment;
        private System.Windows.Forms.Label lblInventoryManagmentList;
        private System.Windows.Forms.DataGridView dgvInventoryManagments;
    }
}