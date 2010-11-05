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

namespace Assessment_Two
{
    public partial class FavouriteWindow : ThreadingView, IFavouriteView
    {
        private FavouritePresenter _FavouritePresenter;

        public FavouriteWindow()
        {
            InitializeComponent();
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

        public void DisplayErrors(Assessment_Two_Logic.Model.ErrorMessageCollection errors)
        {
            throw new NotImplementedException();
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
    }
}
