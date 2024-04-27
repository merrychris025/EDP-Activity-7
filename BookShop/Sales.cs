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

namespace BookShop
{
    public partial class Sales : Form
    {
        public Sales()
        {
            InitializeComponent();
            LoadSales();

            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
        }

        private void LoadSales()
        {
            string connectionString = "Server=127.0.0.1;Port=3306;Database=book_shop;Uid=behati;Pwd=Admin123;";
            string sql = "SELECT * FROM book_shop.productsalesview";

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
                            dataGridViewSales.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error loading sales: " + ex.Message);
            }
        }
        private void dataGridViewBook_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dataGridViewSales.Rows.Count == 0)
            {
                MessageBox.Show("No Data To Export.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var workbook = new XLWorkbook("C://Users//User//Documents/Template.xlsx"))
            {
                var worksheet = workbook.Worksheet("Sheet1");

                int startRow = 10;

                for (int i = 0; i < dataGridViewSales.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridViewSales.Columns.Count; j++)
                    {
                        object cellValue = dataGridViewSales.Rows[i].Cells[j].Value;
                        if (cellValue != null)
                        {
                            worksheet.Cell(startRow + i, j + 1).Value = cellValue.ToString();
                        }
                    }
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();

                saveFileDialog.Filter = "Excel files(*.xlsx)|*.xlsx|All files (*.*)|*.*";

                saveFileDialog.FileName = "Customers.xlsx";

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

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Details details = new Details();
            details.Show();
        }

        private void AboutBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            About about = new About();
            about.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Customers customers = new Customers();
            customers.Show();
        }
    }
    }
