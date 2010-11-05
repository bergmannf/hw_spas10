using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Assessment_Two_Logic.Interfaces;
using Assessment_Two_Logic.Model;
using Assessment_Two_Logic.Presenter;

namespace Assessment_Two
{
    public partial class MainWindow : ThreadingView, IWebpageView, IHistoryView
    {
        private int _NumberOfTabs;

        private PagePresenter _PagePresenter;
        private HistoryPresenter _HistoryPresenter;

        public MainWindow()
        {
            InitializeComponent();
            this._NumberOfTabs = 0;
            this.CreateTab();
            // ToDo: Seperate logic
            this.splitContainer1.Panel1Collapsed = true;
            this.splitContainer1.Panel1.Hide();

            this._PagePresenter = new PagePresenter(this);
            this._HistoryPresenter = new HistoryPresenter(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CreateTab()
        {
            this._NumberOfTabs++;
            String nameOfNewTab = "tabPage" + this._NumberOfTabs;
            String nameOfTextBox = "webPage" + this._NumberOfTabs + "RichTextBox";
            this.webSitesTabControl.SuspendLayout();
            TabPage tb = new TabPage();
            this.webSitesTabControl.TabPages.Add(tb);
            tb.Name = nameOfNewTab;

            RichTextBox rtb = new RichTextBox();
            rtb.Location = new Point(3, 3);
            rtb.Name = nameOfTextBox;
            rtb.Dock = DockStyle.Fill;
            
            tb.Controls.Add(rtb);
            this.webSitesTabControl.ResumeLayout();
        }

        private void DeleteTab()
        {
            TabPage currentTab = this.webSitesTabControl.SelectedTab;
            if (currentTab != null)
            {
                this.webSitesTabControl.TabPages.Remove(currentTab);
                this._NumberOfTabs--;
            }
        }

        private void addTabToolStripButton_Click(object sender, EventArgs e)
        {
            this.CreateTab();
        }

        private void deleteTabToolStripButton_Click(object sender, EventArgs e)
        {
            this.DeleteTab();
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
                    this.urlTextBox.Text = value;
                };
                UpdateUI(uiDelegate);
            }
        }

        public string SiteText
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void DisplayWebPage(SimpleWebResponse response)
        {
            foreach (TabPage page in this.webSitesTabControl.TabPages)
            {
                if (page.Name.Equals(response.Url))
                {
                    MethodInvoker uiDelegate = delegate
                    {
                        page.Controls[0].Text = response.Html;
                        page.Text = response.Title;
                    };
                    UpdateUI(uiDelegate);
                }
            }
        }

        public void DisplayErrors(ErrorMessageCollection errors)
        {
            MessageBox.Show(errors.ToString());
        }

        private void goToolStripButton_Click(object sender, EventArgs e)
        {
            String url = this.urlTextBox.Text;
            this.webSitesTabControl.SelectedTab.Name = url;
            this._PagePresenter.RequestWebpage();
        }

        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
