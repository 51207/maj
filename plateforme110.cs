using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace PlateformWithoutMoov
{
    class PlateForm : PictureBox
    {
        public string TagName { get; set; } = "PlateForm";
        public Random r = new Random();
        private int Lsize { get { return r.Next(180, 185); } }
        private int Hsize { get { return r.Next(27,36); } }
        public PlateForm()
        {
            this.Image = Properties.Resources.plateform2;
            this.SizeMode = (PictureBoxSizeMode)SizeType.Absolute;
            this.Size = new Size(Lsize, Hsize);
            this.BackColor = Color.FromArgb(128, 128,255);
            this.Tag = TagName;
        }
    }
}
