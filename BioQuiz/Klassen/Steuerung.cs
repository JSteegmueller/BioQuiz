using System;
using System.Text;
using BioQuiz.Forms;
using BioQuiz.Properties;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace BioQuiz.Klassen
{
    static class QuizSteuerung
    {
        private static FragenCreator fragenReader;
        private static FragenKatalog myFragenKatalog;
        private static string fragenString;
        private static Frage[] quizFragen;
        static int alterAusgewKatalogEintrag = 0;
        static int ausgewKatalogEintrag;
        static int anzFragen;
        static int back;
        static int ctrFragen = 0;
        static bool frageRichtig = false;
        static int richtigeFragen = 0;
        static Frage[] alleFragen;

        private static AnleitungFenster anleitungForm;
        private static EndUebersichtFenster endUebersichtForm;
        private static StartFenster startForm;
        private static FragenFenster fragenForm;
        private static FragenEditor fragenEditForm;




        public static int EVENT_BUTTON_BEENDEN = 0;
        public static int EVENT_BUTTON_START = 1;
        public static int EVENT_BUTTON_ANLEITUNG = 2;
        public static int EVENT_BUTTON_FRAGEABGEBEN = 3;
        public static int EVENT_BUTTON_WEITER = 4;
        public static int EVENT_BUTTON_BEARBEITEN = 5;
        public static int EVENT_BUTTON_BACK = 6;
        public static int EVENT_INDEX_CHANGE_EDIT = 7;
        public static int EVENT_BUTTON_NEW_QUESTION = 8;
        public static int EVENT_BUTTON_SAVE_QUESTION = 9;





        public static void init()
        {
            fragenString = Encoding.Default.GetString(Resources.BioFragen);

            fragenReader = new FragenCreator(fragenString);
            myFragenKatalog = new FragenKatalog(fragenReader.getFragen());


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
                    quizFragen = myFragenKatalog.GetRandFragen(anzFragen);
                }
                else
                {
                    anzFragen = myFragenKatalog.GetAnzFragen();
                    quizFragen = myFragenKatalog.GetRandFragen(anzFragen);
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

                    foreach ( Control myCont in fragenForm.Controls)
                    {
                        myCont.Visible = false;
                    }
                    

                    StringBuilder cap = new StringBuilder("Frage " + (ctrFragen+2) + " von " + back);
                    fragenForm.Text = cap.ToString() ; 

                    ctrFragen++;
                    fragenForm.radioButton1.Text = quizFragen[ctrFragen].dieAntworten[0];
                    fragenForm.radioButton2.Text = quizFragen[ctrFragen].dieAntworten[1];
                    fragenForm.radioButton3.Text = quizFragen[ctrFragen].dieAntworten[2];
                    fragenForm.radioButton4.Text = quizFragen[ctrFragen].dieAntworten[3];
                    fragenForm.label1.Text = quizFragen[ctrFragen].derFrageSatz;
                    
                    anzFragen--;

                    foreach (Control myCont in fragenForm.Controls)
                    {
                        myCont.Visible = true;
                    }


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
                    fragenForm.button2.BackColor = Color.Green;
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
            else if (eventID == EVENT_BUTTON_BEARBEITEN)
            {
                fragenEditForm = new FragenEditor();
                refreshList();
                fragenEditForm.textBox1.Text = alleFragen[0].derFrageSatz;
                fragenEditForm.textBox2.Text = alleFragen[0].dieAntworten[0];
                fragenEditForm.textBox3.Text = alleFragen[0].dieAntworten[1];
                fragenEditForm.textBox4.Text = alleFragen[0].dieAntworten[2];
                fragenEditForm.textBox5.Text = alleFragen[0].dieAntworten[3];
                fragenEditForm.numericUpDown1.Value = alleFragen[0].getRichtigeAntwortInt() + 1;
                fragenEditForm.textBox7.Text = alleFragen[0].dieBegruendung;

                fragenEditForm.Show();
                
            }
            else if (eventID == EVENT_INDEX_CHANGE_EDIT)
            {
                ausgewKatalogEintrag = fragenEditForm.listBox1.SelectedIndex;
                saveQuestion();
                if ( ausgewKatalogEintrag != -1)
                {
                    fragenEditForm.textBox1.Text = alleFragen[ausgewKatalogEintrag].derFrageSatz;
                    fragenEditForm.textBox2.Text = alleFragen[ausgewKatalogEintrag].dieAntworten[0];
                    fragenEditForm.textBox3.Text = alleFragen[ausgewKatalogEintrag].dieAntworten[1];
                    fragenEditForm.textBox4.Text = alleFragen[ausgewKatalogEintrag].dieAntworten[2];
                    fragenEditForm.textBox5.Text = alleFragen[ausgewKatalogEintrag].dieAntworten[3];
                    fragenEditForm.numericUpDown1.Value = alleFragen[ausgewKatalogEintrag].getRichtigeAntwortInt() + 1;
                    fragenEditForm.textBox7.Text = alleFragen[ausgewKatalogEintrag].dieBegruendung;
                    refreshList();
                    alterAusgewKatalogEintrag = ausgewKatalogEintrag;
                }
            }
            else if (eventID == EVENT_BUTTON_BACK)
            {
                fragenEditForm.Close();
            }
            else if (eventID == EVENT_BUTTON_NEW_QUESTION)
            {
                Frage neueFrage = new Frage();

                neueFrage.derFrageSatz = fragenEditForm.textBox1.Text = "NeueFrage";
                neueFrage.dieAntworten[0] =  fragenEditForm.textBox2.Text = null;
                neueFrage.dieAntworten[1] = fragenEditForm.textBox3.Text = null;
                neueFrage.dieAntworten[2] = fragenEditForm.textBox4.Text = null;
                neueFrage.dieAntworten[3] = fragenEditForm.textBox5.Text = null;
                fragenEditForm.numericUpDown1.Value = new decimal(1);
                neueFrage.richtigAntwort = (int)fragenEditForm.numericUpDown1.Value; 
                neueFrage.dieBegruendung =  fragenEditForm.textBox7.Text = null; 

                myFragenKatalog.addFrageAtEnd(neueFrage);

                alterAusgewKatalogEintrag = fragenEditForm.listBox1.Items.Count ;
                ausgewKatalogEintrag = fragenEditForm.listBox1.SelectedIndex;
                saveQuestion();
                refreshList();
                fragenEditForm.listBox1.SelectedItem = fragenEditForm.listBox1.Items.Count - 1;

            }
        }

        public static void saveQuestion()
        {
            List<Frage> myFragenListe = myFragenKatalog.GetFragenListe();

            Frage editierteFrage = myFragenListe[alterAusgewKatalogEintrag];
            editierteFrage.derFrageSatz = fragenEditForm.textBox1.Text;
            editierteFrage.dieBegruendung = fragenEditForm.textBox7.Text;
            editierteFrage.richtigAntwort = (int)fragenEditForm.numericUpDown1.Value - 1;
            editierteFrage.dieAntworten[0] = fragenEditForm.textBox2.Text;
            editierteFrage.dieAntworten[1] = fragenEditForm.textBox3.Text;
            editierteFrage.dieAntworten[2] = fragenEditForm.textBox4.Text;
            editierteFrage.dieAntworten[3] = fragenEditForm.textBox5.Text;

        }

        public static void refreshList()
        {
            alleFragen = myFragenKatalog.GetAlleFragen();
            fragenEditForm.listBox1.Items.Clear();
            foreach (Frage eineFrage in alleFragen)
            {
                fragenEditForm.listBox1.Items.Add(eineFrage.derFrageSatz);
            }
        }
    }
}
