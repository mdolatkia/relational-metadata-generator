
using MyUILibrary;
using MyUILibrary.EntityArea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MyUIGenerator.UIControlHelper
{
    public static class KeyValueControlHelper
    {
        internal static UIControlPackage GenerateControl(DataAccess.Column column, ColumnSetting columnSetting)
        {

            UIControlPackage package = new UIControlPackage();
            package.DataControls = new List<UIControl>();
            UIControlSetting controlUISetting = new UIControlSetting();
            controlUISetting.DesieredColumns = 1;
            controlUISetting.DesieredRows = 1;
            if (columnSetting.IsReadOnly && columnSetting.LabelForReadOnlyText == true)
            {
                var textBox = new TextBlock();

                //textBox.Margin = new System.Windows.Thickness(5);
                textBox.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                textBox.VerticalAlignment = System.Windows.VerticalAlignment.Center;

                package.DataControls.Add(new UIControl() { Control = textBox, UIControlSetting = controlUISetting });
            }
            else
            {
                var textBox = new ComboBox();
                textBox.SelectionChanged += (sender, e) => textBox_SelectionChanged(sender, e, package, column);
                if (!columnSetting.GridView)
                {
                    textBox.Width = 200;
                    textBox.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                }
                else
                    textBox.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
                textBox.DisplayMemberPath = "KeyTitle";
                textBox.SelectedValuePath = "Value";
                textBox.ItemsSource = column.ColumnKeyValue.ColumnKeyValueRange;
                textBox.IsReadOnly = columnSetting.IsReadOnly;
                //   textBox.Margin = new System.Windows.Thickness(5);
                textBox.MinHeight = 24;

                textBox.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                package.DataControls.Add(new UIControl() { Control = textBox, UIControlSetting = controlUISetting });
            }
            return package;
        }
        static void textBox_SelectionChanged(object sender, SelectionChangedEventArgs e, UIControlPackage uiControlPackage, DataAccess.Column column)
        {
            ColumnValueChangeArg arg = new ColumnValueChangeArg();
            arg.NewValue = GetValue(uiControlPackage, column);
            uiControlPackage.OnValueChanged(sender, arg);
        }


        //internal static UIControlSetting GenerateUISetting(DataMaster.EntityDefinition.ND_Type_Property nD_Type_Property, UISetting.DataPackageUISetting.UI_PackagePropertySetting uI_PackagePropertySetting)
        //{
        //    throw new NotImplementedException();
        //}


        internal static bool SetValue(UIControlPackage controlPackage, DataAccess.Column column, string value, ColumnSetting columnSetting)
        {
            var control = controlPackage.DataControls.First().Control;
            if (control is TextBlock)
            {
                DataAccess.ColumnKeyValueRange fItem = null;
                if (column.ColumnKeyValue.ValueFromKeyOrValue)
                    fItem = column.ColumnKeyValue.ColumnKeyValueRange.FirstOrDefault(x => x.KeyTitle == value);
                else
                    fItem = column.ColumnKeyValue.ColumnKeyValueRange.FirstOrDefault(x => x.Value == Convert.ToInt32(value));

                if (fItem != null)
                    (controlPackage.DataControls.First().Control as TextBlock).Text = fItem.KeyTitle;
                else
                    (controlPackage.DataControls.First().Control as TextBlock).Text = "نامشخص";
            }
            else
            {
                if (column.ColumnKeyValue.ValueFromKeyOrValue)
                    (controlPackage.DataControls.First().Control as ComboBox).Text = value;
                else
                {
                    if (value == "")
                        (controlPackage.DataControls.First().Control as ComboBox).SelectedValue = null;
                    else
                        (controlPackage.DataControls.First().Control as ComboBox).SelectedValue = Convert.ToInt32(value);
                }
                if (columnSetting != null)
                {
                    if (columnSetting.IsReadOnly)
                        (controlPackage.DataControls.First().Control as ComboBox).IsReadOnly = true;
                    else
                        (controlPackage.DataControls.First().Control as ComboBox).IsReadOnly = false;
                }
            }

            return true;
        }

        internal static string GetValue(UIControlPackage controlPackage, DataAccess.Column column)
        {
            var control = controlPackage.DataControls.First().Control;
            if (control is TextBlock)
            {
                var text = (controlPackage.DataControls.First().Control as TextBlock).Text;
                DataAccess.ColumnKeyValueRange fItem = column.ColumnKeyValue.ColumnKeyValueRange.FirstOrDefault(x => x.KeyTitle == text);
                if (fItem != null)
                {
                    if (column.ColumnKeyValue.ValueFromKeyOrValue)
                        return fItem.KeyTitle;
                    else
                        return fItem.Value.ToString();
                }
                else
                    return "";
            }
            else
            {
                if (column.ColumnKeyValue.ValueFromKeyOrValue)
                    return (controlPackage.DataControls.First().Control as ComboBox).Text;
                else
                    if ((controlPackage.DataControls.First().Control as ComboBox).SelectedValue != null)
                        return (controlPackage.DataControls.First().Control as ComboBox).SelectedValue.ToString();
                    else
                        return "";
            }
        }
    }
}
