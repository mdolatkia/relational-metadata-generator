using CommonDefinitions.BasicUISettings;
using MyUIGenerator.UIControlHelper;
using MyUILibrary;
using MyUILibrary.EntityArea;
using MyUILibrary.EntityArea.Commands;
using ProxyLibrary;
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

namespace MyUIGenerator.View
{
    /// <summary>
    /// Interaction logic for UC_ViewPackageArea.xaml
    /// </summary>
    public partial class UC_ViewEntityArea : UserControl, I_View_ViewEntityArea
    {



        public event EventHandler<DataSelectedEventArg> DataSelected;

        public bool AllowSelect { set; get; }
        public int SelectCount { set; get; }
        public UC_ViewEntityArea(PackageAreaUISetting packageAreaUISetting)
        {
            InitializeComponent();
            BasicUISetting = packageAreaUISetting;
       

        }

        void LayoutDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (LayoutDataGrid.SelectedItem != null)
                if (LayoutDataGrid.SelectedItem is DP_DataRepository)
                    DataSelected(this, new DataSelectedEventArg() { DataItem = new List<DP_DataRepository>() { LayoutDataGrid.SelectedItem as DP_DataRepository } });
        }
        //List<Control> PropertyControls = new List<Control>();
        //private void InitializePackageArea()
        //{
        //    //foreach (var type in TemplatePackage.TypeConditions)
        //    //{
        //    //    //foreach (var property in type.NDType.Properties)
        //    //    //{
        //    //    //    var column = new DataGridViewTextBoxColumn();
        //    //    //    column.HeaderText = (property.Title == null ? property.Property.Title : property.Title);
        //    //    //    column.Tag = property;
        //    //    //    column.Name = property.Property.Name;
        //    //    //    //column.CellType=GetType(string);
        //    //    //    dataGridView1.Columns.Add(column);
        //    //    //}
        //    //}

        //}
        //public void ShowValues(List<DataAccess.Entity> dataPackages)
        //{
        //    //DataPackages = dataPackages;
        //    //foreach (var dataPackage in dataPackages)
        //    //{
        //    //    //    var row = new DataGridViewRow();
        //    //    int n = dataGridView1.Rows.Add();
        //    //    dataGridView1.Rows[n].Tag = dataPackage;
        //    //    int i = 0;
        //    //    foreach (DataGridViewColumn column in dataGridView1.Columns)
        //    //    {
        //    //        if (column.Tag is DataMaster.EntityDefinition.ND_Type_Property)
        //    //        {
        //    //            var typeProperty = column.Tag as DataMaster.EntityDefinition.ND_Type_Property;
        //    //            foreach (var type in dataPackage.TypeConditions)
        //    //            {
        //    //                var dateTypeProperty = type.NDType.Properties.FirstOrDefault(x => x.ID == typeProperty.ID);
        //    //                if (dateTypeProperty != null)
        //    //                    if (dateTypeProperty.Value != null)
        //    //                        dataGridView1.Rows[n].Cells[i].Value = dateTypeProperty.Value;
        //    //            }

        //    //        }
        //    //        i++;
        //    //    }

        //    //}
        //}
        //public void UpdateValues()
        //{
        //    //foreach (var item in PropertyControls)
        //    //{
        //    //    if (item.Tag is DataMaster.EntityDefinition.ND_Type_Property)
        //    //    {
        //    //        var typeProperty = item.Tag as DataMaster.EntityDefinition.ND_Type_Property;
        //    //        foreach (var type in DataPackage.NDTypes)
        //    //        {
        //    //            var dateTypeProperty = type.Properties.FirstOrDefault(x => x.ID == typeProperty.ID);
        //    //            if (dateTypeProperty != null)
        //    //                dateTypeProperty.Value = item.Text;
        //    //        }
        //    //    }
        //    //}
        //}

        public I_SearchViewEntityArea Controller
        {
            set;
            get;
        }



        //public List<DataAccess.Entity> SelectedViewPackages
        //{
        //    set;
        //    get;
        //}

        public void AddCommands(List<MyUILibrary.EntityArea.Commands.I_ViewAreaCommand> commands)
        {
            foreach (var item in commands.OrderBy(x => x.Position))
            {
                AddCommand(item);
            }
        }
        public void AddCommand(I_ViewAreaCommand item)
        {
            Button btnCommand = UIHelper.GenerateCommand(item);

            btnCommand.Click += btnCommand_Click;
            toolbar.Items.Add(btnCommand);
        }
        void btnCommand_Click(object sender, EventArgs e)
        {

            Controller.ViewCommandExecuted(((sender as Button).Tag as I_ViewAreaCommand));
        }
        public void PrepareViewOfViewTemplate(ViewEntityTemplate EditTemplate)
        {
            SetMainGridForMultipleNDTypes();
        }
        private void SetMainGridForMultipleNDTypes()
        {
            LayoutGrid = new Grid();
            LayoutDataGrid = DataGridHelper.GenerateDataGridControl();
            LayoutDataGrid.MouseDoubleClick += LayoutDataGrid_MouseDoubleClick;
            LayoutDataGrid.IsReadOnly = true;
            LayoutGrid.Children.Add(LayoutDataGrid);
            grdArea.Children.Add(LayoutGrid);
        }
        Grid LayoutGrid;
        RadGridView LayoutDataGrid;
        //public void ViewDataPckages(List<DataAccess.Entity> dataPackages)
        //{
        //    throw new NotImplementedException();
        //}
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


        public void AddMultipleDataDependentControl(DataDependentControlPackage controlPackage, string title, AG_EnumViewControlInsertionMode aG_EnumViewControlInsertionMode)
        {
            //propertyControl.UIControlSetting = new UIControlSetting();
            //propertyControl.UIControlSetting.DesieredColumns = 1;
            //propertyControl.UIControlSetting.DesieredRows = 1;
            //if (propertyControl.UI_PropertySetting.PropertyType == UISetting.DataPackageUISetting.Enum_UI_PropertyType.Text)
            //{
            //    if (propertyControl.UI_PropertySetting.TextPropertySetting.type == UISetting.DataPackageUISetting.Enum_UI_TextPropertyType.Small)
            //    {
            //        propertyControl.UIControlSetting = ControlHelper.TextBoxHelper.GenerateUISetting(propertyControl.TypeProperty, propertyControl.UI_PropertySetting);
            //    }


            //}

            var labelUIControl = LabelHelper.GenerateLabelControl(title, "");
            controlPackage.RelatedUIControls.Add(new AG_RelatedConttol() { RelationType = AG_ControlRelationType.Label, RelatedControl = labelUIControl });
            DataGridHelper.AddControlToLayout(LayoutDataGrid, controlPackage.DataDependentControl, labelUIControl);



            //AddLabelControl(propertyControl);

        }
        public bool ShowMultipleDateItemControlValue(DP_DataRepository dataItem, DataDependentControlPackage controlPackage, string value)
        {
            return DataGridHelper.SetValue(LayoutDataGrid, dataItem, controlPackage, value, null);
        }
        public string FetchMultipleDateItemControlValue(DP_DataRepository dataItem, DataDependentControlPackage controlPackage)
        {
            return DataGridHelper.GetValue(LayoutDataGrid, dataItem, controlPackage);
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
        public CommonDefinitions.BasicUISettings.PackageAreaUISetting BasicUISetting
        {
            set;
            get;
        }







     
    }
}
