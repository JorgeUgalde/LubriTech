using LubriTech.Controller;
using LubriTech.Model.PricesList_Information;
using LubriTech.View.Appointment_View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LubriTech.View
{
    public partial class frmPricesList : Form
    {
        private Form parentForm;
        public event Action<PriceList> PriceListSelected;
        public frmPricesList()
        {
            InitializeComponent();
        }

        public frmPricesList(Form parentForm)
        {
            this.parentForm = parentForm;
            InitializeComponent();
        }

        public void LoadPricesList()
        {
            // Load all price lists
            List<PriceList> priceLists = new PriceList_Controller().getPriceLists();
            dataGridView1.DataSource = priceLists;
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int priceListId = (int)dataGridView1.Rows[e.RowIndex].Cells["id"].Value;
                PriceList selectedPriceList = new PriceList_Controller().getPriceList(priceListId);

                if(parentForm is frmUpsert_Client)
                {
                    ((frmUpsert_Client)parentForm).PriceListSelected(selectedPriceList);
                }
                else
                {
                    frmUpsert_PriceList frmUpsert_PriceList = new frmUpsert_PriceList(priceListId);
                    frmUpsert_PriceList.MdiParent = this.MdiParent;
                    frmUpsert_PriceList.DataChanged += ChildFormDataChangedHandler;
                    frmUpsert_PriceList.Show();

                }

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void ChildFormDataChangedHandler(object sender, EventArgs e)
        {
            LoadPricesList();
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            frmUpsert_PriceList frmUpsert_PriceList = new frmUpsert_PriceList(null);
            frmUpsert_PriceList.MdiParent = this.MdiParent;
            frmUpsert_PriceList.DataChanged += ChildFormDataChangedHandler;
            frmUpsert_PriceList.Show();
        }

        private void frmPricesList_Load(object sender, EventArgs e)
        {
            LoadPricesList();
        }
    }
}
