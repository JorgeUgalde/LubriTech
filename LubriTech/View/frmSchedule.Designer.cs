﻿namespace LubriTech.View
{
    partial class frmSchedule
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelBorder = new System.Windows.Forms.Panel();
            this.lblForm = new System.Windows.Forms.Label();
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddSchedule = new System.Windows.Forms.Button();
            this.dgvSchedules = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pbMaximize = new System.Windows.Forms.PictureBox();
            this.panelBorder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMaximize)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBorder
            // 
            this.panelBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(38)))), ((int)(((byte)(77)))));
            this.panelBorder.Controls.Add(this.pbMaximize);
            this.panelBorder.Controls.Add(this.lblForm);
            this.panelBorder.Controls.Add(this.pbClose);
            this.panelBorder.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panelBorder.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBorder.Location = new System.Drawing.Point(0, 0);
            this.panelBorder.Margin = new System.Windows.Forms.Padding(4);
            this.panelBorder.Name = "panelBorder";
            this.panelBorder.Size = new System.Drawing.Size(1076, 44);
            this.panelBorder.TabIndex = 40;
            this.panelBorder.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelBorder_MouseDown);
            // 
            // lblForm
            // 
            this.lblForm.AutoSize = true;
            this.lblForm.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForm.ForeColor = System.Drawing.Color.White;
            this.lblForm.Location = new System.Drawing.Point(16, 7);
            this.lblForm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblForm.Name = "lblForm";
            this.lblForm.Size = new System.Drawing.Size(89, 28);
            this.lblForm.TabIndex = 10;
            this.lblForm.Text = "Horarios";
            // 
            // pbClose
            // 
            this.pbClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbClose.Image = global::LubriTech.Properties.Resources.closeIco2;
            this.pbClose.Location = new System.Drawing.Point(1032, 7);
            this.pbClose.Margin = new System.Windows.Forms.Padding(4);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(40, 37);
            this.pbClose.TabIndex = 7;
            this.pbClose.TabStop = false;
            this.pbClose.Click += new System.EventHandler(this.pbClose_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(55)))), ((int)(((byte)(111)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnClose.Location = new System.Drawing.Point(854, 550);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(188, 42);
            this.btnClose.TabIndex = 46;
            this.btnClose.Text = "Cerrar";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddSchedule
            // 
            this.btnAddSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddSchedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(55)))), ((int)(((byte)(111)))));
            this.btnAddSchedule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddSchedule.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSchedule.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddSchedule.Location = new System.Drawing.Point(39, 550);
            this.btnAddSchedule.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddSchedule.Name = "btnAddSchedule";
            this.btnAddSchedule.Size = new System.Drawing.Size(188, 42);
            this.btnAddSchedule.TabIndex = 45;
            this.btnAddSchedule.Text = "Crear";
            this.btnAddSchedule.UseVisualStyleBackColor = false;
            this.btnAddSchedule.Click += new System.EventHandler(this.btnAddSchedule_Click);
            // 
            // dgvSchedules
            // 
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(238)))), ((int)(((byte)(254)))));
            this.dgvSchedules.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle21;
            this.dgvSchedules.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSchedules.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSchedules.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSchedules.BackgroundColor = System.Drawing.Color.White;
            this.dgvSchedules.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvSchedules.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dgvSchedules.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(38)))), ((int)(((byte)(77)))));
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSchedules.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.dgvSchedules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSchedules.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSchedules.DefaultCellStyle = dataGridViewCellStyle23;
            this.dgvSchedules.GridColor = System.Drawing.Color.White;
            this.dgvSchedules.Location = new System.Drawing.Point(39, 102);
            this.dgvSchedules.Margin = new System.Windows.Forms.Padding(4);
            this.dgvSchedules.Name = "dgvSchedules";
            this.dgvSchedules.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSchedules.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.dgvSchedules.RowHeadersVisible = false;
            this.dgvSchedules.RowHeadersWidth = 51;
            this.dgvSchedules.Size = new System.Drawing.Size(1003, 420);
            this.dgvSchedules.TabIndex = 44;
            this.dgvSchedules.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSchedules_CellDoubleClick);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(583, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 28);
            this.label3.TabIndex = 43;
            this.label3.Text = "Filtrar por";
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilter.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilter.Location = new System.Drawing.Point(698, 54);
            this.txtFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(343, 34);
            this.txtFilter.TabIndex = 42;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 28);
            this.label2.TabIndex = 41;
            this.label2.Text = "Lista de Horarios";
            // 
            // pbMaximize
            // 
            this.pbMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbMaximize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbMaximize.Image = global::LubriTech.Properties.Resources.maximize;
            this.pbMaximize.Location = new System.Drawing.Point(984, 7);
            this.pbMaximize.Margin = new System.Windows.Forms.Padding(4);
            this.pbMaximize.Name = "pbMaximize";
            this.pbMaximize.Size = new System.Drawing.Size(40, 37);
            this.pbMaximize.TabIndex = 11;
            this.pbMaximize.TabStop = false;
            this.pbMaximize.Click += new System.EventHandler(this.pbMaximize_Click);
            // 
            // frmSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1076, 646);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddSchedule);
            this.Controls.Add(this.dgvSchedules);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panelBorder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSchedule";
            this.Text = "frmSchedule";
            this.panelBorder.ResumeLayout(false);
            this.panelBorder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMaximize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelBorder;
        private System.Windows.Forms.Label lblForm;
        private System.Windows.Forms.PictureBox pbClose;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAddSchedule;
        private System.Windows.Forms.DataGridView dgvSchedules;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pbMaximize;
    }
}