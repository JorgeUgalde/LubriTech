﻿namespace LubriTech.View
{
    partial class frmMakes
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.dgvMakes = new System.Windows.Forms.DataGridView();
            this.btnAddMake = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMakes)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(548, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 28);
            this.label3.TabIndex = 12;
            this.label3.Text = "Filtrar";
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilter.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilter.Location = new System.Drawing.Point(634, 84);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(227, 35);
            this.txtFilter.TabIndex = 11;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // dgvMakes
            // 
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(3, 3, 5, 5);
            this.dgvMakes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMakes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMakes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMakes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvMakes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.dgvMakes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvMakes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMakes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvMakes.Location = new System.Drawing.Point(91, 125);
            this.dgvMakes.Margin = new System.Windows.Forms.Padding(3, 3, 5, 5);
            this.dgvMakes.Name = "dgvMakes";
            this.dgvMakes.RowHeadersWidth = 51;
            this.dgvMakes.RowTemplate.Height = 24;
            this.dgvMakes.Size = new System.Drawing.Size(1004, 325);
            this.dgvMakes.TabIndex = 9;
            this.dgvMakes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMakes_CellContentClick);
            // 
            // btnAddMake
            // 
            this.btnAddMake.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddMake.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(146)))), ((int)(((byte)(69)))));
            this.btnAddMake.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddMake.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddMake.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddMake.ForeColor = System.Drawing.Color.White;
            this.btnAddMake.Location = new System.Drawing.Point(867, 80);
            this.btnAddMake.Name = "btnAddMake";
            this.btnAddMake.Size = new System.Drawing.Size(228, 42);
            this.btnAddMake.TabIndex = 10;
            this.btnAddMake.Text = "Agregar nuevo";
            this.btnAddMake.UseVisualStyleBackColor = false;
            this.btnAddMake.Click += new System.EventHandler(this.btnAddMake_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(85, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(267, 34);
            this.label2.TabIndex = 8;
            this.label2.Text = "Lista de Servicios";
            // 
            // frmMakes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 530);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.dgvMakes);
            this.Controls.Add(this.btnAddMake);
            this.Controls.Add(this.label2);
            this.Name = "frmMakes";
            this.Text = "frmMakes";
            this.Load += new System.EventHandler(this.frmMakes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMakes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.DataGridView dgvMakes;
        private System.Windows.Forms.Button btnAddMake;
        private System.Windows.Forms.Label label2;
    }
}