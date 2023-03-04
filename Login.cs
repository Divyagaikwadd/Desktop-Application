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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        //login button code
        private void button1_Click(object sender, EventArgs e)
        {
            if(UserId.Text=="" || Password.Text == "")
            {
                MessageBox.Show("Enter UserID or Password ");

            }else if (UserId.Text=="Admin" && Password.Text=="Admin123@")
            {
                this.Hide();
                Home obj = new Home();
                obj.Show();
            }
            else
            {
                MessageBox.Show("Wrong UserID Or Password");
            }
        }

        //to Exit the application
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void UserId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
