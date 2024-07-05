﻿using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using LubriTech.Controller;
using LubriTech.Model.Branch_Information;
using LubriTech.Model.Client_Information;
using LubriTech.Model.Item_Information;
using LubriTech.Model.items_Information;
using LubriTech.Model.Vehicle_Information;
using LubriTech.Model.WorkOrder_Information;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Image = System.Drawing.Image;
using Rectangle = System.Drawing.Rectangle;

namespace LubriTech.View
{
    public partial class frmWorkOrder : Form
    {
        PictureBox pictureBoxOpen = new PictureBox();
        int imageId;
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();


        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private int? workOrderId; // Nullable int to store the work order ID
        Work_Order_Controller workOrderController = new Work_Order_Controller();
        Client client = new Client();
        Vehicle vehicle = new Vehicle();
        WorkOrder workOrderTemplate = new WorkOrder();
        List<ObservationPhotos> observationPhotos2;

        public frmWorkOrder(int? workOrderId)
        {
            InitializeComponent();
            this.workOrderId = workOrderId;
            //InitializeTabControl();

            if (workOrderId.HasValue)
            {
                // Load the existing work order
                WorkOrder workOrder = workOrderController.LoadWorkOrder(workOrderId.Value);
                workOrderTemplate = workOrder;
                LoadWorkOrderData(workOrder);
                DataTable workOrderLinesTable = new WorkOrderLine_Model().LoadWorkOrderLinesDT(workOrderId.Value);
                dataGridView1.DataSource = workOrderLinesTable;
                UpdateTotalAmount();
                //dataGridView1.Columns["Identificacion"].Visible = false;
                //dataGridView1.Columns["IdentificacionOrdenTrabajo"].Visible = false;
            }
            else
            {
                // Initialize a new work order
                InitializeNewWorkOrder();
            }
            LoadImages();
        }

        private void LoadWorkOrderData(WorkOrder workOrder)
        {
            //Set the data source of the combo box, State can be 0 for Inactiva 1 for Activa, 2 for En proceso, 3 for Terminada
            cbState.DataSource = new List<KeyValuePair<short, string>>()
            {
                new KeyValuePair<short, string>(0, "Inactiva"),
                new KeyValuePair<short, string>(1, "Activa"),
                new KeyValuePair<short, string>(2, "En proceso"),
                new KeyValuePair<short, string>(3, "Terminada")
            };
            cbState.DisplayMember = "Value";
            cbState.ValueMember = "Key";
            cbState.SelectedIndex = workOrder.State;
            
            cbBranch.DataSource = new Branch_Model().loadAllBranches();
            cbBranch.DisplayMember = "Name";
            cbBranch.ValueMember = "Id";
            cbBranch.SelectedValue = workOrder.Branch.Id;

            dateTimePicker.Value = workOrder.Date;
            //txtDate.Text = workOrder.Date.ToString();
            txtTotalAmount.Text = workOrder.Amount.ToString();

            client = workOrder.Client;
            txtClientId.Enabled = false;
            txtClientId.Text = workOrder.Client.Id.ToString();
            txtClientName.Enabled = false;
            txtClientName.Text = workOrder.Client.FullName.ToString();
            txtCellphone.Enabled = false;
            txtCellphone.Text = workOrder.Client.MainPhoneNum.ToString();
            txtCellphone2.Enabled = false;
            txtCellphone2.Text = workOrder.Client.AdditionalPhoneNum.ToString();
            txtEmail.Enabled = false;
            txtEmail.Text = workOrder.Client.Email.ToString();

            if (workOrder.Vehicle != null)
            {
                vehicle = workOrder.Vehicle;
                txtMake.Enabled = false;
                txtMake.Text = workOrder.Vehicle.Model.Make.ToString();
                txtModel.Enabled = false;
                txtModel.Text = workOrder.Vehicle.Model.ToString() + " " + workOrder.Vehicle.Year;
                txtMileage.Enabled = false;
                txtMileage.Text = workOrder.Vehicle.Mileage.ToString();
                txtCurrentMileage.Text = workOrder.CurrentMileage.ToString();
            }
            else
            {
                txtMake.Text = "NA";
            }
            loadWorkOrderLines(workOrder.Id);
            UpdateTotalAmount();
        }

