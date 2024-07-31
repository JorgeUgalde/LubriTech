using LubriTech.Model.WorkOrder_Information;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace LubriTech.View
{
    public partial class LubriTechStatistics : Form
    {
        public LubriTechStatistics()
        {
            InitializeComponent();
        }

        private void LubriTechStatistics_Load(object sender, EventArgs e)
        {
            LoadWorkOrderChart();
        }

        private void LoadWorkOrderChart()
        {
            List<WorkOrder> workOrders = new WorkOrder_Model().loadWorkOrders();
            var groupedWorkOrders = workOrders.GroupBy(wo => new { wo.Date.Date, wo.State })
                                              .Select(g => new
                                              {
                                                  Date = g.Key.Date,
                                                  State = g.Key.State,
                                                  Count = g.Count()
                                              })
                                              .OrderBy(g => g.Date);

            // Crear un diccionario para almacenar la cantidad de órdenes por fecha y estado
            var workOrderDict = new Dictionary<DateTime, Dictionary<short, int>>();

            foreach (var item in groupedWorkOrders)
            {
                if (!workOrderDict.ContainsKey(item.Date))
                {
                    workOrderDict[item.Date] = new Dictionary<short, int> { { 0, 0 }, { 1, 0 }, { 2, 0 }, { 3, 0 } };
                }
                workOrderDict[item.Date][item.State] = item.Count;
            }

            // Añadir datos a la serie del gráfico
            foreach (var date in workOrderDict.Keys.OrderBy(d => d))
            {
                chartWorkOrders.Series["Ordenes de Trabajo"].Points.AddXY(date, workOrderDict[date][0]);
                chartWorkOrders.Series["Ordenes de Trabajo"].Points.AddXY(date, workOrderDict[date][1]);
                chartWorkOrders.Series["Ordenes de Trabajo"].Points.AddXY(date, workOrderDict[date][2]);
                chartWorkOrders.Series["Ordenes de Trabajo"].Points.AddXY(date, workOrderDict[date][3]);
            }

            // Personalizar el gráfico
            chartWorkOrders.Series["Ordenes de Trabajo"].XValueType = ChartValueType.Date;
            chartWorkOrders.ChartAreas[0].AxisX.LabelStyle.Format = "dd/MM/yyyy";
            chartWorkOrders.ChartAreas[0].AxisX.Interval = 1;
            chartWorkOrders.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Days;
        }
    }
}
