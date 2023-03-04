using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace MyApp
{
    public partial class Salary : Form
    {
        public Salary()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        //View button code to calculate Salary according to Days
        int Dailybase,total;
        private void button1_Click(object sender, EventArgs e)
        {
            if (Positionlbl.Text == "")
            {
                MessageBox.Show("Select An Employee");
            }
            else if(Dayslbl.Text==""|| Convert.ToInt32(Dayslbl.Text) > 28)
            {
                MessageBox.Show("Enter Valid Number of Days");
            }
            else
            {
                if (Positionlbl.Text == "Manager")
                {
                    Dailybase = 250;
                }else if(Positionlbl.Text=="Senior Developer")
                {
                    Dailybase = 230;
                }else if(Positionlbl.Text=="Junior Developer")
                {
                    Dailybase = 200;
                }
                else
                {
                    Dailybase = 100;
                }
                total=Dailybase * Convert.ToInt32(Dayslbl.Text); 
                SalarySlip.Text="\t\t\tEmployee Details\t\t\t\n\n"+"\t\tEmployee ID : "+Idlbl.Text+"\n"+"\t\tEmployee Name : "+Namelbl.Text+"\n"+"\t\tEmployee Position : "+Positionlbl.Text+"\n"+"\t\tWorking Days : "+Dayslbl.Text+"\n"+"\t\tEmployee Salary : "+total;
            }
        }

        //connection with sql inside Server Explorer of EmployeeDB
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ADMIN\Documents\EmployeeDB.mdf;Integrated Security=True;Connect Timeout=30");

        //code for Home Button
        private void btnHome_Click(object sender, EventArgs e)
        {
            Home obj = new Home();
            obj.Show();
            this.Hide();
        }
        //method for display the all data after entering the View button of Salary
        private void fetchempdata()
        {

            if (Idlbl.Text == "")
            {
                MessageBox.Show("Enter Employee Id");
            }
            else
            {

                con.Open();
                string query = "select * from EmployeeTbl where Id='" + Idlbl.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    // Idlbl.Text = dr["Id"].ToString();
                    Namelbl.Text = dr["Name"].ToString();
                    Positionlbl.Text = dr["Position"].ToString();

                }
                con.Close();
            }


        }
        private void Salary_Load(object sender, EventArgs e)
        {

        }

        private void SalarySlip_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //code for print button
        private void button2_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();

            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("\n\nEmployee Details", new Font("Sitka Subheading", 26, FontStyle.Bold), Brushes.DarkBlue, new Point(200));
            e.Graphics.DrawString("\n\n\n\n"+"Employee ID : "+Idlbl.Text+"\n"+"Employee Name : "+Namelbl.Text+"\n"+"Employee Position : "+Positionlbl.Text+"\n"+"Working Days : "+Dayslbl.Text+"\n"+"Employee Salary : "+total, new Font("Sitka Subheading", 22, FontStyle.Bold), Brushes.DarkBlue, new Point(200));

        }

        private void Deletebtn_Click(object sender, EventArgs e)
        {
            fetchempdata();
        }
    }
}
