using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FMst.Views.Forms
{
    public partial class UserSettings : Form
    {
        public UserSettings()
        {
            InitializeComponent();
        }

        private void UserSettings_Load(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = Properties.Settings.Default;
        }

        private void UserSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            // AppData\Local\Microsoft_Corporation\<addin name followed by random text>\<Excel Version Number>\user.config
            Properties.Settings.Default.Save();
            ThisAddIn.LoadUserSettings();
        }
    }
}
