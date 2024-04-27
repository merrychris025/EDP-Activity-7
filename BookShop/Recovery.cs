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
    public partial class Recovery : Form
    {

        private static readonly Dictionary<string, (string password, string securityQuestion, string securityAnswer)> UserCredentials = new Dictionary<string, (string, string, string)>
        {
            {"behati", ("Admin123", "What is your pet's name?", "panda")}
        };

        public Recovery()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

            Login login = new Login();
            login.Show();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
             
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            string username = txtUN.Text.Trim();
            string answer = txtAnswer.Text.Trim();

            // Check if the username exists in the dictionary
            if (UserCredentials.ContainsKey(username))
            {
                var (password, securityQuestion, securityAnswer) = UserCredentials[username];
            
            // Check if the entered answer matches the stored security answer
            if (answer.ToLower() == securityAnswer.ToLower())
            {
                MessageBox.Show($"Username: {username}\nPassword: {password}", "Your Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }
            else
            {
                MessageBox.Show("Incorrect security answer. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
            else
            {
                MessageBox.Show("Unknown username. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}
    }
}


