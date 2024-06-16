namespace LubriTech.View
{
    partial class MDI_View
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
            this.components = new System.ComponentModel.Container();
            this.sideBarTimer = new System.Windows.Forms.Timer(this.components);
            this.panelMenu = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panelParametersSubmenu = new System.Windows.Forms.Panel();
            this.button10 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.btnParamConfig = new System.Windows.Forms.Button();
            this.btnArticles = new System.Windows.Forms.Button();
            this.panelInventorySubmenu = new System.Windows.Forms.Panel();
            this.btnSuppliers = new System.Windows.Forms.Button();
            this.btnGoodsIssue = new System.Windows.Forms.Button();
            this.btnGoodsReceipt = new System.Windows.Forms.Button();
            this.btnPurchaseOrder = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.btnWorkOrders = new System.Windows.Forms.Button();
            this.btnAppointments = new System.Windows.Forms.Button();
            this.panelClientsSubmenu = new System.Windows.Forms.Panel();
            this.btnVehicleMasterData = new System.Windows.Forms.Button();
            this.btnClientMasterData = new System.Windows.Forms.Button();
            this.btnClients = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelMenu.SuspendLayout();
            this.panelParametersSubmenu.SuspendLayout();
            this.panelInventorySubmenu.SuspendLayout();
            this.panelClientsSubmenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // sideBarTimer
            // 
            this.sideBarTimer.Enabled = true;
            this.sideBarTimer.Interval = 5;
            this.sideBarTimer.Tick += new System.EventHandler(this.sideBarTimer_Tick);
            // 
            // panelMenu
            // 
            this.panelMenu.AutoScroll = true;
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(38)))), ((int)(((byte)(77)))));
            this.panelMenu.Controls.Add(this.button1);
            this.panelMenu.Controls.Add(this.panelParametersSubmenu);
            this.panelMenu.Controls.Add(this.btnParamConfig);
            this.panelMenu.Controls.Add(this.btnArticles);
            this.panelMenu.Controls.Add(this.panelInventorySubmenu);
            this.panelMenu.Controls.Add(this.btnInventory);
            this.panelMenu.Controls.Add(this.btnWorkOrders);
            this.panelMenu.Controls.Add(this.btnAppointments);
            this.panelMenu.Controls.Add(this.panelClientsSubmenu);
            this.panelMenu.Controls.Add(this.btnClients);
            this.panelMenu.Controls.Add(this.panel2);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(250, 749);
            this.panelMenu.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(0, 704);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(250, 45);
            this.button1.TabIndex = 14;
            this.button1.Text = "Cerrar sesión";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelParametersSubmenu
            // 
            this.panelParametersSubmenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(45)))), ((int)(((byte)(92)))));
            this.panelParametersSubmenu.Controls.Add(this.button10);
            this.panelParametersSubmenu.Controls.Add(this.button12);
            this.panelParametersSubmenu.Controls.Add(this.button13);
            this.panelParametersSubmenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelParametersSubmenu.Location = new System.Drawing.Point(0, 569);
            this.panelParametersSubmenu.Name = "panelParametersSubmenu";
            this.panelParametersSubmenu.Size = new System.Drawing.Size(250, 129);
            this.panelParametersSubmenu.TabIndex = 13;
            // 
            // button10
            // 
            this.button10.Dock = System.Windows.Forms.DockStyle.Top;
            this.button10.FlatAppearance.BorderSize = 0;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button10.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button10.Location = new System.Drawing.Point(0, 80);
            this.button10.Name = "button10";
            this.button10.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.button10.Size = new System.Drawing.Size(250, 40);
            this.button10.TabIndex = 10;
            this.button10.Text = "Sucursales";
            this.button10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button12
            // 
            this.button12.Dock = System.Windows.Forms.DockStyle.Top;
            this.button12.FlatAppearance.BorderSize = 0;
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button12.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button12.Location = new System.Drawing.Point(0, 40);
            this.button12.Name = "button12";
            this.button12.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.button12.Size = new System.Drawing.Size(250, 40);
            this.button12.TabIndex = 7;
            this.button12.Text = "Catálogo de vehículos";
            this.button12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button12.UseVisualStyleBackColor = true;
            // 
            // button13
            // 
            this.button13.Dock = System.Windows.Forms.DockStyle.Top;
            this.button13.FlatAppearance.BorderSize = 0;
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button13.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button13.Location = new System.Drawing.Point(0, 0);
            this.button13.Name = "button13";
            this.button13.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.button13.Size = new System.Drawing.Size(250, 40);
            this.button13.TabIndex = 6;
            this.button13.Text = "Lista de precios de artículos";
            this.button13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button13.UseVisualStyleBackColor = true;
            // 
            // btnParamConfig
            // 
            this.btnParamConfig.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnParamConfig.FlatAppearance.BorderSize = 0;
            this.btnParamConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnParamConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnParamConfig.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnParamConfig.Location = new System.Drawing.Point(0, 524);
            this.btnParamConfig.Name = "btnParamConfig";
            this.btnParamConfig.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnParamConfig.Size = new System.Drawing.Size(250, 45);
            this.btnParamConfig.TabIndex = 12;
            this.btnParamConfig.Text = "Configurar parámetros";
            this.btnParamConfig.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnParamConfig.UseVisualStyleBackColor = true;
            this.btnParamConfig.Click += new System.EventHandler(this.btnParamConfig_Click);
            // 
            // btnArticles
            // 
            this.btnArticles.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnArticles.FlatAppearance.BorderSize = 0;
            this.btnArticles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArticles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnArticles.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnArticles.Location = new System.Drawing.Point(0, 479);
            this.btnArticles.Name = "btnArticles";
            this.btnArticles.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnArticles.Size = new System.Drawing.Size(250, 45);
            this.btnArticles.TabIndex = 11;
            this.btnArticles.Text = "Artículos";
            this.btnArticles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnArticles.UseVisualStyleBackColor = true;
            // 
            // panelInventorySubmenu
            // 
            this.panelInventorySubmenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(45)))), ((int)(((byte)(92)))));
            this.panelInventorySubmenu.Controls.Add(this.btnSuppliers);
            this.panelInventorySubmenu.Controls.Add(this.btnGoodsIssue);
            this.panelInventorySubmenu.Controls.Add(this.btnGoodsReceipt);
            this.panelInventorySubmenu.Controls.Add(this.btnPurchaseOrder);
            this.panelInventorySubmenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInventorySubmenu.Location = new System.Drawing.Point(0, 308);
            this.panelInventorySubmenu.Name = "panelInventorySubmenu";
            this.panelInventorySubmenu.Size = new System.Drawing.Size(250, 171);
            this.panelInventorySubmenu.TabIndex = 10;
            // 
            // btnSuppliers
            // 
            this.btnSuppliers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSuppliers.FlatAppearance.BorderSize = 0;
            this.btnSuppliers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuppliers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnSuppliers.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSuppliers.Location = new System.Drawing.Point(0, 120);
            this.btnSuppliers.Name = "btnSuppliers";
            this.btnSuppliers.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnSuppliers.Size = new System.Drawing.Size(250, 40);
            this.btnSuppliers.TabIndex = 10;
            this.btnSuppliers.Text = "Proveedores";
            this.btnSuppliers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSuppliers.UseVisualStyleBackColor = true;
            this.btnSuppliers.Click += new System.EventHandler(this.btnSuppliers_Click);
            // 
            // btnGoodsIssue
            // 
            this.btnGoodsIssue.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGoodsIssue.FlatAppearance.BorderSize = 0;
            this.btnGoodsIssue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoodsIssue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnGoodsIssue.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnGoodsIssue.Location = new System.Drawing.Point(0, 80);
            this.btnGoodsIssue.Name = "btnGoodsIssue";
            this.btnGoodsIssue.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnGoodsIssue.Size = new System.Drawing.Size(250, 40);
            this.btnGoodsIssue.TabIndex = 8;
            this.btnGoodsIssue.Text = "Salida de mercancía";
            this.btnGoodsIssue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGoodsIssue.UseVisualStyleBackColor = true;
            // 
            // btnGoodsReceipt
            // 
            this.btnGoodsReceipt.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGoodsReceipt.FlatAppearance.BorderSize = 0;
            this.btnGoodsReceipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoodsReceipt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnGoodsReceipt.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnGoodsReceipt.Location = new System.Drawing.Point(0, 40);
            this.btnGoodsReceipt.Name = "btnGoodsReceipt";
            this.btnGoodsReceipt.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnGoodsReceipt.Size = new System.Drawing.Size(250, 40);
            this.btnGoodsReceipt.TabIndex = 7;
            this.btnGoodsReceipt.Text = "Entrada de mercancía";
            this.btnGoodsReceipt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGoodsReceipt.UseVisualStyleBackColor = true;
            // 
            // btnPurchaseOrder
            // 
            this.btnPurchaseOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPurchaseOrder.FlatAppearance.BorderSize = 0;
            this.btnPurchaseOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPurchaseOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnPurchaseOrder.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPurchaseOrder.Location = new System.Drawing.Point(0, 0);
            this.btnPurchaseOrder.Name = "btnPurchaseOrder";
            this.btnPurchaseOrder.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnPurchaseOrder.Size = new System.Drawing.Size(250, 40);
            this.btnPurchaseOrder.TabIndex = 6;
            this.btnPurchaseOrder.Text = "Orden de compra";
            this.btnPurchaseOrder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPurchaseOrder.UseVisualStyleBackColor = true;
            // 
            // btnInventory
            // 
            this.btnInventory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInventory.FlatAppearance.BorderSize = 0;
            this.btnInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnInventory.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnInventory.Location = new System.Drawing.Point(0, 263);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnInventory.Size = new System.Drawing.Size(250, 45);
            this.btnInventory.TabIndex = 9;
            this.btnInventory.Text = "Inventario";
            this.btnInventory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInventory.UseVisualStyleBackColor = true;
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // btnWorkOrders
            // 
            this.btnWorkOrders.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnWorkOrders.FlatAppearance.BorderSize = 0;
            this.btnWorkOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWorkOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnWorkOrders.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnWorkOrders.Location = new System.Drawing.Point(0, 218);
            this.btnWorkOrders.Name = "btnWorkOrders";
            this.btnWorkOrders.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnWorkOrders.Size = new System.Drawing.Size(250, 45);
            this.btnWorkOrders.TabIndex = 8;
            this.btnWorkOrders.Text = "Órdenes de trabajo";
            this.btnWorkOrders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWorkOrders.UseVisualStyleBackColor = true;
            this.btnWorkOrders.Click += new System.EventHandler(this.btnWorkOrders_Click);
            // 
            // btnAppointments
            // 
            this.btnAppointments.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAppointments.FlatAppearance.BorderSize = 0;
            this.btnAppointments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAppointments.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnAppointments.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAppointments.Location = new System.Drawing.Point(0, 173);
            this.btnAppointments.Name = "btnAppointments";
            this.btnAppointments.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnAppointments.Size = new System.Drawing.Size(250, 45);
            this.btnAppointments.TabIndex = 7;
            this.btnAppointments.Text = "Citas";
            this.btnAppointments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAppointments.UseVisualStyleBackColor = true;
            this.btnAppointments.Click += new System.EventHandler(this.btnAppointments_Click);
            // 
            // panelClientsSubmenu
            // 
            this.panelClientsSubmenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(45)))), ((int)(((byte)(92)))));
            this.panelClientsSubmenu.Controls.Add(this.btnVehicleMasterData);
            this.panelClientsSubmenu.Controls.Add(this.btnClientMasterData);
            this.panelClientsSubmenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelClientsSubmenu.Location = new System.Drawing.Point(0, 90);
            this.panelClientsSubmenu.Name = "panelClientsSubmenu";
            this.panelClientsSubmenu.Size = new System.Drawing.Size(250, 83);
            this.panelClientsSubmenu.TabIndex = 3;
            // 
            // btnVehicleMasterData
            // 
            this.btnVehicleMasterData.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVehicleMasterData.FlatAppearance.BorderSize = 0;
            this.btnVehicleMasterData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVehicleMasterData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnVehicleMasterData.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnVehicleMasterData.Location = new System.Drawing.Point(0, 40);
            this.btnVehicleMasterData.Name = "btnVehicleMasterData";
            this.btnVehicleMasterData.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnVehicleMasterData.Size = new System.Drawing.Size(250, 40);
            this.btnVehicleMasterData.TabIndex = 7;
            this.btnVehicleMasterData.Text = "Dato maestro vehículo";
            this.btnVehicleMasterData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVehicleMasterData.UseVisualStyleBackColor = true;
            this.btnVehicleMasterData.Click += new System.EventHandler(this.btnVehicleMasterData_Click);
            // 
            // btnClientMasterData
            // 
            this.btnClientMasterData.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClientMasterData.FlatAppearance.BorderSize = 0;
            this.btnClientMasterData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientMasterData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnClientMasterData.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnClientMasterData.Location = new System.Drawing.Point(0, 0);
            this.btnClientMasterData.Name = "btnClientMasterData";
            this.btnClientMasterData.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnClientMasterData.Size = new System.Drawing.Size(250, 40);
            this.btnClientMasterData.TabIndex = 6;
            this.btnClientMasterData.Text = "Dato maestro cliente";
            this.btnClientMasterData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientMasterData.UseVisualStyleBackColor = true;
            this.btnClientMasterData.Click += new System.EventHandler(this.btnClientMasterData_Click);
            // 
            // btnClients
            // 
            this.btnClients.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClients.FlatAppearance.BorderSize = 0;
            this.btnClients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClients.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnClients.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnClients.Location = new System.Drawing.Point(0, 45);
            this.btnClients.Name = "btnClients";
            this.btnClients.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnClients.Size = new System.Drawing.Size(250, 45);
            this.btnClients.TabIndex = 6;
            this.btnClients.Text = "Clientes";
            this.btnClients.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClients.UseVisualStyleBackColor = true;
            this.btnClients.Click += new System.EventHandler(this.btnClients_Click);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 45);
            this.panel2.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LubriTech.Properties.Resources.menu1;
            this.pictureBox1.Location = new System.Drawing.Point(260, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // MDI_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(694, 749);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panelMenu);
            this.DoubleBuffered = true;
            this.IsMdiContainer = true;
            this.Name = "MDI_View";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LubriTech";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MDI_View_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelParametersSubmenu.ResumeLayout(false);
            this.panelInventorySubmenu.ResumeLayout(false);
            this.panelClientsSubmenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.Timer sideBarTimer;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelClientsSubmenu;
        private System.Windows.Forms.Button btnClients;
        private System.Windows.Forms.Button btnVehicleMasterData;
        private System.Windows.Forms.Button btnClientMasterData;
        private System.Windows.Forms.Button btnWorkOrders;
        private System.Windows.Forms.Button btnAppointments;
        private System.Windows.Forms.Panel panelInventorySubmenu;
        private System.Windows.Forms.Button btnGoodsIssue;
        private System.Windows.Forms.Button btnGoodsReceipt;
        private System.Windows.Forms.Button btnPurchaseOrder;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Button btnSuppliers;
        private System.Windows.Forms.Button btnArticles;
        private System.Windows.Forms.Panel panelParametersSubmenu;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button btnParamConfig;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}



