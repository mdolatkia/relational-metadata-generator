using CommonDefinitions.UISettings;
using DataAccess;

using MyUIGenerator.UIControlHelper;
using MyUIGenerator;
using MyUILibrary;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;

using MyUILibrary.EntityArea;
using MyUILibrary.EntityArea.Commands;
using ProxyLibrary;
using CommonDefinitions.BasicUISettings;


namespace MyUIGenerator.View
{
    /// <summary>
    /// Interaction logic for UC_EditPackageArea.xaml
    /// </summary>
    public partial class UC_EditEntityArea : UserControl, I_View_EditEntityAreaDataView
    {




        //private DataManager.DataPackage.DP_Package TemplatePackage { set; get; }
        //public DataManager.DataPackage.DP_Package DataPackage { set; get; }

        //private UISetting.BasicUISettings.PackageAreaUISetting UISetting;
        public UC_EditEntityArea(PackageAreaUISetting packageAreaUISetting)
        {
            InitializeComponent();
            BasicUISetting = packageAreaUISetting;
            //DataGridHelper.DataCotainerIsReady += DataGridHelper_DataCotainerIsReady;

        }

        void DataGridHelper_DataCotainerIsReady(object sender, Arg_DataContainer e)
        {
            if (sender == LayoutDataGrid)
            {
                if (DataCotainerIsReady != null)
                    DataCotainerIsReady(this, e);
            }
        }


        //List<Control> PropertyControls = new List<Control>();
        //private void InitializePackageArea()
        //{
        //    this.Width = UISetting.DefaultWidth;
        //    this.Height = UISetting.DefaultHeigh;


        //    SetMainGrid();

        //    //DataMaster.EntityDefinition.ND_Type mainType = AgentHelper.GetMainNDType(TemplatePackage);







        //    //groupBox1.Text = TemplatePackage.Name;
        //    //foreach (var type in TemplatePackage.TypeConditions)
        //    //{
        //    //    var top = 0;
        //    //    foreach (var property in type.NDType.Properties)
        //    //    {
        //    //        top += 20;
        //    //        Label lbl = new Label();
        //    //        lbl.Text = (property.Title == null ? property.Property.Name : property.Title);
        //    //        lbl.TextAlign = ContentAlignment.MiddleCenter;
        //    //        lbl.Height = 20;
        //    //        lbl.Width = groupBox1.Width - 50;
        //    //        lbl.Left = 25;
        //    //        lbl.Top = top;
        //    //        groupBox1.Controls.Add(lbl);

        //    //        top += 20;
        //    //        TextBox txt = new TextBox();
        //    //        txt.Width = groupBox1.Width - 50;
        //    //        txt.Height = 20;
        //    //        txt.Left = 25;
        //    //        txt.Tag = property;
        //    //        txt.Top = top;
        //    //        PropertyControls.Add(txt);
        //    //        groupBox1.Controls.Add(txt);

        //    //        if (property.IsKey)
        //    //            txt.Enabled = false;
        //    //    }
        //    //}

        //}


        //public void ShowValues(DataManager.DataPackage.DP_Package dataPackage)
        //{
        //    DataPackage = dataPackage;
        //    foreach (var item in PropertyControls)
        //    {
        //        if (item.Tag is DataMaster.EntityDefinition.ND_Type_Property)
        //        {
        //            var typeProperty = item.Tag as DataMaster.EntityDefinition.ND_Type_Property;
        //            foreach (var type in dataPackage.TypeConditions)
        //            {
        //                var dateTypeProperty = type.NDType.Properties.FirstOrDefault(x => x.ID == typeProperty.ID);
        //                //if (dateTypeProperty != null)
        //                //    item.Text = dateTypeProperty.Value;
        //            }
        //        }
        //    }
        //}
        //public void UpdateValues()
        //{
        //    foreach (var item in PropertyControls)
        //    {
        //        if (item.Tag is DataMaster.EntityDefinition.ND_Type_Property)
        //        {
        //            var typeProperty = item.Tag as DataMaster.EntityDefinition.ND_Type_Property;
        //            foreach (var type in DataPackage.TypeConditions)
        //            {
        //                var dateTypeProperty = type.NDType.Properties.FirstOrDefault(x => x.ID == typeProperty.ID);
        //                //if (dateTypeProperty != null)
        //                //    dateTypeProperty.Value = item.Text;
        //            }
        //        }
        //    }
        //}



