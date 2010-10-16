using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ApplicationLogic.Interfaces;
using ApplicationLogic.Presenter;
using ApplicationLogic.Model;
using System.Collections.Specialized;
using Assessment_One.Properties;

namespace Assessment_One
{
    public partial class MainWindow : Form, ICongregateView, IStockItemView, IBankAccountView
    {
        private CongregatePresenter _Presenter;
        private IViewModel _Model;
        private List<Control> backgroundColorChanged;

        private const int STOCKITEMTAB = 0;
        private const int BANKACCOUNTTAB = 1;

        public MainWindow()
        {
            InitializeComponent();
            this._Model = new AppDataManager();
            _Presenter = new CongregatePresenter(this, this, this, this._Model);
            this.backgroundColorChanged = new List<Control>();
            LoadFilePathSettings();
            SetUpDataBindings();
        }

        

        #region EventHandler

        private void bankAccountsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.bankAccountsListBox.SelectedItem != null)
            {
                this.tabControl1.SelectTab(BANKACCOUNTTAB);
                this.SwitchBankAccountControls(true);
            }
            else
            {
                this.SwitchBankAccountControls(false);
            }
        }

        private void stockItemsListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.stockItemsListBox.SelectedItem != null)
            {
                this.tabControl1.SelectTab(STOCKITEMTAB);
                this.SwitchStockItemControls(true);
            }
            else
            {
                this.SwitchStockItemControls(false);
            }
        }

        private void addStockItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._Presenter.CreateNewStockItem();
        }

        private void deleteStockItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Presenter.DeleteStockItem();
        }

        private void addBankAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._Presenter.CreateNewBankAccount();
        }

        private void deleteBankAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._Presenter.DeleteBankAccount();
        }

        private void openStockItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.openFileDialog.ShowDialog();
            OpenFileDialog file = this.openFileDialog;
            this._Presenter.LoadStockItemsFromFile(file.FileName);
        }

        private void openBankAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.openFileDialog.ShowDialog();
            OpenFileDialog file = this.openFileDialog;
            this._Presenter.LoadBankAccountsFromFile(file.FileName);
        }

        private void saveStockItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.saveFileDialog.ShowDialog();
            SaveFileDialog file = this.saveFileDialog;
            this._Presenter.SaveStockItemsToFile(file.FileName);
        }

        private void saveBankAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.saveFileDialog.ShowDialog();
            SaveFileDialog file = this.saveFileDialog;
            this._Presenter.SaveBankAccountsToFile(file.FileName);
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            this.ResetColoring();
            this._Presenter.EditStockItem();
        }

        private void ResetColoring()
        {
            foreach (Control control in this.backgroundColorChanged)
            {
                control.BackColor = Color.White;
            }
        }

        private void applyBankAccountButton_Click(object sender, EventArgs e)
        {
            this.ResetColoring();
            this._Presenter.EditBankAccount();
        }

        void PlaceOrderButton_Click(object sender, EventArgs e)
        {
            this._Presenter.OrderItem();
        }

        private void depositButton_Click(object sender, EventArgs e)
        {
            this._Presenter.Deposit();
        }

        private void withdrawButton_Click(object sender, EventArgs e)
        {
            this._Presenter.Withdraw();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._Presenter.CloseApplication();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsWindow sw = new SettingsWindow();
            sw.ShowDialog();
        }

        #endregion

        #region IStockItemView

        public int CurrentStock
        {
            get
            {
                int currentStock;
                try
                {
                    currentStock = int.Parse(currStockTextBox.Text);
                    return currentStock;
                }
                catch (FormatException e)
                {
                    this.DisplayError(currStockTextBox);
                    throw;
                }
            }
        }

        public int RequiredStock
        {
            get
            {
                int requiredStock;
                try
                {
                    requiredStock = int.Parse(reqStockTextBox.Text);
                    return requiredStock;
                }
                catch (FormatException e)
                {
                    this.DisplayError(reqStockTextBox);
                    throw;
                }
            }
        }

        public string StockCode
        {
            get { return stockCodeTextBox.Text; }
        }

        public string SupplierName
        {
            get { return supplierNameTextBox.Text; }
        }

        public double UnitCost
        {
            get
            {
                double unitCost;
                try
                {
                    unitCost = double.Parse(priceTextBox.Text);
                    return unitCost;
                }
                catch (FormatException e)
                {
                    this.DisplayError(priceTextBox);
                    throw;
                }
            }
        }

        public string ItemName
        {
            get { return itemNameTextBox.Text; }
        }

        #endregion

        #region IBankAccountView

        public int AccountNumber
        {
            get
            {
                int accountNumber;
                try
                {
                    accountNumber = int.Parse(accountNumberTextBox.Text);
                    return accountNumber;
                }
                catch (FormatException e)
                {
                    this.DisplayError(accountNumberTextBox);
                    throw;
                }
            }
        }

        public string Surname
        {
            get { return nameTextBox.Text; }
        }

        public double Balance
        {
            get
            {
                double balance;
                try
                {
                    balance = double.Parse(balanceTextBox.Text);
                    return balance;
                }
                catch (FormatException e)
                {
                    this.DisplayError(balanceTextBox);
                    throw;
                }
            }
        }

        #endregion

        #region ICongregateView

        public StockItem StockItem
        {
            get { return (StockItem)this.stockItemsListBox.SelectedItem; }
        }

        public BankAccount BankAccount
        {
            get { return (BankAccount)this.bankAccountsListBox.SelectedItem; }
        }

        public int Quantity
        {
            get
            {
                int quan = 0;
                try
                {
                    quan = int.Parse(quantityTextBox.Text);
                    return quan;
                }
                catch (FormatException e)
                {
                    this.DisplayError(quantityTextBox);
                    throw;
                }
            }
        }

        public double Deposit
        {
            get
            {
                double deposit;
                try
                {
                    deposit = double.Parse(depositQuantityTextBox.Text);
                    return deposit;
                }
                catch (FormatException e)
                {
                    this.DisplayError(depositQuantityTextBox);
                    throw;
                }
            }
        }

        public double Withdraw
        {
            get
            {
                double withdraw;
                try
                {
                    withdraw = double.Parse(withdrawQuantityTextBox.Text);
                    return withdraw;
                }
                catch (FormatException e)
                {
                    this.DisplayError(withdrawQuantityTextBox);
                    throw;
                }
            }
        }

        public void DisplayValidationErrors(ErrorMessageCollection errorCollection)
        {
            MessageBox.Show(errorCollection.ToString(), "Errors occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public bool ConfirmDelete()
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this item?", "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result == DialogResult.Yes;
        }

        public bool ConfirmClose()
        {
            DialogResult result = MessageBox.Show("Are you sure you want to close the application?", "Confirm close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result == DialogResult.Yes;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Switches the BankAccount Controls depending on the selection.
        /// </summary>
        /// <param name="enabled">True if controls shall be enabled, false otherwise.</param>
        private void SwitchBankAccountControls(bool enabled)
        {
            this.deleteBankAccountToolStripMenuItem.Enabled = enabled;
            this.deleteBankAccountToolStripButton.Enabled = enabled;
        }

        /// <summary>
        /// Switches the StockItem Controls depending on the selection.
        /// </summary>
        /// <param name="enabled">True if controls shall be enabled, false otherwise.</param>
        private void SwitchStockItemControls(bool enabled)
        {
            this.deleteStockItemToolStripButton.Enabled = enabled;
            this.deleteStockItemToolStripMenuItem.Enabled = enabled;
        }

        private void DisplayError(Control form)
        {
            backgroundColorChanged.Add(form);
            form.BackColor = Color.MistyRose;
        }

        private void LoadFilePathSettings()
        {
            Settings settings = Settings.Default;

            String filePathStockItems = settings.StockItemFilePath;
            String filePathBankAccounts = settings.BankAccountFilePath;
            if (!String.IsNullOrEmpty(filePathStockItems))
            {
                this._Presenter.SetUpStockItemFilePath(filePathStockItems);
            }
            if (!String.IsNullOrEmpty(filePathBankAccounts))
            {
                this._Presenter.SetUpBankAccountsFilePath(filePathBankAccounts);
            }
        }

        private void SetUpDataBindings()
        {
            stockItemsListBox.DataSource = _Model.StockItems;
            stockItemsListBox.DisplayMember = "Name";

            /*
             * The datasourceupdatemode is set to "Never".
             * This leads to the ability to enforce the use of the presenter to update the values in the model.
             * This way the validation errors can be handled by the presenter thus leading to better seperation of concerns.
             */
            stockCodeTextBox.DataBindings.Add("Text", _Model.StockItems, "StockCode", false, DataSourceUpdateMode.Never);
            itemNameTextBox.DataBindings.Add("Text", _Model.StockItems, "Name", false, DataSourceUpdateMode.Never);
            supplierNameTextBox.DataBindings.Add("Text", _Model.StockItems, "SupplierName", false, DataSourceUpdateMode.Never);
            currStockTextBox.DataBindings.Add("Text", _Model.StockItems, "CurrentStock", false, DataSourceUpdateMode.Never);
            reqStockTextBox.DataBindings.Add("Text", _Model.StockItems, "RequiredStock", false, DataSourceUpdateMode.Never);
            priceTextBox.DataBindings.Add("Text", _Model.StockItems, "UnitCost", false, DataSourceUpdateMode.Never);

            bankAccountsListBox.DataSource = _Model.BankAccounts;
            bankAccountsListBox.DisplayMember = "AccountNumber";

            accountNumberTextBox.DataBindings.Add("Text", _Model.BankAccounts, "AccountNumber", false, DataSourceUpdateMode.Never);
            nameTextBox.DataBindings.Add("Text", _Model.BankAccounts, "Surname", false, DataSourceUpdateMode.Never);
            balanceTextBox.DataBindings.Add("Text", _Model.BankAccounts, "Balance", false, DataSourceUpdateMode.Never);
        }

        #endregion
    }
}
