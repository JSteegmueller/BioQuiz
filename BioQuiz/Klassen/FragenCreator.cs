using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace JSONTest.Klassen
{
    class FragenCreator
    {
        private string jsonFragen;     //Eingelesene JSON-Datei

        public FragenCreator(string jsonFragen)
        {
            this.jsonFragen = jsonFragen;
        }

        public Frage[] getFragen()
        {
            int fragenZaehler = 0;
            int anzFragen = 0;
            JArray frageListe = JArray.Parse(jsonFragen);

            foreach (JObject fragen in frageListe)
            {
                foreach (KeyValuePair<String, JToken> frageAntwort in fragen)
                {
                    anzFragen++;
                }
            }

            Frage[] dieFragen = new Frage[anzFragen];

            foreach (JObject fragen in frageListe)
            {
                foreach (KeyValuePair<String, JToken> frageDaten in fragen)
                {
                    dieFragen[fragenZaehler] = new Frage();
                    dieFragen[fragenZaehler].dieFrage = (string)frageDaten.Value["frage"];

                    for ( int j = 0; j < 4; j++)
                    {
                        StringBuilder antwortJ = new StringBuilder("antwort" + (j+1));
                        dieFragen[fragenZaehler].dieAntworten[j] = (string)frageDaten.Value[antwortJ.ToString()];
                    }

                    dieFragen[fragenZaehler].richtigAntwort = (int)frageDaten.Value["richtigeAntwort"]-1;   //Antworten in der JSON: 1-4 / Im Array: 0-3
                    dieFragen[fragenZaehler].dieBegruendung = (string)frageDaten.Value["erklaerung"];
                    fragenZaehler++; 
                }

            }
            return dieFragen;
        }
    }
}