        //Initialize a new work order
        private void InitializeNewWorkOrder()
        {
            //Set the data source of the combo box, State can be 0 for Inactiva 1 for Activa, 2 for En proceso, 3 for Terminada
            cbState.DataSource = new List<KeyValuePair<short, string>>()
            {
                new KeyValuePair<short, string>(0, "Inactiva"),
                new KeyValuePair<short, string>(1, "Activa"),
                new KeyValuePair<short, string>(2, "En proceso"),
                new KeyValuePair<short, string>(3, "Terminada")
            };
            cbState.DisplayMember = "Value";
            cbState.ValueMember = "Key";
            cbState.SelectedIndex = 1;

            cbBranch.DataSource = new Branch_Model().loadAllBranches();
            cbBranch.DisplayMember = "Name";
            cbBranch.ValueMember = "Id";
            cbBranch.SelectedIndex = 0;

            dateTimePicker.Value = DateTime.Now;
            //txtDate.Text = DateTime.Now.ToString();
            txtTotalAmount.Text = "0";
            txtClientId.Enabled = true;
            txtClientId.Text = "";
            txtClientName.Enabled = true;
            txtClientName.Text = "";
            txtCellphone.Enabled = true;
            txtCellphone.Text = "";
            txtCellphone2.Enabled = true;
            txtCellphone2.Text = "";
            txtEmail.Enabled = true;
            txtEmail.Text = "";
            txtMake.Enabled = true;
            txtMake.Text = "";
            txtModel.Enabled = true;
            txtModel.Text = "";
            txtMileage.Enabled = true;
            txtMileage.Text = "";
            dataGridView1.DataSource = new DataTable();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmWorkOrder_Load(object sender, EventArgs e)
        {

        }

        private void loadWorkOrderLines(int workOrderId)
        {
            dataGridView1.DataSource = new WorkOrderLine_Model().LoadWorkOrderLinesDT(workOrderId);
            dataGridView1.Columns["Identificacion"].Visible = false;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    DataRowView rowView = row.DataBoundItem as DataRowView;

                    if (rowView != null)
                    {
                        // Verificar si la columna modificada es la de CodigoArticulo
                        if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Código Artículo")
                        {
                            // Obtener el código del artículo
                            string itemCode = rowView["Código Artículo"].ToString();

                            // Obtener el artículo desde la base de datos
                            Item item = new Item_Model().getItem(itemCode);

                            // Asignar los valores del artículo a la fila actual
                            if (item != null)
                            {
                                row.Cells["Descripción"].Value = item.name;
                                row.Cells["Precio Unitario"].Value = new PriceList_Controller().getPriceByItem(itemCode, client.PriceList.id);
                                return;
                            }
                        }
                        // Verificar si los valores requeridos no son DBNull
                        bool hasValidValues = rowView["Código Artículo"] != DBNull.Value &&
                                          rowView["Cantidad"] != DBNull.Value &&
                                          rowView["Monto"] != DBNull.Value;

                        if (hasValidValues)
                        {
                            // Hacer el upsert solo si es una fila nueva y tiene todos los valores requeridos
                            bool success = new WorkOrderLine_Model().UpsertWorkOrderLine(rowView.Row);
                            if (!success)
                            {
                                MessageBox.Show("Failed to save changes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        UpdateTotalAmount();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateTotalAmount()
        {
            decimal totalAmount = 0;

            foreach (DataRow row in ((DataTable)dataGridView1.DataSource).Rows)
            {
                if (row["Monto"] != DBNull.Value)
                {
                    totalAmount += Convert.ToDecimal(row["Monto"]);
                }
            }

            txtTotalAmount.Text = totalAmount.ToString("N2"); // Formatear el número como decimal
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DataRowView rowView = e.Row.DataBoundItem as DataRowView;
            if (rowView != null)
            {
                bool success = new WorkOrderLine_Model().DeleteWorkOrderLine((int)rowView["Identificacion"]);
                if (!success)
                {
                    MessageBox.Show("Failed to delete row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true; // Cancel the deletion if the delete operation failed
                }
            }
        }

        private void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["IdentificacionOrdenTrabajo"].Value = workOrderId;
            //e.Row.Cells["IsNewRow"].Value = true;
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

            string errorMessage = e.Exception.Message;
            errorMessage = errorMessage.Replace("nulls", "vacíos");
            MessageBox.Show("Error: " + errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void HandleItemSelected(Item item)
        {
            ShowItemInWorkOrder(item);
        }

        public void ShowItemInWorkOrder(Item item)
        {
            if (item != null)
            {
                // Obtener la fila actualmente seleccionada
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[rowIndex];

                // Asignar los valores del artículo seleccionado a la fila actual
                row.Cells["Código Artículo"].Value = item.code;
                row.Cells["Descripción"].Value = item.name;
                row.Cells["Precio Unitario"].Value = new PriceList_Controller().getPriceByItem(item.code,client.PriceList.id);
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Código Artículo"].Index && e.RowIndex >= 0)
            {
                //Validate if the cell already has a button
                if (e.Value != null && e.Value.ToString() == "...")
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                    e.Handled = true;
                    return;
                }
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                // Crear el botón
                Button btn = new Button();
                btn.Text = "...";
                btn.Size = new Size(13, e.CellBounds.Height - 8);

                // Calcular la posición del botón
                var buttonWidth = btn.Width;
                var buttonHeight = btn.Height;
                var x = e.CellBounds.Left + e.CellBounds.Width - buttonWidth - 5;
                var y = e.CellBounds.Top + (e.CellBounds.Height - buttonHeight) / 2;


                // Dibujar el botón en la celda
                e.Graphics.FillRectangle(Brushes.White, x, y, buttonWidth, buttonHeight);
                e.Graphics.DrawRectangle(Pens.Black, x, y, buttonWidth, buttonHeight);
                TextRenderer.DrawText(e.Graphics, "...", btn.Font, new Rectangle(x, y, buttonWidth, buttonHeight), btn.ForeColor);

                e.Handled = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Código Artículo"].Index && e.RowIndex >= 0)
            {
                // Verificar si el clic ocurrió en el botón
                var rect = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                var buttonWidth = 20;
                var x = rect.Right - buttonWidth - 2;

                if (dataGridView1.PointToClient(Cursor.Position).X >= x)
                {
                    dataGridView1.EndEdit(); // Finalizar la edición de la celda actual

                    frmItems frmItems = new frmItems(this);
                    frmItems.ItemSelected += HandleItemSelected;
                    frmItems.MdiParent = this.MdiParent;
                    frmItems.Show();
                }
            }
        }

        private void HandleClientSelected(Client selectedClient)
        {
            SelectClientWorkOrder(selectedClient);
        }

        public void SelectClientWorkOrder(Client selectedClient)
        {
            if (selectedClient != null)
            {
                this.client = selectedClient;
                txtClientId.Text = selectedClient.Id.ToString();
                txtClientName.Text = selectedClient.FullName;
                txtCellphone.Text = selectedClient.MainPhoneNum == null ? "NA" : selectedClient.MainPhoneNum.ToString();
                txtCellphone2.Text = selectedClient.AdditionalPhoneNum == null ? "NA" : selectedClient.AdditionalPhoneNum.ToString();
                txtEmail.Text = selectedClient.Email == null ? "NA" : selectedClient.Email;
                txtMake.Text = "";
                txtModel.Text = "";
                txtMileage.Text = "";
            }

            if (client.Id is null)
            {
                return;
            }
            if (workOrderId.HasValue)
            {
                WorkOrder existingWorkOrder = new WorkOrder();
                existingWorkOrder.Id = (int)workOrderId;
                existingWorkOrder.Branch = cbBranch.SelectedItem as Branch;
                existingWorkOrder.Date = dateTimePicker.Value;
                existingWorkOrder.State = (short)cbState.SelectedIndex;
                existingWorkOrder.Amount = Convert.ToDecimal(txtTotalAmount.Text);
                existingWorkOrder.Client = client;
                workOrderController.UpsertWorkOrder(existingWorkOrder);
            }
            else
            {
                WorkOrder workOrder = new WorkOrder();
                workOrder.Id = 0;
                workOrder.Branch = cbBranch.SelectedItem as Branch;
                workOrder.Date = dateTimePicker.Value;
                workOrder.State = (short)cbState.SelectedValue;
                workOrder.Amount = Convert.ToDecimal(txtTotalAmount.Text);
                workOrder.Client = client;

                this.workOrderId = workOrderController.UpsertWorkOrder(workOrder);
                loadWorkOrderLines(workOrderId.Value);
                dataGridView1.Refresh();
            }
        }

        private void btnSelectClient_Click(object sender, EventArgs e)
        {
            frmClients frmClients = new frmClients(this);
            frmClients.ClientSelected += HandleClientSelected;
            frmClients.MdiParent = this.MdiParent;
            frmClients.Show();

        }

        private void HandleVehicleSelected(Vehicle vehicle)
        {
            SelectVehicleWorkOrder(vehicle);
        }


        public void SelectVehicleWorkOrder(Vehicle vehicle)
        {
            if (vehicle != null)
            {
                txtMake.Text = vehicle.Model.Make.ToString();
                txtModel.Text = vehicle.Model.ToString() + " " + vehicle.Year;
                txtMileage.Text = vehicle.Mileage.ToString();
            }

            if (client != null)
            {
                WorkOrder existingWorkOrder = new WorkOrder();
                existingWorkOrder.Id = (int)workOrderId;
                existingWorkOrder.Branch = cbBranch.SelectedItem as Branch;
                existingWorkOrder.Date = dateTimePicker.Value;
                existingWorkOrder.State = (short)cbState.SelectedIndex;
                existingWorkOrder.Amount = Convert.ToDecimal(txtTotalAmount.Text);
                existingWorkOrder.Client = client;
                existingWorkOrder.Vehicle = vehicle;
                workOrderController.UpsertWorkOrder(existingWorkOrder);
            }
            else
            {
                WorkOrder workOrder = new WorkOrder();
                workOrder.Id = 0;
                workOrder.Branch = cbBranch.SelectedItem as Branch;
                workOrder.Date = dateTimePicker.Value;
                workOrder.State = (short)cbState.SelectedValue;
                workOrder.Amount = Convert.ToDecimal(txtTotalAmount.Text);
                workOrder.Client = client;
                workOrder.Vehicle = vehicle;

                this.workOrderId = workOrderController.UpsertWorkOrder(workOrder);
                loadWorkOrderLines(workOrderId.Value);
                dataGridView1.Refresh();
            }
        }
        private void btnAddVehicle_Click(object sender, EventArgs e)
        {
            if(client == null)
            {
                MessageBox.Show("Por favor seleccione un cliente primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmVehicles frmVehicles = new frmVehicles(this,this.client.Id);
            frmVehicles.VehicleSelected += HandleVehicleSelected;
            frmVehicles.MdiParent = this.MdiParent;
            frmVehicles.Show();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (this.workOrderId.HasValue && this.client != null)
            {
                WorkOrder workOrder = new Work_Order_Controller().LoadWorkOrder(workOrderId.Value);
                workOrder.Branch = cbBranch.SelectedItem as Branch;
                workOrder.Date = dateTimePicker.Value;
                workOrder.State = (short)cbState.SelectedIndex;
                workOrder.Amount = Convert.ToDecimal(txtTotalAmount.Text);

                if(this.vehicle != null && txtCurrentMileage.Text != "")
                {

                    workOrder.CurrentMileage = Convert.ToInt32(txtCurrentMileage.Text);
                    this.vehicle.Mileage = Convert.ToInt32(txtCurrentMileage.Text);
                    new Vehicle_Controller().upsert(this.vehicle);
                }
                if(new Work_Order_Controller().UpdateWorkOrder(workOrder))
                {
                    this.Dispose();
                    MessageBox.Show("Cambios guardados exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione un cliente primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadImages()
        {
            tabPage2.Controls.Clear();

            List<ObservationPhotos> observationPhotos = new ObservationPhotos_Controller().GetAll(6);
            observationPhotos2 = observationPhotos;
            List<byte[]> images = observationPhotos.Select(op => op.Photo).ToList();
            
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.FlowDirection = FlowDirection.TopDown; 
            flowLayoutPanel.WrapContents = true;
            flowLayoutPanel.AutoScroll = true;
            this.Controls.Add(flowLayoutPanel);

            foreach (var photo in observationPhotos)
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.Width = 200; 
                pictureBox.Height = 150;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                if (photo.Photo != null)
                {
                    using (MemoryStream ms = new MemoryStream(photo.Photo))
                    {
                        pictureBox.Tag = photo;
                        pictureBox.Image = Image.FromStream(ms);
                    }
                }

                pictureBox.MouseEnter += (sender, e) => pictureBox.Cursor = Cursors.Hand;

                pictureBox.Click += (sender, e) =>
                {
                    pictureBoxOpen = pictureBox;
                    PictureBox_Click(sender, e);
                   
                };

                flowLayoutPanel.Controls.Add(pictureBox);
            }
            tabPage2.Controls.Add(flowLayoutPanel);

        }

        private void ChildFormDataChangedHandler(object sender, EventArgs e)
        {
            LoadImages();
        }
        private void PictureBox_Click(object sender, EventArgs e)
        {
            ObservationPhotos observationPhoto = pictureBoxOpen.Tag as ObservationPhotos;

            if (pictureBoxOpen.Image != null)
            {
                int observationPhotoId = observationPhoto.Id;
                // Crear una instancia de frmImage y pasar la imagen
                frmImage frmImage = new frmImage(pictureBoxOpen.Image, observationPhotoId);
                frmImage.MdiParent = this.MdiParent;
                frmImage.DataChanged += ChildFormDataChangedHandler;
                frmImage.Show(); 
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                int Tamanio = (int)openFileDialog1.OpenFile().Length;
                byte[] ImagenOriginal = new byte[Tamanio];

                using (BinaryReader reader = new BinaryReader(openFileDialog1.OpenFile()))
                {
                    reader.Read(ImagenOriginal, 0, Tamanio);
                }
                new ObservationPhotos_Controller().Upsert(6, ImagenOriginal);
            }
            LoadImages();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = "Archivos de Pdf|*.pdf";
            savefile.FileName = string.Format(DateTime.Now.ToString("ddMMyyyyHHmmss"));

            string PaginaHTML_Texto = Properties.Resources.Template.ToString();
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@BRANCH", workOrderTemplate.Branch.Name);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@DATE", workOrderTemplate.Date.ToString());

            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@ID", client.Id);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@NAME", client.FullName);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@MAINPHONE", client.MainPhoneNum.ToString());
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@ADDITIONALPHONE", client.AdditionalPhoneNum.ToString());
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@EMAIL", client.Email);

            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@LICENSEPLATE", vehicle.LicensePlate);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@MAKE", workOrderTemplate.Vehicle.Model.Make.ToString());
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@MODEL", vehicle.Model + " " + vehicle.Year);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@MILEAGE", vehicle.Mileage.ToString());
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@CURRENTMILEAGE", workOrderTemplate.CurrentMileage.ToString());

            string htmlTable = "<table border='1'><tr>";

            // Agrega las cabeceras de las columnas
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                htmlTable += "<th>" + column.HeaderText + "</th>";
            }
            htmlTable += "</tr>";

            // Agrega las filas y celdas de datos
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                htmlTable += "<tr>";
                foreach (DataGridViewCell cell in row.Cells)
                {
                    htmlTable += "<td>" + cell.Value?.ToString() + "</td>"; // Agrega el valor de la celda como contenido de <td>
                }
                htmlTable += "</tr>";
            }

            // Cierra la tabla HTML
            htmlTable += "</table>";

            // Reemplaza @TABLA_PRODUCTOS en PaginaHTML_Texto con la tabla HTML generada
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@TABLA_PRODUCTOS", htmlTable);




            //string imagenesHTML = string.Empty;

            //foreach (var photo in observationPhotos2)
            //{
            //    string base64Image = Convert.ToBase64String(photo.Photo);
            //    imagenesHTML += $"<img src=\"data:image/png;base64,{base64Image}\" alt=\"Observation Photo\" />";
            //}

            //// Ahora reemplazamos @IMAGENES en PaginaHTML_Texto con imagenesHTML
            //PaginaHTML_Texto = PaginaHTML_Texto.Replace("@IMAGENES", imagenesHTML);

            //< img src = "data:image/png;base64,@image" alt = "Observation Photo" />



            if (savefile.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                {
                    //Creamos un nuevo documento y lo definimos como PDF
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);

                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    pdfDoc.Add(new Phrase(""));

                    //pdfDoc.Add(new Phrase("Hola Mundo"));
                    using (StringReader sr = new StringReader(PaginaHTML_Texto))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }

                    pdfDoc.Close();
                    stream.Close();
                }


            }
        }
    }
}