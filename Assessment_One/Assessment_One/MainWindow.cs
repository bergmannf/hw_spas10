using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ApplicationLogic.Interfaces;
using ApplicationLogic.Presenter;
using ApplicationLogic.Model;

namespace Assessment_One
{
    public partial class MainWindow : Form, ICongregateView, IStockItemView, IBankAccountView
    {
        private CongregatePresenter _Presenter;
		private IViewModel _Model;

        private const int STOCKITEMTAB = 0;
        private const int BANKACCOUNTTAB = 1;

        public MainWindow()
        {
            InitializeComponent();
			this._Model = new AppLogicManager();
            _Presenter = new CongregatePresenter(this, this, this, this._Model);
            SetUpDataBindings();
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

        private void button2_Click(object sender, EventArgs e)
        {

        }

        public bool ConfirmDelete()
        {
			DialogResult result = MessageBox.Show("Are you sure you want to delete this item?", "Confirm delete");
            return result == DialogResult.OK;
        }

        public bool ConfirmClose()
        {
			DialogResult result = MessageBox.Show("Are you sure you want to close the application?", "Confirm close");
			return result == DialogResult.OK;
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

        /// <summary>
        /// Switches the StockItem Controls depending on the selection.
        /// </summary>
        /// <param name="enabled">True if controls shall be enabled, false otherwise.</param>
        private void SwitchStockItemControls(bool enabled)
        {
            this.deleteStockItemToolStripButton.Enabled = enabled;
            this.deleteStockItemToolStripMenuItem.Enabled = enabled;
        }

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

        /// <summary>
        /// Switches the BankAccount Controls depending on the selection.
        /// </summary>
        /// <param name="enabled">True if controls shall be enabled, false otherwise.</param>
        private void SwitchBankAccountControls(bool enabled)
        {
            this.deleteBankAccountToolStripMenuItem.Enabled = enabled;
            this.deleteBankAccountToolStripButton.Enabled = enabled;
        }

        private void addStockItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._Presenter.CreateNewStockItem();
        }

        private void deleteStockItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Presenter.DeleteStockItem(stockItemsListBox.SelectedIndex);
        }

        private void addBankAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._Presenter.CreateNewBankAccount();
        }

        private void deleteBankAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._Presenter.DeleteBankAccount(bankAccountsListBox.SelectedIndex);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.openFileDialog.ShowDialog();
            var file = this.openFileDialog;
            Console.WriteLine(file.ToString());
        }


        public void DisplayValidationErrors(ErrorMessageCollection errorCollection)
        {
            MessageBox.Show(errorCollection.ToString());
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            int index = stockItemsListBox.SelectedIndex;
            this._Presenter.EditStockItem(index);
        }

        private void applyBankAccountButton_Click(object sender, EventArgs e)
        {
            int index = bankAccountsListBox.SelectedIndex;
            this._Presenter.EditBankAccount(index);
        }

        public int CurrentStock
        {
            get { return int.Parse(currStockTextBox.Text); }
        }

        public int RequiredStock
        {
            get { return int.Parse(reqStockTextBox.Text); }
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
            get { return double.Parse(priceTextBox.Text); }
        }


        public string ItemName
        {
            get { return itemNameTextBox.Text; }
        }

        public int AccountNumber
        {
            get { return int.Parse(accountNumberTextBox.Text); }
        }

        public string Surname
        {
            get { return nameTextBox.Text; }
        }

        public double Balance
        {
            get { return double.Parse(balanceTextBox.Text); }
        }
    }
}
