using System;
using System.Windows.Forms;

namespace BioQuiz.Forms
{
    public partial class EndUebersichtFenster : Form
    {
        public EndUebersichtFenster()
        {
            InitializeComponent();
        }

        private void EndUebersichtFenster_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
