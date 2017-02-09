
using MyDataManagerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Telerik.Windows.Controls;

namespace WPF_MyIdea
{
    /// <summary>
    /// Interaction logic for frmMain.xaml
    /// </summary>
    public partial class frmMain : Window
    {
        MyUIGenerator.UIManager UIManager;
        public frmMain()
        {
            InitializeComponent();
            UIManager = new MyUIGenerator.UIManager(this);
            treePackageList.MouseLeftButtonUp += treePackageList_MouseLeftButtonUp;
            this.Loaded += frmMain_Loaded;
        }
        bool loaded = false;
        void frmMain_Loaded(object sender, RoutedEventArgs e)
        {
            if (loaded == false)
            {
                UIManager.OnDatabaseListRequested();
                loaded = true;
            }
        }

        void treePackageList_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //if (e.ClickCount == 2)
            //try
            //{
            if (e.Source is TreeViewItem)
                if ((e.Source as TreeViewItem).Tag is DataAccess.TableDrivedEntity)
                    UIManager.OnShowPackageForEditRequested(((e.Source as TreeViewItem).Tag as DataAccess.TableDrivedEntity));
            //}
            //catch { }
        }






        internal void ShowPackageTree(DP_ResultPackageStructure packageTree)
        {
            treePackageList.Items.Clear();
            foreach (var item in packageTree.Structure.OrderBy(x => x.Name))
            {
                treePackageList.Items.Add(new TreeViewItem() { Header = item.Name, Tag = item.Package });
            }
        }


        internal void ShowForm(Control userControl, string title)
        {
            RadPane pane = new RadPane();
            pane.Header = title;
            pane.Content = userControl;
            pnlForms.Items.Add(pane);
        }
        TextBlock InfoTextBlock;
        internal void ShowInfo(string text, string detail, Color color)
        {
            if (pnlInfo.Content == null)
            {
                ScrollViewer scroll = new ScrollViewer();
                InfoTextBlock = new TextBlock();
                scroll.Content = InfoTextBlock;
                pnlInfo.Content = scroll;
            }
            pnlInfo.IsActive = true;
            //      grpInfo.ShowAllPanes();
            var runTitle = new Run(text + Environment.NewLine) { Foreground = new SolidColorBrush(color) };


            if (InfoTextBlock.Inlines.Any())
                InfoTextBlock.Inlines.InsertBefore(InfoTextBlock.Inlines.First(), runTitle);
            else
                InfoTextBlock.Inlines.Add(runTitle);

            if (!string.IsNullOrEmpty(detail))
            {
                var runDetail = new Run("   " + detail + Environment.NewLine);
                InfoTextBlock.Inlines.InsertAfter(InfoTextBlock.Inlines.First(), runDetail);
            }
        }

        private void cmbDatabases_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbDatabases.SelectedItem != null)
            {
                UIManager.OnPackageTreeRequested((cmbDatabases.SelectedItem as DP_DatabaseListItem).Name);
            }
        }

        internal void ShowDatabaseList(DP_ResultDatabaseList result)
        {
           cmbDatabases.SelectedValuePath = "Name";
            cmbDatabases.DisplayMemberPath = "Name";
            cmbDatabases.ItemsSource = result.Databases;
            if (result.Databases.Count > 0)
                cmbDatabases.SelectedItem = result.Databases.FirstOrDefault(x => x.Name.ToLower().Contains("sample"));

        }
    }
}
