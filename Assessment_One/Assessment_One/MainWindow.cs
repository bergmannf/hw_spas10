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
    public partial class MainWindow : Form, ICongregateView
    {
        private CongregatePresenter _Presenter;

        private const int STOCKITEMTAB = 0;
        private const int BANKACCOUNTTAB = 1;

        public MainWindow()
        {
            InitializeComponent();
            _Presenter = new CongregatePresenter(this);
            SetUpDataBindings();
        }

        private void SetUpDataBindings()
        {
            stockItemsListBox.DataSource = _Presenter.StockItems;
            stockItemsListBox.DisplayMember = "Name";

            stockCodeTextBox.DataBindings.Add("Text", _Presenter.StockItems, "StockCode", false, DataSourceUpdateMode.OnValidation);
            itemNameTextBox.DataBindings.Add("Text", _Presenter.StockItems, "Name", false, DataSourceUpdateMode.OnPropertyChanged);
            supplierNameTextBox.DataBindings.Add("Text", _Presenter.StockItems, "SupplierName", false, DataSourceUpdateMode.OnPropertyChanged);
            currStockTextBox.DataBindings.Add("Text", _Presenter.StockItems, "CurrentStock", false, DataSourceUpdateMode.OnPropertyChanged);
            reqStockTextBox.DataBindings.Add("Text", _Presenter.StockItems, "RequiredStock", false, DataSourceUpdateMode.OnPropertyChanged);
            priceTextBox.DataBindings.Add("Text", _Presenter.StockItems, "UnitCost", false, DataSourceUpdateMode.OnPropertyChanged);

            bankAccountsListBox.DataSource = _Presenter.BankAccounts;
            bankAccountsListBox.DisplayMember = "AccountNumber";

            accountNumberTextBox.DataBindings.Add("Text", _Presenter.BankAccounts, "AccountNumber", false, DataSourceUpdateMode.OnValidation);
            nameTextBox.DataBindings.Add("Text", _Presenter.BankAccounts, "Surname", false, DataSourceUpdateMode.OnValidation);
            balanceTextBox.DataBindings.Add("Text", _Presenter.BankAccounts, "Balance", false, DataSourceUpdateMode.OnValidation);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        public bool ConfirmDelete()
        {
            throw new NotImplementedException();
        }

        public bool ConfirmClose()
        {
            throw new NotImplementedException();
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
    }
}
