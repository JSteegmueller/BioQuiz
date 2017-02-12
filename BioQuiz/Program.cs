using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BioQuiz.Forms;
using BioQuiz.Klassen;

namespace BioQuiz
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        public static QuizSteuerung main;
        [STAThread]
        static void Main()
        {
            main = new QuizSteuerung();
            main.init();
        }
    }
}
