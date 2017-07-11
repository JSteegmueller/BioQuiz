using System;
using BioQuiz.Klassen;
using System.Windows.Forms;

namespace BioQuiz.Forms
{
    public partial class FragenEditor : Form
    {
        public FragenEditor()
        {
            InitializeComponent();
        }

        public void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            QuizSteuerung.onEvent(QuizSteuerung.EVENT_INDEX_CHANGE_EDIT);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            QuizSteuerung.onEvent(QuizSteuerung.EVENT_BUTTON_BACK);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            QuizSteuerung.onEvent(QuizSteuerung.EVENT_BUTTON_NEW_QUESTION);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QuizSteuerung.onEvent(QuizSteuerung.EVENT_BUTTON_FRAGE_LOESCHEN);
        }
    }
}
