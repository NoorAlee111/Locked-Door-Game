using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LockedDoor
{
    public partial class End : Form
    {
        public End(Image img)
        {
            InitializeComponent();
            this.BackgroundImage = img;
        }

        private void End_Load(object sender, EventArgs e)
        {
          
        }

        private void Restart_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }
    }
}
