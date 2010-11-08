using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Assessment_Two.Properties;

namespace Assessment_Two
{
    public partial class SettingsWindow : Form
    {
        public SettingsWindow()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void LoadSettings()
        {
            Settings settings = Settings.Default;
            this.homepageTextBox.Text = settings.Homepage;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            String homepage = homepageTextBox.Text;
            this.SaveSettings(homepage);
            this.Dispose();
        }

        private void SaveSettings(String homePage)
        {
            Settings settings = Settings.Default;
            settings.Homepage = homePage;
            settings.Save();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
