using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AdoNetLesson3
{
    public partial class Form1 : Form
    {
        SqlDataReader reader;
        DataTable dataTable;
        SqlConnection sqlConnection = null;
        string connString = @"Data Source=CR4-00\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True;";
        public Form1()
        {
            InitializeComponent();
            
        }


        private void btnExacute_Click(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(connString);

            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = textBox1.Text;
                sqlCommand.Connection = sqlConnection;

                dataGridView1.DataSource = null;

                sqlConnection.Open();
                dataTable = new DataTable();
                reader = sqlCommand.ExecuteReader();
                int line = 0;
                while (reader.Read())
                {
                    if(line == 0)
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            dataTable.Columns.Add(reader.GetName(i));
                        }
                    }
                    line++;
                    DataRow row = dataTable.NewRow();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        row[i] = reader[i];
                    }
                    dataTable.Rows.Add(row);
                }
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }
    }
}
