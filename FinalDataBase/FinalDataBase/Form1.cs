using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace FinalDataBase
{
    public partial class Form1 : Form
    {
        private OleDbConnection connection = new OleDbConnection();

        public Form1()
        {
            InitializeComponent();
            connection.ConnectionString= @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Debora UT\Desktop\FINAL GUI\FinalDataBase\Student.mdb";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            try
            {
                connection.Open();
            }
            catch
            {
                MessageBox.Show("problem");

            }
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "select * from Students;";

            OleDbDataReader reader = command.ExecuteReader();

            cmb_Names.Items.Clear();

            int count = 0;
            while (reader.Read())
            {
                //cmb_Names.Items.Add(reader[2].ToString() + ", " + reader[3].ToString());  || or use
                cmb_Names.Items.Add(reader["Last Name"].ToString() + ", " + reader["First Name"].ToString());
                count = count + 1;

            }
        }

        private void btn_select_Click(object sender, EventArgs e)
        {
            if (cmb_Names.SelectedItem != null)
            {                
                RecordSelected.selid = cmb_Names.SelectedIndex.ToString();
                RecordSelected.selname = cmb_Names.Text.ToString();

                connection.Close();

                StudentsClasses showstudentsclasses = new StudentsClasses();
                showstudentsclasses.Visible = true;                
            }
            else
            {
                MessageBox.Show("Please Select Name", "Input Error");
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
