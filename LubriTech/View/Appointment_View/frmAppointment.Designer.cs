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
            this.txtId = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlAppointments = new System.Windows.Forms.Panel();
            this.lblDaySelected = new System.Windows.Forms.Label();
            this.panelBorder = new System.Windows.Forms.Panel();
            this.lblForm = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnSearchVehicle = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbMaximize = new System.Windows.Forms.PictureBox();
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.dayContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSunday = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.pnlCalendar = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.pnlAppointments.SuspendLayout();
            this.panelBorder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMaximize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            this.pnlCalendar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(45)))), ((int)(((byte)(92)))));
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.btnSearchVehicle);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtId);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.pnlCalendar);
            this.panel1.Location = new System.Drawing.Point(0, 37);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.MinimumSize = new System.Drawing.Size(375, 906);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(375, 906);
            this.panel1.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(19, 527);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(129, 28);
            this.label9.TabIndex = 51;
            this.label9.Text = "Identificación";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtId
            // 
            this.txtId.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtId.Location = new System.Drawing.Point(24, 564);
            this.txtId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtId.Multiline = true;
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(313, 32);
            this.txtId.TabIndex = 50;
            this.txtId.TextChanged += new System.EventHandler(this.txtId_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(19, 441);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 28);
            this.label8.TabIndex = 49;
            this.label8.Text = "Nombre";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtName.Location = new System.Drawing.Point(24, 482);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(316, 32);
            this.txtName.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(259, 402);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 27);
            this.button1.TabIndex = 48;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(19, 402);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(196, 28);
            this.label7.TabIndex = 48;
            this.label7.Text = "Seleccione un Cliente";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlAppointments
            // 
            this.pnlAppointments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAppointments.AutoScroll = true;
            this.pnlAppointments.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlAppointments.Controls.Add(this.panel2);
            this.pnlAppointments.Location = new System.Drawing.Point(381, 83);
            this.pnlAppointments.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlAppointments.MinimumSize = new System.Drawing.Size(606, 620);
            this.pnlAppointments.Name = "pnlAppointments";
            this.pnlAppointments.Size = new System.Drawing.Size(643, 850);
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
            this.lblDaySelected.Location = new System.Drawing.Point(374, 37);
            this.lblDaySelected.Name = "lblDaySelected";
            this.lblDaySelected.Size = new System.Drawing.Size(652, 44);
            this.lblDaySelected.TabIndex = 48;
            this.lblDaySelected.Text = "Dia, Mes , Año";
            this.lblDaySelected.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelBorder
            // 
            this.panelBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(38)))), ((int)(((byte)(77)))));
            this.panelBorder.Controls.Add(this.pbMaximize);
            this.panelBorder.Controls.Add(this.pbClose);
            this.panelBorder.Controls.Add(this.lblForm);
            this.panelBorder.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panelBorder.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBorder.Location = new System.Drawing.Point(0, 0);
            this.panelBorder.Margin = new System.Windows.Forms.Padding(4);
            this.panelBorder.Name = "panelBorder";
            this.panelBorder.Size = new System.Drawing.Size(1026, 44);
            this.panelBorder.TabIndex = 49;
            this.panelBorder.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelBorder_MouseDown);
            // 
            // lblForm
            // 
            this.lblForm.AutoSize = true;
            this.lblForm.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForm.ForeColor = System.Drawing.Color.White;
            this.lblForm.Location = new System.Drawing.Point(71, 7);
            this.lblForm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblForm.Name = "lblForm";
            this.lblForm.Size = new System.Drawing.Size(55, 28);
            this.lblForm.TabIndex = 10;
            this.lblForm.Text = "Citas";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(19, 667);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 28);
            this.label11.TabIndex = 55;
            this.label11.Text = "Modelo";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBox2.Location = new System.Drawing.Point(24, 700);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(316, 32);
            this.textBox2.TabIndex = 52;
            // 
            // btnSearchVehicle
            // 
            this.btnSearchVehicle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))));
            this.btnSearchVehicle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchVehicle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearchVehicle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSearchVehicle.ForeColor = System.Drawing.Color.White;
            this.btnSearchVehicle.Location = new System.Drawing.Point(263, 631);
            this.btnSearchVehicle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearchVehicle.Name = "btnSearchVehicle";
            this.btnSearchVehicle.Size = new System.Drawing.Size(85, 27);
            this.btnSearchVehicle.TabIndex = 53;
            this.btnSearchVehicle.Text = "Buscar";
            this.btnSearchVehicle.UseVisualStyleBackColor = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(19, 631);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(210, 28);
            this.label12.TabIndex = 54;
            this.label12.Text = "Seleccione un Vehículo";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(19, 745);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 28);
            this.label10.TabIndex = 56;
            this.label10.Text = "Placa";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(24, 776);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(316, 36);
            this.comboBox1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(643, 850);
            this.panel2.TabIndex = 0;
            // 
            // pbMaximize
            // 
            this.pbMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbMaximize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbMaximize.Image = global::LubriTech.Properties.Resources.maximize;
            this.pbMaximize.Location = new System.Drawing.Point(934, 7);
            this.pbMaximize.Margin = new System.Windows.Forms.Padding(4);
            this.pbMaximize.Name = "pbMaximize";
            this.pbMaximize.Size = new System.Drawing.Size(40, 37);
            this.pbMaximize.TabIndex = 8;
            this.pbMaximize.TabStop = false;
            this.pbMaximize.Click += new System.EventHandler(this.pbMaximize_Click);
            // 
            // pbClose
            // 
            this.pbClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbClose.Image = global::LubriTech.Properties.Resources.closeIco2;
            this.pbClose.Location = new System.Drawing.Point(982, 7);
            this.pbClose.Margin = new System.Windows.Forms.Padding(4);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(40, 37);
            this.pbClose.TabIndex = 7;
            this.pbClose.TabStop = false;
            this.pbClose.Click += new System.EventHandler(this.pbClose_Click);
            // 
            // dayContainer
            // 
            this.dayContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dayContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dayContainer.Location = new System.Drawing.Point(4, 69);
            this.dayContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dayContainer.MinimumSize = new System.Drawing.Size(317, 252);
            this.dayContainer.Name = "dayContainer";
            this.dayContainer.Size = new System.Drawing.Size(317, 252);
            this.dayContainer.TabIndex = 39;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(155, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 20);
            this.label3.TabIndex = 44;
            this.label3.Text = "X";
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
            // btnPrevious
            // 
            this.btnPrevious.BackColor = System.Drawing.Color.Transparent;
            this.btnPrevious.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrevious.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(45)))), ((int)(((byte)(92)))));
            this.btnPrevious.FlatAppearance.BorderSize = 0;
            this.btnPrevious.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPrevious.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevious.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPrevious.ForeColor = System.Drawing.Color.White;
            this.btnPrevious.Image = global::LubriTech.Properties.Resources.Flecha_Calendario_Izquierda;
            this.btnPrevious.Location = new System.Drawing.Point(22, 0);
            this.btnPrevious.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(35, 32);
            this.btnPrevious.TabIndex = 38;
            this.btnPrevious.UseVisualStyleBackColor = false;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.Transparent;
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(45)))), ((int)(((byte)(92)))));
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnNext.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Image = global::LubriTech.Properties.Resources.Flecha_Calendario_Derecha;
            this.btnNext.Location = new System.Drawing.Point(269, 0);
            this.btnNext.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(35, 32);
            this.btnNext.TabIndex = 37;
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click_1);
            // 
            // pnlCalendar
            // 
            this.pnlCalendar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(45)))), ((int)(((byte)(92)))));
            this.pnlCalendar.Controls.Add(this.btnNext);
            this.pnlCalendar.Controls.Add(this.btnPrevious);
            this.pnlCalendar.Controls.Add(this.label6);
            this.pnlCalendar.Controls.Add(this.label5);
            this.pnlCalendar.Controls.Add(this.label4);
            this.pnlCalendar.Controls.Add(this.label3);
            this.pnlCalendar.Controls.Add(this.label2);
            this.pnlCalendar.Controls.Add(this.label1);
            this.pnlCalendar.Controls.Add(this.lblDate);
            this.pnlCalendar.Controls.Add(this.lblSunday);
            this.pnlCalendar.Controls.Add(this.dayContainer);
            this.pnlCalendar.Location = new System.Drawing.Point(24, 27);
            this.pnlCalendar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlCalendar.Name = "pnlCalendar";
            this.pnlCalendar.Size = new System.Drawing.Size(325, 326);
            this.pnlCalendar.TabIndex = 1;
            // 
            // frmAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1026, 944);
            this.Controls.Add(this.panelBorder);
            this.Controls.Add(this.lblDaySelected);
            this.Controls.Add(this.pnlAppointments);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1026, 944);
            this.Name = "frmAppointment";
            this.Text = "Citas";
            this.Load += new System.EventHandler(this.frmAppointment_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlAppointments.ResumeLayout(false);
            this.panelBorder.ResumeLayout(false);
            this.panelBorder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMaximize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            this.pnlCalendar.ResumeLayout(false);
            this.pnlCalendar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel pnlAppointments;
        private System.Windows.Forms.Label lblDaySelected;
        private System.Windows.Forms.PictureBox pbMaximize;
        private System.Windows.Forms.PictureBox pbClose;
        private System.Windows.Forms.Panel panelBorder;
        private System.Windows.Forms.Label lblForm;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnSearchVehicle;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlCalendar;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblSunday;
        private System.Windows.Forms.FlowLayoutPanel dayContainer;
    }
}