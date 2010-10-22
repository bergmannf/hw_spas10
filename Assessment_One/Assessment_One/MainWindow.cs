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

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
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
            this.quantityTextBox.Text = "";
        }

        private void addBankAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._Presenter.CreateNewBankAccount();
        }

        private void deleteBankAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._Presenter.DeleteBankAccount();
            this.depositQuantityTextBox.Text = "";
            this.withdrawQuantityTextBox.Text = "";
        }

        private void openStockItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                OpenFileDialog file = this.openFileDialog;
                this._Presenter.LoadStockItemsFromFile(file.FileName);
            }
        }

        private void openBankAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                OpenFileDialog file = this.openFileDialog;
                this._Presenter.LoadBankAccountsFromFile(file.FileName);
            }
        }

        private void saveStockItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveFileDialog file = this.saveFileDialog;
                this._Presenter.SaveStockItemsToFile(file.FileName);
            }
        }

        private void saveBankAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveFileDialog file = this.saveFileDialog;
                this._Presenter.SaveBankAccountsToFile(file.FileName);
            }
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
            this.quantityTextBox.Text = "";
        }

        private void depositButton_Click(object sender, EventArgs e)
        {
            this._Presenter.Deposit();
            this.depositQuantityTextBox.Text = "";
        }

        private void withdrawButton_Click(object sender, EventArgs e)
        {
            this._Presenter.Withdraw();
            this.withdrawQuantityTextBox.Text = "";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._Presenter.CloseApplication();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsWindow sw = new SettingsWindow();
            sw.ShowDialog();
            this.LoadFilePathSettings();
        }

        private void saveStripButton_Click(object sender, EventArgs e)
        {
            this._Presenter.SaveBankAccountsToFile();
            this._Presenter.SaveStockItemsToFile();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == BANKACCOUNTTAB)
            {
                if (bankAccountsListBox.SelectedItem != null)
                {
                    this.SwitchBankAccountControls(true);
                }
                else
                {
                    this.SwitchBankAccountControls(false);
                }
            }
            else
            {
                if (stockItemsListBox.SelectedItem != null)
                {
                    this.SwitchStockItemControls(true);
                }
                else
                {
                    this.SwitchStockItemControls(false);
                }
            }
        }

        private void quantityTextBox_TextChanged(object sender, EventArgs e)
        {
            CheckQuantity();
        }

        #endregion

        #region IStockItemView

        /// <summary>
        /// Gets the current stock.
        /// </summary>
        /// <value>The current stock.</value>
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

        /// <summary>
        /// Gets the required stock.
        /// </summary>
        /// <value>The required stock.</value>
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

        /// <summary>
        /// Gets the stock code.
        /// </summary>
        /// <value>The stock code.</value>
        public string StockCode
        {
            get { return stockCodeTextBox.Text; }
        }

        /// <summary>
        /// Gets the name of the supplier.
        /// </summary>
        /// <value>The name of the supplier.</value>
        public string SupplierName
        {
            get { return supplierNameTextBox.Text; }
        }

        /// <summary>
        /// Gets the unit cost.
        /// </summary>
        /// <value>The unit cost.</value>
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

        /// <summary>
        /// Gets the name of the item.
        /// </summary>
        /// <value>The name of the item.</value>
        public string ItemName
        {
            get { return itemNameTextBox.Text; }
        }

        #endregion

        #region IBankAccountView

        /// <summary>
        /// Gets the account number.
        /// </summary>
        /// <value>The account number.</value>
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

        /// <summary>
        /// Gets the surname.
        /// </summary>
        /// <value>The surname.</value>
        public string Surname
        {
            get { return nameTextBox.Text; }
        }

        /// <summary>
        /// Gets the balance.
        /// </summary>
        /// <value>The balance.</value>
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

        /// <summary>
        /// Gets the stock item.
        /// </summary>
        /// <value>The stock item.</value>
        public StockItem StockItem
        {
            get { return (StockItem)this.stockItemsListBox.SelectedItem; }
        }

        /// <summary>
        /// Gets the bank account.
        /// </summary>
        /// <value>The bank account.</value>
        public BankAccount BankAccount
        {
            get { return (BankAccount)this.bankAccountsListBox.SelectedItem; }
        }

        /// <summary>
        /// Gets the quantity value.
        /// </summary>
        /// <value>The quantity.</value>
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

        /// <summary>
        /// Gets the deposit value.
        /// </summary>
        /// <value>The deposit.</value>
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

        /// <summary>
        /// Gets the withdraw value.
        /// </summary>
        /// <value>The withdraw.</value>
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

        /// <summary>
        /// Displays the validation errors.
        /// </summary>
        /// <param name="errorCollection">The error collection.</param>
        public void DisplayValidationErrors(ErrorMessageCollection errorCollection)
        {
            MessageBox.Show(errorCollection.ToString(), "Errors occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Asks fir confirmation of a deletion.
        /// </summary>
        /// <returns></returns>
        public bool ConfirmDelete()
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this item?", "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result == DialogResult.Yes;
        }

        /// <summary>
        /// Asks fir confirmation of closing the application.
        /// </summary>
        /// <returns></returns>
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
            this.accountNumberTextBox.Enabled = enabled;
            this.nameTextBox.Enabled = enabled;
            this.depositQuantityTextBox.Enabled = enabled;
            this.withdrawQuantityTextBox.Enabled = enabled;
        }

        /// <summary>
        /// Switches the StockItem Controls depending on the selection.
        /// </summary>
        /// <param name="enabled">True if controls shall be enabled, false otherwise.</param>
        private void SwitchStockItemControls(bool enabled)
        {
            this.deleteStockItemToolStripButton.Enabled = enabled;
            this.deleteStockItemToolStripMenuItem.Enabled = enabled;
            this.stockCodeTextBox.Enabled = enabled;
            this.itemNameTextBox.Enabled = enabled;
            this.supplierNameTextBox.Enabled = enabled;
            this.reqStockTextBox.Enabled = enabled;
            this.currStockTextBox.Enabled = enabled;
            this.priceTextBox.Enabled = enabled;
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

        

        private void CheckQuantity()
        {
            String newText = quantityTextBox.Text;
            int parseInt = 0;
            if (int.TryParse(newText, out parseInt))
            {
                placeOrderButton.Enabled = true;
            }
            else
            {
                placeOrderButton.Enabled = false;
            }
        }

        #endregion

        
    }
}
