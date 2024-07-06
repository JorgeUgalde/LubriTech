using LubriTech.Controller;
using LubriTech.Model.WorkOrder_Information;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LubriTech.View
{
    public partial class frmInsertUpsert_Observation : Form
    {
        List<ObservationPhotos> observationPhotos2;
        PictureBox pictureBoxOpen = new PictureBox();
        Observation o = new Observation();
        public event EventHandler ObservationChanged;

        public frmInsertUpsert_Observation(Observation observation)
        {
            o = observation;
            InitializeComponent();
            LoadImages();
            txtCode.Text = observation.Code.ToString();
            txtCode.Enabled = false;
            txtDescription.Text = observation.Description;
        }

        public frmInsertUpsert_Observation(Observation observation, string mode)
        {
            InitializeComponent();
            LoadImages();
            observation = new Observation_Controller().Upsert(observation);
            o= observation;
            if (observation != null)
            {
                txtCode.Text = observation.Code.ToString();
                txtCode.Enabled = false;
                txtDescription.Text = observation.Description;
            }
            else
            {
                MessageBox.Show("Failed to insert or update the observation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtCode.Text) || !string.IsNullOrEmpty(this.txtDescription.Text))
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    int fileSize = (int)openFileDialog1.OpenFile().Length;
                    byte[] imageBytes = new byte[fileSize];

                    // Leer la imagen seleccionada en bytes
                    using (BinaryReader reader = new BinaryReader(openFileDialog1.OpenFile()))
                    {
                        reader.Read(imageBytes, 0, fileSize);
                    }


                    // Llamar al método Upsert en ObservationPhotos_Controller pasando el ID de la observación y los bytes de la imagen
                    new ObservationPhotos_Controller().Upsert(o.Code, imageBytes);
                }

                // Recargar las imágenes después de realizar el upsert
                LoadImages();
            }

        }

        private void LoadImages()
        {
            panel1.Controls.Clear();

            List<ObservationPhotos> observationPhotos = new ObservationPhotos_Controller().GetAll(o.Code);
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
            panel1.Controls.Add(flowLayoutPanel);
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

        private void btnAccept_Click(object sender, EventArgs e)
        {
            string description = this.txtDescription.Text.Trim();
            o.Description = description;
            o = new Observation_Controller().Upsert(o);
            ObservationChanged?.Invoke(this, EventArgs.Empty);


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
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
