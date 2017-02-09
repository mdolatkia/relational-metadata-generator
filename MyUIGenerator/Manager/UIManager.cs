
using MyDataManagerLibrary;

using MyUILibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MyUIGenerator.View;
using MyUILibrary.PackageArea;
using MyUILibrary.EntityArea;
using Telerik.Windows.Controls;
using System.Windows.Media;
using ProxyLibrary;
using System.Windows.Controls;
using MyUIGenerator.UIControlHelper;
using CommonDefinitions.BasicUISettings;


namespace MyUIGenerator
{
    public class UIManager : IAgentUIManager
    {
        public event EventHandler<PackageTreeRequestArg> PackageTreeRequested;
        public event EventHandler DatabaseListRequested;

        public event EventHandler<Arg_PackageRequest> ShowPackageRequested;
        WPF_MyIdea.frmMain MainForm { set; get; }

        public void OnDatabaseListRequested()
        {
            if (DatabaseListRequested != null)
                DatabaseListRequested(this, null);
        }
        public void OnPackageTreeRequested(string databaseName)
        {
            if (PackageTreeRequested != null)
                PackageTreeRequested(this, new PackageTreeRequestArg() { DatabaseName = databaseName });
        }

        public void OnShowPackageForEditRequested(DataAccess.TableDrivedEntity package)
        {
            if (ShowPackageRequested != null)
            {
                Arg_PackageRequest arg = new Arg_PackageRequest();
                arg.Package = package;
                ShowPackageRequested(this, arg);
            }
        }

        public IAgentUICoreMediator AgentUIMediator
        {
            get;
            set;
        }
        public UIManager(WPF_MyIdea.frmMain form)
        {
            MainForm = form;
            AgentUIMediator = AgentUICoreMediator.GetAgentUICoreMediator;
            AgentUIMediator.SetUIManager(this);

        }





        public void ShowPackageTree(DP_ResultPackageStructure packageTree)
        {
            MainForm.ShowPackageTree(packageTree);
        }



        //public void GenerateViewOfEditPackageArea(EditPackageAreaInitializer initializer)
        //{


        //    //////initializer.Mode = Enum_AG_PackageRequestGranularity.OneByOne;
        //    //////initializer.DataPackageTemplate = packages[0];
        //    initializer.View = new frmEditPackageArea();

        //    //container.CommandRequested += container_CommandRequested;

        //    //return container;
        //}

        public I_View_SearchViewArea GenerateSearchViewArea()
        {

            // SearchViewPackageAreaInitializer initParam = new SearchViewPackageAreaInitializer();

            return new UC_SearchViewArea();

            //container.CommandRequested += container_CommandRequested;

            //return container;
        }
        //void container_CommandRequested(object sender, Arg_CommandRequest e)
        //{
        //    var request = new AG_CommandExecutionRequest();
        //    request.Command = new AG_PackageAreaCommand();
        //    //request.SourcePackageArea = sender;
        //    request.Command.Packages = e.Packages;
        //    request.Command.CommandGoal = Enum_AG_PackageAreaCommand.Add;
        //    AgentUIMediator.ExecuteCommand(request);
        //}







        public UIControlPackage GenerateControlPackage(object view, ColumnSetting columnSetting)
        {
            if (view is UserControl)
            {
                Random rnd = new Random();
                //if (rnd.Next(8) == 1)
                (view as UserControl).Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF0F0F0"));
                //else if (rnd.Next(8) == 2)
                //    (view as UserControl).Background = Brushes.LightGreen);
                //else if (rnd.Next(8) == 3)
                //    (view as UserControl).Background = Brushes.LightPink);
                //else if (rnd.Next(8) == 4)
                //    (view as UserControl).Background = Brushes.LightSteelBlue);
                //else if (rnd.Next(8) == 5)
                //    (view as UserControl).Background = Brushes.LightCoral);
                //else if (rnd.Next(8) == 6)
                //    (view as UserControl).Background = Brushes.LightBlue);
                //else if (rnd.Next(8) == 7)
                //    (view as UserControl).Background = Brushes.LightSalmon);
                //else if (rnd.Next(8) == 8)
                //    (view as UserControl).Background = Brushes.LightSeaGreen);
                //else
                //    (view as UserControl).Background = Brushes.LightYellow);
                //     (view as UserControl).Margin = new Thickness(7);
                if (view.GetType() != typeof(UC_TemporaryDataSearchLink))
                {
                    (view as UserControl).BorderThickness = new Thickness(1);
                    (view as UserControl).BorderBrush = Brushes.Black;
                }
            }
            return ControlHelper.GenerateControlPackage(view, columnSetting);
        }


