using ClosedXML.Excel;
using MySql.Data.MySqlClient;
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
    public partial class Details : Form
    {
        public Details()
        {
            InitializeComponent();
            LoadDetails();
            LoadReport();

        }
        private void LoadDetails()
        {
            string connectionString = "Server=127.0.0.1;Port=3306;Database=book_shop;Uid=behati;Pwd=Admin123;";
            string sql = "SELECT * FROM book_shop.CustomerOrderView";

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
                            dataGridViewDeets.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error loading details: " + ex.Message);
            }
        }

        private void Details_Load(object sender, EventArgs e)
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dataGridViewDeets.Rows.Count == 0)
            {
                MessageBox.Show("No Data To Export.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var workbook = new XLWorkbook("C://Users//User//Documents/Template.xlsx"))
            {
                var worksheet = workbook.Worksheet("Sheet1");

                int startRow = 10;

                for (int i = 0; i < dataGridViewDeets.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridViewDeets.Columns.Count; j++)
                    {
                        object cellValue = dataGridViewDeets.Rows[i].Cells[j].Value;
                        if (cellValue != null)
                        {
                            worksheet.Cell(startRow + i, j + 1).Value = cellValue.ToString();
                        }
                    }
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();

                saveFileDialog.Filter = "Excel files(*.xlsx)|*.xlsx|All files (*.*)|*.*";

                saveFileDialog.FileName = "PurchasedDetails.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        workbook.SaveAs(saveFileDialog.FileName);

                        MessageBox.Show("Export Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error saving file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        
    }

        private void AboutBtn_Click_1(object sender, EventArgs e)
        {
            this.Close();
            About about = new About();
            about.Show();
        }

        private void LoadReport()
        {
            string connectionString = "Server=127.0.0.1;Port=3306;Database=book_shop;Uid=behati;Pwd=Admin123;";
            string sql = "SELECT * FROM book_shop.MonthlySalesView";

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
                            dataGridViewMonth.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error loading report: " + ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridViewMonth.Rows.Count == 0)
            {
                MessageBox.Show("No Data To Export.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var workbook = new XLWorkbook("C://Users//User//Documents/Template.xlsx"))
            {
                var worksheet = workbook.Worksheet("Sheet1");

                int startRow = 10;

                for (int i = 0; i < dataGridViewMonth.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridViewMonth.Columns.Count; j++)
                    {
                        object cellValue = dataGridViewMonth.Rows[i].Cells[j].Value;
                        if (cellValue != null)
                        {
                            worksheet.Cell(startRow + i, j + 1).Value = cellValue.ToString();
                        }
                    }
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();

                saveFileDialog.Filter = "Excel files(*.xlsx)|*.xlsx|All files (*.*)|*.*";

                saveFileDialog.FileName = "MonthlyReport.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        workbook.SaveAs(saveFileDialog.FileName);

                        MessageBox.Show("Export Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error saving file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }
    }
}
