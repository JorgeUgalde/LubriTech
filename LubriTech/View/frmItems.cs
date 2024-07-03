using LubriTech.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LubriTech.Model.Supplier_Information;
using LubriTech.Model.Item_Information;
using System.Runtime.InteropServices;
using LubriTech.View.Appointment_View;
using LubriTech.Model.InventoryManagment_Information;
using System.Reflection;

namespace LubriTech.View
{
    public partial class frmItems : Form
    {
        //private List<Item> items;
        //private Form parentForm;
        //public event Action<Supplier> ItemSelected;

        //public frmItems()
        //{
        //    items = new List<Item>();
        //    InitializeComponent();
        //    load_Items(null);

        //}

        ////Para manejar el item seleccionado
        //public frmItems(Form parentForm)
        //{
        //    items = new List<Item>();
        //    this.parentForm = parentForm;
        //    InitializeComponent();
        //    load_Items(null);

        //}

        //private void frmItems_Load(object sender, EventArgs e)
        //{
        //    txtFilter.TextChanged += new EventHandler(txtFilter_TextChanged);
        //}

        //private void load_Items(List<Item> filteredList)
        //{
        //    if (filteredList != null)
        //    {
        //        if (filteredList.Count == 0)
        //        {
        //            dgvItems.DataSource = items;

        //        }
        //        else
        //        {
        //            dgvItems.DataSource = filteredList;
        //        }
        //    }
        //    else
        //    {
        //        items = new Supplier_Controller().getAll();
        //        if (items.Count == 0)
        //        {
        //            MessageBox.Show("No hay proveedores registrados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            return;
        //        }
        //        dgvItems.DataSource = items;

        //    }
        //    dgvItems.Columns["id"].HeaderText = "Codigo";
        //    dgvItems.Columns["name"].HeaderText = "Nombre";
        //    dgvItems.Columns["email"].HeaderText = "Correo electrónico";
        //    dgvItems.Columns["phone"].HeaderText = "Teléfono";
        //    SetColumnOrder();

        //    typeof(DataGridView).InvokeMember(
        //        "DoubleBuffered",
        //        BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
        //        null,
        //        dgvSuppliers,
        //        new object[] { true });
        //}


        //private void ChildFormDataChangedHandler(object sender, EventArgs e)
        //{
        //    load_Items(null);
        //}


        //private void txtFilter_TextChanged(object sender, EventArgs e)
        //{
        //    ApplyFilter();
        //}


        //private void btnAddSupplier_Click(object sender, EventArgs e)
        //{
        //    frmInsertUpdateSupplier frmInsertUpdateSupplier = new frmInsertUpdateSupplier();
        //    frmInsertUpdateSupplier.MdiParent = this.MdiParent;
        //    frmInsertUpdateSupplier.DataChanged += ChildFormDataChangedHandler;
        //    frmInsertUpdateSupplier.Show();
        //}


        //private void ApplyFilter()
        //{
        //    string filterValue = txtFilter.Text.ToLower();

        //    // Filtrar la lista de proveedores
        //    var filteredList = items.Where(p =>
        //    p.id.ToLower().Contains(filterValue) ||
        //    p.name.ToLower().Contains(filterValue) ||
        //    p.email.ToLower().Contains(filterValue) ||
        //    p.phone.ToString().Contains(filterValue)
        //    ).ToList();

        //    // Refrescar el DataGridView
        //    dgvSuppliers.DataSource = null;
        //    load_Suppliers(filteredList);
        //}


        //private void SetColumnOrder()
        //{
        //    dgvSuppliers.Columns["id"].DisplayIndex = 0;
        //    dgvSuppliers.Columns["name"].DisplayIndex = 1;
        //    dgvSuppliers.Columns["email"].DisplayIndex = 2;
        //    dgvSuppliers.Columns["phone"].DisplayIndex = 3;
        //}


        //private void btnClose_Click(object sender, EventArgs e)
        //{
        //    this.Dispose();
        //}

        //private void dgvSuppliers_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    if (e.RowIndex >= 0)
        //    {
        //        string supplierId = dgvSuppliers.Rows[e.RowIndex].Cells["id"].Value.ToString();
        //        List<Supplier> suppliers = new Supplier_Controller().getAll();
        //        Supplier selectedSupplier = suppliers.FirstOrDefault(supplier => supplier.id == supplierId);

