
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
namespace ConsoleServeurPG
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        static void main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //****initialisation du nombre de players grâce à l'encodage du nombre dans le Textbox******

            int nplayer = Int32.Parse(textplayers.Text);
            Console.WriteLine(nplayer);
            int Nombredeplayers = nplayer;





            //*****  connecting players**********

            Socket listener;

            IPAddress ip = IPAddress.Parse("192.168.1.5");


            int port = 8001;
            IPEndPoint localip = new IPEndPoint(ip, port);
            listener = new Socket(SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(localip);
            listener.Listen(100);
            Console.WriteLine("waiting connexion clients  ......");

            //    Socket client1 = listener.Accept();
            //  Console.WriteLine("accept client1");
            //Socket client2 = listener.Accept();
            //Console.WriteLine("accept client2");

            byte[] bufferNbredeplayers = new byte[1024];




            //***** tableau de clients*******


            Socket[] clients = new Socket[Nombredeplayers];
            // Socket[] clients  ;
            for (int i = 0; i < clients.Length; i++)
            {
                clients[i] = listener.Accept();
                Console.WriteLine("accept client" + i);


            }



            //***** Envoie l'id à chaque joueur ce qui permettra de savoir quelle joueur on s'occupe*******


            for (int i = 0; i < clients.Length; i++)
            {

                Socket client = clients[i];
                byte[] buffer = Encoding.ASCII.GetBytes("ID:" + i.ToString() + ":" + nplayer.ToString());
                //    byte[] buffer2 = Encoding.ASCII.GetBytes("ID2:1");

                client.Send(buffer);



                //  Socket  client1 = clients[0];
                // Socket client2 = clients[1];
                //    byte[] buffer1 = Encoding.ASCII.GetBytes("ID1:0");
                //    byte[] buffer2 = Encoding.ASCII.GetBytes("ID2:1");
                //  client1.Send(buffer1);
                // client1.Send(buffer1);

            }







            List<string> ReceptmsgLists = new List<string>();
            /*
             * ReceptmsgLists.Add("empty");
             * ReceptmsgLists.Add("empty");
             *  
             */



            List<byte[]> SendmsgLists = new List<byte[]>();
            byte[] jaar = new byte[1024];

            //*** initialisations des listes  en fonctions du nombre de joueurs


            // for ( int i = 0; i< Nombredeplayers; i++)
            for (int i = 0; i < clients.Length; i++)
            {
                ReceptmsgLists.Add("empty");
                SendmsgLists.Add(jaar);

                // List<byte[]> SendmsgLists = new List<byte[]>();
                //   byte[] jaar = new byte[1024];
                //  SendmsgLists.Add(jaar);
                // SendmsgLists.Add(jaar);
            }

            Console.WriteLine("Initialisation de toutes les listes et tableaux");
            //try
           // {

                while (true)
                {// on boucle à l'infini  pour la reception des données




                    //***** reception ******     


                    //cette boucle permet de généraliser la réceptions des données  par rapports au nombre de clients 

                    for (int i = 0; i < ReceptmsgLists.Count; i++)
                    {
                        byte[] buffersrecept = new byte[10024];
                        int bytecodes = clients[i].Receive(buffersrecept);
                        string msg = Encoding.ASCII.GetString(buffersrecept, 0, bytecodes);
                        ReceptmsgLists[i] = msg;


                    if (msg == "GAMEOVER")
                    {
                        Console.WriteLine("Game Over messages");

                        for (int j = 0; j < ReceptmsgLists.Count; j++)
                        {
                            if (i != j) { 
                            
                            

                                byte[] bufs1 = Encoding.ASCII.GetBytes(msg);
                                clients[j].Send(bufs1);
                                Console.WriteLine("message envoyé au client:" + " " + j + 1 + " ");

                                byte[] buf2 = new byte[1024];

                                int bytecode = clients[j].Receive(buf2);

                                string msg1 = Encoding.ASCII.GetString(buf2, 0, bytecode);


                                Console.WriteLine("Accusé de reception :" + " " + j + 1 + " " + msg1);

                            }
                        }

                           Environment.Exit(1);
                        }

                   

                        /*
                         *      la boucle for remplace ce texte qui  permet de recevoir les données envoyées par les deux clients.
                         * 
                         *      byte[] buf2 = new byte[1024];
                                int bytecode = client1.Receive(buf2);
                                string msg1 = Encoding.ASCII.GetString(buf2, 0, bytecode);
                                buf2 = new byte[1024];
                                bytecode = client2.Receive(buf2);
                                string msg2 = Encoding.ASCII.GetString(buf2, 0, bytecode);
                        */


                    }






                    for (int j = 0; j < SendmsgLists.Count; j++)
                    {
                    //mettre dans une liste les differents buffer qu'on veut envoyé

                        SendmsgLists[j] = Encoding.ASCII.GetBytes(ReceptmsgLists[j]);

                        /*c'est la même chose que si on fait ça
                         * 
                         *  //byte[] buffer1 = Encoding.ASCII.GetBytes(msg1);
                         * 
                         * sauf qu'ici SendmsgList[j]= est une liste qui a comme entrée  "byte [] "
                         * 
                         *  envoyé le client1 du serveur envoie les information du bufferr2 qui est le buffer du client 2  client1.send(buffer2);
                         * 
                         *                      
                         */
                    }




                    for (int i = 0; i < clients.Length; i++)


                    {
                        for (int j = 0; j < SendmsgLists.Count; j++)
                        {
                            if (i != j)
                            {


                                clients[i].Send(SendmsgLists[j]);

                                byte[] goodreception = new byte[1024];

                                clients[i].Receive(goodreception);


                                /*  les deux boucles "for" font la même chose que si on fait ça sans être dans une boucle:
                             * 
                             *  Socket  client1 = clients[0];
                             *  Socket client2 = clients[1];
                                     byte[] buffer1s = SendmsgLists[0];
                                     byte[] buffer2s = SendmsgLists[1];
                                     client1.Send(buffer2s);
                                     client2.Send(buffer1s);
                            
                             *
                             */


                            }


                        }


                    }




            }


        }

    }
}