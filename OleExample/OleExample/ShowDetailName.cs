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

namespace OleExample
{
    public partial class ShowDetailForm : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        private OleDbConnection connection2 = new OleDbConnection();

        public ShowDetailForm()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Workarea\Contactmanager.accdb;";
            connection2.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Workarea\Contactmanager.accdb;";
        }

        private void ShowDetailForm_Load(object sender, EventArgs e)
        {
            //load contact information
            WindowState = FormWindowState.Maximized;
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            string wkname = RecordSelected.selname;
            string lastname = wkname.Split(',')[0];
            string firstname = wkname.Split(',')[1].Trim();
            command.CommandText = "select * from contacts where [Last Name] ='" + lastname + "' AND [First Name] = '" + firstname + "';";
            OleDbDataReader reader = command.ExecuteReader();
            reader.Read();

            RecordSelected.selid = reader["ID"].ToString();
            txtFirstName.Text = reader["First Name"].ToString();
            txtLastName.Text = reader["Last Name"].ToString();
            txtEMailAddress.Text = reader["E-mail Address"].ToString();
            txtJobTitle.Text = reader["Job Title"].ToString();
            txtPhoneNo.Text = reader["Business Phone"].ToString();
            connection.Close();

            /*load call information
            connection2.Open();

            string sql = "Select [CALL TIME], [SUBJECT], [NOTES] from calls where [Contact] = "+ RecordSelected.selid.ToString()+ ";";
            OleDbConnection connectionc = new OleDbConnection(connection2.ConnectionString);
            OleDbDataAdapter dataadapter = new OleDbDataAdapter(sql, connection2);

            DataSet ds = new DataSet();
            dataadapter.Fill(ds, "Calls");
            connectionc.Close();

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Calls";
            //***********/
            try
            {
                //Load up Data Grid
                connection2.Open();
                //OleDbCommand command2 = new OleDbCommand()
                //command2.Connection = connection;
                string sql = "Select [CALL TIME],[SUBJECT],[NOTES] from calls where [Contact] = " + RecordSelected.selid.ToString() + ";";
                //OleDbConnection connection2 = new OleDbConnection(ConnectionString);
                OleDbConnection connectionc = new OleDbConnection(connection2.ConnectionString);
                OleDbDataAdapter dataadapter = new OleDbDataAdapter(sql, connection2);
                DataSet ds = new DataSet();
                //connectionc.Open();
                dataadapter.Fill(ds, "Calls");
                connectionc.Close();
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Calls";
                connection2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            connection.Open();
            string updateCommand = "UPDATE Contacts SET [Last Name] = '" + txtLastName.Text + 
                "', [First Name] = '" + txtFirstName.Text +
                "', [E-Mail Address] = '" + txtEMailAddress.Text + 
                "', [Job Title] = '" + txtJobTitle.Text + "', [Business Phone] = '" + txtPhoneNo.Text +
                "' where [ID] = " + RecordSelected.selid + ";";
            OleDbCommand command = new OleDbCommand(updateCommand, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if(btnInsert.Text =="Insert New Contact")
            {
                btnInsert.Text = "Add Record";
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtEMailAddress.Text = "";
                txtPhoneNo.Text = "";
                txtJobTitle.Text = "";
                txtFirstName.Focus();
            }
            else
            {
                //Add any required testing
                connection.Open();
                string insertcommand = "INSERT INTO Contacts" + "([Last Name], [First Name], [E-Mail Address], [Job Title], [Business Phone])" + " Values " + 
                    "('"+ txtLastName.Text +"', '"+ txtFirstName.Text +"', '"+ txtEMailAddress.Text +"', '"+ txtJobTitle.Text +"', '"+ txtPhoneNo.Text +"');";
                OleDbCommand command = new OleDbCommand(insertcommand, connection);
                command.ExecuteNonQuery();
                connection.Close();
                btnInsert.Text = "Insert New Contact";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnAddMsg_Click(object sender, EventArgs e)
        {
            AddMessage showaddmessage = new AddMessage();
            showaddmessage.Visible = true;
            
           /* AddMessage form = new AddMessage(txtFirstName.Text, txtLastName.Text);
            form.Show();
            form.Text += " for " + txtFirstName.Text + " " + txtLastName.Text;*/
        }
    }
}
