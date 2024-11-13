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
    public partial class LevelChange : Form
    {
        private string Labelstring;
        public LevelChange(Image img,string labeltext)
        {
            InitializeComponent();
            this.BackgroundImage = img;
            this.Labelstring = labeltext;

           
        }

        private void LevelChange_Load(object sender, EventArgs e)
        {
            Restart.Text = Labelstring;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void Restart_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }
    }
}
