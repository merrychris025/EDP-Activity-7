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
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Bibliography;


namespace BookShop
{
    public partial class Books : Form
    {
        public Books()
        {
            InitializeComponent();
            LoadBooks();

            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
        }

        private void LoadBooks()
        {
            string connectionString = "Server=127.0.0.1;Port=3306;Database=book_shop;Uid=behati;Pwd=Admin123;";
            string sql = "SELECT * FROM book_shop.Products";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            dataGridViewBook.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message);
            }
        }

        private void AddBooks(string ProductName, decimal Price, int CategoryID)
        {
            string connectionString = "Server=127.0.0.1;Port=3306;Database=book_shop;Uid=behati;Pwd=Admin123;";
            string sql = "INSERT INTO Customers (ProductName, Price, CategoryID) VALUES (@ProductName, @Price, @CategoryID)";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProductName", ProductName);
                        cmd.Parameters.AddWithValue("@Price", Price);
                        cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Customer Detail added successfully.");
                LoadBooks(); // Refresh DataGridView after adding account
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error adding products: " + ex.Message);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lgt_Click(object sender, EventArgs e)
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

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Customers customers = new Customers();
            customers.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Sales sales = new Sales();
            sales.Show();
        }

        private void AboutBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            About about = new About();
            about.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Details details = new Details();
            details.Show();
        }
    }
}
