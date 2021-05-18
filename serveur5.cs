using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
namespace serveursss
{
    class Program
    {
        static void Main(string[] args)
        {
           int Nombredeplayers = 2;
            string msgnbreplayer;
            int playerNumbers=0;
            
            Socket listener;
           
            IPAddress ip = IPAddress.Parse("192.168.1.5");

           //connecting players
            int port = 8001;
            IPEndPoint localip = new IPEndPoint(ip, port);
            listener = new Socket(SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(localip);
            listener.Listen(100);
            Console.WriteLine("waiting connexion clients  ......");
            //   int n = 1;
            //    Socket client1 = listener.Accept();
            //  Console.WriteLine("accept client1");
            //Socket client2 = listener.Accept();
            //Console.WriteLine("accept client2");

            byte[] bufferNbredeplayers = new byte[1024];




            //tableau de clients
            //Socket[] clients = new Socket[3];

            /*       Socket[] clients = new Socket[Nombredeplayers];
                 // Socket[] clients  ;
                     for (int i = 0; i < clients.Length; i++)
                     {
                         clients[i] = listener.Accept();
                         Console.WriteLine("accept client" + i);


                     }*/




            Socket[] clit = new Socket[1];
               Socket[] clients;

            for (int i = 0; i < 1; i++)
            {
                clit[i] = listener.Accept();
                Console.WriteLine("accept client" + i);
            }

               

                       int noctets = clit[0].Receive(bufferNbredeplayers);
                       msgnbreplayer = Encoding.ASCII.GetString(bufferNbredeplayers, 0, noctets);
                       //playerNumbers = Int32.Parse(msgnbreplayer);
                       Console.WriteLine("le nombre de joueur est   " + msgnbreplayer);
                       string mess = "réçu";
                       byte[] bufNP = Encoding.ASCII.GetBytes(mess);
                       clit[0].Send(bufNP);

                        playerNumbers = Int32.Parse(msgnbreplayer);
                   



                   


             int   NIP = playerNumbers;

              clients = new Socket[NIP];
            clients[0] = clit.ElementAt(0);
            //elementAT[] : retourne l'element situé à la situtation donnée
            byte[] de;

               for (int j = 0; j < clients.Length; j++)
               {
                   if (j == 0) {
                    
                       continue; }

                   else
                   {
                       clients[j] = listener.Accept();

                       Console.WriteLine("accept client" + j);

                   }


               }

           



            for (int i = 0; i < clients.Length; i++)
            {

                Socket client = clients[i];
                    byte[] buffer = Encoding.ASCII.GetBytes( "ID:"+i.ToString());
                    //    byte[] buffer2 = Encoding.ASCII.GetBytes("ID2:1");

                    client.Send(buffer);

                    //  client.Send(buffer2);
                }














            //  Socket  client1 = clients[0];

            // Socket client2 = clients[1];

            List<string> ReceptmsgLists = new List<string>();
            //ReceptmsgLists.Add("empty");
            //ReceptmsgLists.Add("empty");
           
            List<byte[]> SendmsgLists = new List<byte[]>();
            byte[] jaar = new byte[1024];

            //*** initialisations des listes  en fonctions du nombre de joueurs
         
            
            // for ( int i = 0; i< Nombredeplayers; i++)
               for (int i = 0; i < clients.Length; i++)
                {
                ReceptmsgLists.Add("empty");
                SendmsgLists.Add(jaar);
            }




           // List<byte[]> SendmsgLists = new List<byte[]>();
         //   byte[] jaar = new byte[1024];
          //  SendmsgLists.Add(jaar);
           // SendmsgLists.Add(jaar);


            while (true)
            {


               
            
                
                
                
                
                
                // reception     


                //liste de string pour chaque msg
               // byte[] buffersrecept = new byte[1024];

                //cette boucle permet de généraliser la réceptions des données  par rapports au nombre de clients 

                for (int i = 0; i < ReceptmsgLists.Count; i++)
                {
                  byte[]  buffersrecept = new byte[10024];
                    int bytecodes = clients[i].Receive(buffersrecept);
                    string msg = Encoding.ASCII.GetString(buffersrecept, 0, bytecodes);
                    ReceptmsgLists[i] = msg;

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
                { //mettre dans une liste les differents buffer qu'on veut envoyé

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

               // for (int i = 0; i < playerNumbers; i++)
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
                             *
                             *
                             *
                             */


                        }
               
                    
                    }
            
                
                }
               


                    }
                //    n++;

        }
    }
}
