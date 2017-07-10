using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using BioQuiz.Properties;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BioQuiz.Klassen
{
    class JSONFragenWriter
    {
        public void testc()
        {
            //Schreibt den JSON-String in die json-Datei
            string currentPath = Directory.GetCurrentDirectory();
            File.WriteAllText(currentPath + "\\BioFragenTest.json", "Test");

        }
    }
}
