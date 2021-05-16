using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
namespace PlateformWithoutMoov
{
    public partial class Form1 : Form
    {
        // player id
        int playersID ;
        int Nbresdejoueurs = 3;
        public List<Player> listdesplayers0 = new List<Player>();
        public void lalistedesplayers()
        {
            listdesplayers0.Add(player1);
            listdesplayers0.Add(player2);
            listdesplayers0.Add(player3);
            
        }


        public void checkbresdeplayers( int i)
        {
         /*  if(i == 1)
            {
                i = 2;
               
            }
            
            else if(i >= 2 && i< listdesplayers0.Count)
            {
                for (int a = i + 1; a < listdesplayers0.Count; a++)
                {
                    listdesplayers0.ElementAt(i).Visible = false;

                }

            }*/
           



            
        }


        Socket listen;
      
        public void initializesocket()
        {
            try
            {
                IPAddress ip = IPAddress.Parse("192.168.1.5");
                int port = 8001;
                IPEndPoint local = new IPEndPoint(ip, port);
                listen = new Socket(SocketType.Stream, ProtocolType.Tcp);
                //  IAsyncResult result= listen.BeginConnect(local,null , null);
                listen.Connect(local);
                Console.WriteLine("client connexion");


                byte[] bufid = new byte[1024];

                int bytecodeid = listen.Receive(bufid);


                string msg = Encoding.ASCII.GetString(bufid, 0, bytecodeid);

                string[] ID = msg.Split(':');

                //ID[1]= correspond à la valeur de l'id qui peut être soit 1 soit 0   ID[0]= nom de l'id qui est ID 
                //puis on convertit en int la valeur de l'ID
                playersID = int.Parse(ID[1]);
            //   int Nbresde = int.Parse(ID[2]);

             //   checkbresdeplayers(Nbresde);



            }
           
            catch (Exception e) { Console.WriteLine(e.Message); }
        }

     //   private int Score { get; set; }
      
        Coin door = new Coin();
        public event EventHandler<EventScore> Win;
        
        





        
        
        public Form1()
        {   


            InitializeComponent();
            
            
            //on initialise la liste des players 
            lalistedesplayers();

            //on initialise les sockets
            initializesocket();
            

            //on initialise les scores de la liste de score (pour le player 1 et pour le player 2
          for (int i =0; i<listdesplayers0.Count; i++)
            {
                listScoreplayers.Add(0);
            }
          //  listScoreplayers.Add(0);
           // listScoreplayers.Add(0);

           

        }


     



