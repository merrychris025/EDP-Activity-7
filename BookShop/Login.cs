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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

                 string username = txtUsername.Text;
                 string password = txtPass.Text;
                 string hostname = "127.0.0.1";
                 int port = 3306;

                 string connectionString = $"Server={hostname};Port={port};Database=book_shop;Uid={username};Pwd={password};AllowPublicKeyRetrieval=true;SslMode=Preferred;";

                 MySqlConnection connection = new MySqlConnection(connectionString);

                 try
                 {
                     connection.Open();
                     MessageBox.Show("CONNECTED: Logged In Successfully");

                    this.Hide();

                    Home home = new Home(username,password,hostname,port);
                    home.Show();
                }catch(Exception a){
                    MessageBox.Show("Error Connecting" + a.Message);
                }
                finally
               {
                connection.Close();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit this program?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Recovery recovery = new Recovery();
            recovery.ShowDialog();
        }
    }
}