        //public List<DataAccess.Entity> CurrentSelectedNDTypes
        //{
        //    get { throw new NotImplementedException(); }
        //}

        public I_EditEntityArea Controller
        {
            get;
            set;
        }

        //public void ShowNDTypes(List<DataMaster.EntityDefinition.ND_Type> ndTypes)
        //{
        //    throw new NotImplementedException();
        //}

        //public void UpdateNDTypes(List<DataMaster.EntityDefinition.ND_Type> ndTypes)
        //{
        //    throw new NotImplementedException();
        //}

        public void AddCommands(List<I_EntityAreaCommand> commands)
        {
            foreach (var item in commands.OrderBy(x => x.Position))
            {
                AddCommand(item);
            }
        }

        public void AddCommand(I_EntityAreaCommand item)
        {
            Button btnCommand = UIHelper.GenerateCommand(item);
            btnCommand.Click += btnCommand_Click;
            toolbar.Items.Add(btnCommand);
        }

        void btnCommand_Click(object sender, EventArgs e)
        {

            Controller.CommandExecuted(((sender as Button).Tag as I_EntityAreaCommand));
        }

        //public void GenerateEditTemplate(EditTemplate editTemplate)
        //{
        //    throw new NotImplementedException();
        //}


        public void PrepareViewOfEditTemplate(EditTemplate EditTemplate)
        {
            if (EditTemplate.DataMode == DataMode.Multiple)
            {
                SetMainGridForMultipleNDTypes();
            }
            else
                SetMainGridForOneNDType();
        }

        private void SetMainGridForMultipleNDTypes()
        {
            LayoutGrid = new Grid();
            LayoutDataGrid = DataGridHelper.GenerateDataGridControl();
            LayoutGrid.Children.Add(LayoutDataGrid);
            grdArea.Children.Add(LayoutGrid);
        }

        RadGridView LayoutDataGrid;
        Grid LayoutGrid;
        int CurrentColumn = 0;
        int CurrentRow = 0;

        public CommonDefinitions.BasicUISettings.PackageAreaUISetting BasicUISetting
        {
            get;
            set;
        }
        private void SetMainGridForOneNDType()
        {
            double formWidth = BasicUISetting.DefaultWidth;
            int uiColumnsCount = BasicUISetting.DefaultColumnCount * 2;
            var calculatedColumnWidth = formWidth / uiColumnsCount;
            while (calculatedColumnWidth < BasicUISetting.MinimumColumnWidth)
            {
                uiColumnsCount -= 2;
                if (uiColumnsCount <= 0)
                    throw (new Exception(""));
                calculatedColumnWidth = formWidth / uiColumnsCount;
            }
            LayoutGrid = new Grid();
            for (var i = 0; i < uiColumnsCount; i++)
            {
                var columnDefinition = new ColumnDefinition();
                if (i % 2 == 0)
                    columnDefinition.Width = GridLength.Auto;
                LayoutGrid.ColumnDefinitions.Add(columnDefinition);
            }

            for (var i = 0; i < 40; i++)
            {
                // LayoutGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(BasicUISetting.MinimumRowHeight) });
                LayoutGrid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            }
            //LayoutGrid.ShowGridLines = true;
            grdArea.Children.Add(LayoutGrid);

        }




        // public event EventHandler<Arg_DataDependentControlGeneration> DataControlGenerated;
        public UIControlPackage GenerateMultipleDataDependentControl(DataAccess.Column column, ColumnSetting columnSetting)
        {
            //  List<object> result = new List<object>();

            var controlPackage = UIControlHelper.DataGridHelper.GenerateMultipleDataDependentControl(column, columnSetting);
            //if (controlPackage.DataDependentControl != null)
            //{
            //    controlPackage.DataDependentControl.DataControlGenerated += DataDependentControl_DataControlGenerated;
            //}
            return controlPackage;
            //return null;
        }

