using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ActiveDirectoryConnector;

namespace ActiveDirectoryLookup
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            toolStripStatusLabelVersion.Text = toolStripStatusLabelVersion.Text + Application.ProductVersion;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string adgroup = textBoxSearchTerms.Text.Trim().ToUpper();

            try
            {
                dataGridViewResults.DataSource = ActiveDirectoryServices.GetUsersFromGroup(adgroup);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
