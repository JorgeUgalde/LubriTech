namespace LubriTech.View
{
    partial class frmInsertUpdateSupplier
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
            this.btUpsert = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.panelId = new System.Windows.Forms.Panel();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.panelEmail = new System.Windows.Forms.Panel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.panelName = new System.Windows.Forms.Panel();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.panelPhone = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registrar o modificar Proveedor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(150, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Código";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(475, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nombre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(150, 239);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Correo electrónico";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(475, 239);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Número telefónico";
            // 
            // btUpsert
            // 
            this.btUpsert.Location = new System.Drawing.Point(337, 361);
            this.btUpsert.Name = "btUpsert";
            this.btUpsert.Size = new System.Drawing.Size(75, 23);
            this.btUpsert.TabIndex = 5;
            this.btUpsert.Text = "Agregar";
            this.btUpsert.UseVisualStyleBackColor = true;
            this.btUpsert.Click += new System.EventHandler(this.btUpsert_Click);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(155, 159);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(100, 20);
            this.txtId.TabIndex = 6;
            this.txtId.TextChanged += new System.EventHandler(this.txtId_TextChanged);
            // 
            // panelId
            // 
            this.panelId.Location = new System.Drawing.Point(153, 158);
            this.panelId.Name = "panelId";
            this.panelId.Size = new System.Drawing.Size(103, 23);
            this.panelId.TabIndex = 10;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(157, 265);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(100, 20);
            this.txtEmail.TabIndex = 11;
            // 
            // panelEmail
            // 
            this.panelEmail.Location = new System.Drawing.Point(155, 264);
            this.panelEmail.Name = "panelEmail";
            this.panelEmail.Size = new System.Drawing.Size(103, 23);
            this.panelEmail.TabIndex = 12;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(480, 159);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 13;
            // 
            // panelName
            // 
            this.panelName.Location = new System.Drawing.Point(478, 158);
            this.panelName.Name = "panelName";
            this.panelName.Size = new System.Drawing.Size(103, 23);
            this.panelName.TabIndex = 14;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(480, 266);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(100, 20);
            this.txtPhone.TabIndex = 15;
            // 
            // panelPhone
            // 
            this.panelPhone.Location = new System.Drawing.Point(478, 265);
            this.panelPhone.Name = "panelPhone";
            this.panelPhone.Size = new System.Drawing.Size(103, 23);
            this.panelPhone.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(475, 184);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 13);
            this.label7.TabIndex = 18;
            // 
            // frmInsertUpdateSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.panelPhone);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.panelName);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.panelEmail);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.btUpsert);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelId);
            this.Name = "frmInsertUpdateSupplier";
            this.Text = "frmInsertUpdateSupplier";
            this.Load += new System.EventHandler(this.frmInsertUpdateSupplier_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btUpsert;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Panel panelId;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Panel panelEmail;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Panel panelName;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Panel panelPhone;
        private System.Windows.Forms.Label label7;
    }
}