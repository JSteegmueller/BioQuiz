using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace BioQuiz.Klassen
{
    class JSONFragenWriter
    {
        private void writeJSONFromString(string jsonString)
        {
            //Schreibt den JSON-String in die json-Datei
            string currentPath = Directory.GetCurrentDirectory();
            File.WriteAllText("..//..//FragenJSON//BioFragen.json", jsonString);
        }

        public void writeJSONStringFromQuestionPool(Frage[] dieFragen)
        {
            StringBuilder jsonString = new StringBuilder();
            StringWriter myStringWriter = new StringWriter(jsonString);

            using (JsonWriter myJsonWriter = new JsonTextWriter(myStringWriter))
            {
                myJsonWriter.Formatting = Formatting.Indented;
                myJsonWriter.WriteStartArray();
                myJsonWriter.WriteStartObject();
                int fragenZaehler = 0;

                foreach ( Frage aktFrage in dieFragen)
                {
                    StringBuilder frageX = new StringBuilder();
                    frageX.Append("frage" + fragenZaehler);

                    //Ein neues Frageobjekt
                    myJsonWriter.WritePropertyName(frageX.ToString());
                    myJsonWriter.WriteStartObject();

                    //Der Fragesatz
                    myJsonWriter.WritePropertyName("frage");
                    myJsonWriter.WriteValue(aktFrage.derFrageSatz);

                    //Die Antworten
                    int aktuelleAntwort = 1;
                    foreach (string antwort in aktFrage.dieAntworten)
                    {
                        StringBuilder antwortX = new StringBuilder();
                        antwortX.Append("antwort" + aktuelleAntwort);
                        myJsonWriter.WritePropertyName(antwortX.ToString());
                        myJsonWriter.WriteValue(antwort);
                        aktuelleAntwort++;
                    }

                    //Richtige Antwort
                    myJsonWriter.WritePropertyName("richtigeAntwort");
                    myJsonWriter.WriteValue((aktFrage.richtigAntwort+1).ToString());

                    //Erklaerung
                    myJsonWriter.WritePropertyName("erklaerung");
                    myJsonWriter.WriteValue(aktFrage.dieBegruendung);

                    myJsonWriter.WriteEndObject();
                    fragenZaehler++;
                }
                myJsonWriter.WriteEndObject();
                myJsonWriter.WriteEndArray();
            }
            writeJSONFromString(jsonString.ToString());
        }
    }
}
