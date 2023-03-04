using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {   //too start timer
            timer1.Start();
        }

        private void label3_Click(object sender, EventArgs e)
        {
                   }


        //code for timer
        int start = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            start += 4;
            progressBar1.Value = start;
            if (progressBar1.Value == 100)
            {
                progressBar1.Value = 0;
                timer1.Stop();
                this.Hide();
                Login obj=new Login();
                obj.Show(); 
            }

        }
    }
}
