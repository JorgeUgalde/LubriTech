namespace LubriTech.View
{
    partial class frmInsertUpdate_Schedule
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
            this.lblForm = new System.Windows.Forms.Label();
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.panelBorder = new System.Windows.Forms.Panel();
            this.cbBranch = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.cbStartHour = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbStartMinute = new System.Windows.Forms.ComboBox();
            this.cbEndMinute = new System.Windows.Forms.ComboBox();
            this.cbEndHour = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbDurationMinuts = new System.Windows.Forms.ComboBox();
            this.cbDurationHours = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnAddSchedule = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.cbState = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            this.panelBorder.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblForm
            // 
            this.lblForm.AutoSize = true;
            this.lblForm.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForm.ForeColor = System.Drawing.Color.White;
            this.lblForm.Location = new System.Drawing.Point(16, 7);
            this.lblForm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblForm.Name = "lblForm";
            this.lblForm.Size = new System.Drawing.Size(209, 28);
            this.lblForm.TabIndex = 10;
            this.lblForm.Text = "Dato Maestro Horario";
            // 
            // pbClose
            // 
            this.pbClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbClose.Image = global::LubriTech.Properties.Resources.closeIco2;
            this.pbClose.Location = new System.Drawing.Point(406, 7);
            this.pbClose.Margin = new System.Windows.Forms.Padding(4);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(40, 37);
            this.pbClose.TabIndex = 7;
            this.pbClose.TabStop = false;
            this.pbClose.Click += new System.EventHandler(this.pbClose_Click);
            // 
            // panelBorder
            // 
            this.panelBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(38)))), ((int)(((byte)(77)))));
            this.panelBorder.Controls.Add(this.lblForm);
            this.panelBorder.Controls.Add(this.pbClose);
            this.panelBorder.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panelBorder.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBorder.Location = new System.Drawing.Point(0, 0);
            this.panelBorder.Margin = new System.Windows.Forms.Padding(4);
            this.panelBorder.Name = "panelBorder";
            this.panelBorder.Size = new System.Drawing.Size(450, 44);
            this.panelBorder.TabIndex = 36;
            this.panelBorder.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelBorder_MouseDown);
            // 
            // cbBranch
            // 
            this.cbBranch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBranch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBranch.FormattingEnabled = true;
            this.cbBranch.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cbBranch.Location = new System.Drawing.Point(143, 146);
            this.cbBranch.Margin = new System.Windows.Forms.Padding(4);
            this.cbBranch.Name = "cbBranch";
            this.cbBranch.Size = new System.Drawing.Size(283, 36);
            this.cbBranch.TabIndex = 44;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 154);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 28);
            this.label1.TabIndex = 43;
            this.label1.Text = "Sucursal";
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTitle.BackColor = System.Drawing.SystemColors.Window;
            this.txtTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.Location = new System.Drawing.Point(143, 71);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(4);
            this.txtTitle.MaxLength = 50;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(283, 34);
            this.txtTitle.TabIndex = 42;
            // 
            // lblFullName
            // 
            this.lblFullName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullName.Location = new System.Drawing.Point(28, 77);
            this.lblFullName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(62, 28);
            this.lblFullName.TabIndex = 41;
            this.lblFullName.Text = "Titulo";
            // 
            // cbStartHour
            // 
            this.cbStartHour.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbStartHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStartHour.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStartHour.FormattingEnabled = true;
            this.cbStartHour.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24"});
            this.cbStartHour.Location = new System.Drawing.Point(207, 334);
            this.cbStartHour.Margin = new System.Windows.Forms.Padding(4);
            this.cbStartHour.Name = "cbStartHour";
            this.cbStartHour.Size = new System.Drawing.Size(92, 36);
            this.cbStartHour.TabIndex = 46;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 342);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 28);
            this.label2.TabIndex = 45;
            this.label2.Text = "Hora Inicio";
            // 
            // cbStartMinute
            // 
            this.cbStartMinute.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbStartMinute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStartMinute.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStartMinute.FormattingEnabled = true;
            this.cbStartMinute.Items.AddRange(new object[] {
            "00",
            "15",
            "30",
            "45"});
            this.cbStartMinute.Location = new System.Drawing.Point(334, 334);
            this.cbStartMinute.Margin = new System.Windows.Forms.Padding(4);
            this.cbStartMinute.Name = "cbStartMinute";
            this.cbStartMinute.Size = new System.Drawing.Size(92, 36);
            this.cbStartMinute.TabIndex = 47;
            // 
            // cbEndMinute
            // 
            this.cbEndMinute.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbEndMinute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEndMinute.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEndMinute.FormattingEnabled = true;
            this.cbEndMinute.Items.AddRange(new object[] {
            "00",
            "15",
            "30",
            "45"});
            this.cbEndMinute.Location = new System.Drawing.Point(334, 394);
            this.cbEndMinute.Margin = new System.Windows.Forms.Padding(4);
            this.cbEndMinute.Name = "cbEndMinute";
            this.cbEndMinute.Size = new System.Drawing.Size(92, 36);
            this.cbEndMinute.TabIndex = 50;
            // 
            // cbEndHour
            // 
            this.cbEndHour.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbEndHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEndHour.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEndHour.FormattingEnabled = true;
            this.cbEndHour.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24"});
            this.cbEndHour.Location = new System.Drawing.Point(207, 394);
            this.cbEndHour.Margin = new System.Windows.Forms.Padding(4);
            this.cbEndHour.Name = "cbEndHour";
            this.cbEndHour.Size = new System.Drawing.Size(92, 36);
            this.cbEndHour.TabIndex = 49;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 402);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 28);
            this.label3.TabIndex = 48;
            this.label3.Text = "Hora Salida";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(310, 334);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 28);
            this.label4.TabIndex = 51;
            this.label4.Text = ":";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(310, 394);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 28);
            this.label5.TabIndex = 52;
            this.label5.Text = ":";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(29, 463);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(154, 28);
            this.label7.TabIndex = 53;
            this.label7.Text = "Duración de cita";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(310, 455);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 28);
            this.label6.TabIndex = 56;
            this.label6.Text = ":";
            // 
            // cbDurationMinuts
            // 
            this.cbDurationMinuts.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbDurationMinuts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDurationMinuts.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDurationMinuts.FormattingEnabled = true;
            this.cbDurationMinuts.Items.AddRange(new object[] {
            "00",
            "15",
            "30",
            "45"});
            this.cbDurationMinuts.Location = new System.Drawing.Point(334, 455);
            this.cbDurationMinuts.Margin = new System.Windows.Forms.Padding(4);
            this.cbDurationMinuts.Name = "cbDurationMinuts";
            this.cbDurationMinuts.Size = new System.Drawing.Size(92, 36);
            this.cbDurationMinuts.TabIndex = 55;
            // 
            // cbDurationHours
            // 
            this.cbDurationHours.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbDurationHours.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDurationHours.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDurationHours.FormattingEnabled = true;
            this.cbDurationHours.Items.AddRange(new object[] {
            "00",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24"});
            this.cbDurationHours.Location = new System.Drawing.Point(207, 455);
            this.cbDurationHours.Margin = new System.Windows.Forms.Padding(4);
            this.cbDurationHours.Name = "cbDurationHours";
            this.cbDurationHours.Size = new System.Drawing.Size(92, 36);
            this.cbDurationHours.TabIndex = 54;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(219, 292);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 28);
            this.label8.TabIndex = 57;
            this.label8.Text = "Horas";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(342, 292);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 28);
            this.label9.TabIndex = 58;
            this.label9.Text = "Minutos";
            // 
            // btnAddSchedule
            // 
            this.btnAddSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddSchedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(55)))), ((int)(((byte)(111)))));
            this.btnAddSchedule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddSchedule.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSchedule.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddSchedule.Location = new System.Drawing.Point(285, 550);
            this.btnAddSchedule.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddSchedule.Name = "btnAddSchedule";
            this.btnAddSchedule.Size = new System.Drawing.Size(141, 34);
            this.btnAddSchedule.TabIndex = 60;
            this.btnAddSchedule.Text = "Cerrar";
            this.btnAddSchedule.UseVisualStyleBackColor = false;
            this.btnAddSchedule.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(55)))), ((int)(((byte)(111)))));
            this.btnConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnConfirm.Location = new System.Drawing.Point(26, 550);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(141, 34);
            this.btnConfirm.TabIndex = 59;
            this.btnConfirm.Text = "Confirmar";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // cbState
            // 
            this.cbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbState.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbState.FormattingEnabled = true;
            this.cbState.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cbState.Location = new System.Drawing.Point(143, 222);
            this.cbState.Margin = new System.Windows.Forms.Padding(5);
            this.cbState.Name = "cbState";
            this.cbState.Size = new System.Drawing.Size(283, 36);
            this.cbState.TabIndex = 62;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(29, 225);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 28);
            this.label10.TabIndex = 61;
            this.label10.Text = "Estado";
            // 
            // frmInsertUpdate_Schedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(450, 610);
            this.Controls.Add(this.cbState);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnAddSchedule);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbDurationMinuts);
            this.Controls.Add(this.cbDurationHours);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbEndMinute);
            this.Controls.Add(this.cbEndHour);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbStartMinute);
            this.Controls.Add(this.cbStartHour);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbBranch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.panelBorder);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(450, 510);
            this.Name = "frmInsertUpdate_Schedule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmInsertUpdate_Schedule";
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            this.panelBorder.ResumeLayout(false);
            this.panelBorder.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblForm;
        private System.Windows.Forms.PictureBox pbClose;
        private System.Windows.Forms.Panel panelBorder;
        private System.Windows.Forms.ComboBox cbBranch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.ComboBox cbStartHour;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbStartMinute;
        private System.Windows.Forms.ComboBox cbEndMinute;
        private System.Windows.Forms.ComboBox cbEndHour;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbDurationMinuts;
        private System.Windows.Forms.ComboBox cbDurationHours;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnAddSchedule;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.ComboBox cbState;
        private System.Windows.Forms.Label label10;
    }
}