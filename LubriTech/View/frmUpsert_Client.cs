using LubriTech.Controller;
using LubriTech.Model.Client_Information;
using System;
using System.Windows.Forms;

namespace LubriTech.View
{
    public partial class frmUpsert_Client : Form
    {
        public frmUpsert_Client()
        {
            InitializeComponent();
        }

        private void btnSaveClient_Click(object sender, EventArgs e)
        {
            try
            {

                if (!string.IsNullOrEmpty(this.txtFullName.Text) ||
                    !string.IsNullOrEmpty(this.txtMainPhone.Text) ||
                    !string.IsNullOrEmpty(this.txtAdditionalPhone.Text) ||
                    !string.IsNullOrEmpty(this.txtEmail.Text) ||
                    !string.IsNullOrEmpty(this.txtAddresse.Text))
                {
                    Clients_Controller clientsController = new Clients_Controller();

                    string id = this.txtID.Text.Trim();
                    string fullname = this.txtFullName.Text.Trim();
                    int mainPhone = Convert.ToInt32(this.txtMainPhone.Text.Trim());
                    int additionalPhone = Convert.ToInt32(this.txtAdditionalPhone.Text.Trim());
                    string email = this.txtEmail.Text.Trim();
                    string addresse = this.txtAddresse.Text.Trim();
                    Client client = new Client(id, fullname, mainPhone, additionalPhone, email, addresse);
                    clientsController.saveClient(client);

                    MessageBox.Show("Cliente registrado correctamente", "Confirmado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Ingrese todos los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUpsert_Client_Load(object sender, EventArgs e)
        {
            Vehicle_Controller vehicleController = new Vehicle_Controller();
            dgvVehiclesClients.DataSource = vehicleController.getAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmNewVehicle frmNewVehicle = new frmNewVehicle();
            frmNewVehicle.ShowDialog();
        }
    }
}
