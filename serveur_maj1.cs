 class Program
    {
        static void Main(string[] args)
        {

            Socket listener;
          
            IPAddress ip = IPAddress.Parse("192.168.1.5");

           //connecting player1
            int port = 8001;
            IPEndPoint localip = new IPEndPoint(ip, port);
            listener = new Socket(SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(localip);
            listener.Listen(100);
            Console.WriteLine("waiting connexion client 1 ......");
            int n = 1;
            Socket client1 = listener.Accept();
            Socket client2 = listener.Accept();
            Console.WriteLine("accept client1");
        

            byte[] buffer1 = Encoding.ASCII.GetBytes("ID:0");
            byte[] buffer2 = Encoding.ASCII.GetBytes("ID:1");

            client1.Send(buffer2);
            client2.Send(buffer1);



            while (true)
            {
         
                
                
                // reception     
          
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

         
                    if (plateform == "1") { Console.WriteLine("plateforme ok"); }
                
             
                      
                   if(piece[0] != "-1") { Console.WriteLine("le joueur a pris un coin: a" ); }
         
                    
                    if (piece[1] != "-1") { Console.WriteLine(" le joueur a pris un coin : b"); }
         
                    
                    
            
             


                if (moov[0] == "1")
                {
                    Console.WriteLine(" left player");

                }
                    else if (moov[1] == "1"){ Console.WriteLine(" Right player"); }
              
                
                // Console.WriteLine(moov[2]);
                if(moov[2] == "0") { Console.WriteLine(" No jump "); }
                
                
                if (moov[2] == "1") { Console.WriteLine(" jump and falling "); }
                
                
                if (moov[2] == "2") { Console.WriteLine(" he can jump  "); }
             
              buffer1 = Encoding.ASCII.GetBytes(msg1);
              buffer2 = Encoding.ASCII.GetBytes(msg2);

                client1.Send(buffer2);
                client2.Send(buffer1);
            }
            n++;

        }
    }
}
