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

namespace LubriTech.View
{
    public partial class frmImage : Form
    {
        int IdToRemove;
        public frmImage(Image image, int Id)
        {
            IdToRemove = Id;
            InitializeComponent();
            pbImage.SizeMode = PictureBoxSizeMode.StretchImage;
            pbImage.Image = image;
            this.Controls.Add(pbImage);
        }

        public event EventHandler DataChanged;

        /// <summary>
        /// Invoca el evento DataChanged para notificar a los suscriptores de que los datos han cambiado.
        /// </summary>
        /// <param name="e">Argumentos del evento.</param>
        protected virtual void OnDataChanged(EventArgs e)
        {
            DataChanged?.Invoke(this, e);
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

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            new ObservationPhotos_Controller().Delete(IdToRemove);
            OnDataChanged(EventArgs.Empty);
            this.Dispose();
        }
    }
}