        //***** game over *****
        public void GameOver()
        {

            if (listdesplayers0[playersID].Top + listdesplayers0[playersID].Height > this.ClientSize.Height)
            {

                // important: la gravité est 8 
                int Score = listScoreplayers[0];
                int Score2 = listScoreplayers[1];
                labelscore.Text = "Score : " + Score.ToString();
               labelscoreother.Text = "Score : " + Score2.ToString();

                timer.Stop();
                
                
                if (MessageBox.Show("Vous avez perdu. " + Environment.NewLine + labelscore.Text + " Points " +"and" + labelscore.Text + "Score : " + Score2.ToString() +"points " ,"Game Over", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Application.Restart();
                   // Restart();
                }
                
                
                else
                {
                    Environment.Exit(1);
                }

            }
        }





        //****** Restart ******
        private void Restart()
        {
            listdesplayers0[playersID].Jump = false;

            listdesplayers0[playersID].left = false;

            listdesplayers0[playersID].right = false;
            
           int Score = 0;
            
            labelscore.Text = "Score : " + Score.ToString();


            // renitialisation des scores (players)

            listScoreplayers[0] = 0;
            listScoreplayers[1] = 0;




            foreach (Control x in this.Controls)
            {

                if (x is PictureBox && x.Visible == false)
                {
                    x.Visible = true;
               
                }
                
                coin11.Location = new Point(97, 250);
                
                coin8.Location = new Point(25, 135);
                
                coin14.Location = new Point(221, 135);
                
                coin1.Location = new Point(353, 50);
                
                coin2.Location = new Point(519, 112);
                
                
                coin13.Location = new Point(718, 112);
                
                coin7.Location = new Point(609, 250);
                
                coin15.Location = new Point(403, 323);
                
                player1.Location = new Point(200, 0);
                
                timer.Start();

            }

        }




        public List<int> listScoreplayers = new List<int>();
       





        //***** collisions coins ******
   


      





        public Random r = new Random(0);





        //**** collision player 1

        public string collisionCoinsPlayer1()
        {
            string s = "100"; string q = "100"; int a = 0; int b = 0; 

          //  Random r = new Random(0);


          // List<Player> listplayers = new List<Player>();


           // listplayers.Add(player1);
            
                int Score = listScoreplayers.ElementAt(playersID);


                foreach (Control item in listdesplayers0[playersID].Parent.Controls)
                {


                    if (item is Coin)
                    {



                        if ((string)item.Tag == "Coin")
                        {


                            if (Score < 40)
                            {
                                coin3.Visible = false;
                            }
                            else
                            {
                                coin3.Visible = true;
                                coin3.Location = new Point(233, 50);
                            }


                        // listdesplayers0[playersID+1]% nombredejoueur 
                        if (listdesplayers0[playersID].Bounds.IntersectsWith(item.Bounds))
                            {
                                 a = r.Next(10, (listdesplayers0[(playersID)%Nbresdejoueurs].Parent.ClientSize.Width - 50));
                                 b = r.Next(43, (listdesplayers0[(playersID ) % Nbresdejoueurs].Parent.ClientSize.Height - 50));
                                item.Location = new Point(a, b);

                                s = a.ToString();
                                q = b.ToString();

                           
                                
                            
                            if (item.AccessibleName == "coin-1")
                                {


                                    if (Score < 30)
                                    {
                                    //  Score -= 1;


                                    //element i de la liste : on retire 1 point au joueur i

                                    //  listScoreplayers[0] -= 1; = players1[0] -= 1;

                                    listScoreplayers[(playersID ) % Nbresdejoueurs] -= 1;

                                }

                                    else if (Score > 30)

                                    {

                                    //Score -= 4; 


                                    // listScoreplayers[0] -= 4;

                                    listScoreplayers[(playersID) % Nbresdejoueurs] -= 4;
                                    }

                                }



                                if (item.AccessibleName == "coin+1")
                                {
                                //Score += 1;
                                // listScoreplayers[0] += 1;
                               
                                listScoreplayers[(playersID) % Nbresdejoueurs] += 1;


                            }



                                if (item.AccessibleName == "coin+2")
                                {
                                //    Score += 2;
                                //  listScoreplayers[0] += 2;
                                listScoreplayers[(playersID) % Nbresdejoueurs] += 2;

                            }



                                if (item.AccessibleName == "coin+3")
                                {
                                //    Score += 3; 
                                //   listScoreplayers[0] += 3;
                               
                                listScoreplayers[(playersID ) % Nbresdejoueurs] += 3;

                                }




                                labelscore.Text = "score :" + Score.ToString(); ;

                                if (listdesplayers0[playersID % Nbresdejoueurs].Bounds.IntersectsWith(item.Bounds) && (Score >= 30))
                              
                                 {

                                    EventScore eventScore = new EventScore();

                                    eventScore.WinScore = "On va corser un peu plus le choses";

                                    labelscore30.Text = eventScore.WinScore;
                                }

                                }

                          item.BringToFront();



                            if (listdesplayers0[playersID % Nbresdejoueurs].Bounds.IntersectsWith(coin3.Bounds) && Score >= 40)
                            {


                                if (coin3.AccessibleName == "door")
                                {

                                    timerlabel1.stoptimer();
                                    timer.Stop();


                                    if (MessageBox.Show("You win avec un score de :" + labelscore.Text + Environment.NewLine + "et un temps de :" + "" + timerlabel1.Text, "Game Finish", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                    {
                                        Restart();
                                        timerlabel1.starttimer();
                                    }

                                    else { Application.Exit(); }

                                item.BringToFront();

                            }
                           // item.BringToFront();

                        }


                        }
                }
                }
            
            //return s + ":" + q;
            return s + ":" + q;
        }



        //****collisions des autres players execepté le prayer1

     

        public void collisionCoinsplayer2(int a, int b)
        {
          

            //foreach (Player item1 in listplayers)
            for (int i = 0; i < listdesplayers0.Count; i++)
            {
                if (i == playersID)
                {
                    continue;
               
                    //continue c'est l'inverse du break ,  si cette condition est vrai , on retourne directement dans la boucle for sans lire le reste
                }
                // cette condition =  if( i != playerID{ executer tous le reste du code}



                //**ajouts des autres joueurs dans la liste des joueurs

                Player item1 = listdesplayers0.ElementAt(i);

               

                //** on fait (i+1) parceque  listScoreplayers.ElementAt(i) correpond au socre du player1 **  

                int Score = listScoreplayers.ElementAt(i );


                foreach (Control item in item1.Parent.Controls)
                {
                  //  Random r = new Random(0);
                    //0 est un seed

                    if (item is Coin)
                    {



                        if ((string)item.Tag == "Coin")
                        {


                            if (Score < 40)
                            {

                                coin3.Visible = false;

                            }
                            else
                            {
                                coin3.Visible = true;
                                    coin3.Location = new Point(233, 50);
                               // coin3.Location = new Point(a, b);

                            }


                            if (item1.Bounds.IntersectsWith(item.Bounds))
                            {
                                a = r.Next(10, (listdesplayers0[(playersID) % Nbresdejoueurs].Parent.ClientSize.Width - 50));
                                b = r.Next(43, (listdesplayers0[(playersID) % Nbresdejoueurs].Parent.ClientSize.Height - 50));
                                item.Location = new Point(a, b);



                                if (item.AccessibleName == "coin-1")
                                {


                                    if (Score < 30)
                                    {
                                        //  Score -= 1;


                                        //element (i+1)  de la liste : on retire 1 point au player(2 ou 3 ou 4) 

                                        listScoreplayers[i ] -= 1;

                                    }
                                    else if (Score > 30)

                                    {

                                        //Score -= 4; 
                                        listScoreplayers[i] -= 4;
                                    }

                                }



                                if (item.AccessibleName == "coin+1")
                                {
                                    //Score += 1;
                                    listScoreplayers[i ] += 1;
                                }



                                if (item.AccessibleName == "coin+2")
                                {
                                    //    Score += 2;
                                    listScoreplayers[i] += 2;
                                }



                                if (item.AccessibleName == "coin+3")
                                {
                                    //    Score += 3; 
                                    listScoreplayers[i ] += 3;

                                }




                                labelscoreother.Text = "score :" + Score.ToString(); ;

                                if (item1.Bounds.IntersectsWith(item.Bounds) && (Score >= 30))
                                {

                                    EventScore eventScore = new EventScore();

                                    eventScore.WinScore = "On va corser un peu plus le choses";

                                    labelscore30.Text = eventScore.WinScore;


                                }

                            }

                            item.BringToFront();



                            if (item1.Bounds.IntersectsWith(coin3.Bounds) && Score >= 40)
                            {


                                if (coin3.AccessibleName == "door")
                                {

                                    timerlabel1.stoptimer();
                                    timer.Stop();


                                    if (MessageBox.Show("You win avec un score de :" + labelscoreother.Text + Environment.NewLine + "et un temps de :" + "" + timerlabel1.Text, "Game Finish", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                    {
                                        Restart();
                                        timerlabel1.starttimer();
                                    }

                                    else { Application.Exit(); }

                                    item.BringToFront();

                                }

                              


                            }
                        }

                    }
                   
                }

            }

        }






        public string collisionPlatform2listplayers()
        {//attention si on veut utiliser cette methode dans form1 le "this.parent.control " devient Player1.parent.controls"
            string m = "0";
            string a = "1";
            List<Player> listplayers = new List<Player>();
            listplayers.Add(listdesplayers0[playersID]);
            listplayers.Add(listdesplayers0[(playersID + 1) % Nbresdejoueurs]);

            foreach (Player item1 in listplayers)
            {


                foreach (Control item in item1.Parent.Controls)
                {

                    if (item is Control)
                    {

                        if ((string)item.Tag == "PlateForm")
                        {

                            if (item1.Bounds.IntersectsWith(item.Bounds))
                            {
                                item1.G = 8;

                                item1.Top = item.Top - item1.Height;
                                // Jump = false;
                                m = a;

                                return m;
                            }

                            item.BringToFront();
                        }
                    }
                }
            }

            return m;
        }

        
        

        //*****intersection left - Right*****        
        
        public string intersect_Low_High1()
        {
            string a = "0";
           
            
            foreach (Control item in listdesplayers0[playersID].Parent.Controls)
            {
                
                if (item is Player)
                {

                 
                    if (item.Top < panelGame1.Top)
                    {
                       
                        item.Top = panelGame1.Top;
                        a = "1";
                    }
                        else
                             {
                                 a = "0"; ;
                             }
                
                }


            }
            return a;
        }



        public string intersect_Right_Left1()
        { 
            string i = "0", k = "0";
            foreach (Control item in listdesplayers0[playersID].Parent.Controls)
            {
               
                if (item is Player)
                {
                  
                    
                    if (item.Left < 0)
                    {
                        item.Left = 0; return i = "1";
                    }
                    
                    
                    
                    if (item.Right > item.Parent.ClientSize.Width)
                    {

                        item.Left = item.Parent.ClientSize.Width - item.Width;
                        
                        
                        return k = "1";
                    }
                }
            }

            return i + ":" + k;
        
        }






        // ***** mouvement des autres joueurs *****      

        private void moovotherplayer(bool goleft, bool goright, bool goup,int i)
        {


            //pour chaque joueur dans la la listdes players
               // Player otherplayer = listdesplayers0.ElementAt(i);


                    //cette condition permet de dire que si i==playerID ça concerne le players principal et donc on coonait deja ces mouvemment 
                    //ça concerne donc les autres joueurs comme le player2 ou player3 player4 etc...
                    //playerID correspond au premier player qui se connecte.
                  
            
            
            
            
            
            
            
            
                    if (goleft == true)
                    {
                        // listdesplayers0[(playersID + 1) % Nbresdejoueurs].left = true;
                          listdesplayers0[(i) ].left = true;
                     //  otherplayer.left = true;
                    }

                    else
                    {
                        // listdesplayers0[(playersID + 1) % Nbresdejoueurs].left = false;
                            listdesplayers0[(i)].left = false;
                      //  otherplayer.left = false;
                    }




                    if (goright == true)
                    {
                        //  listdesplayers0[(playersID + 1) % Nbresdejoueurs].right = true;
                          listdesplayers0[(i) ].right = true;

                      // otherplayer.right = true;
                    }

                    else
                    {

                        //  listdesplayers0[(playersID + 1) % Nbresdejoueurs].right = false;
                         listdesplayers0[(i)].right = false;
                      //otherplayer.right = false;
                    }




                    if (goup == true)
                    {
                        //   listdesplayers0[(playersID + 1) % Nbresdejoueurs].Jump = true;
                         listdesplayers0[(i) ].Jump = true;
                        //otherplayer.Jump = true;

                    }
                    else
                    {

                        //  listdesplayers0[(playersID + 1) % Nbresdejoueurs].Jump = false;
                          listdesplayers0[(i) ].Jump = false;
                      //otherplayer.Jump = false;

                    }

                

            
        }



        // ***** methode permettant de commander les touche *****

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) { listdesplayers0[playersID].left = true; }
            
            
            if (e.KeyCode == Keys.Right) { listdesplayers0[playersID].right = true; }
            
            
            if (e.KeyCode == Keys.Up && listdesplayers0[playersID].Jump == false)
            {
                listdesplayers0[playersID].Jump = true;
            
            }


            base.OnKeyDown(e);
        }





        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) {

                listdesplayers0[playersID].left = false; 
            }
            
            
            if (e.KeyCode == Keys.Right) {

                listdesplayers0[playersID].right = false;
            
            }
            
            
            if (listdesplayers0[playersID].Jump == true) 
            {
                listdesplayers0[playersID].Jump = false;
            
            }
            base.OnKeyUp(e);
        }





    


        



        //***** timer tick *****
       
        private void timer_Tick(object sender, EventArgs e)
            {

         //   bool goleft=false, goright=false, gojump=false; 
        


            //**intersection **

            intersect_Low_High1();
            
            intersect_Right_Left1();
            
            timerlabel1.starttimer();
               
            
            
            
            
            //***** mouvements des joueurs *****
            
            string movement = listdesplayers0[playersID].movement();




            //   player2.movement();




            //***** collision plateforme *****
            //string plate = collisionPlatform2listplayers();//player1.collisionPlatform1();
            string plate = listdesplayers0[playersID].collisionPlatform1();;



            //*****  score player 1 ****** 

           int  Score = listScoreplayers[0];
            
            labelscore.Text = Score.ToString();



            //****** score player2 ******

           int Score2 = listScoreplayers[1];
            labelscoreother.Text = Score2.ToString();












            // *****  coin ******

            //string coin =  collisionCoins1();
            string valcoins = collisionCoinsPlayer1(); //collisionCoins();



      
        

            //****** buffer à envoyer au serveur ******
           
            
            
          //  byte[] buffer = Encoding.ASCII.GetBytes(movement + "/" + plate + "/" + valcoins + "/" + labelscore.Text);
            byte[] buffer = Encoding.ASCII.GetBytes(movement + "/" + plate + "/" + valcoins );
            //listen.RemoteEndPoint.ToString()





            // **** on envoie le buffer ****

            listen.Send(buffer);
            
            GameOver();





            // **** buffer receptions du buffer *****



            for (int i = 0; i < listdesplayers0.Count; i++)
            {
                bool goleft = false, goright = false, gojump = false;
                if (i == playersID)
                {
                    continue;
                }
                else
                {
                    byte[] buf2 = new byte[1024];

                    int bytecode = listen.Receive(buf2);


                    string msg = Encoding.ASCII.GetString(buf2, 0, bytecode);

                    buffer = Encoding.ASCII.GetBytes("ok player"+i);

                    listen.Send(buffer);

                    //*** premier split ***

                    string[] data = msg.Split('/');



                    string movement1 = data[0];



                    string platef = data[1];




                    string coin1 = data[2];




                    //     string score1 = data[3];


                    //*** deuxième split ***

                    string[] moov = movement1.Split(':');


                    //** left **

                    if (moov[0] == "1")
                    {

                        goleft = true;

                    }



                    //** right **

                    if (moov[1] == "1")
                    {

                        goright = true;

                    }


                    //**Jump**

                    if (moov[2] == "0")
                    {

                        gojump = false;
                    }


                    if (moov[2] == "1")
                    {

                        gojump = true;
                    }


                    if (moov[2] == "2")
                    {

                        gojump = false;
                    }


                     listdesplayers0[(i) ].movement();
                   /* for (int j = 0; j < listdesplayers0.Count; j++)
                    {

                        if (j != playersID)
                        {

                            listdesplayers0[(j) % Nbresdejoueurs].movement();
                        }
                    }*/

                    moovotherplayer(goleft, goright, gojump, i);




                    //recuperation valeur coin
                    string[] coinsplit = coin1.Split(':');
                    int a = Int32.Parse(coinsplit[0]);
                    int b = Int32.Parse(coinsplit[1]);


                    //string tmp = coinsplit[100];
                    collisionCoinsplayer2(a, b);
                    //string tmp = coinsplit[100];


                    //  collisionCoinsplayer2(a, b);

                    //*****plateform****

                    // if (platef == "1") { player2.collisionPlatform1(); }

                    //  if (platef == "1") { collisionPlatform2listplayers(); }

                    //  listdesplayers0[(playersID + 1) % Nbresdejoueurs].collisionPlatform1();

                }
            }





                    for (int i = 0; i < listdesplayers0.Count; i++)
                    {
                        //Player item = listdesplayers0.ElementAt(i);
                        if (i != playersID)
                        {

                            listdesplayers0[(i)].collisionPlatform1();
                            // item.collisionPlatform1();
                        }
                    }





                

            

        }

        
    







// ****** changement de couleurs de joueurs ****** 


        private void cdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void butToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            Form2 form2 = new Form2();
           
            form2.Show();
            
       
        }

