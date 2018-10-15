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
    public partial class AddMessage : Form
    {
        //******************/
        string firstName;
       string lastName;
        //******************/
        private OleDbConnection connection = new OleDbConnection();
       // private OleDbConnection connection2 = new OleDbConnection();

        //******************************************************
        public AddMessage(string fName, string lName)
        {
            InitializeComponent();
            firstName = fName;
            lastName = lName;
        }
        //******************************************************/
        public AddMessage()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Workarea\Contactmanager.accdb;";
            //connection2.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Workarea\Contactmanager.accdb;";
        }

        private void AddMessage_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            /******************************************************                   
            //load call information
            string sql = "Select [CALL TIME], [SUBJECT], [NOTES] from calls where [Contact] = " + RecordSelected.selid.ToString() + ";";
            OleDbConnection connectionc = new OleDbConnection(connection.ConnectionString);
            OleDbDataAdapter dataadapter = new OleDbDataAdapter(sql, connection);

            DataSet ds = new DataSet();
            dataadapter.Fill(ds, "Calls");
            connectionc.Close();
            //*****************************************************/
            string wkname = RecordSelected.selname;
            string lastname = wkname.Split(',')[0];
            string firstname = wkname.Split(',')[1].Trim();
            this.Text = "Add Message for " + firstname + " " + lastname;
            dateTimePicker1.Value = DateTime.Now;
           /* Subject.Items.Add("Service Issue");
            Subject.Items.Add("General Communication");
            Subject.Items.Add("Account Management");*/
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            //connection.Open();            
            /*string insertcommand = "INSERT INTO Contacts ( [Last Name], [First Name], [Subject], [Date], [Notes]) Values ('" + lastName + "', '" + firstName + "', '" + Subject.SelectedText + "', '" + dateTimePicker1.Text + "', '" + Notes.Text + "');";
            OleDbCommand command = new OleDbCommand(insertcommand, connection);
            command.ExecuteNonQuery();
             connection.Close();
            this.Close();*/
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.CommandText = "INSERT INTO [Calls]([Call Time],[Subject],[Notes]) VALUES(@CallTime,@Subject,@Notes);";
                /*command.CommandText = "INSERT INTO [Calls]([Last Name], [First Name],[Call Time],[Subject],[Notes]) VALUES(@lastName,@firstName,@CallTime,@Subject,@Notes);";
                command.Parameters.AddWithValue("@wknane", RecordSelected.selname);
                command.Parameters.AddWithValue("@lastName", lastName);
                command.Parameters.AddWithValue("@firstName", firstName);*/
                command.Parameters.AddWithValue("@CallTime", dateTimePicker1.Text);
                command.Parameters.AddWithValue("@Subject", Subject.SelectedItem.ToString());
                command.Parameters.AddWithValue("@Notes", Notes.Text);
                command.Connection = connection;
                command.ExecuteNonQuery();
                connection.Close();
                this.Close();
            }
            catch (Exception ex)
            {
                Notes.Text = ex.ToString();
                this.Close();
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            connection.Close();
            this.Close();
            
        }
    }
}
