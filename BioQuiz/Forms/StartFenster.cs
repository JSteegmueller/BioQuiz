using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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
            Program.main.onEvent(QuizSteuerung.EVENT_BUTTON_START);  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.main.onEvent(QuizSteuerung.EVENT_BUTTON_BEENDEN);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Program.main.onEvent(QuizSteuerung.EVENT_BUTTON_ANLEITUNG);
        }
    }
}
