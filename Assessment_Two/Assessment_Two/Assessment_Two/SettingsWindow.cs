using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Assessment_Two.Properties;
using Assessment_Two_Logic.Model;

namespace Assessment_Two
{
    /// <summary>
    /// Allows the changing of the homepage.
    /// </summary>
    public partial class SettingsWindow : ThreadingView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsWindow"/> class.
        /// </summary>
        public SettingsWindow()
        {
            InitializeComponent();
            LoadSettings();
        }

        /// <summary>
        /// Loads the settings.
        /// </summary>
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

        /// <summary>
        /// Saves the settings.
        /// </summary>
        /// <param name="homePage">The home page.</param>
        private void SaveSettings(String homePage)
        {
            if (!PageHandler.IsValidUrl(homePage))
            {
                MessageBox.Show("The provided url is not valid.");
            }
            else
            {
                Settings settings = Settings.Default;
                settings.Homepage = homePage;
                settings.Save();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