        private void evilToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
            listdesplayers0[playersID].Image = Properties.Resources.emoji13;

          //  listdesplayers0[playersID].BackColor = Color.FromArgb(128, 128, 255); ;
        
    }

        private void multiemoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listdesplayers0[playersID].Image = Properties.Resources.emoji10;
        }

        private void angryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        
            listdesplayers0[playersID+1].Image = Properties.Resources.emoji2;
           
        }

        private void coboyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listdesplayers0[playersID+1].Image = Properties.Resources.emoji3;
        }








        /*  listdesplayers0[playersID].Image = Properties.Resources.emoji71;

              listdesplayers0[playersID].BackColor = Color.FromArgb(128, 128, 255); ;



        coboy
            listdesplayers0[playersID].Image = Properties.Resources.emoji3;




            evil
               listdesplayers0[playersID].Image = Properties.Resources.emoji2;


            angry
                 listdesplayers0[playersID].Image = Properties.Resources.emoji13;

              listdesplayers0[playersID].BackColor = Color.FromArgb(128, 128, 255); ;



            greenemoji
                listdesplayers0[playersID].Image = Properties.Resources.emoji5;


            blueemoji

              listdesplayers0[playersID].Image = Properties.Resources.emoji1;

              listdesplayers0[playersID].BackColor = Color.FromArgb(128, 128, 255); ;




             Multiemoji
               listdesplayers0[playersID].Image = Properties.Resources.emoji10;




            classemoji
               listdesplayers0[playersID].Image = Properties.Resources.emoji71;

              listdesplayers0[playersID].BackColor = Color.FromArgb(128, 128, 255); ;*/




    }
}
