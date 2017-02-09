
using MyUILibrary;
using MyUILibrary.EntityArea;
using ProxyLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using Telerik.Windows.Controls;

namespace MyUIGenerator.UIControlHelper
{
    public static class DataGridHelper
    {
        //public static event EventHandler<Arg_DataContainer> DataCotainerIsReady;
        internal static RadGridView GenerateDataGridControl()
        {
            RadGridView dataGrid = new RadGridView();

            dataGrid.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            dataGrid.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
            dataGrid.AutoGenerateColumns = false;
            dataGrid.ShowGroupPanel = false;
            //dataGrid.AddingNewDataItem += dataGrid_AddingNewDataItem;
            //     dataGrid.
            //dataGrid.RowLoaded += dataGrid_RowLoaded;
            //dataGrid.CellLoaded+=dataGrid_CellLoaded;
            return dataGrid;





        }

        //static void dataGrid_RowLoaded(object sender, Telerik.Windows.Controls.GridView.RowLoadedEventArgs e)
        //{

        //}

        //static void dataGrid_AddingNewDataItem(object sender, Telerik.Windows.Controls.GridView.GridViewAddingNewEventArgs e)
        //{
        //    if (e.NewObject is DP_DataRepository)
        //    {
        //        if (DataCotainerIsReady != null)
        //        {
        //            Arg_DataContainer arg = new Arg_DataContainer();
        //            arg.DataItem = (e.NewObject as DP_DataRepository);
        //            DataCotainerIsReady(sender, arg);
        //        }
        //    }
        //}

        internal static DataDependentControlPackage GenerateMultipleDataDependentControl(DataAccess.Column correspondingTypeProperty, ColumnSetting columnSetting)
        {
            DataDependentControlPackage package = new DataDependentControlPackage();
            //package.DataControls = new List<UIControl>();
            //UIControlSetting controlUISetting = new UIControlSetting();
            //controlUISetting.DesieredColumns = 1;
            //controlUISetting.DesieredRows = 1;
          //  Telerik.Windows.Controls.GridViewColumn column;
            //if (AgentHelper.GetColumnType(correspondingTypeProperty) == Enum_UIColumnType.Text)
            //{
            //    column = new DataGridTextColumn(correspondingTypeProperty, columnSetting);
            //}
            //else
            //{
             var   column = new DataGridTextColumn(correspondingTypeProperty, columnSetting);
             column.ValueChanged +=(sender,e)=> column_ValueChanged(sender,e,package);
            //}
            column.IsReadOnly = columnSetting.IsReadOnly;

            package.DataDependentControl = column;
            //package.DataDependentControl.UIControlSetting = controlUISetting;
            //var textBox = new TextBox();
            //textBox.Margin = new System.Windows.Thickness(5);
            //textBox.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            //textBox.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
            //  package.DataControls.Add(new UIControl() { Control = column, UIControlSetting = controlUISetting });


            return package;
        }

        static void column_ValueChanged(object sender, ColumnValueChangeArg e, DataDependentControlPackage dataDependentControlPackage)
        {
            dataDependentControlPackage.OnValueChanged(sender, e);
        }
        internal static I_View_DataDependentControl GenerateMultipleDataDependentViewControl(DataAccess.Column column, ColumnSetting columnSetting, TemporaryLinkType linkType)
        {
            return new DataGridViewColumn(column, columnSetting, linkType);
        }

        internal static DataDependentControlPackage GenerateContolPackageOfView(object view, ColumnSetting columnSetting)
        {
            //UIControlPackage viewPackage = new UIControlPackage();
            //viewPackage.DataControls = new List<UIControl>();
            //UIControlSetting controlUISettingviewPackage = new UIControlSetting();
            //controlUISettingviewPackage.DesieredColumns = 1;
            //controlUISettingviewPackage.DesieredRows = 1;
            //viewPackage.DataControls.Add(ag_UIControl);



            DataDependentControlPackage package = new DataDependentControlPackage();


            //package.DataControls = new List<UIControl>();
            //UIControlSetting 


            //column.lo
            //UIControlSetting controlUISetting = new UIControlSetting();
            //controlUISetting.DesieredColumns = 1;
            //controlUISetting.DesieredRows = 1;


            package.DataDependentControl = view;
            //package.DataDependentControl.UIControlSetting = controlUISetting;

            return package;
        }