        //void DataDependentControl_DataControlGenerated(object sender, Arg_DataDependentControlGeneration e)
        //{
        //    if (DataControlGenerated != null)
        //        DataControlGenerated(sender, e);
        //}


        public UIControlPackage GenerateControl(DataAccess.Column uI_PackagePropertySettin, ColumnSetting columnSetting)
        {

            return ControlHelper.GenerateControl(uI_PackagePropertySettin, columnSetting);

            //return null;
        }
        public void AddMultipleDataDependentControl(DataDependentControlPackage controlPackage, string title, string tooltip)
        {
            //propertyControl.UIControlSetting = new UIControlSetting();
            //propertyControl.UIControlSetting.DesieredColumns = 1;
            //propertyControl.UIControlSetting.DesieredRows = 1;
            //if (propertyControl.UI_PropertySetting.PropertyType == UISetting.DataPackageUISetting.Enum_UI_PropertyType.Text)
            //{
            //    if (propertyControl.UI_PropertySetting.TextPropertySetting.type == UISetting.DataPackageUISetting.Enum_UI_TextPropertyType.Small)
            //    {
            //        propertyControl.UIControlSetting = ControlHelpers.TextBoxHelper.GenerateUISetting(propertyControl.TypeProperty, propertyControl.UI_PropertySetting);
            //    }


            //}

            var labelUIControl = LabelHelper.GenerateLabelControl(title, tooltip);
            controlPackage.RelatedUIControls.Add(new AG_RelatedConttol() { RelationType = AG_ControlRelationType.Label, RelatedControl = labelUIControl });
            DataGridHelper.AddControlToLayout(LayoutDataGrid, controlPackage.DataDependentControl, labelUIControl);



            //AddLabelControl(propertyControl);

        }


        public void AddControls(UIControlPackage controlPackage, string title, string tooltip = "", string groupKey = "")
        {

            var labelUIControl = LabelHelper.GenerateLabelControl(title, tooltip);
            var uiControl = ControlHelper.GetUIControl(controlPackage);
            controlPackage.RelatedUIControls.Add(new AG_RelatedConttol() { RelationType = AG_ControlRelationType.Label, RelatedControl = labelUIControl });
            if (string.IsNullOrEmpty(groupKey))
            {


                if (labelUIControl.UIControlSetting.DesieredColumns > LayoutGrid.ColumnDefinitions.Count)
                {
                    labelUIControl.UIControlSetting.DesieredColumns = LayoutGrid.ColumnDefinitions.Count;
                }
                if (uiControl.UIControlSetting.DesieredColumns > LayoutGrid.ColumnDefinitions.Count)
                {
                    uiControl.UIControlSetting.DesieredColumns = LayoutGrid.ColumnDefinitions.Count;
                }

                if (labelUIControl.UIControlSetting.DesieredColumns + uiControl.UIControlSetting.DesieredColumns + CurrentColumn > LayoutGrid.ColumnDefinitions.Count)
                    MoveToNewRow();
                AddControlToLayout(labelUIControl);
                AddControlToLayout(uiControl);
            }
            else
            {
                var tabControl = TabHelper.AddTab(TabControls, groupKey, uiControl, labelUIControl);
                if (tabControl != null)
                {
                    UIControl tabUiControl = new UIControl();
                    tabUiControl.Control = tabControl;
                    tabUiControl.UIControlSetting.DesieredColumns = LayoutGrid.ColumnDefinitions.Count;
                    AddControlToLayout(tabUiControl);
                }
            }



            //AddLabelControl(propertyControl);

        }
        private List<RadTabControl> TabControls = new List<RadTabControl>();
        private void AddControlToLayout(UIControl uiControl)
        {
            if (uiControl.UIControlSetting.DesieredColumns + CurrentColumn > LayoutGrid.ColumnDefinitions.Count)
                MoveToNewRow();

            Grid.SetColumn(uiControl.Control as UIElement, CurrentColumn);
            Grid.SetRow(uiControl.Control as UIElement, CurrentRow);
            if (uiControl.UIControlSetting.DesieredColumns != 0)
                Grid.SetColumnSpan(uiControl.Control as UIElement, uiControl.UIControlSetting.DesieredColumns);
            if (uiControl.UIControlSetting.DesieredRows != 0)
                Grid.SetRowSpan(uiControl.Control as UIElement, uiControl.UIControlSetting.DesieredRows);
            CurrentColumn += uiControl.UIControlSetting.DesieredColumns;
            // CurrentRow += uiControl.UIControlSetting.DesieredRows;

            LayoutGrid.Children.Add(uiControl.Control as UIElement);
        }




