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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.Show();
            this.Hide();

        }


        // Logout code in home after logout it redirected in login form
        private void button2_Click(object sender, EventArgs e)
        {
            /*  Login log=new Login();
              log.Show();    // & display the login form for which we created a object
              this.Hide();  // means hide current form &..*/
            Application.Exit();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ViewEmployee obj=new ViewEmployee();
            obj.Show();
            this.Hide();

        }

        //Salary Code
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Salary sal = new Salary();
            sal.Show();
            this.Hide();
        }
    }
}
