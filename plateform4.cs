  
    public Random r = new Random(0);
    //seed permet d'afficher une certain sequence de valeur selon la valeur du seed
//0 est un seed cad le random renvoir une sequence de valeur selon le seed 0
//si le si est 1 , on aura aussi d'utre sequence de valeur
//on peut tester le seed en faison
//Random r = new random(0);
//for(int i=0 ;i< 10 ;i++){
//console.Writeline(r.next(i));
//}
//si on change le see  exple Random r = new random(8080) et on efffectue la même commande on observera que
//la sequence de valeur n'est pas la même.



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



                                }

                                item.BringToFront();
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



                                }

                                item.BringToFront();


                            }
                        }

                    }
                }
            }

        }


  
  private void moovotherplayer(bool goleft,bool goright, bool goup)
        { //foreach(Control item in player1.Parent.Controls){}
                       
            if(goleft == true)
            {
                listdesplayers0[(playersID + 1) % Nbresdejoueurs].left = true; 

            }
        
            else
                {
                listdesplayers0[(playersID + 1) % Nbresdejoueurs].left = false;
                }
           
            


            if (goright == true)
            {
                listdesplayers0[(playersID + 1) % Nbresdejoueurs].right = true;
            }
             
            else {

                listdesplayers0[(playersID + 1) % Nbresdejoueurs].right = false;
                  
            }




            if (goup == true)
            {
                listdesplayers0[(playersID + 1) % Nbresdejoueurs].Jump = true;

            }
            else { listdesplayers0[(playersID + 1) % Nbresdejoueurs].Jump = false; }
        
        }




