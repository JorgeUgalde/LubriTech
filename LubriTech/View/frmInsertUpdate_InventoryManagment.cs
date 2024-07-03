﻿using LubriTech.Controller;
using LubriTech.Model.Branch_Information;
using LubriTech.Model.Client_Information;
using LubriTech.Model.InventoryManagment_Information;
using LubriTech.Model.Supplier_Information;
using LubriTech.Model.Vehicle_Information;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LubriTech.View
{
    public partial class frmInsertUpdate_InventoryManagment : Form
    {
        private List<Supplier> suppliers;
        private List<Branch> branches;
        private Supplier selectedSupplier = null;
        private List<DetailLine> detailLines;
        private InventoryManagment existingInventoryManagment = null;

        public frmInsertUpdate_InventoryManagment()
        {
            suppliers = new List<Supplier>();
            branches = new Branch_Controller().getAll();
            detailLines = new List<DetailLine>();
            InitializeComponent();
            setComboBox();
            tbSupplierName.Enabled = false;
            tbTotalAmount.Enabled = false;
        }

        public frmInsertUpdate_InventoryManagment(InventoryManagment inventoryManagment)
        {
            suppliers = new List<Supplier>();
            branches = new Branch_Controller().getAll();
            detailLines = new DetailLine_Controller().getDetailLines(inventoryManagment.Id);
            existingInventoryManagment = inventoryManagment;
            InitializeComponent();
            setComboBox();

            tbSupplierName.Text = inventoryManagment.Supplier.name;
            tbSupplierId.Text = inventoryManagment.Supplier.id;
            cbBranch.Text = inventoryManagment.Branch.Name;
            cbDay.Text = inventoryManagment.DocumentDate.Day.ToString();
            cbMonth.Text = inventoryManagment.DocumentDate.Month.ToString();
            cbYear.Text = inventoryManagment.DocumentDate.Year.ToString();
            cbDocumentType.Text = inventoryManagment.DocumentType;
            cbState.Text = inventoryManagment.State;
            //tbTotalAmount.Text = calculateTotalAmount().ToString();
            tbTotalAmount.Enabled = false;

            load_DetailLines(detailLines);
        }

        private void frmInsertUpdateInventoryManagment_Load(object sender, EventArgs e)
        {
            if (existingInventoryManagment != null)
            {
                DetailLine_Controller detailLine_Controller = new DetailLine_Controller();
                detailLines = detailLine_Controller.getDetailLines(existingInventoryManagment.Id);
            }

            load_DetailLines(detailLines);
        }

        private void load_DetailLines(List<DetailLine> filteredList)
        {
            if (filteredList != null)
            {
                if (filteredList.Count == 0)
                {
                    dgvDetailLines.DataSource = detailLines;

                }
                else
                {
                    dgvDetailLines.DataSource = filteredList;
                }
            }
            else
            {
                detailLines = new DetailLine_Controller().getAll();
                if (detailLines == null)
                {
                    MessageBox.Show("No hay líneas de detalle en esta gestión de inventario", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                dgvDetailLines.DataSource = detailLines;
            }
            dgvDetailLines.DataSource = detailLines;
            dgvDetailLines.Columns["InventoryManagment"].Visible = false;
            dgvDetailLines.Columns["Item"].HeaderText = "Artículo";
            dgvDetailLines.Columns["Quantity"].HeaderText = "Cantidad";
            dgvDetailLines.Columns["Amount"].HeaderText = "Monto";
            tbTotalAmount.Text = calculateTotalAmount().ToString();
            SetColumnOrder();
        }

        private void SetColumnOrder()
        {
            dgvDetailLines.Columns["Item"].DisplayIndex = 0;
            dgvDetailLines.Columns["Quantity"].DisplayIndex = 1;
            dgvDetailLines.Columns["Amount"].DisplayIndex = 2;
        }

        public event EventHandler DataChanged;

        protected virtual void OnDataChanged(EventArgs e)
        {
            DataChanged?.Invoke(this, e);
        }

        private void ChildFormDataChangedHandler(object sender, EventArgs e)
        {
            branches = new Branch_Controller().getAll();
            setComboBox();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            InventoryManagment_Controller inventoryManagmentController = new InventoryManagment_Controller();

            if (cbDay.Text.Trim() == ""
            || cbMonth.Text.Trim() == ""
            || cbYear.Text.Trim() == ""
            || cbBranch.Text.Trim() == ""
            || cbDocumentType.Text.Trim() == ""
            || cbState.Text.Trim() == ""
            || tbSupplierName.Text.Trim() == "")
            {
                MessageBox.Show("Por favor llene todos los campos");
            }
            else if (tbSupplierId.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar un proveedor");
            }
            else
            {
                InventoryManagment inventoryManagment = new InventoryManagment();
                inventoryManagment.Supplier = new Supplier_Controller().GetSupplier(tbSupplierId.Text.Trim());
                inventoryManagment.Branch = new Branch_Controller().get(Convert.ToInt32(cbBranch.SelectedValue.ToString()));
                string date = cbYear.Text.Trim() + "/" + cbMonth.Text.Trim() + "/" + cbDay.Text.Trim();
                inventoryManagment.DocumentDate = Convert.ToDateTime(date);
                inventoryManagment.DocumentType = cbDocumentType.Text;
                inventoryManagment.State = cbState.Text;
                if (tbTotalAmount.Text.Trim() != "")
                {
                    inventoryManagment.TotalAmount = Convert.ToDouble(tbTotalAmount.Text.Trim());
                }
                else
                {
                    inventoryManagment.TotalAmount = 0;
                }

                if(existingInventoryManagment != null)
                {
                    inventoryManagment.Id = existingInventoryManagment.Id;
                }

                int insertedId = inventoryManagmentController.upsert(inventoryManagment);

                if (insertedId != -1)
                {
                    OnDataChanged(EventArgs.Empty);
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("El manejo de inventario no se ha agregado correctamente");
                }
            }

        }

        private double calculateTotalAmount()
        {
            double totalAmount = 0;
            if (dgvDetailLines.Rows.Count > 0 && !dgvDetailLines.Rows[0].IsNewRow)
            {
                foreach (DataGridViewRow row in dgvDetailLines.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        double amount = Convert.ToDouble(row.Cells["Amount"].Value);

                        totalAmount += amount;
                    }
                }
                return totalAmount;
            }
            return totalAmount;
        }

        private void tbNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void setComboBox()
        {
            cbBranch.DataSource = branches;
            cbBranch.ValueMember = "Id";
            cbBranch.DisplayMember = "Name";
            cbBranch.SelectedIndex = -1;
        }

        private void btnSelectSupplier_Click(object sender, EventArgs e)
        {
            frmSuppliers frmSupplier = new frmSuppliers(this);
            frmSupplier.SupplierSelected += HandleSupplierSelected;
            frmSupplier.MdiParent = this.MdiParent;
            frmSupplier.Show();
        }

        private void HandleSupplierSelected(Supplier selectedSupplier)
        {
            ShowSupplierInUpsertInventoryManagment(selectedSupplier);
        }

        public void ShowSupplierInUpsertInventoryManagment(Supplier supplier)
        {
            if (supplier != null)
            {
                tbSupplierName.Text = supplier.name;
                tbSupplierId.Text = supplier.id;
            }


        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();


        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelControlBox_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void pbMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btnAddDetailLine_Click(object sender, EventArgs e)
        {
            if (existingInventoryManagment == null)
            {
                if (cbDay.Text.Trim() == ""
                || cbMonth.Text.Trim() == ""
                || cbYear.Text.Trim() == ""
                || cbBranch.Text.Trim() == ""
                || cbDocumentType.Text.Trim() == ""
                || cbState.Text.Trim() == ""
                || tbSupplierName.Text.Trim() == "")
                {
                    MessageBox.Show("Por favor llene los campos anteriores");
                }
                else if (tbSupplierId.Text.Trim() == "")
                {
                    MessageBox.Show("Debe seleccionar un proveedor");
                }
                else
                {
                    InventoryManagment_Controller inventoryManagmentController = new InventoryManagment_Controller();
                    InventoryManagment inventoryManagment = new InventoryManagment();

                    inventoryManagment.Supplier = new Supplier_Controller().GetSupplier(tbSupplierId.Text.Trim());
                    inventoryManagment.Branch = new Branch_Controller().get(Convert.ToInt32(cbBranch.SelectedValue.ToString()));
                    string date = cbYear.Text.Trim() + "/" + cbMonth.Text.Trim() + "/" + cbDay.Text.Trim();
                    inventoryManagment.DocumentDate = Convert.ToDateTime(date);
                    inventoryManagment.DocumentType = cbDocumentType.Text;
                    inventoryManagment.State = cbState.Text;
                    if (tbTotalAmount.Text.Trim() != "")
                    {
                        inventoryManagment.TotalAmount = Convert.ToDouble(tbTotalAmount.Text.Trim());
                    }
                    else
                    {
                        inventoryManagment.TotalAmount = 0;
                    }

                    existingInventoryManagment = inventoryManagment;
                    int insertedId = inventoryManagmentController.upsert(inventoryManagment);
                    existingInventoryManagment.Id = insertedId;

                    if (insertedId != -1)
                    {
                        OnDataChanged(EventArgs.Empty);
                        frmInsertUpdate_DetailLine frmUpsert_DetailLine = new frmInsertUpdate_DetailLine(insertedId);
                        frmUpsert_DetailLine.MdiParent = this.MdiParent;
                        frmUpsert_DetailLine.DataChanged += ChildFormDataChangedHandler;
                        frmUpsert_DetailLine.FormClosed += FrmUpsert_DetailLine_FormClosed;
                        frmUpsert_DetailLine.Show();
                    }
                    else
                    {
                        MessageBox.Show("Error con el manejo de inventario");
                    }
                }
            }
            else
            {
                OnDataChanged(EventArgs.Empty);
                frmInsertUpdate_DetailLine frmUpsert_DetailLine = new frmInsertUpdate_DetailLine(existingInventoryManagment.Id);
                frmUpsert_DetailLine.MdiParent = this.MdiParent;
                frmUpsert_DetailLine.DataChanged += ChildFormDataChangedHandler;
                frmUpsert_DetailLine.FormClosed += FrmUpsert_DetailLine_FormClosed;
                frmUpsert_DetailLine.Show();
            }
        }

        private void FrmUpsert_DetailLine_FormClosed(object sender, FormClosedEventArgs e)
        {
            detailLines = new DetailLine_Controller().getDetailLines(existingInventoryManagment.Id);
            load_DetailLines(detailLines);
        }
    }
}