        private void MoveToNewRow()
        {
            CurrentColumn = 0;
            CurrentRow++;
        }


        public bool ShowControlValue(UIControlPackage controlPackage, DataAccess.Column control, string value, ColumnSetting columnSetting)
        {
            return ControlHelper.SetValue(control, controlPackage, value, columnSetting);
        }
        public bool ShowMultipleDateItemControlValue(DP_DataRepository dataItem, DataDependentControlPackage controlPackage, string value, ColumnSetting columnSetting)
        {
            return DataGridHelper.SetValue(LayoutDataGrid, dataItem, controlPackage, value, columnSetting);
        }
        public string FetchMultipleDateItemControlValue(DP_DataRepository dataItem, DataDependentControlPackage controlPackage)
        {
            return DataGridHelper.GetValue(LayoutDataGrid, dataItem, controlPackage);
        }
        public string FetchControlValue(UIControlPackage controlPackage, DataAccess.Column control)
        {
            return ControlHelper.GetValue(control, controlPackage);
        }




        public void SetBackgroundColor(string color)
        {
            grdArea.Background = new SolidColorBrush(UIHelper.getColorFromHexString(color));
        }





        public void AddDataContainers(List<DP_DataRepository> data)
        {
            //if (AgentHelper.GetDataEntryMode(EditTemplate) == DataMode.Multiple)
            //{
            DataGridHelper.AddDataContainers(LayoutDataGrid, data);
            //}
        }



        public event EventHandler<Arg_DataContainer> DataCotainerIsReady;


        public void RemoveDataContainers()
        {
            //if (Controller.EditTemplate.Template.TableDrivedEntity.Table.BatchDataEntry == true)
            //{
            DataGridHelper.RemoveDataContainers(LayoutDataGrid);
            //}
        }
        public void RemoveDataContainers(DP_DataRepository data)
        {
            //if (Controller.EditTemplate.Template.TableDrivedEntity.Table.BatchDataEntry == true)
            //{
            DataGridHelper.RemoveDataContainers(LayoutDataGrid, data);
            //}
        }

        public List<DP_DataRepository> GetSelectedData()
        {
            //if (AgentHelper.GetDataEntryMode(EditTemplate) == DataMode.Multiple)
            //{
            return DataGridHelper.GetSelectedData(LayoutDataGrid);
            //}
            //else
            //    return null;
        }
        public void SetSelectedData(List<DP_DataRepository> dataItems)
        {
            DataGridHelper.SetSelectedData(LayoutDataGrid, dataItems);

        }

        public void RemoveSelectedDataContainers()
        {
            //if (AgentHelper.GetDataEntryMode( EditTemplate) == DataMode.Multiple)
            //{
            DataGridHelper.RemoveSelectedDataContainers(LayoutDataGrid);
            //}
        }



        //public bool ShowMultipleDateItemControlValue(DP_DataRepository dataItem, DataDependentControlPackage controlPackage, string value)
        //{
        //    throw new NotImplementedException();
        //}


        //public void AddMultipleDataDependentControl(UIControlPackage controlPackage, string title, AG_EnumViewControlInsertionMode aG_EnumViewControlInsertionMode)
        //{
        //    throw new NotImplementedException();
        //}









    }


}
