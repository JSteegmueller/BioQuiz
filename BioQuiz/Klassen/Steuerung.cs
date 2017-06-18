using System;
using System.Text;
using BioQuiz.Forms;
using System.Windows.Forms;
using System.Drawing;

namespace BioQuiz.Klassen
{
    static class QuizSteuerung
    {
        private static FragenCreator fragenReader;
        private static FragenKatalog fragenListe;
        private static string fragenString;
        private static Frage[] quizFragen;
        static int anzFragen;
        static int back;
        static int ctrFragen = 0;
        static bool frageRichtig = false;
        static int richtigeFragen = 0;

        private static AnleitungFenster anleitungForm;
        private static EndUebersichtFenster endUebersichtForm;
        private static StartFenster startForm;
        private static FragenFenster fragenForm;




        public static int EVENT_BUTTON_BEENDEN = 0;
        public static int EVENT_BUTTON_START = 1;
        public static int EVENT_BUTTON_ANLEITUNG = 2;
        public static int EVENT_BUTTON_FRAGEABGEBEN = 3;
        public static int EVENT_BUTTON_WEITER = 4;





        public static void init()
        {
            fragenString = System.IO.File.ReadAllText("BioFragen.json");

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

        public static void onEvent(int eventID)
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

                if ( startForm.comboBox1.SelectedItem.ToString() != "Alle")
                {
                    anzFragen = Convert.ToInt32(startForm.comboBox1.SelectedItem.ToString());
                    quizFragen = fragenListe.getRandFragen(anzFragen);
                }
                else
                {
                    anzFragen = fragenListe.getAnzFragen();
                    quizFragen = fragenListe.getRandFragen(anzFragen);
                }


                back = anzFragen;
                fragenForm.radioButton1.Text = quizFragen[ctrFragen].dieAntworten[0];
                fragenForm.radioButton2.Text = quizFragen[ctrFragen].dieAntworten[1];
                fragenForm.radioButton3.Text = quizFragen[ctrFragen].dieAntworten[2];
                fragenForm.radioButton4.Text = quizFragen[ctrFragen].dieAntworten[3];
                fragenForm.label1.Text = quizFragen[ctrFragen].derFrageSatz;
                StringBuilder cap = new StringBuilder("Frage " + 1 + " von " + back);
                fragenForm.Text = cap.ToString();

                fragenForm.button1.Enabled = false;
                fragenForm.button2.Enabled = true;
                fragenForm.label3.Text = "";


                fragenForm.Show();
            }
            else if (eventID == EVENT_BUTTON_WEITER)
            {
                fragenForm.label3.Text = "";
                fragenForm.button2.Text = "Antwort abgeben";
                fragenForm.button2.BackColor = Color.Goldenrod;
                if (anzFragen > 1)
                {

                    StringBuilder cap = new StringBuilder("Frage " + (ctrFragen+2) + " von " + back);
                    fragenForm.Text = cap.ToString() ; 

                    ctrFragen++;
                    fragenForm.radioButton1.Text = quizFragen[ctrFragen].dieAntworten[0];
                    fragenForm.radioButton2.Text = quizFragen[ctrFragen].dieAntworten[1];
                    fragenForm.radioButton3.Text = quizFragen[ctrFragen].dieAntworten[2];
                    fragenForm.radioButton4.Text = quizFragen[ctrFragen].dieAntworten[3];
                    fragenForm.label1.Text = quizFragen[ctrFragen].derFrageSatz;
                    
                    anzFragen--;
                }
                else
                {
                    fragenForm.Hide();
                    int i = 0;
                    foreach (Frage x in quizFragen)
                    {
                        endUebersichtForm.dataGridView1.Rows.Add();
                        endUebersichtForm.dataGridView1.Rows[i].Cells[0].Value = x.derFrageSatz;
                        endUebersichtForm.dataGridView1.Rows[i].Cells[1].Value = x.getRichtigeAntwortString();
                        endUebersichtForm.dataGridView1.Rows[i].Cells[2].Value = x.dieAntworten[x.abgegebeneAntwort];
                        if(x.frageRichtigBeantwortet == 1)
                        {
                            richtigeFragen++;
                        }
                        endUebersichtForm.dataGridView1.AutoResizeRow(i);
                        i++;
                    }
                    endUebersichtForm.dataGridView1.Rows.Add();
                    StringBuilder rAntworten = new StringBuilder( "Du hast " + richtigeFragen + " Fragen richtig beantwortet.");
                    endUebersichtForm.dataGridView1.Rows[i].Cells[2].Value = rAntworten;
                    endUebersichtForm.Show();
  
                }
                fragenForm.button1.Enabled = false;
                fragenForm.button2.Enabled = true;

            }
            else if (eventID == EVENT_BUTTON_FRAGEABGEBEN)
            {
                if (fragenForm.radioButton1.Checked == true)
                {
                    frageRichtig = quizFragen[ctrFragen].beantworteFrage(0);
                }

                else if (fragenForm.radioButton2.Checked == true)
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


                if (frageRichtig)
                {
                    // fragenForm.label2.Text = "Richtig!";
                     fragenForm.label3.Text = quizFragen[ctrFragen].dieBegruendung; 
                    fragenForm.button2.Text = "Richtig!";
                }
                else
                {
                    //fragenForm.label2.Text = "Falsch!";
                    fragenForm.label3.Text = quizFragen[ctrFragen].dieBegruendung;
                    fragenForm.button2.BackColor = Color.Red;
                    fragenForm.button2.Text = "Falsch!";
                }
                fragenForm.button1.Enabled = true;
                fragenForm.button2.Enabled = false;
            }

        }
    }
}
