using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioQuiz.Klassen
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

                //Keine Frage doppelt//
                int safe = i;
                bool eigen = true;
                foreach (Frage x in returnFragen)
                {
                    if (x == returnFragen[safe])
                    {
                        if (eigen == false)
                        {
                            i--;
                        }
                        eigen = false;
                    }
                }
            }
            return returnFragen;
        }
    }
}
