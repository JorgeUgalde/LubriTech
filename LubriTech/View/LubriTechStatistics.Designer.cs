namespace LubriTech.View
{
    partial class LubriTechStatistics
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartWorkOrders = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartWorkOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // chartWorkOrders
            // 
            chartArea1.Name = "ChartArea1";
            this.chartWorkOrders.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartWorkOrders.Legends.Add(legend1);
            this.chartWorkOrders.Location = new System.Drawing.Point(52, 95);
            this.chartWorkOrders.Name = "chartWorkOrders";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Ordenes de Trabajo";
            this.chartWorkOrders.Series.Add(series1);
            this.chartWorkOrders.Size = new System.Drawing.Size(600, 300);
            this.chartWorkOrders.TabIndex = 0;
            this.chartWorkOrders.Text = "chart1";
            // 
            // LubriTechStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chartWorkOrders);
            this.Name = "LubriTechStatistics";
            this.Text = "LubriTechStatistics";
            this.Load += new System.EventHandler(this.LubriTechStatistics_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartWorkOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartWorkOrders;
    }
}