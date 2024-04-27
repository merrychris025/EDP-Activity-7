using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                Login login = new Login();
                login.Show();

                MessageBox.Show("Logged out Successfully!");
                this.Close();

                Environment.Exit(0);

            }
            else
            {

            }
        }

        private void Dashbtn_Click(object sender, EventArgs e)
        {
            this.Close();
            Home home = new Home();
            home.Show();
        }

        private void UsersBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            User user = new User();
            user.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Books books = new Books();
            books.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Sales sales = new Sales();
            sales.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Customers customers = new Customers();
            customers.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Details details = new Details();
            details.Show();
        }
    }
}