        internal static bool SetValue(RadGridView dataGrid, DP_DataRepository dataItem, DataDependentControlPackage controlPackage, string value, ColumnSetting columnSetting)
        {
            //(typePropertyControl.ControlPackage.DataControls.First().Control as TextBox).Text = value;
            ////var dataRow = GetDataRow(dataGrid, dataItem);
            //var dataRow = dataGrid.GetRowForItem(dataItem);
            //if (dataRow == null)
            //{
            //    //   dataGrid.Items.Add(dataItem);

            //    //dataGrid.ref.BeginInsert();
            //    dataRow = dataGrid.RowInEditMode;
            //    dataRow.DataContext = dataItem;

            ////}
            //if (dataRow != null)
            //{
            //    var cell = dataRow.GetCell(controlPackage.DataControls.First().Control as Telerik.Windows.Controls.GridViewColumn);

            //    if (cell != null)
            return (controlPackage.DataDependentControl as DataGridTextColumn).SetValue(dataItem, value, columnSetting);
            //cell.Content = value;
            //    return true;
            //}
            //return false;
        }

        internal static string GetValue(RadGridView dataGrid, DP_DataRepository dataItem, DataDependentControlPackage controlPackage)
        {
            return (controlPackage.DataDependentControl as DataGridTextColumn).GetValue(dataItem);
        }

        internal static void AddDataContainers(RadGridView dataGrid, List<DP_DataRepository> dataItems)
        {
            foreach (var item in dataItems)
                if (!dataGrid.Items.Contains(item))
                    dataGrid.Items.Add(item);
            //     dataGrid.BeginInsert();
            //dataGrid.ItemsSource = dataItems;
        }

        internal static void RemoveDataContainers(RadGridView dataGrid)
        {
            //foreach (var item in dataItems)
            //    if (!dataGrid.Items.Contains(item))
            dataGrid.Items.Clear();
        }
        internal static void RemoveDataContainers(RadGridView dataGrid, DP_DataRepository dataItem)
        {
            //foreach (var item in dataItems)
            dataGrid.Items.Remove(dataItem);
            //dataGrid.Items.Remove(item);
        }
        internal static void RemoveSelectedDataContainers(RadGridView dataGrid)
        {
            var selectedItems = GetSelectedData(dataGrid);
            foreach (var item in selectedItems)
                dataGrid.Items.Remove(item);
        }

        internal static List<DP_DataRepository> GetSelectedData(RadGridView dataGrid)
        {
            List<DP_DataRepository> result = new List<DP_DataRepository>();
            foreach (var item in dataGrid.SelectedItems)
                if (item is DP_DataRepository)
                    result.Add(item as DP_DataRepository);
            return result;
        }

        public static Telerik.Windows.Controls.GridView.GridViewCellBase GetCell(this Telerik.Windows.Controls.GridView.GridViewRow row, Telerik.Windows.Controls.GridViewColumn column)
        {
            if (row != null)
            {
                foreach (var cell in row.Cells)
                    if (cell.Column == column)
                        return cell;
            }
            return null;
        }

        //internal static bool SetValue(DataGrid dataGrid, DP_DataRepository dataItem, ColumnControl typePropertyControl, string value)
        //{
        //    //(typePropertyControl.ControlPackage.DataControls.First().Control as TextBox).Text = value;
        //    ////var dataRow = GetDataRow(dataGrid, dataItem);
        //    var dataRow = dataGrid.GetDataRow(dataItem);
        //    if (dataRow != null)
        //    {
        //        var cell = dataGrid.GetCell(dataRow, typePropertyControl.ControlPackage.DataControls.First().Control as DataGridColumn);
        //        cell.Content = value;
        //        return true;
        //    }
        //    return false;
        //}

        //internal static string GetValue(DataGrid dataGrid, DP_DataRepository dataItem, ColumnControl typePropertyControl)
        //{
        //    var dataRow = dataGrid.GetDataRow(dataItem);
        //    if (dataRow != null)
        //    {
        //        var cell = dataGrid.GetCell(dataRow, typePropertyControl.ControlPackage.DataControls.First().Control as DataGridColumn);
        //        if (cell.Content != null)
        //            return cell.Content.ToString();
        //    }
        //    return "";
        //}



