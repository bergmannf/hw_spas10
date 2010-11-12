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
    /// <summary>
    /// Main window of the application.
    /// Displays the web pages, the history, the favourites.
    /// Allow adding of favourites, printing, changing of the homepage.
    /// </summary>
    public partial class MainWindow : ThreadingView, IWebpageView, IHistoryView, IFavouritesView, IPrintView
    {
        String _StringToPrint;

        private int _NumberOfTabs;
        private int _ReuestedPages;

        private PagePresenter _PagePresenter;
        private HistoryPresenter _HistoryPresenter;
        private FavouritesPresenter _FavouritesPresenter;
        private PrintPresenter _PrintPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            this._NumberOfTabs = 0;
            this.CreateTab();

            this.splitContainer1.Panel1Collapsed = true;
            this.splitContainer1.Panel1.Hide();

            this._PagePresenter = new PagePresenter(this);
            this._HistoryPresenter = new HistoryPresenter(this);
            this._FavouritesPresenter = new FavouritesPresenter(this);
            this._PrintPresenter = new PrintPresenter(this);

            LoadHomePage();
        }

        /// <summary>
        /// Loads the home page.
        /// </summary>
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
            else
            {
                this.urlTextBox.Text = "http://";
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

        public string Print
        {
            get { return this.SiteText; }
        }

        public Font CurrentFont
        {
            get
            {
                Font font = this.Font;
                return font;
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
                    RequestPage(tn.Text);
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
                this.DisplayFavouritesPage();
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
                this.RequestPage(fav.Url);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._FavouritesPresenter.DeleteFavourite();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog = new PrintDialog();
            printDialog.Document = printDocument;
            DialogResult result = printDialog.ShowDialog();
            this._PrintPresenter.SetPrintString();
            if (result == DialogResult.OK)
            {
                // ToDo: Make this call Async?
                printDocument.Print();
            }
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

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            this._PrintPresenter.Print(e);
        }

        private void webSitesTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (webSitesTabControl.SelectedTab != null)
            {
                String newUrl = webSitesTabControl.SelectedTab.Name;
                if (!newUrl.StartsWith("http://"))
                {
                    this.urlTextBox.Text = "http://";
                }
                else
                {
                    this.urlTextBox.Text = newUrl;
                }

            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._HistoryPresenter.ClearHistory();
        }

        private void favouriteContextMenu_Opening(object sender, CancelEventArgs e)
        {
            Object favourite = favouriteListBox.SelectedItem;
            if (favourite != null)
            {
                this.EnableContextButtons(true);
            }
            else
            {
                this.EnableContextButtons(false);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.ShowDialog();
        }
        #endregion

        /// <summary>
        /// Creates the tab.
        /// </summary>
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

        /// <summary>
        /// Deletes the tab.
        /// </summary>
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

        /// <summary>
        /// Determines whether history tab is visible.
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if [is history tab visible]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsHistoryTabVisible()
        {
            bool visible = false;
            if (this.sideTabControl.SelectedTab == this.sideTabControl.TabPages[0])
            {
                visible = true;
            }
            return visible;
        }

        /// <summary>
        /// Determines whether panel is visible.
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if [is panel visible]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsPanelVisible()
        {
            return !this.splitContainer1.Panel1Collapsed;
        }

        /// <summary>
        /// Displays the history page.
        /// </summary>
        private void DisplayHistoryPage()
        {
            this.sideTabControl.SelectedTab = this.sideTabControl.TabPages[0];
        }

        /// <summary>
        /// Changes the panel visibility.
        /// </summary>
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

        /// <summary>
        /// Adds the favourite.
        /// </summary>
        private void AddFavourite()
        {
            FavouriteWindow fw = new FavouriteWindow();
            fw.Url = this.urlTextBox.Text;
            fw.ShowDialog();
        }

        /// <summary>
        /// Displays the favourites page.
        /// </summary>
        private void DisplayFavouritesPage()
        {
            this.sideTabControl.SelectedTab = this.sideTabControl.TabPages[1];
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        private void Save()
        {
            this._FavouritesPresenter.SaveFavourites();
            this._HistoryPresenter.SaveHistory();
        }

        /// <summary>
        /// Enables the context buttons.
        /// </summary>
        /// <param name="p">if set to <c>true</c> [p].</param>
        private void EnableContextButtons(bool p)
        {
            this.editToolStripMenuItem1.Enabled = p;
            this.deleteToolStripMenuItem.Enabled = p;
        }

        /// <summary>
        /// Requests the page.
        /// </summary>
        /// <param name="text">The text.</param>
        private void RequestPage(String text)
        {
            this.urlTextBox.Text = text;
            this.webSitesTabControl.SelectedTab.Name = text;
            this._PagePresenter.RequestWebpage();
        }
    }
}
