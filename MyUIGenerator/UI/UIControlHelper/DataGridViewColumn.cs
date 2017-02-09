
using MyUIGenerator;
using MyUIGenerator.UIControlHelper;
using MyUIGenerator.View;
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
    public class DataGridViewColumn : Telerik.Windows.Controls.GridViewColumn, I_View_DataDependentControl
    {
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

        public DataGridViewColumn(DataAccess.Column column, ColumnSetting columnSetting, TemporaryLinkType linkType)
        {
            ColumnSetting = columnSetting;
            LinkType = linkType;
            // TypeProperty = correspondingTypeProperty;
            Column = column;
            //UnSetValue = null;
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
            var control = GenerateTemporaryView();
            control.DataItem = dataItem;
            control.Column = Column;
            control.TemporaryDisplayViewRequested += control_TemporaryDisplayViewRequested;
            return control as FrameworkElement;

        }

        void control_TemporaryDisplayViewRequested(object sender, Arg_TemporaryDisplayViewRequested e)
        {
            OnTemporaryViewRequested(sender, e);
        }


        public override FrameworkElement CreateCellEditElement(GridViewCell cell, object dataItem)
        {
            //cell.Loaded += cell_Loaded;

            var control = GenerateTemporaryView();
            control.DataItem = dataItem;
            control.Column = Column;
            control.TemporaryDisplayViewRequested += control_TemporaryDisplayViewRequested;
            return control as FrameworkElement;

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



        //internal bool SetValue(DP_DataRepository dataItem, string value, ColumnSetting columnSetting)
        //{
        //    //UnSetValue = null;
        //    //var dataRow = GetDataRow(dataGrid, dataItem);

        //    var dataRow = this.DataControl.GetRowForItem(dataItem);
        //    //  var dataRow = this.DataControl.ItemContainerGenerator.ContainerFromItem(dataItem) as GridViewRow;
        //    var cell = dataRow.GetCell(this);
        //    if (dataRow != null)
        //    {
        //        if (cell != null)
        //        {
        //            return ControlHelper.SetValue(Column, cell.Tag as UIControlPackage, value, columnSetting);
        //        }
        //    }
        //    else
        //    {
        //        if (dataItems.Any(x => x.Item1 == dataItem))
        //        {
        //            var fitem = dataItems.First(x => x.Item1 == dataItem);
        //            dataItems.Remove(fitem);
        //        }
        //        dataItems.Add(new Tuple<object, string>(dataItem, value));
        //        return true;
        //    }

        //    //dataItems.Add(new Tuple<object, string>(dataItem, value));

        //    //var cellItem = dataItems.Where(x => x.Item1 == dataItem).FirstOrDefault();
        //    //if (cellItem != null)
        //    //{
        //    //    ControlHelper.SetValue(Column, control, cellItem.Item2);
        //    //}
        //    //else
        //    //    dataItems.Add(new Tuple<object, string>(dataItem, value));
        //    return true;

        //}
        //internal string GetValue(DP_DataRepository dataItem)
        //{
        //    //var dataRow = GetDataRow(dataGrid, dataItem);
        //    var dataRow = this.DataControl.GetRowForItem(dataItem);

        //    if (dataRow != null)
        //    {
        //        var cell = dataRow.GetCell(this);

        //        if (cell != null)
        //        {
        //            return ControlHelper.GetValue(Column, cell.Tag as UIControlPackage);

        //        }
        //    }
        //    return "";
        //}


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

        public event EventHandler<Arg_TemporaryDisplayViewRequested> TemporaryViewRequested;

        public IAG_View_TemporaryView GenerateTemporaryView()
        {
            UC_TemporaryDataSearchLink view = new UC_TemporaryDataSearchLink();
            view.LinkType = LinkType;
            return view;
        }
        public IAG_View_TemporaryView GetTemporaryView(object dataItem)
        {
            var dataRow = this.DataControl.GetRowForItem(dataItem);

            if (dataRow != null)
            {
                var cell = dataRow.GetCell(this);

                if (cell != null)
                {
                    return cell.Content as IAG_View_TemporaryView;
                }

            }
            return null;
        }
        public void OnTemporaryViewRequested(object sender, Arg_TemporaryDisplayViewRequested arg)
        {
            if (TemporaryViewRequested != null)
                TemporaryViewRequested(this, arg);
        }

        public TemporaryLinkType LinkType
        {
            set;
            get;
        }
    }



}
