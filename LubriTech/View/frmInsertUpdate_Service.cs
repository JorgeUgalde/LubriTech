using LubriTech.Controller;
using LubriTech.Model.Service_Information;
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
    public partial class frmInsertUpdate_Service : Form
    {
        private Service newService;
        public frmInsertUpdate_Service()
        {
            InitializeComponent();
        }

        public frmInsertUpdate_Service(Service serviceToUpdate)
        {
            InitializeComponent();
            loadService(serviceToUpdate);
            
        }

        private void loadService(Service servicetoUpdate)
        {
            newService = new Service();
            newService.ID = servicetoUpdate.ID;
            txtName.Text = servicetoUpdate.name;
            txtPrice.Text = servicetoUpdate.price.ToString();

        }

        public event EventHandler DataChanged;

        protected virtual void OnDataChanged(EventArgs e)
        {
            DataChanged?.Invoke(this, e);
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (newService == null)
            {
                newService = new Service();
            }
            newService.name = txtName.Text;
            newService.price = Convert.ToDouble(txtPrice.Text);
            new Service_Controller().Upsert(newService);
            OnDataChanged(EventArgs.Empty);
            this.Close();

        }
    }
}
