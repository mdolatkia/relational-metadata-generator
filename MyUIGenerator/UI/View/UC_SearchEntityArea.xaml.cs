using CommonDefinitions.BasicUISettings;
using MyUIGenerator.UIControlHelper;
using MyUILibrary;
using MyUILibrary.EntityArea;
using MyUILibrary.EntityArea.Commands;
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

namespace MyUIGenerator.View
{
    /// <summary>
    /// Interaction logic for UC_ViewPackageArea.xaml
    /// </summary>
    public partial class UC_SearchEntityArea : UserControl, I_View_SearchEntityArea
    {


        Grid LayoutGrid;
        int CurrentColumn = 0;
        int CurrentRow = 0;

        public UC_SearchEntityArea(PackageAreaUISetting packageAreaUISetting)
        {
            InitializeComponent();
            BasicUISetting = packageAreaUISetting;


        }

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


        public I_SearchViewEntityArea Controller
        {
            set;
            get;
        }


        public UIControlPackage GenerateControl(DataAccess.Column uI_PackagePropertySettin, ColumnSetting columnSetting)
        {

            return ControlHelper.GenerateControl(uI_PackagePropertySettin, columnSetting);

            //return null;
        }

        public void AddCommands(List<MyUILibrary.EntityArea.Commands.I_SearchAreaCommand> commands)
        {
            foreach (var item in commands.OrderBy(x => x.Position))
            {
                AddCommand(item);
            }
        }
        public void AddCommand(I_SearchAreaCommand item)
        {
            Button btnCommand = UIHelper.GenerateCommand(item);
            btnCommand.Click += btnCommand_Click;
            toolbar.Items.Add(btnCommand);
        }
        void btnCommand_Click(object sender, EventArgs e)
        {

            Controller.SearchCommandExecuted(((sender as Button).Tag as I_SearchAreaCommand));
        }


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

        public void AddControls(UIControlPackage controlPackage, string title)
        {

            var labelUIControl = LabelHelper.GenerateLabelControl(title, "");

            controlPackage.RelatedUIControls.Add(new AG_RelatedConttol() { RelationType = AG_ControlRelationType.Label, RelatedControl = labelUIControl });

            var uiControl = ControlHelper.GetUIControl(controlPackage);

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




            //AddLabelControl(propertyControl);

        }
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
        public bool ShowControlValue(UIControlPackage controlPackage, DataAccess.Column control, string value)
        {
            return ControlHelper.SetValue(control, controlPackage, value, null);
        }
        public string FetchControlValue(UIControlPackage controlPackage, DataAccess.Column control)
        {
            return ControlHelper.GetValue(control, controlPackage);
        }


        public void PrepareViewOfSearchTemplate(SearchEntityTemplate EditTemplate)
        {

            SetMainGridForOneNDType();
        }



    }
}
