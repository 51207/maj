using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace PlateformWithoutMoov
{
    class EventScoreSup30
    {
        public delegate string Scoresup();





        //etape1:
        //Scoresup est le nom que j'ai donnée au delegué
        // ce delegate est aussi le publisher
        //il faut les mettre en public  " event et le delegate
        public event Scoresup ScoreSuperieur;
        // etape 2 : declare event
        //defini evenement basé sur le delegate 


    
    // Scoresup ScoreSuperieur = Afficher;
        public string  Affiche()
        {// comment publier l'évenement maintenant ? => il suffit juste d'appeler l'event ici
            if (ScoreSuperieur != null)
            {
                ScoreSuperieur();

                // si on fait ça seulement  <<   ScoreSuperieur();>> maitenant comme personne n'est connecté (inscrit)  à l'évent, il est null et ça levera une exception  
                //du coup on fait la condition.
                // on peut raccourcir ceci  <<if (  ScoreSuperieur() != null)>> en <<  ScoreSuperieur()?.Invoke() 
            }
            return ScoreSuperieur();
        }
    }
}
