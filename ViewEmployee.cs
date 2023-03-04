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
    public partial class ViewEmployee : Form
    {
        public ViewEmployee()
        {
            InitializeComponent();
        }
        //connection with sql inside Server Explorer of EmployeeDB
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ADMIN\Documents\EmployeeDB.mdf;Integrated Security=True;Connect Timeout=30");
       

        //method for display the all data after entering the Employee Id
        private void fetchempdata()
        {
            con.Open();
            string query = "select * from EmployeeTbl where Id='" + IdSearch.Text + "'";
            SqlCommand cmd=new SqlCommand(query,con);
            DataTable dt=new DataTable();
            SqlDataAdapter sda=new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                Idlbl.Text = dr["Id"].ToString();
                Namelbl.Text = dr["Name"].ToString();
                Addresslbl.Text = dr["Address"].ToString();
                Phonenolbl.Text = dr["Phoneno"].ToString();
                Genderlbl.Text = dr["Gender"].ToString() ;
                Positionlbl.Text = dr["Position"].ToString();
                Educationlbl.Text = dr["Education"].ToString();
                //visible option in form make false to display data on click we made here true
                Idlbl.Visible = true;
                Namelbl.Visible = true;
                Addresslbl.Visible = true;
                Phonenolbl.Visible = true;
                Genderlbl.Visible = true;
                Positionlbl.Visible = true;
                Educationlbl.Visible = true;
            }
            con.Close();
        }
        private void ViewEmployee_Load(object sender, EventArgs e)
        {

        }

        //code for refresh button
        private void btnDelete_Click(object sender, EventArgs e)
        {
            fetchempdata(); 
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
        //code for print buttton
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(printPreviewDialog1.ShowDialog()==DialogResult.OK){
                printDocument1.Print();

            }
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {
            
        }

        //To Display details in Print
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("\n\nEmployee Details", new Font("Sitka Subheading", 26, FontStyle.Bold), Brushes.DarkBlue, new Point(200));
            e.Graphics.DrawString("\n\n\n\n\nEmployee Id : "+Idlbl.Text+"\nEmployee Name : "+Namelbl.Text + "\nEmployee Address : " + Addresslbl.Text + "\nEmployee Gender : " + Genderlbl.Text + "\nEmployee Phone N0 : " + Phonenolbl.Text + "\nEmployee Education : " + Educationlbl.Text + "\nEmployee Position : " + Positionlbl.Text, new Font("Sitka Subheading", 22, FontStyle.Bold), Brushes.DarkBlue, new Point(200));
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
