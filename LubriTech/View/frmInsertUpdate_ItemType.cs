using LubriTech.Controller;
using LubriTech.Model.Item_Information;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LubriTech.View
{
    public partial class frmInsertUpdate_ItemType : Form
    {

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();


        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private ItemType itemType;
        public frmInsertUpdate_ItemType()
        {
            InitializeComponent();
            itemType = new ItemType();
        }

        public frmInsertUpdate_ItemType(ItemType itemType)
        {
            InitializeComponent();
            this.itemType = itemType;
            txtItemType.Text = itemType.Name;
            cbState.Text = itemType.State;
        }

        // Define a custom event
        public event EventHandler DataChanged;

        // Method to raise the event
        protected virtual void OnDataChanged(EventArgs e)
        {
            DataChanged?.Invoke(this, e);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtItemType.Text == "")
            {
                MessageBox.Show("Debe ingresar un nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cbState.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar un estado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            itemType.Name = txtItemType.Text;
            itemType.State = cbState.Text;

            if (new ItemType_Controller().UpsertItemType(itemType))
            {
                MessageBox.Show("Tipo de artículo registrado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OnDataChanged(EventArgs.Empty);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al registrar el tipo de artículo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void panelBorder_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
