using LubriTech.Controller;
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
    public partial class frmUpsert_Make_Model : Form
    {
        Make make;
        CarModel carModel;
        string mode;
        string action;

        public frmUpsert_Make_Model( string action , string mode)
        {
            InitializeComponent();
            make = new Make();
            carModel = new CarModel();

            this.mode = mode;
            this.action = action;


            if (mode == "Make")
            {
                this.Text = "Gestion de Marca";
                lblMake.Visible = false;
                cbMakes.Visible = false;

                Point point = cbState.Location;
                point.Y += 70;
                btnConfirm.Location = point;
                btnClose.Location = new Point(point.X, point.Y += 70);
                this.Size = new Size(this.MaximumSize.Width, this.MaximumSize.Height - 98);
            }
            else
            {
                this.Text = "Gestion de Modelo";
                cbMakes.DataSource = null;
                loadMakes();
            }


            
        }

        public frmUpsert_Make_Model(Make make, string action)
        {
            InitializeComponent();
            this.Text = "Gestion de Marca";

            lblMake.Visible = false;
            cbMakes.Visible = false;

            this.mode = "Make";
            this.action = action;
            this.make = make;
            txtName.Text = make.Name;
            cbState.SelectedIndex = cbState.FindStringExact(make.State);

            if (action == "Details")
            {          
                btnConfirm.Visible = false;

                txtName.Enabled = false;
                cbState.Enabled = false;
                cbMakes.Enabled = false;

                Point point = cbState.Location;
                point.Y += 70;
                btnClose.Location = point;
                this.Size = MinimumSize;
            } else
            {
                Point point = cbState.Location;
                point.Y += 70;
                btnConfirm.Location = point;
                btnClose.Location = new Point(point.X, point.Y += 70);
                this.Size = new Size(this.MaximumSize.Width, this.MaximumSize.Height - 98);

            }

        }

        public frmUpsert_Make_Model(CarModel carModel, string action)
        {
            InitializeComponent();
            this.Text = "Gestion de Modelo";
            mode = "Model";
            this.action = action;
            this.carModel = carModel;
            cbMakes.DataSource = null;
            loadMakes();
            txtName.Text = carModel.Name;
            cbState.SelectedIndex = cbState.FindStringExact(carModel.State);
            cbMakes.SelectedIndex = cbMakes.FindStringExact(carModel.Make.Name);

            if (action == "Details")
            {
                btnConfirm.Visible = false;

                txtName.Enabled = false;
                cbState.Enabled = false;
                cbMakes.Enabled = false;

                Point point = cbMakes.Location;
                point.Y += 70;
                btnClose.Location = point;
                this.Size = new Size(this.MaximumSize.Width, this.MaximumSize.Height - 49);
            }
            

        }


        private void frmUpsert_Make_Model_Load(object sender, EventArgs e)
        {
           
        }

        public event EventHandler DataChanged;

        // Method to raise the event
        protected virtual void OnDataChanged(EventArgs e)
        {
            DataChanged?.Invoke(this, e);
        }

        // create a funtion to load all the makes to cbMakes
        private void loadMakes()
        {
            List<Make> makes = new Make_Controller().getAll();
            cbMakes.DataSource = makes;
            cbMakes.DisplayMember = "Name";
            cbMakes.ValueMember = "Id";
        }

        private void btnConfirm_Click_1(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Debe ingresar un nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cbState.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar un estado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (mode == "Make")
            {
                if (make == null)
                {
                    make = new Make();
                }

                make.Name = txtName.Text;
                make.State = cbState.Text;

                if (new Make_Controller().upsertMake(make))
                {
                    MessageBox.Show("Marca guardada con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OnDataChanged(EventArgs.Empty);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al guardar la marca", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (carModel == null)
                {
                    carModel = new CarModel();
                }

                carModel.Name = txtName.Text;
                carModel.State = cbState.Text;

                if (action == "Insert")
                {
                    if (cbMakes.SelectedItem == null)
                    {
                        MessageBox.Show("Debe seleccionar una marca", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }                    
                }
                carModel.Make = (Make)cbMakes.SelectedItem;

                if (new CarModel_Controller().upsert(carModel))
                {
                    MessageBox.Show("Modelo guardado con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OnDataChanged(EventArgs.Empty);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al guardar el modelo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
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
    }
}
