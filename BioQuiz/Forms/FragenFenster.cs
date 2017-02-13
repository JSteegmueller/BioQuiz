using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            Program.main.onEvent(BioQuiz.Klassen.QuizSteuerung.EVENT_BUTTON_WEITER);
        }

        private void FragenFenster_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.main.onEvent(BioQuiz.Klassen.QuizSteuerung.EVENT_BUTTON_FRAGEABGEBEN);
        }
    }
}
