namespace LubriTech.View.Appointment_View
{
    partial class frmAppointment
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlCalendar = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblSunday = new System.Windows.Forms.Label();
            this.dayContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.pnlAppointments = new System.Windows.Forms.Panel();
            this.lblDaySelected = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlCalendar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(45)))), ((int)(((byte)(92)))));
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.pnlCalendar);
            this.panel1.Location = new System.Drawing.Point(2, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(374, 653);
            this.panel1.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(19, 543);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(129, 28);
            this.label9.TabIndex = 51;
            this.label9.Text = "Identificación";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBox2.Location = new System.Drawing.Point(24, 574);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(314, 32);
            this.textBox2.TabIndex = 50;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(19, 461);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 28);
            this.label8.TabIndex = 49;
            this.label8.Text = "Nombre";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBox1.Location = new System.Drawing.Point(24, 492);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(316, 32);
            this.textBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(259, 412);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 27);
            this.button1.TabIndex = 48;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(19, 412);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(196, 28);
            this.label7.TabIndex = 48;
            this.label7.Text = "Seleccione un Cliente";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCalendar
            // 
            this.pnlCalendar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(45)))), ((int)(((byte)(92)))));
            this.pnlCalendar.Controls.Add(this.label6);
            this.pnlCalendar.Controls.Add(this.label5);
            this.pnlCalendar.Controls.Add(this.label4);
            this.pnlCalendar.Controls.Add(this.label3);
            this.pnlCalendar.Controls.Add(this.label2);
            this.pnlCalendar.Controls.Add(this.label1);
            this.pnlCalendar.Controls.Add(this.lblDate);
            this.pnlCalendar.Controls.Add(this.lblSunday);
            this.pnlCalendar.Controls.Add(this.dayContainer);
            this.pnlCalendar.Controls.Add(this.btnPrevious);
            this.pnlCalendar.Controls.Add(this.btnNext);
            this.pnlCalendar.Location = new System.Drawing.Point(24, 27);
            this.pnlCalendar.Name = "pnlCalendar";
            this.pnlCalendar.Size = new System.Drawing.Size(325, 358);
            this.pnlCalendar.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(287, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 20);
            this.label6.TabIndex = 47;
            this.label6.Text = "S";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(243, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 20);
            this.label5.TabIndex = 46;
            this.label5.Text = "V";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(201, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 20);
            this.label4.TabIndex = 45;
            this.label4.Text = "J";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(154, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 20);
            this.label3.TabIndex = 44;
            this.label3.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(107, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 20);
            this.label2.TabIndex = 43;
            this.label2.Text = "M";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(68, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 20);
            this.label1.TabIndex = 42;
            this.label1.Text = "L";
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(47, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(233, 28);
            this.lblDate.TabIndex = 41;
            this.lblDate.Text = "Mes , Año";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSunday
            // 
            this.lblSunday.AutoSize = true;
            this.lblSunday.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSunday.ForeColor = System.Drawing.Color.White;
            this.lblSunday.Location = new System.Drawing.Point(20, 37);
            this.lblSunday.Name = "lblSunday";
            this.lblSunday.Size = new System.Drawing.Size(20, 20);
            this.lblSunday.TabIndex = 40;
            this.lblSunday.Text = "D";
            // 
            // dayContainer
            // 
            this.dayContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dayContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dayContainer.Location = new System.Drawing.Point(4, 69);
            this.dayContainer.Name = "dayContainer";
            this.dayContainer.Size = new System.Drawing.Size(316, 252);
            this.dayContainer.TabIndex = 39;
            // 
            // btnPrevious
            // 
            this.btnPrevious.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))));
            this.btnPrevious.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrevious.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPrevious.ForeColor = System.Drawing.Color.White;
            this.btnPrevious.Location = new System.Drawing.Point(6, 328);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(77, 27);
            this.btnPrevious.TabIndex = 38;
            this.btnPrevious.Text = "Anterior";
            this.btnPrevious.UseVisualStyleBackColor = false;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))));
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(237, 327);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(85, 27);
            this.btnNext.TabIndex = 37;
            this.btnNext.Text = "Siguiente";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click_1);
            // 
            // pnlAppointments
            // 
            this.pnlAppointments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAppointments.AutoScroll = true;
            this.pnlAppointments.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlAppointments.Location = new System.Drawing.Point(382, 60);
            this.pnlAppointments.MinimumSize = new System.Drawing.Size(589, 600);
            this.pnlAppointments.Name = "pnlAppointments";
            this.pnlAppointments.Size = new System.Drawing.Size(589, 600);
            this.pnlAppointments.TabIndex = 2;
            // 
            // lblDaySelected
            // 
            this.lblDaySelected.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDaySelected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(45)))), ((int)(((byte)(92)))));
            this.lblDaySelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDaySelected.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblDaySelected.ForeColor = System.Drawing.Color.White;
            this.lblDaySelected.Location = new System.Drawing.Point(374, 7);
            this.lblDaySelected.Name = "lblDaySelected";
            this.lblDaySelected.Size = new System.Drawing.Size(597, 44);
            this.lblDaySelected.TabIndex = 48;
            this.lblDaySelected.Text = "Dia, Mes , Año";
            this.lblDaySelected.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(971, 661);
            this.Controls.Add(this.lblDaySelected);
            this.Controls.Add(this.pnlAppointments);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(989, 708);
            this.Name = "frmAppointment";
            this.Text = "frmAppointment";
            this.Load += new System.EventHandler(this.frmAppointment_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlCalendar.ResumeLayout(false);
            this.pnlCalendar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel pnlCalendar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblSunday;
        private System.Windows.Forms.FlowLayoutPanel dayContainer;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Panel pnlAppointments;
        private System.Windows.Forms.Label lblDaySelected;
    }
}