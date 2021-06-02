using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace PlateformWithoutMoov
{
    class PanelGame : PictureBox
    {
        public PanelGame()
        {
            this.BackColor = Color.FromArgb(128, 128, 255);
            this.Dock = DockStyle.Bottom;
        }
    }
}
