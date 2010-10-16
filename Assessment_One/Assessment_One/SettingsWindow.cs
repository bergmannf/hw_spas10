using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.Configuration;
using Assessment_One.Properties;

namespace Assessment_One
{
    public partial class SettingsWindow : Form
    {
        public SettingsWindow()
        {
            InitializeComponent();
            SetUpTextBoxes();
        }

        private void SetUpTextBoxes()
        {
            Settings settings = Settings.Default;
            stockItemsFilePathTextBox.Text = settings.StockItemFilePath;
            bankAccountFilePathTextBox.Text = settings.BankAccountFilePath;
        }

        private void chooseStockItemsFilePath_Click(object sender, EventArgs e)
        {
            this.openFileDialog.ShowDialog();
            OpenFileDialog file = this.openFileDialog;
            this.stockItemsFilePathTextBox.Text = file.FileName;
        }

        private void chooseBankAccountsFilePath_Click(object sender, EventArgs e)
        {
            this.openFileDialog.ShowDialog();
            OpenFileDialog file = this.openFileDialog;
            this.bankAccountFilePathTextBox.Text = file.FileName;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            String stockItemsFilePath = stockItemsFilePathTextBox.Text;
            String bankAccountsFilePath = bankAccountFilePathTextBox.Text;
            this.SaveApplicationSettings(stockItemsFilePath, bankAccountsFilePath);
            this.Dispose();
        }

        private void SaveApplicationSettings(string stockItemsFilePath, string bankAccountsFilePath)
        {
            Settings settings = Settings.Default;
            settings.StockItemFilePath = stockItemsFilePath;
            settings.BankAccountFilePath = bankAccountsFilePath;
            settings.Save();
        }
    }
}
