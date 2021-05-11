 class Program
    {
        static void Main(string[] args)
        {
            int Nombredeplayers = 2;

            Socket listener;
          
            IPAddress ip = IPAddress.Parse("192.168.1.5");

           //connecting players
            int port = 8001;
            IPEndPoint localip = new IPEndPoint(ip, port);
            listener = new Socket(SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(localip);
            listener.Listen(100);
            Console.WriteLine("waiting connexion clients  ......");
            int n = 1;
        //    Socket client1 = listener.Accept();
          //  Console.WriteLine("accept client1");
            //Socket client2 = listener.Accept();
            //Console.WriteLine("accept client2");

            Socket[] clients = new Socket[Nombredeplayers];
            for (int i = 0; i < clients.Length; i++)
            {
                clients[i] = listener.Accept();
                Console.WriteLine("accept client" + i);

            }
            for (int i = 0; i < clients.Length; i++)
            {

                Socket client = clients[i];
                    byte[] buffer = Encoding.ASCII.GetBytes("ID:" + i.ToString());
                    //    byte[] buffer2 = Encoding.ASCII.GetBytes("ID2:1");

                    client.Send(buffer);
                    //  client.Send(buffer2);
                }

          Socket  client1 = clients[0];

            Socket client2 = clients[1];
            while (true)
            {
         
                
                
                // reception     
          

                //listt de string pour chaque msg
                byte[] buf2 = new byte[1024];
                int bytecode = client1.Receive(buf2);
                string msg1 = Encoding.ASCII.GetString(buf2, 0, bytecode);
 
                buf2 = new byte[1024];
               bytecode = client2.Receive(buf2);
                string msg2 = Encoding.ASCII.GetString(buf2, 0, bytecode);


                string [] data =  msg1.Split('/');
                   
                //Split: Returns a string array that contains the substrings in this instance that are delimited by elements of a specified string or Unicode character array.
            
                    string movement = data[0];
   
                    string plateform = data[1];
            
                    string coina = data[2];
 
                    string scoring = data[3];
               
                   
                
                
                    string[] moov = movement.Split(':');
              
                    string[] piece = coina.Split(':');

         
                 //   if (plateform == "1") { Console.WriteLine("plateforme ok"); }
                
             
                      
                   if(piece[0] != "100") { Console.WriteLine("a:" + piece[0] + "  b:" + piece[1]); }
         
                    
                    if (piece[1] != "100") { Console.WriteLine("a:" + piece[0] + "  b:" + piece[1]); }

              
                    
            
             


                if (moov[0] == "1")
                {
           //         Console.WriteLine(" left player");

                }
               //     else if (moov[1] == "1"){ Console.WriteLine(" Right player"); }
              
                
                // Console.WriteLine(moov[2]);
           //     if(moov[2] == "0") { Console.WriteLine(" No jump "); }
                
                
           //     if (moov[2] == "1") { Console.WriteLine(" jump and falling "); }
                
                
             //   if (moov[2] == "2") { Console.WriteLine(" he can jump  "); }
             
         byte[]    buffer1 = Encoding.ASCII.GetBytes(msg1);
             byte[] buffer2 = Encoding.ASCII.GetBytes(msg2);

                client1.Send(buffer2);
                client2.Send(buffer1);


            }
            n++;

        }
    }
}