        public I_View_DataDependentControl GenerateMultipleDataDependentViewControl(DataAccess.Column column, ColumnSetting columnSetting, TemporaryLinkType linkType)
        {
            return UIControlHelper.DataGridHelper.GenerateMultipleDataDependentViewControl(column, columnSetting, linkType);
        }
        public DataDependentControlPackage GenerateDataDependentControlPackage(object view, ColumnSetting columnSetting)
        {
            //if (view is UserControl)
            //{
            //    Random rnd = new Random();
            //    //if (rnd.Next(8) == 1)
            //    (view as UserControl).Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF0F0F0"));
            //    //else if (rnd.Next(8) == 2)
            //    //    (view as UserControl).Background = Brushes.LightGreen);
            //    //else if (rnd.Next(8) == 3)
            //    //    (view as UserControl).Background = Brushes.LightPink);
            //    //else if (rnd.Next(8) == 4)
            //    //    (view as UserControl).Background = Brushes.LightSteelBlue);
            //    //else if (rnd.Next(8) == 5)
            //    //    (view as UserControl).Background = Brushes.LightCoral);
            //    //else if (rnd.Next(8) == 6)
            //    //    (view as UserControl).Background = Brushes.LightBlue);
            //    //else if (rnd.Next(8) == 7)
            //    //    (view as UserControl).Background = Brushes.LightSalmon);
            //    //else if (rnd.Next(8) == 8)
            //    //    (view as UserControl).Background = Brushes.LightSeaGreen);
            //    //else
            //    //    (view as UserControl).Background = Brushes.LightYellow);
            //    //     (view as UserControl).Margin = new Thickness(7);
            //    if (view.GetType() != typeof(UC_TemporaryDataSearchLink))
            //    {
            //        (view as UserControl).BorderThickness = new Thickness(1);
            //        (view as UserControl).BorderBrush = Brushes.Black;
            //    }
            //}
            return DataGridHelper.GenerateContolPackageOfView(view, columnSetting);
        }

        public void ShowEditPackageArea(I_View_EditPackageArea view, string title)
        {
            if (view is Control)
                MainForm.ShowForm((view as Control), title);
        }
        //public void ShowSearchViewPackageArea(I_View_SearchViewPackageArea view)
        //{
        //    if (view is Window)
        //        (view as Window).ShowDialog();
        //}



        public void CloseEditPackageArea(I_View_EditPackageArea view)
        {
            if (view is Window)
                (view as Window).Close();
        }

        //public void CloseSearchViewPackageArea(I_View_SearchViewPackageArea view)
        //{
        //    if (view is Window)
        //        (view as Window).Close();
        //}


        public I_View_EditPackageArea GenerateEditPackageArea(PackageAreaUISetting packageAreaUISetting)
        {
            return new frmEditPackageArea(packageAreaUISetting);
        }




        public I_View_EditEntityAreaDataView GenerateViewOfEditNDTypeArea(PackageAreaUISetting packageAreaUISetting)
        {
            var view = new UC_EditEntityArea(packageAreaUISetting);
            view.Margin = new Thickness(0, 0, 0, 5);
            //  view.grdArea.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.LightPink);
            return view;
        }





        public I_View_SearchEntityArea GenerateViewOfSearchEntityArea(PackageAreaUISetting packageAreaUISetting)
        {
            var view = new UC_SearchEntityArea(packageAreaUISetting);
            //  view.grdArea.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.LightPink);
            return view;
        }

