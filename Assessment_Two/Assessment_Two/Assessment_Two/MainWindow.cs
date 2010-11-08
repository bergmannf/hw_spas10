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
using Assessment_Two.Properties;

namespace Assessment_Two
{
    public partial class MainWindow : ThreadingView, IWebpageView, IHistoryView, IFavouritesView
    {
        String _StringToPrint;

        private int _NumberOfTabs;

        private PagePresenter _PagePresenter;
        private HistoryPresenter _HistoryPresenter;
        private FavouritesPresenter _FavouritesPresenter;

        public MainWindow()
        {
            InitializeComponent();
            this._NumberOfTabs = 0;
            this.CreateTab();
            // ToDo: Seperate logic
            this.splitContainer1.Panel1Collapsed = true;
            this.splitContainer1.Panel1.Hide();
            // ToDo: Load Settings and create handlers;

            this._PagePresenter = new PagePresenter(this);
            this._HistoryPresenter = new HistoryPresenter(this);
            this._FavouritesPresenter = new FavouritesPresenter(this);

             LoadHomePage();
        }

        private void LoadHomePage()
        {
            Settings settings = Settings.Default;
            String homePage = settings.Homepage;

            this.urlTextBox.Text = homePage;
            if (!String.IsNullOrEmpty(homePage))
            {
                TabPage tp = webSitesTabControl.SelectedTab;
                tp.Name = homePage;
                this._PagePresenter.RequestWebpage();
            }
        }

        #region Interfaces

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
                TabPage page = this.webSitesTabControl.SelectedTab;
                return page.Controls[0].Text;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void DisplayErrors(ErrorMessageCollection errors)
        {
            MessageBox.Show(errors.ToString());
        }

        public Favourite Favourite
        {
            get
            {
                return (Favourite)this.favouriteListBox.SelectedItem;
            }
        }

        public void DisplayHistory(History history)
        {
            this.historyTreeView.Nodes.Clear();
            HashSet<String> coll = new HashSet<String>();
            foreach (DateTime t in history.VisitList.Keys)
            {
                String item = String.Format("{0}-{1}-{2}", t.Year.ToString(), t.Month.ToString(), t.Day.ToString());
                coll.Add(item);
            }
            foreach (String str in coll)
            {
                this.historyTreeView.Nodes.Add(str);
            }
            foreach (KeyValuePair<DateTime, String> t in history.VisitList)
            {
                String item = String.Format("{0}-{1}-{2}", t.Key.Year.ToString(), t.Key.Month.ToString(), t.Key.Day.ToString());
                foreach (TreeNode tn in historyTreeView.Nodes)
                {
                    if (tn.Text.Equals(item))
                    {
                        tn.Nodes.Add(t.Value);
                    }
                }
            }
        }

        public void DisplayFavourites(ICollection<Assessment_Two_Logic.Model.Favourite> favourites)
        {
            this.favouriteListBox.Items.Clear();
            foreach (Favourite fav in favourites)
            {
                this.favouriteListBox.Items.Add(fav);
            }
        }
        #endregion

        #region Eventhandler

        private void addTabToolStripButton_Click(object sender, EventArgs e)
        {
            this.CreateTab();
        }

        private void deleteTabToolStripButton_Click(object sender, EventArgs e)
        {
            this.DeleteTab();
        }

