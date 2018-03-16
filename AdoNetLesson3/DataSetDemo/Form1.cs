using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DataSetDemo
{
    public partial class Form1 : Form
    {
        string connString = @"Data Source=CR4-00\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True;";
        SqlConnection sqlConnetion;
        SqlDataAdapter sqlDataAdapter;
        DataSet dataSet = null;
        SqlCommandBuilder sqlCommandBuilder = null;
        public Form1()
        {
            InitializeComponent();
            sqlConnetion = new SqlConnection(connString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataSet = new DataSet();
                sqlDataAdapter = new SqlDataAdapter(textBox1.Text, sqlConnetion);
                dataGridView1.DataSource = null;
                sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);
                sqlDataAdapter.Fill(dataSet, "myHome");
                dataGridView1.DataSource = dataSet.Tables["myHome"];
            }
            catch
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sqlDataAdapter.Update(dataSet, "myHome");
        }
    }
}