        public I_View_ViewEntityArea GenerateViewOfViewEntityArea(PackageAreaUISetting packageAreaUISetting)
        {
            var view = new UC_ViewEntityArea(packageAreaUISetting);
            //  view.grdArea.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.LightPink);
            return view;
        }


        public IAG_View_TemporaryView GenerateTemporaryLinkUI(TemporaryLinkType linkType)
        {
            var view = new UC_TemporaryDataSearchLink();
            view.LinkType = linkType;
            return view;
        }


        public I_View_EditEntityAreaInfo GenerateViewOfEditEntityAreaInfo()
        {
            var view = new UC_EditEntityAreaInfo();
            return view;
        }
        //public IAG_View_TemporaryView GenerateTemporarySearchViewLinkUI()
        //{
        //    var view = new UC_TemporarySearchViewLink();
        //    //  view.grdArea.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.LightPink);
        //    return view;
        //}
        //public IAG_View_TemporaryView GenerateTemporaryDataSearchViewLinkUI()
        //{
        //    var view = new UC_TemporaryDataSearchLink();
        //    //  view.grdArea.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.LightPink);
        //    return view;
        //}
        public void ShowDialog(object view, string title)
        {
            RadWindow window = new RadWindow();
            window.Content = view;
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.Width = 700;
            window.Height = 500;
            window.Background = Brushes.Beige;
            window.BringToFront();
            window.WindowState = WindowState.Normal;
            window.Header = title;
            window.ShowDialog();
        }




        public void CloseDialog(object view)
        {
            if (view is UIElement)
            {
                var window = (view as UIElement).ParentOfType<RadWindow>();
                if (window != null)
                    window.Close();
            }
        }


        public void ShowValidationMessage(UIControlPackage uIControlPackage, string message)
        {
            if (uIControlPackage.RelatedUIControls != null)
            {
                if (uIControlPackage.RelatedUIControls.Count > 0)
                {
                    var label = uIControlPackage.RelatedUIControls.FirstOrDefault(x => x.RelationType == AG_ControlRelationType.Label);
                    if (label != null)
                    {
                        LabelHelper.Highlight(label.RelatedControl, message);
                    }
                }
            }

        }
        public void ClearValidationMessage(UIControlPackage uIControlPackage)
        {
            if (uIControlPackage.RelatedUIControls != null)
            {
                if (uIControlPackage.RelatedUIControls.Count > 0)
                {
                    var label = uIControlPackage.RelatedUIControls.FirstOrDefault(x => x.RelationType == AG_ControlRelationType.Label);
                    if (label != null)
                    {
                        LabelHelper.DeHighlight(label.RelatedControl);
                    }
                }
            }
        }

        public string GetGroupControlKey(string mainName, string itemName)
        {
            return TabHelper.GetTabKey(mainName, itemName);
        }


        public MyUILibrary.Temp.ConfirmResul ShowConfirm(string title, string text)
        {
            if (MessageBox.Show(text, title, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                return MyUILibrary.Temp.ConfirmResul.Yes;
            else
                return MyUILibrary.Temp.ConfirmResul.No;
        }




        public void ShowInfo(string title, string detail, MyUILibrary.Temp.InfoColor infoColor = MyUILibrary.Temp.InfoColor.Black)
        {
            Color color = Colors.Black;
            if (infoColor == MyUILibrary.Temp.InfoColor.Blue)
                color = Colors.Blue;
            else if (infoColor == MyUILibrary.Temp.InfoColor.Green)
                color = Colors.Green;
            else if (infoColor == MyUILibrary.Temp.InfoColor.Red)
                color = Colors.Red;
            MainForm.ShowInfo(title + " " + DateTime.Now.ToString("HH:mm:ss"), detail, color);
        }





        public bool ViewIsVisible(object view)
        {
            return (view as UIElement).Visibility == Visibility.Visible;
        }


        public void ShowDatabaseList(DP_ResultDatabaseList result)
        {
            MainForm.ShowDatabaseList(result);
        }
    }
  
}
