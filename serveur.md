## class Program
  ##  {
##        static void Main(string[] args)
        {

            Socket listener;
            IPAddress ip = IPAddress.Parse("192.168.1.5");
            int port = 8001;
            IPEndPoint localip = new IPEndPoint(ip, port);
            listener = new Socket(SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(localip);
            listener.Listen(100);
            Console.WriteLine("waiting connexion ......");
            int n = 1;
            Socket client = listener.Accept();
            Console.WriteLine("accept client");
            while (true)
            {
          
          
          # reception     
          
                byte[] buf2 = new byte[1024];
                int bytecode = client.Receive(buf2);
                string msg = Encoding.ASCII.GetString(buf2, 0, bytecode);
            
                    
                    
                   
        string [] data =  msg.Split('/');
        
     
     #Split: Returns a string array that contains the substrings in this #instance that are delimited by elements of a specified #string or #Unicode character array.
         


         string movement = data[0];
   
         string plateform = data[1];
            
         string coina = data[2];
 
         string scoring = data[3];
               
         string[] moov = movement.Split(':');
              
         string[] piece = coina.Split(':');

         
                
         //*** plateform ***
                
         if (plateform == "1") { Console.WriteLine("plateforme ok"); }
                
        
                
         //*** coin *** 
         
             if(piece[2] == "1") { Console.WriteLine("le coin est 1" ); }
         
             if (piece[2] == "2") { Console.WriteLine("le coin est 2"); }
         
             if (piece[2] == "3") { Console.WriteLine("le coin est 3"); }
            
             
                
                
                
         //*** envoie de données: ***

             byte[] buffer = Encoding.ASCII.GetBytes(msg);


            client.Send(buffer);

            }
                n++;

        }
  ##  }
# } 