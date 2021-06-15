using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing;

namespace PlateformWithoutMoov
{
    class Coin : PictureBox
    {
        Random r = new Random();

        public string TagCo { get; set; }
        public string TagCoin { get; set; } = "Coin";
        public Coin()
        {
            Random r = new Random();

            changeImage(r.Next(1, 5));




            this.SizeMode = (PictureBoxSizeMode)SizeType.Absolute;
            this.BackColor = Color.FromArgb(128, 128, 255);
            this.Tag = TagCoin;
            this.Size = new Size(30, 30);
            this.AccessibleName = TagCo;
        }

       private void changeImage(int i)
        {
            switch (i)
            {
                case 1:
                    this.Image = Properties.Resources.door;
                    this.TagCo = "door";
                    break;
                case 2:
                    this.Image = Properties.Resources.coin2;
                    this.TagCo = "coin+1";
                    break;
                case 3:
                    this.Image = Properties.Resources.coin5;
                    this.TagCo = "coin-1";
                    break;
                case 4:
                    this.Image = Properties.Resources.coin8;
                    this.TagCo = "coin+3";
                    break;
                default:
                    this.Image = Properties.Resources.coin1;
                    this.TagCo = "coin+2";

                    break;
            }
            


        }
    }
}
