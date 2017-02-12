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
    }
}
