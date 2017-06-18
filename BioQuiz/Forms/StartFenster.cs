using System;
using System.Windows.Forms;
using BioQuiz.Klassen;

namespace BioQuiz.Forms
{
    public partial class StartFenster : Form
    {
        public StartFenster()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Program.main.onEvent(QuizSteuerung.EVENT_BUTTON_START); 
            QuizSteuerung.onEvent(QuizSteuerung.EVENT_BUTTON_START);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Program.main.onEvent(QuizSteuerung.EVENT_BUTTON_BEENDEN);
            QuizSteuerung.onEvent(QuizSteuerung.EVENT_BUTTON_BEENDEN);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Program.main.onEvent(QuizSteuerung.EVENT_BUTTON_ANLEITUNG);
            QuizSteuerung.onEvent(QuizSteuerung.EVENT_BUTTON_ANLEITUNG);
        }

        private void StartFenster_Load(object sender, EventArgs e)
        {

        }
    }
}
