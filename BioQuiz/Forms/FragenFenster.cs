using System;
using System.Windows.Forms;
using BioQuiz.Klassen;

namespace BioQuiz.Forms
{
    public partial class FragenFenster : Form
    {
        public FragenFenster()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FragenFenster_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Program.main.onEvent(Klassen.QuizSteuerung.EVENT_BUTTON_WEITER);
            QuizSteuerung.onEvent(QuizSteuerung.EVENT_BUTTON_WEITER);
        }

        private void FragenFenster_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Program.main.onEvent(Klassen.QuizSteuerung.EVENT_BUTTON_FRAGEABGEBEN);
            QuizSteuerung.onEvent(QuizSteuerung.EVENT_BUTTON_FRAGEABGEBEN);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