        //        if (selectedSupplier != null)
        //        {
        //            if (parentForm is frmInsertUpdate_InventoryManagment)
        //            {
        //                ((frmInsertUpdate_InventoryManagment)parentForm).ShowSupplierInUpsertInventoryManagment(selectedSupplier);
        //                this.Close();
        //            }
        //            else
        //            {
        //                frmInsertUpdateSupplier frmInsertUpdateSupplier = new frmInsertUpdateSupplier(selectedSupplier);
        //                frmInsertUpdateSupplier.MdiParent = this.MdiParent;
        //                frmInsertUpdateSupplier.DataChanged += ChildFormDataChangedHandler;
        //                frmInsertUpdateSupplier.Show();
        //                load_Items(null);
        //            }
        //        }
        //    }
        //}

        //private void pbClose_Click(object sender, EventArgs e)
        //{
        //    this.Dispose();
        //}

        //private void pbMaximize_Click(object sender, EventArgs e)
        //{
        //    if (this.WindowState == FormWindowState.Normal)
        //    {
        //        this.WindowState = FormWindowState.Maximized;
        //    }
        //    else
        //    {
        //        this.WindowState = FormWindowState.Normal;
        //    }

        //}

        //private void pbMinimize_Click(object sender, EventArgs e)
        //{
        //    this.WindowState = FormWindowState.Normal;

        //}

        //private void pbMaximize_Click_1(object sender, EventArgs e)
        //{
        //    if (this.WindowState == FormWindowState.Normal)
        //    {
        //        this.WindowState = FormWindowState.Maximized;
        //    }
        //    else
        //    {
        //        this.WindowState = FormWindowState.Normal;
        //    }
        //}

        //private void pbClose_Click_1(object sender, EventArgs e)
        //{
        //    this.Dispose();
        //}

        //[DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        //private extern static void ReleaseCapture();


        //[DllImport("user32.DLL", EntryPoint = "SendMessage")]
        //private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        //private void panelBorder_MouseDown(object sender, MouseEventArgs e)
        //{
        //    ReleaseCapture();
        //    SendMessage(this.Handle, 0x112, 0xf012, 0);
        //}
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private List<Item> items;
        private Form parentForm;
        public event Action<Item> ItemSelected;

        public frmItems()
        {
            items = new List<Item>();
            InitializeComponent();
            load_Items(null);
        }

        public frmItems(Form parentForm)
        {
            items = new List<Item>();
            this.parentForm = parentForm;
            InitializeComponent();
            load_Items(null);
        }

        private void frmItems_Load(object sender, EventArgs e)
        {
            txtFilter.TextChanged += new EventHandler(txtFilter_TextChanged);
        }

