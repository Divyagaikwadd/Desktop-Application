using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace MyApp
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }

        //connection with sql inside Server Explorer of EmployeeDB
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ADMIN\Documents\EmployeeDB.mdf;Integrated Security=True;Connect Timeout=30");

        //to display the data on grid when the form is load 
        private void populate()
        {
            con.Open();
            string query = "select * from EmployeeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            EmpDGV.DataSource = ds.Tables[0];


            con.Close();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //if the field is empty then show the message
            if (Id.Text == "" || Name.Text == "" || Phoneno.Text == "" || Address.Text == "")
            {
                MessageBox.Show("Please Enter the all Fields");
            }
            else
            {
                // else add the data code might has exception then write inside the try catch
                try
                {

                    con.Open();
                    //insertion query
                    string query = "insert into EmployeeTbl values('" + Id.Text + "','" + Name.Text + "','" + Address.Text + "','" + Phoneno.Text + "','" + Gender.SelectedItem.ToString() + "','" + Position.SelectedItem.ToString() + "','" + Education.SelectedItem.ToString() + "')";
                    // string query = "INSERT INTO EmployeeTbl (Id, Name, Address, Phoneno,Gender, Position, Education) VALUES (@Id, @Name, @Address,  @Phoneno , @Gender,@Position, @Education)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Successfully Added");
                   
                    con.Close();
                    populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // Code to delete the Employee
        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (Id.Text == "")
            {
                MessageBox.Show("Enter The Employee ID ");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "delete from EmployeeTbl where Id='" + Id.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Deleted Successfully");
                    con.Close();
                    populate();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }
        }

        // Code for update the Employee data
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (Id.Text == "")
            {

                MessageBox.Show("Missing Information");

            }
            else
            {
                try
                {
                    con.Open();
                    string query = "update EmployeeTbl set Name='" + Name.Text + "',Address='" + Address.Text + "',Phoneno='" + Phoneno + "',Position='" + Position.SelectedItem.ToString() + "',Education='" + Education.SelectedItem.ToString() + "'where Id='" + Id.Text + "'; ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee updated Successfully");
                    con.Close();
                    populate();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // code to redirect to home page
        private void btnHome_Click(object sender, EventArgs e)
        {
            Home home=new Home();
            home.Show();
            this.Hide();
        }
    }
}
