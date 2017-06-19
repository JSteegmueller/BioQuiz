using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioQuiz.Klassen
{
    class FragenKatalog
    {
        private List<Frage> dieFragenListe;
        private Frage[] dieFragen;
        private int     anzFragen;
        private Random  randGenerator;

        public FragenKatalog(Frage[] dieFragen)
        {
            this.dieFragen = dieFragen;
            dieFragenListe = new List<Frage>();
            
            foreach ( Frage eineFrage in dieFragen)
            {
                dieFragenListe.Add(eineFrage);
            }
        
            randGenerator = new Random();
            anzFragen = dieFragen.GetLength(0);
        }

        public void addFrageAtEnd(Frage neueFrage)
        {
            dieFragenListe.Add(neueFrage);
            dieFragen = dieFragenListe.ToArray();
        }

        public int GetAnzFragen()
        {
            anzFragen = dieFragenListe.Count;
            return anzFragen;
        }
        
        //Bekomme ein Array mit zufälligen Fragen 
        public Frage[] GetRandFragen(int anzGewollteFragen)
        {
            dieFragen = dieFragenListe.ToArray();

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
            dieFragen = dieFragenListe.ToArray();
            return dieFragen;
        }

        public List<Frage> GetFragenListe()
        {
            return dieFragenListe;
        }
    }
}
