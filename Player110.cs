using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace PlateformWithoutMoov
{
   public  class Player:PictureBox
    {
        public bool left { get; set; }
        public bool right { get; set; }
        public bool Jump { get; set; }
       
        public int G { get; set; }
        public int speed { get; set; } = 5;
        public int jumpspeed { get; set; }
        public int score { get; set; } = 0;


        public Player() {
            this.SizeMode = (PictureBoxSizeMode)SizeType.Absolute;
            this.BackColor = Color.FromArgb(128, 128, 255);
        }




        
        
        public string collisionPlatform1()
        {//attention si on veut utiliser cette methode dans form1 le "this.parent.control " devient Player1.parent.controls"
            string m = "-1";
            string a = "1";
           
                    foreach (Control item in this.Parent.Controls)
                    {
                       
                         if (item is Control)
                           {
                          
                                if ((string)item.Tag == "PlateForm")
                                    {
                                
                                    if (this.Bounds.IntersectsWith(item.Bounds))
                                        {
                                            this.G = 8;
                        
                                            this.Top = item.Top - this.Height;
                                            // Jump = false;
                                            m = a;
                                              
                                            return m;
                                         }
                                         
                                        //    item.BringToFront();
                            }
                        }
                    }
             
            return m;
        }
     
      

        public string movement()
        {
            
            //left
          string i = "0", j = "0", k = "0";  
           
            
            // string a = "0,0,0";
            if (this.left == true)
            {
                this.Left -= speed;
                i = "1";
            }
            
            
            //rigth
            if (this.right == true)
            {
                this.Left += speed;
                j = "1";
            }
            
            
            //jump
            //G=gravité quand qu'on est sur une plateform la G =8,quand jump =true G diminue de -1 à chaque tick
            //quand G=0 jump =false on ne saute plus et jumpseed=5 et donc le joueur redescend.
           
           this.Top += this.jumpspeed;
           
            
            if (this.Jump && this.G < 0)
            {
                this.Jump = false;
                k = "0";
            }
            
            
            
            else if (this.Jump)
            {
                this.jumpspeed = -7;
                this.G -= 1;
                k = "1";
            
            }

            else
            {
                this.jumpspeed = 5;
              
                k = "2";
            }
         
            return  i + ":" + j + ":" + k ;
        }
    }
}
