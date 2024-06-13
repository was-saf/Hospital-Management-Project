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

namespace Hospital_Mangement_System
{
    public partial class Admin : Form
    {

        SqlConnection conn = new SqlConnection(@"Data Source=WASSAF;Initial Catalog=Hospital;Integrated Security=True");

        public Admin()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabelUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            User user = new User();
            user.Show();
            this.Hide();
        }


        private void btnAdminLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Enter Username and Password");
                return;
            }

            string username = txtUsername.Text;
            string password = txtPassword.Text;

            string query = "SELECT COUNT(*) FROM Admin WHERE Username = @Username AND Password = @Password";

            using (conn)
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        int count = (int)cmd.ExecuteScalar();

                        if (count > 0)
                        {
                            Doctor doctor = new Doctor();
                            doctor.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid Username or Password");
                            Admin admin = new Admin();
                            admin.Show();
                            this.Hide();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
