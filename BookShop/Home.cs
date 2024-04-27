using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace BookShop
{
    public partial class Home : Form
    {
        private string username;
        private string password;
        private string hostname;
        private int port;

        public Home(string username, string password, string hostname, int port)
        {
            InitializeComponent();
            this.username = username;
            this.password = password;
            this.hostname = hostname;
            this.port = port;
        }

        public Home()
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {

                Login login = new Login();
                login.Show();

                MessageBox.Show("Logged out Successfully!");
                this.Close();

            }
            else
            {

            }

        }


private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Close();
            User user = new User();
            user.Show();

        }

        private void AboutBtn_Click(object sender, EventArgs e)
        {
          this.Close();
          About about = new About();
          about.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Sales sales = new Sales();
            sales.Show();

        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            this.Close();
            Books books = new Books();
            books.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Customers customers = new Customers();
            customers.Show();
        }

        private void button4_Click_2(object sender, EventArgs e)
        {
            this.Close();
            Details details = new Details();
            details.Show();
        }
    }
}
