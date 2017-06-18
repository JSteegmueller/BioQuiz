namespace BioQuiz.Klassen
{
    class Frage
    {
        public string   derFrageSatz;
        public string[] dieAntworten = new string[4];              //Min/Max 4
        public string   dieBegruendung;            //Das Wieso
        public int      richtigAntwort;            //Kann sein: 0 - 3
        public int      frageRichtigBeantwortet = 2;   //0 = Nein , 1 = Ja, 2 = Unbeantwortet
        public int      abgegebeneAntwort;

       
        
        
        
        //Array-Zahl der richtigen Antwort   
        public int getRichtigeAntwortInt()
        {
            return richtigAntwort;
        }

        //Richtige Antwort als String
        public string getRichtigeAntwortString()
        {
            return dieAntworten[richtigAntwort];
        }

        //Begruendung als String
        public string getBegruendung()
        {
            return dieBegruendung;
        }

        //Ueberpruefung, ob frage richtig beantwortet wurde
        public bool beantworteFrage(int antwort)
        {
            abgegebeneAntwort = antwort;
            if (antwort == richtigAntwort)
            {
                frageRichtigBeantwortet = 1;
                return true;
            }
            else
            {
                frageRichtigBeantwortet = 0;
                return false;
            }
        }
         
    }
}
