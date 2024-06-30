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
    public partial class ItemCellEditor : UserControl
    {
        public TextBox TextBox { get; private set; }
        public Button Button { get; private set; }

        public ItemCellEditor()
        {
            InitializeComponent();
            TextBox = new TextBox { Dock = DockStyle.Fill, BorderStyle = BorderStyle.None };
            Button = new Button { Text = "...", Dock = DockStyle.Right, Width = 30 };

            this.Controls.Add(TextBox);
            this.Controls.Add(Button);
        }
    }
}
