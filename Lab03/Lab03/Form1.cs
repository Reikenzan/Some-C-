using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnOpenSecondForm_Click(object sender, EventArgs e)
        {
            SecondForm showsecondform = new SecondForm();
            showsecondform.Visible = true;
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewToolStripMenuItem.Enabled = true;
        }

        private void viewToolStripMenuItem_EnabledChanged(object sender, EventArgs e)
        {
            MessageBox.Show("I am enabled");
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewToolStripMenuItem.Enabled = false;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About showabout = new About();
            showabout.Visible = true;
        }

        private void contactUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContactUs showcontactus = new ContactUs();
            showcontactus.Visible = true;
        }

    }
}