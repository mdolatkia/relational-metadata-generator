
using MyUIGenerator;
using MyUIGenerator.UIControlHelper;
using MyUILibrary;
using MyUILibrary.EntityArea;
using ProxyLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace MyUIGenerator.UIControlHelper
{
    public class DataGridTextColumn : Telerik.Windows.Controls.GridViewColumn
    {
        public event EventHandler<ColumnValueChangeArg> ValueChanged;
        // DataMaster.EntityDefinition.ND_Type_Property TypeProperty { set; get; }
        public DataAccess.Column Column { set; get; }
        public ColumnSetting ColumnSetting { set; get; }

        //I_View_EditEntityAreaDataView ViewEditNDTypeArea { set; get; }
        //public event EventHandler<Arg_TemporaryDisplayViewRequested> TemporaryViewRequested;
        //public event EventHandler<Arg_TemporaryDisplayViewRequested> TemporarySearchViewRequested;
        //I_View_DataDependentControl TemporaryArg { set; get; }

        //public DataGridTextColumn(IAG_View_TemporaryDisplayView temporaryViewLink)
        //{
        //    // TypeProperty = correspondingTypeProperty;

        //    TemporaryViewLink = temporaryViewLink;
        //}

        //public DataGridTextColumn(I_View_DataDependentControl temporaryArg)
        //{
        //    TemporaryArg = temporaryArg;
        //    // TypeProperty = correspondingTypeProperty;
        //    Column = temporaryArg.Column;
        //    //UnSetValue = null;
        //    //this.Loaded += DataGridTextColumn_Loaded;
        //}
        public DataGridTextColumn(DataAccess.Column column, ColumnSetting columnSetting)
        {
            ColumnSetting = columnSetting;
            ColumnSetting.LabelForReadOnlyText = true;
            ColumnSetting.GridView = true;
            // TypeProperty = correspondingTypeProperty;
            Column = column;
            //this.Loaded += DataGridTextColumn_Loaded;

        }

        //void DataGridTextColumn_Loaded(object sender, RoutedEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}
        List<Tuple<object, string>> dataItems = new List<Tuple<object, string>>();
        //string UnSetValue { set; get; }
        public override FrameworkElement CreateCellElement(GridViewCell cell, object dataItem)
        {

            //if (TemporaryArg == null)
            //{
            var cellItem = dataItems.Where(x => x.Item1 == dataItem).FirstOrDefault();
            var control = ControlHelper.GenerateControl(Column, ColumnSetting);
            control.ValueChanged += (sender, e) => control_ValueChanged(sender, e, cellItem);
            cell.Tag = control;
            //cell.Loaded += cell_Loaded;

            if (cellItem != null)
            {
                ControlHelper.SetValue(Column, control, cellItem.Item2, null);
            }
            return ControlHelper.GetUIControl(control).Control as FrameworkElement;
            //}
            //else
            //{
            //    var control = TemporaryArg.GenerateTemporaryView();
            //    control.DataItem = dataItem;
            //    control.Column = Column;
            //    control.TemporaryDisplayViewRequested += control_TemporaryDisplayViewRequested;
            //    return control as FrameworkElement;

            //}
            //return null;

        }

        void control_ValueChanged(object sender, ColumnValueChangeArg e, object dataItem)
        {
            e.DataItem = dataItem;
            if (ValueChanged != null)
                ValueChanged(sender, e);
        }



        //void control_TemporaryDisplayViewRequested(object sender, Arg_TemporaryDisplayViewRequested e)
        //{
        //    TemporaryArg.OnTemporaryViewRequested(sender, e);
        //}


        public override FrameworkElement CreateCellEditElement(GridViewCell cell, object dataItem)
        {
            ////cell.Loaded += cell_Loaded;
            //if (TemporaryArg == null)
            //{
            var control = ControlHelper.GenerateControl(Column, ColumnSetting);

            cell.Tag = control;

            var cellItem = dataItems.Where(x => x.Item1 == dataItem).FirstOrDefault();
            if (cellItem != null)
            {
                ControlHelper.SetValue(Column, control, cellItem.Item2, null);
            }

            //ControlHelper.SetValue(UI_PackagePropertySetting, control, TypeProperty.Value);
            return ControlHelper.GetUIControl(control).Control as FrameworkElement;
            //}
            //else
            //{
            //    var control = TemporaryArg.GenerateTemporaryView();
            //    control.DataItem = dataItem;
            //    control.Column = Column;
            //    control.TemporaryDisplayViewRequested += control_TemporaryDisplayViewRequested;
            //    return control as FrameworkElement;
            //}
        }

        //////void cell_Loaded(object sender, RoutedEventArgs e)
        //////{
        //////    var cell = (e.Source as GridViewCell);
        //////    var dataItem = cell.DataContext;
        //////    if (dataItem != null)
        //////    {
        //////        var cellItem = dataItems.Where(x => x.Item1 == dataItem).FirstOrDefault();
        //////        if (cellItem != null)
        //////        {
        //////            ControlHelper.SetValue(Column, cell.Tag as UIControlPackage, cellItem.Item2);
        //////        }
        //////    }

        //////}



        internal bool SetValue(DP_DataRepository dataItem, string value, ColumnSetting columnSetting)
        {
            //UnSetValue = null;
            //var dataRow = GetDataRow(dataGrid, dataItem);

            var dataRow = this.DataControl.GetRowForItem(dataItem);
            //  var dataRow = this.DataControl.ItemContainerGenerator.ContainerFromItem(dataItem) as GridViewRow;
            var cell = dataRow.GetCell(this);
            if (dataRow != null)
            {
                if (cell != null)
                {
                    return ControlHelper.SetValue(Column, cell.Tag as UIControlPackage, value, columnSetting);
                }
            }
            else
            {
                if (dataItems.Any(x => x.Item1 == dataItem))
                {
                    var fitem = dataItems.First(x => x.Item1 == dataItem);
                    dataItems.Remove(fitem);
                }
                dataItems.Add(new Tuple<object, string>(dataItem, value));
                return true;
            }

            //dataItems.Add(new Tuple<object, string>(dataItem, value));

            //var cellItem = dataItems.Where(x => x.Item1 == dataItem).FirstOrDefault();
            //if (cellItem != null)
            //{
            //    ControlHelper.SetValue(Column, control, cellItem.Item2);
            //}
            //else
            //    dataItems.Add(new Tuple<object, string>(dataItem, value));
            return true;

        }
        internal string GetValue(DP_DataRepository dataItem)
        {
            //var dataRow = GetDataRow(dataGrid, dataItem);
            var dataRow = this.DataControl.GetRowForItem(dataItem);

            if (dataRow != null)
            {
                var cell = dataRow.GetCell(this);

                if (cell != null)
                {
                    return ControlHelper.GetValue(Column, cell.Tag as UIControlPackage);

                }
            }
            return "";
        }


        //public IAG_View_TemporaryView GenerateTemporaryView()
        //{
        //    throw new NotImplementedException();
        //}


        //public TemporaryLinkType LinkType
        //{
        //    set;
        //    get;
        //}

        //public void OnTemporaryViewRequested(object sender, Arg_TemporaryDisplayViewRequested arg)
        //{
        //    throw new NotImplementedException();
        //}
    }



}
