
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateformWithoutMoov
{
    //Corsage du jeu
     class EventScore
    {
        private string a = "On va corser un peu plus le jeu";
        public string WinScore { get { return a; } }

        private EventScoreSup30 EventScoreSup30;
        public EventScore(EventScoreSup30 eventScoreSup30)
        {
            this.EventScoreSup30 = eventScoreSup30;
            eventScoreSup30.ScoreSuperieur += WinScoreSup;
        }
        public   string WinScoreSup()
        {
            return a;
        }

    }



    //identité du joueur
    public class  Identitylabel
    {

        public Identitylabel()
        {
          }
        

        public string  identitylabel(int playersID)
        {
            string a = "";
            // Labelidentity.Visible = true;
            if (playersID == 0)
            {
                a = "[ player principal ]=  I";
           
            }
            else if (playersID == 1)
            {
                a = "[ player principal ]=  II";
             
            }
            else if (playersID ==2)
            {
                a = "[ player principal ]=  III";
               
            }
            else if (playersID ==3)
            {
                a = "[ player principal ]=  IV";
              
            }
            else
            {
                a = "[ player principal ]=  V";
               
            }
            return a;
        }

    }

}