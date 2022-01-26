using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Problem4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string response = "";
            ProblemLogic problemLogic = new ProblemLogic();
            int thNumber = Convert.ToInt32(numericUpDown1.Value);

            response = problemLogic.CreateRandomNumber(thNumber);

            MessageBox.Show(response);


        }
    }
}