        public static T GetVisualChild<T>(Visual parent) where T : Visual
        {
            T child = default(T);
            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < numVisuals; i++)
            {
                Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
                child = v as T;
                if (child == null)
                {
                    child = GetVisualChild<T>(v);
                }
                if (child != null)
                {
                    break;
                }
            }
            return child;
        }

        //public static DataGridRow GetSelectedRow(this DataGrid grid)
        //{
        //    return (DataGridRow)grid.ItemContainerGenerator.ContainerFromItem(grid.SelectedItem);
        //}
        //public static DataGridRow GetDataRow(this DataGrid grid, int index)
        //{
        //    DataGridRow row = (DataGridRow)grid.ItemContainerGenerator.ContainerFromIndex(index);
        //    if (row == null)
        //    {
        //        // May be virtualized, bring into view and try again.
        //        grid.UpdateLayout();
        //        grid.ScrollIntoView(grid.Items[index]);
        //        row = (DataGridRow)grid.ItemContainerGenerator.ContainerFromIndex(index);
        //    }
        //    return row;
        //}
        //private static DataGridRow GetDataRow(this DataGrid dataGrid, object dataItem)
        //{
        //    foreach (var item in dataGrid.Items)
        //    {
        //        if (item == dataItem)
        //        {
        //            DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator
        //                                                       .ContainerFromItem(item);
        //            return row;
        //        }
        //    }
        //    return null;
        //}
        //public static DataGridCell GetCell(this DataGrid grid, DataGridRow row, int column)
        //{
        //    if (row != null)
        //    {
        //        DataGridCellsPresenter presenter = GetVisualChild<DataGridCellsPresenter>(row);

        //        if (presenter == null)
        //        {
        //            grid.ScrollIntoView(row, grid.Columns[column]);
        //            presenter = GetVisualChild<DataGridCellsPresenter>(row);
        //        }

        //        DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
        //        return cell;
        //    }
        //    return null;
        //}
        //public static DataGridCell GetCell(this DataGrid grid, DataGridRow row, DataGridColumn column)
        //{
        //    if (row != null)
        //    {
        //        DataGridCellsPresenter presenter = GetVisualChild<DataGridCellsPresenter>(row);

        //        if (presenter == null)
        //        {
        //            grid.ScrollIntoView(row, column);
        //            presenter = GetVisualChild<DataGridCellsPresenter>(row);
        //        }

        //        DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(grid.Columns.IndexOf(column));
        //        return cell;
        //    }
        //    return null;
        //}



        //public static DataGridCell GetCell(this DataGrid grid, int row, int column)
        //{
        //    DataGridRow rowContainer = grid.GetDataRow(row);
        //    return grid.GetCell(rowContainer, column);
        //}

        ////internal static UIControlSetting GenerateUISetting(DataMaster.EntityDefinition.ND_Type_Property nD_Type_Property, UISetting.DataPackageUISetting.UI_PackagePropertySetting uI_PackagePropertySetting)
        ////{
        ////    throw new NotImplementedException();
        ////}


        //internal static bool SetValue(ColumnControl typePropertyControl, string value)
        //{
        //    (typePropertyControl.ControlPackage.DataControls.First().Control as TextBox).Text = value;
        //    return true;
        //}

        //internal static string GetValue(ColumnControl typePropertyControl)
        //{
        //    return (typePropertyControl.ControlPackage.DataControls.First().Control as TextBox).Text;
        //}



        internal static void AddControlToLayout(RadGridView LayoutDataGrid, object iAG_DataDependentControl, UIControl labelUIControl)
        {
            var column = (iAG_DataDependentControl as Telerik.Windows.Controls.GridViewColumn);
            column.Header = labelUIControl.Control;
            //(labelUIControl.Control as System.Windows.Controls.Label).Foreground = Brushes.White;
            LayoutDataGrid.Columns.Add(column);
        }

        internal static void SetSelectedData(RadGridView LayoutDataGrid, List<DP_DataRepository> dataItems)
        {
            if (dataItems != null)
            {
                ObservableCollection<object> items = new ObservableCollection<object>();
                dataItems.ForEach(x => items.Add(x));
                LayoutDataGrid.SelectedItem = items.FirstOrDefault();
            }
            else
                LayoutDataGrid.SelectedItem = null;
        }
    }
}
