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

        public int GetAnzFragen()
        {
            return anzFragen;
        }
        
        //Bekomme ein Array mit zufälligen Fragen 
        public Frage[] GetRandFragen(int anzGewollteFragen)
        {
            Frage[] returnFragen = new Frage[anzGewollteFragen];

            for (int i = 0; i < anzGewollteFragen; i++)
            {
                returnFragen[i] = dieFragen[randGenerator.Next(0, anzFragen)];

                //Keine Frage doppelt wenn anzFragen > anzGewollteFragen //
                if(anzFragen >= anzGewollteFragen)
                {
                    int safe = i;
                    bool eigeneFrage = true;
                    foreach (Frage eineFrage in returnFragen)
                    {
                        if (eineFrage == returnFragen[safe])
                        {
                            if (eigeneFrage == false)
                            {
                                i--;
                            }
                            eigeneFrage = false;
                        }
                    }
                }
            }
            return returnFragen;
        }

        public Frage[] GetAlleFragen()
        {
            return dieFragen;
        }
    }
}