        private void goToolStripButton_Click(object sender, EventArgs e)
        {
            String url = this.urlTextBox.Text;
            this.webSitesTabControl.SelectedTab.Name = url;
            this._PagePresenter.RequestWebpage();
        }

        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!IsPanelVisible())
            {
                ChangePanelVisibility();
                DisplayHistoryPage();
            }
            else
            {
                if (IsHistoryTabVisible())
                {
                    ChangePanelVisibility();
                }
                else
                {
                    DisplayHistoryPage();
                }
            }
        }

        private void addFavouriteToolStripButton_Click(object sender, EventArgs e)
        {
            AddFavourite();
        }

        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode tn = this.historyTreeView.SelectedNode;
            if (tn != null)
            {
                if (tn.Level == 1)
                {
                    this.urlTextBox.Text = tn.Text;
                    this.webSitesTabControl.SelectedTab.Name = tn.Text;
                    this._PagePresenter.RequestWebpage();
                }
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AddFavourite();
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FavouriteWindow fw = new FavouriteWindow();

            fw.IsEdit = true;
            Favourite fav = (Favourite)this.favouriteListBox.SelectedItem;
            fw.Favourite = fav;
            fw.Url = fav.Url;
            fw.FavName = fav.Name;
            fw.ShowDialog();
        }

        private void favouritesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!IsPanelVisible())
            {
                ChangePanelVisibility();
            }
            else
            {
                if (!IsHistoryTabVisible())
                {
                    ChangePanelVisibility();
                }
                else
                {
                    DisplayFavouritesPage();
                }
            }
        }

        private void favouriteListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = this.favouriteListBox.SelectedItem;
            if (item != null)
            {
                Favourite fav = item as Favourite;
                this.urlTextBox.Text = fav.Url;
                this.webSitesTabControl.SelectedTab.Name = fav.Url;
                this._PagePresenter.RequestWebpage();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._FavouritesPresenter.DeleteFavourite();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog = new PrintDialog();
            printDialog.Document = printDocument1;
            DialogResult result = printDialog.ShowDialog();
            this._StringToPrint = this.SiteText;
            if (result == DialogResult.OK)
            {
                // ToDo: Make this call Async?
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int charactersOnPage = 0;
            int linesPerPage = 0;

            // Sets the value of charactersOnPage to the number of characters 
            // of stringToPrint that will fit within the bounds of the page.
            e.Graphics.MeasureString(this._StringToPrint, this.Font,
                e.MarginBounds.Size, StringFormat.GenericTypographic,
                out charactersOnPage, out linesPerPage);

            // Draws the string within the bounds of the page
            e.Graphics.DrawString(this._StringToPrint, this.Font, Brushes.Black,
                e.MarginBounds, StringFormat.GenericTypographic);

            // Remove the portion of the string that has been printed.
            this._StringToPrint = this._StringToPrint.Substring(charactersOnPage);

            // Check to see if more pages are to be printed.
            e.HasMorePages = (this._StringToPrint.Length > 0);
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsWindow sw = new SettingsWindow();
            sw.ShowDialog();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Save();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Save();
            this.Dispose();
        }
        #endregion

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
            if (this._NumberOfTabs.Equals(0))
            {
                this.CreateTab();
            }
        }

        private bool IsHistoryTabVisible()
        {
            bool visible = false;
            if (this.sideTabControl.SelectedTab == this.sideTabControl.TabPages[0])
            {
                visible = true;
            }
            return visible;
        }

        private bool IsPanelVisible()
        {
            return !this.splitContainer1.Panel1Collapsed;
        }

        private void DisplayHistoryPage()
        {
            this.sideTabControl.SelectedTab = this.sideTabControl.TabPages[0];
        }

        private void ChangePanelVisibility()
        {
            Boolean isInvisible = this.splitContainer1.Panel1Collapsed;
            if (isInvisible)
            {
                this.splitContainer1.Panel1Collapsed = false;
                this.splitContainer1.Panel1.Show();
            }
            else
            {
                this.splitContainer1.Panel1Collapsed = true;
                this.splitContainer1.Panel1.Hide();
            }
        }

        private void AddFavourite()
        {
            FavouriteWindow fw = new FavouriteWindow();
            fw.Url = this.urlTextBox.Text;
            fw.ShowDialog();
        }

        private void DisplayFavouritesPage()
        {
            this.sideTabControl.SelectedTab = this.sideTabControl.TabPages[1];
        }

        private void Save()
        {
            this._FavouritesPresenter.SaveFavourites();
            this._HistoryPresenter.SaveHistory();
        }
    }
}
