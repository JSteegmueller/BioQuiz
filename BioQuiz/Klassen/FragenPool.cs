using System;
using System.Collections.Generic;

namespace BioQuiz.Klassen
{
    class FragenPool
    {
        private List<Frage> dieFragenListe;
        private Frage[] dieFragen;
        private int     anzFragen;
        private Random  randGenerator;

        public FragenPool(Frage[] dieFragen)
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
            anzFragen = dieFragen.GetLength(0);
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

                //Keine Frage doppelt wenn anzFragen > anzGewollteFragen 
                if(anzFragen >= anzGewollteFragen)
                {
                    int aktuellerFragenIndex = i;                 // i ist die Anzahl der durchläufe der Zählschleife, aktuelle Anzahl der Fragen im Array 
                    bool frageDoppelt = false;            // Die Frage darf einmal im Array vorkommen
                    foreach (Frage eineFrage in returnFragen)    //Für jede Frage im FragenArray
                    {
                        if (eineFrage == returnFragen[aktuellerFragenIndex])   //Wenn eine Frage im Array ist die Gleiche wie die Aktuell neu hinzugefügte    
                        {
                            if (frageDoppelt == true)                //Doppelte Frage erkannnt
                            {
                                i--;                          
                            }
                            frageDoppelt = true;                     //Die frage ist nun 1-mal vorgekommen
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
