using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Assessment_Two_Logic.Interfaces;
using Assessment_Two_Logic.Presenter;
using Assessment_Two_Logic.Model;

namespace Assessment_Two
{
    public partial class FavouriteWindow : ThreadingView, IFavouriteView
    {
        private FavouritePresenter _FavouritePresenter;

        private Favourite _Favourite;

        public bool IsEdit { get; set; }

        public FavouriteWindow()
        {
            InitializeComponent();
            this.IsEdit = false;
            this._FavouritePresenter = new FavouritePresenter(this);
        }

        public string Url
        {
            get
            {
                return this.urlTextBox.Text;
            }
            set
            {
                MethodInvoker uiDelegate = delegate
                {
                    urlTextBox.Text = value;
                };
                UpdateUI(uiDelegate);
            }
        }

        public string FavName
        {
            get
            {
                return this.nameTextBox.Text;
            }
            set
            {
                MethodInvoker uiDelegate = delegate
                {
                    nameTextBox.Text = value;
                };
                UpdateUI(uiDelegate);
            }
        }

        public Assessment_Two_Logic.Model.Favourite Favourite
        {
            get
            {
                return this._Favourite;
            }
            set
            {
                this._Favourite = value;
            }
        }

        public void DisplayErrors(Assessment_Two_Logic.Model.ErrorMessageCollection errors)
        {
            throw new NotImplementedException();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (!IsEdit)
            {
                this._FavouritePresenter.AddFavourite();
            }
            else
            {
                this._FavouritePresenter.EditFavourite();
            }
            // ToDo: Only dispose if changes work.
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        
    }
}