        private void load_Items(List<Item> filteredList)
        {
            if (filteredList != null)
            {
                if (filteredList.Count == 0)
                {
                    dgvItems.DataSource = items;

                }
                else
                {
                    dgvItems.DataSource = filteredList;
                }
            }
            else
            {
                items = new Item_Controller().getAll();
                if (items.Count == 0)
                {
                    MessageBox.Show("No hay artículos resgistrados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                dgvItems.DataSource = items;
            }
            dgvItems.Columns["code"].HeaderText = "Código";
            dgvItems.Columns["name"].HeaderText = "Nombre";
            dgvItems.Columns["purchasePrice"].HeaderText = "Precio Compra";
            dgvItems.Columns["measureUnit"].HeaderText = "Unidad Medida";
            dgvItems.Columns["state"].HeaderText = "Estado";
            dgvItems.Columns["type"].HeaderText = "Tipo";
            dgvItems.Columns["stock"].Visible = false;
            dgvItems.Columns["recommendedServiceInterval"].Visible = false;

            SetColumnOrder();

            typeof(DataGridView).InvokeMember(
                "DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                null,
                dgvItems,
                new object[] { true });
        }

        private void ChildFormDataChangedHandler(object sender, EventArgs e)
        {
            load_Items(null);
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            frmInsertUpdate_Item frmInsertUpdateItem = new frmInsertUpdate_Item();
            frmInsertUpdateItem.MdiParent = this.MdiParent;
            frmInsertUpdateItem.DataChanged += ChildFormDataChangedHandler;
            frmInsertUpdateItem.Show();
        }

        private void ApplyFilter()
        {
            string filterValue = txtFilter.Text.ToLower();

            // Filtrar la lista de artículos
            var filteredList = items.Where(p =>
                p.code.ToString().ToLower().Contains(filterValue) ||
                p.name.ToString().ToLower().Contains(filterValue) ||
                p.purchasePrice.ToString().ToLower().Contains(filterValue) ||
                p.measureUnit.ToString().ToLower().Contains(filterValue) ||
                p.state.ToString().ToLower().Contains(filterValue) ||
                p.type.ToString().ToLower().Contains(filterValue)
            ).ToList();

            // Refrescar el DataGridView
            dgvItems.DataSource = null;
            load_Items(filteredList);
        }

        private void SetColumnOrder()
        {
            dgvItems.Columns["code"].DisplayIndex = 0;
            dgvItems.Columns["name"].DisplayIndex = 1;
            dgvItems.Columns["measureUnit"].DisplayIndex = 2;
            dgvItems.Columns["type"].DisplayIndex = 3;
            dgvItems.Columns["purchasePrice"].DisplayIndex = 4;
            dgvItems.Columns["state"].DisplayIndex = 5;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dgvItems_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string selectedCode = dgvItems.Rows[e.RowIndex].Cells["code"].Value.ToString();
                List<Item> items = new Item_Controller().getAll();
                Item selectedItem = items.FirstOrDefault(item => item.code == selectedCode);

                if (selectedItem != null)
                {
                    if (parentForm is frmInsertUpdate_DetailLine)
                    {
                        ((frmInsertUpdate_DetailLine)parentForm).ShowItemInDetailLine(selectedItem);
                        this.Close();
                    }
                    else
                    {
                        frmInsertUpdate_Item frmInsertUpdateItem = new frmInsertUpdate_Item(selectedItem);
                        frmInsertUpdateItem.MdiParent = this.MdiParent;
                        frmInsertUpdateItem.DataChanged += ChildFormDataChangedHandler;
                        frmInsertUpdateItem.Show();
                        load_Items(null);
                    }
                }
            }
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

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();


        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panelBorder_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //private List<Item> items;
        //private Form parentForm;

        //public event Action<Item> ItemSelected;

        //public frmItems()
        //{
        //    InitializeComponent();
        //    items = new List<Item>();
        //    SetupDataGridView();
        //    load_Items(null);
        //}

        //public frmItems(Form parentForm)
        //{
        //    items = new List<Item>();
        //    this.parentForm = parentForm;
        //    InitializeComponent();
        //    SetupDataGridView();
        //    load_Items(null);
        //}

        //// **************************************** Filtrado inicio  ***************************************************//

        //// ************************* crear lista de lo que hacen, en mi caso la linea 18 tiene la lista de productos global


        //private void load_Items(List<Item> filteredList)
        //{
        //    if (filteredList != null)
        //    {
        //        if (filteredList.Count == 0)
        //        {
        //            dgvItems.DataSource = items.Select(p => new
        //            {
        //                code = p.code,
        //                name = p.name,
        //                measureUnit = p.measureUnit,
        //                state = p.state,
        //                type = p.type
        //            }).ToList();

        //        }
        //        else
        //        {
        //            dgvItems.DataSource = filteredList.Select(p => new
        //            {
        //                code = p.code,
        //                name = p.name,
        //                measureUnit = p.measureUnit,
        //                state = p.state,
        //                type = p.type
        //            }).ToList();
        //        }
        //    }
        //    else
        //    {
        //        items = new Item_Controller().getAll();

        //        // dont show all the columns, only show the columns that are needed
        //        dgvItems.DataSource = items.Select(p => new
        //        {
        //            code = p.code,
        //            name = p.name,
        //            measureUnit = p.measureUnit,
        //            state = p.state,
        //            type = p.type
        //        }).ToList();


        //    }
        //    dgvItems.Columns["code"].HeaderText = "Código";
        //    dgvItems.Columns["name"].HeaderText = "Nombre";
        //    //dgvItems.Columns["sellPrice"].HeaderText = "Precio Venta";
        //    dgvItems.Columns["measureUnit"].HeaderText = "Unidad Medida";
        //    dgvItems.Columns["state"].HeaderText = "Estado";
        //    dgvItems.Columns["type"].HeaderText = "Tipo";
        //    SetColumnOrder();
        //}

        //private void SetColumnOrder()
        //{
        //    dgvItems.Columns["code"].DisplayIndex = 0;
        //    dgvItems.Columns["name"].DisplayIndex = 1;
        //    //dgvItems.Columns["sellPrice"].DisplayIndex = 2;
        //    dgvItems.Columns["measureUnit"].DisplayIndex = 2;
        //    dgvItems.Columns["state"].DisplayIndex = 3;
        //    dgvItems.Columns["type"].DisplayIndex = 4;
        //    dgvItems.Columns["ModifyImageColumn"].DisplayIndex = 5;
        //    dgvItems.Columns["DetailImageColumn"].DisplayIndex = 6;
        //}

        //private void txtFilter_TextChanged(object sender, EventArgs e)
        //{
        //    ApplyFilter();
        //}

        //private void ApplyFilter()
        //{
        //    string filterValue = txtFilter.Text.ToLower();

        //    // Filtrar la lista de productos
        //    var filteredList = items.Where(p =>
        //        p.code.ToLower().Contains(filterValue) ||
        //        p.name.ToLower().Contains(filterValue) ||
        //        p.measureUnit.ToLower().Contains(filterValue)
        //    ).ToList();

        //    // Refrescar el DataGridView
        //    dgvItems.DataSource = null;
        //    load_Items(filteredList);
        //}
        ////**************************************** Filtrado final ***************************************************//

        //private void SetupDataGridView()
        //{
        //    // Modify button column
        //    DataGridViewImageColumn modifyImageColumn = new DataGridViewImageColumn();
        //    modifyImageColumn.Name = "ModifyImageColumn";
        //    modifyImageColumn.HeaderText = "Modificar";
        //    modifyImageColumn.Image = Properties.Resources.edit;
        //    dgvItems.Columns.Add(modifyImageColumn);

        //    DataGridViewImageColumn detailImageColumn = new DataGridViewImageColumn();
        //    detailImageColumn.Name = "DetailImageColumn";
        //    detailImageColumn.HeaderText = "Detalles";
        //    detailImageColumn.Image = Properties.Resources.detail;
        //    dgvItems.Columns.Add(detailImageColumn);
        //}

        //private void btnAddItem_Click(object sender, EventArgs e)
        //{
        //    frmInsertUpdate_Item frmInsertProduct = new frmInsertUpdate_Item();
        //    frmInsertProduct.MdiParent = this.MdiParent;
        //    frmInsertProduct.DataChanged += ChildFormDataChangedHandler;
        //    this.WindowState = FormWindowState.Normal;
        //    frmInsertProduct.Show();
        //}

        //private void ChildFormDataChangedHandler(object sender, EventArgs e)
        //{
        //    load_Items(null);
        //}

        //private void dgvItems_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.ColumnIndex == dgvItems.Columns["ModifyImageColumn"].Index && e.RowIndex >= 0)
        //    {
        //        string idToModify = dgvItems.Rows[e.RowIndex].Cells["code"].Value.ToString();
        //        Item itemSelected = new Item_Controller().get(idToModify);

        //        frmInsertUpdate_Item frmUpsert = new frmInsertUpdate_Item(itemSelected, 1);
        //        frmUpsert.MdiParent = this.MdiParent;
        //        this.WindowState = FormWindowState.Normal;
        //        frmUpsert.DataChanged += ChildFormDataChangedHandler;
        //        frmUpsert.Show();
        //        return;
        //    }

        //    if (e.ColumnIndex == dgvItems.Columns["DetailImageColumn"].Index && e.RowIndex >= 0)
        //    {
        //        string idOfDetails = dgvItems.Rows[e.RowIndex].Cells["code"].Value.ToString();
        //        Item itemSelected = new Item_Controller().get(idOfDetails);

        //        frmInsertUpdate_Item frmUpsert = new frmInsertUpdate_Item(itemSelected, 0);
        //        frmUpsert.MdiParent = this.MdiParent;
        //        this.WindowState = FormWindowState.Normal;
        //        frmUpsert.DataChanged += ChildFormDataChangedHandler;
        //        frmUpsert.Show();

        //        return;

        //    }

        //}

        //private void btnClose_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}

        //private void pbMaximize_Click(object sender, EventArgs e)
        //{
        //    if (this.WindowState == FormWindowState.Normal)
        //    {
        //        this.WindowState = FormWindowState.Maximized;
        //    }
        //    else
        //    {
        //        this.WindowState = FormWindowState.Normal;
        //    }
        //}

        //private void pbClose_Click(object sender, EventArgs e)
        //{
        //    this.Dispose();
        //}

        //[DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        //private extern static void ReleaseCapture();


        //[DllImport("user32.DLL", EntryPoint = "SendMessage")]
        //private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        //private void panelBorder_MouseDown(object sender, MouseEventArgs e)
        //{
        //    ReleaseCapture();
        //    SendMessage(this.Handle, 0x112, 0xf012, 0);
        //}

        //private void dgvItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex >= 0)
        //    {
        //        string code = dgvItems.Rows[e.RowIndex].Cells["code"].Value.ToString();
        //        Item item = new Item_Controller().get(code);

        //        if (parentForm is frmWorkOrder)
        //        {
        //            ((frmWorkOrder)parentForm).ShowItemInWorkOrder(item);
        //            this.Close();
        //        }
        //        else if (parentForm is frmUpsert_PriceList)
        //        {
        //            ((frmUpsert_PriceList)parentForm).ShowItemInPriceList(item);
        //            this.Close();
        //        }
        //        else
        //        {
        //            frmInsertUpdate_Item frmInsertProduct = new frmInsertUpdate_Item(item, 0);
        //            frmInsertProduct.MdiParent = this.MdiParent;
        //            frmInsertProduct.DataChanged += ChildFormDataChangedHandler;
        //            frmInsertProduct.Show();
        //            load_Items(null);
        //        }
        //    }
        //}
    }
}
