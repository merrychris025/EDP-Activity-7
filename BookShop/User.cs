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
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
            LoadActiveAccounts();

            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            this.btnDelete.Click += new System.EventHandler(this.DeactivateAccount_Click);

            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

        }

        private void LoadActiveAccounts()
        {
            string connectionString = "Server=127.0.0.1;Port=3306;Database=book_shop;Uid=behati;Pwd=Admin123;";
            string sql = "SELECT * FROM users WHERE status = 'active'";

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
                            dataGridView1.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error loading active accounts: " + ex.Message);
            }
        }

        private void AddAccount(string username, string password)
        {
            string connectionString = "Server=127.0.0.1;Port=3306;Database=book_shop;Uid=behati;Pwd=Admin123;";
            string sql = "INSERT INTO users (username, password, status) VALUES (@username, @password, 'Active')";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Account added successfully.");
                LoadActiveAccounts(); // Refresh DataGridView after adding account
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error adding account: " + ex.Message);
            }
        }

        private void UpdateAccount(int userId, string username, string password)
        {
            string connectionString = "Server=127.0.0.1;Port=3306;Database=book_shop;Uid=behati;Pwd=Admin123;";
            string sql = "UPDATE users SET username = @username, password = @password WHERE id = @id";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", userId);
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Account updated successfully.");
                LoadActiveAccounts(); // Refresh DataGridView after updating account
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error updating account: " + ex.Message);
            }
        }

        private void ActivateAccount(int userId)
        {
            string connectionString = "Server=127.0.0.1;Port=3306;Database=book_shop;Uid=behati;Pwd=Admin123;";
            string sql = "UPDATE users SET status = 'active' WHERE id = @id";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", userId);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Account activated successfully.");
                LoadActiveAccounts(); // Refresh DataGridView after activating account
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error activating account: " + ex.Message);
            }
        }

        private void DeactivateAccount(int userId)
        {
            string connectionString = "Server=127.0.0.1;Port=3306;Database=book_shop;Uid=behati;Pwd=Admin123;";
            string sql = "UPDATE users SET status = 'inactive' WHERE id = @id";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", userId);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Account deactivated successfully.");
                LoadActiveAccounts(); // Refresh DataGridView after deactivating account
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error deactivating account: " + ex.Message);
            }
        }



        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string username = txtUN.Text;
            string password = txtPW.Text;
            AddAccount(username, password);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                int userId = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["id"].Value);
                string username = txtUN.Text;
                string password = txtPW.Text;
                UpdateAccount(userId, username, password);
            }
            else
            {
                MessageBox.Show("Please select a row to update.");
            }
        }

        private void ActivateAccount_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                int userId = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["id"].Value);
                ActivateAccount(userId);
            }
            else
            {
                MessageBox.Show("Please select a row to activate.");
            }
        }

        private void DeactivateAccount_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                int userId = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["id"].Value);
                DeactivateAccount(userId);
            }
            else
            {
                MessageBox.Show("Please select a row to deactivate.");
            }
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            string username = txtSearch.Text;
            SearchAccounts(username);
        }

        private void SearchAccounts(string username)
        {
            string connectionString = "Server=127.0.0.1;Port=3306;Database=book_shop;Uid=behati;Pwd=Admin123;";
            string sql = "SELECT * FROM users WHERE username LIKE @username AND status = 'Active'"; // Modify as needed

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", "%" + username + "%");
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            dataGridView1.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error searching accounts: " + ex.Message);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Dashbtn_Click(object sender, EventArgs e)
        {
            this.Close();
            Home home = new Home();
            home.Show();
        }

        private void AboutBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            About about = new About();
            about.Show();
        }

        private void UsersBtn_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Books books = new Books();
            books.Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
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

        private void txtUN_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
