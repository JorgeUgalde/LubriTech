namespace LubriTech.View
{
    partial class Vehicles
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
            this.dgvVehicles = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicles)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvVehicles
            // 
            this.dgvVehicles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVehicles.Location = new System.Drawing.Point(77, 53);
            this.dgvVehicles.Name = "dgvVehicles";
            this.dgvVehicles.Size = new System.Drawing.Size(654, 351);
            this.dgvVehicles.TabIndex = 0;
            // 
            // Vehicles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvVehicles);
            this.Name = "Vehicles";
            this.Text = "Vehicles";
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVehicles;
    }
}