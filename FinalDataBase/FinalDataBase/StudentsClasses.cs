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
    public partial class StudentsClasses : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        private OleDbConnection connection2 = new OleDbConnection();

        public StudentsClasses()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Debora UT\Desktop\FINAL GUI\FinalDataBase\Student.mdb";
            connection2.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Debora UT\Desktop\FINAL GUI\FinalDataBase\Student.mdb";
        }

        private void StudentsClasses_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'studentDataSet.Classes' table. You can move, or remove it, as needed.
            //this.classesTableAdapter.Fill(this.studentDataSet.Classes);

            //load Student Info
            WindowState = FormWindowState.Maximized;
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            string wkname = RecordSelected.selname;
            string lastname = wkname.Split(',')[0];
            string firstname = wkname.Split(',')[1].Trim();
            command.CommandText = "Select * from Students where [Last Name] ='" + lastname + "' AND [First Name] = '" + firstname + "';";
            OleDbDataReader reader = command.ExecuteReader();
            reader.Read();
                        
            //RecordSelected.selid = reader["Student ID"].ToString();
            txtID.Text = reader["Student ID"].ToString();
            txtFirstName.Text = reader["First Name"].ToString();
            txtLastName.Text = reader["Last Name"].ToString();
            txtGender.Text = reader["Gender"].ToString();
            txtMajor.Text = reader["Major"].ToString();

            connection.Close();

            //***********************************************************
            try
            {
                //Load up Data Grid
                connection2.Open();
                string sql = "Select [Course],[Section],[Grade] from Classes where [Student ID] = " + txtID.ToString() + ";";//RecordSelected.selid.ToString() + ";"; 
                OleDbConnection connectionc = new OleDbConnection(connection2.ConnectionString);
                OleDbDataAdapter dataadapter = new OleDbDataAdapter(sql, connection2);
                DataSet ds = new DataSet();
                //connectionc.Open();
                
                //connectionc.Close();
                dataGridView1.DataSource = studentDataSet;
                dataGridView1.DataMember = "Classes";
                dataadapter.Fill(studentDataSet, "Classes");

                //this.classesTableAdapter.Fill(this.studentDataSet.Classes);
                connection2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex);
            }

        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
