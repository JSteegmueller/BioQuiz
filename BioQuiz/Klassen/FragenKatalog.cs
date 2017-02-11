using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JSONTest.Klassen;

namespace JSONTest.Klassen
{
    class FragenKatalog
    {
        private Frage[] dieFragen;
        private int     anzFragen;
        private Random  randGenerator;

        public FragenKatalog(Frage[] dieFragen)
        {
            this.dieFragen = dieFragen;
            randGenerator = new Random();
            anzFragen = dieFragen.GetLength(0);
        }
        
        //Bekomme ein Array mit zufälligen Fragen 
        public Frage[] getRandFragen(int anzGewollteFragen)
        {
            Frage[] returnFragen = new Frage[anzGewollteFragen];

            for (int i = 0; i < anzGewollteFragen; i++)
            {
                returnFragen[i] = dieFragen[randGenerator.Next(0, anzFragen)];
            }
            return returnFragen;
        }
  
    }
}
