﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioQuiz.Forms;
using BioQuiz.Klassen;
using System.Windows.Forms;

namespace BioQuiz.Klassen
{
    class QuizSteuerung
    {
        private FragenCreator fragenReader;
        private FragenKatalog fragenListe;
        private string fragenString;
        private Frage[] quizFragen;
        int anzFragen;
        int ctrFragen = 0;
        bool frageRichtig = false;

        private AnleitungFenster anleitungForm;
        private EndUebersichtFenster endUebersichtForm;
        private StartFenster startForm;
        private FragenFenster fragenForm;


        

        public static int EVENT_BUTTON_BEENDEN = 0;
        public static int EVENT_BUTTON_START = 1;
        public static int EVENT_BUTTON_ANLEITUNG = 2;
        public static int EVENT_BUTTON_FRAGEABGEBEN = 3;





        public void init()
        {
            fragenString = System.IO.File.ReadAllText("../../FragenJSON/BioFragen.json");

            fragenReader = new FragenCreator(fragenString);
            fragenListe = new FragenKatalog(fragenReader.getFragen());


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            anleitungForm = new AnleitungFenster();
            endUebersichtForm = new EndUebersichtFenster();
            startForm = new StartFenster();
            fragenForm = new FragenFenster();

            startForm.comboBox1.SelectedIndex = 0;
            Application.Run(startForm);
        }

        public void onEvent(int eventID)
        {
            if (eventID == EVENT_BUTTON_BEENDEN)
            {
                Application.Exit();
            }
            else if (eventID == EVENT_BUTTON_ANLEITUNG)
            {
                anleitungForm.Show();
                anleitungForm = new AnleitungFenster();
            } 
            else if (eventID == EVENT_BUTTON_START)
            {
                startForm.Hide();
                anzFragen = Convert.ToInt32(startForm.comboBox1.SelectedItem.ToString());
                quizFragen = fragenListe.getRandFragen(anzFragen);
                fragenForm.radioButton1.Text = quizFragen[ctrFragen].dieAntworten[0];
                fragenForm.radioButton2.Text = quizFragen[ctrFragen].dieAntworten[1];
                fragenForm.radioButton3.Text = quizFragen[ctrFragen].dieAntworten[2];
                fragenForm.radioButton4.Text = quizFragen[ctrFragen].dieAntworten[3];
                fragenForm.label1.Text = quizFragen[ctrFragen].dieFrage;
                fragenForm.label2.Visible = false;
                fragenForm.Show();
            }
            else if (eventID == EVENT_BUTTON_FRAGEABGEBEN)
            {
                if (fragenForm.radioButton1.Checked == true)
                {
                    frageRichtig = quizFragen[ctrFragen].beantworteFrage(0);
                }

                else if(fragenForm.radioButton2.Checked == true)
                {
                    frageRichtig = quizFragen[ctrFragen].beantworteFrage(1);
                }

                else if (fragenForm.radioButton3.Checked == true)
                {
                    frageRichtig = quizFragen[ctrFragen].beantworteFrage(2);
                }

                else if (fragenForm.radioButton4.Checked == true)
                {
                    frageRichtig = quizFragen[ctrFragen].beantworteFrage(3);
                }

                if (anzFragen > 1)
                {

                    ctrFragen++;
                    fragenForm.radioButton1.Text = quizFragen[ctrFragen].dieAntworten[0];
                    fragenForm.radioButton2.Text = quizFragen[ctrFragen].dieAntworten[1];
                    fragenForm.radioButton3.Text = quizFragen[ctrFragen].dieAntworten[2];
                    fragenForm.radioButton4.Text = quizFragen[ctrFragen].dieAntworten[3];
                    fragenForm.label1.Text = quizFragen[ctrFragen].dieFrage;
                    fragenForm.label2.Visible = false;
                    
                    anzFragen--;
                }
                else
                {
                    fragenForm.Hide();
                    endUebersichtForm.Show();

                }
                if (frageRichtig)
                {
                    fragenForm.label2.Visible = true;
                    fragenForm.label2.Text = "Das War Richtig";
                }
            }
        }
    }
}