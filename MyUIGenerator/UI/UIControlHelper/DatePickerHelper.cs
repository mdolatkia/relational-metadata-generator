
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
    public static class DatePickerHelper
    {
        internal static UIControlPackage GenerateControl(DataAccess.Column correspondingTypeProperty, ColumnSetting columnSetting)
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
                var textBox = new DatePicker();
                textBox.SelectedDateChanged += (sender, e) => textBox_SelectedDateChanged(sender, e, package);
                textBox.IsEnabled = !columnSetting.IsReadOnly;
                if (!columnSetting.GridView)
                {
                    textBox.Width = 200;
                    textBox.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                }
                else
                    textBox.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;

                //   textBox.Margin = new System.Windows.Thickness(5);
                textBox.MinHeight = 24;
                //textBox.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
                textBox.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                package.DataControls.Add(new UIControl() { Control = textBox, UIControlSetting = controlUISetting });
            }
            return package;
        }

        static void textBox_SelectedDateChanged(object sender, SelectionChangedEventArgs e, UIControlPackage uiControlPackage)
        {
            ColumnValueChangeArg arg = new ColumnValueChangeArg();
            arg.NewValue = GetValue(uiControlPackage);
            uiControlPackage.OnValueChanged(sender, arg);
        }

        //internal static UIControlSetting GenerateUISetting(DataMaster.EntityDefinition.ND_Type_Property nD_Type_Property, UISetting.DataPackageUISetting.UI_PackagePropertySetting uI_PackagePropertySetting)
        //{
        //    throw new NotImplementedException();
        //}


        internal static bool SetValue(UIControlPackage controlPackage, string value, ColumnSetting columnSetting)
        {
            if (value == "getdate()")
                value = DateTime.Today.ToString();
            var control = controlPackage.DataControls.First().Control;
            if (control is TextBlock)
            {
                (controlPackage.DataControls.First().Control as TextBlock).Text = value;
            }
            else
            {
                (controlPackage.DataControls.First().Control as DatePicker).Text = value;
                if (columnSetting != null)
                {
                    if (columnSetting.IsReadOnly)
                        (controlPackage.DataControls.First().Control as DatePicker).IsEnabled = false;
                    else
                        (controlPackage.DataControls.First().Control as DatePicker).IsEnabled = true;
                }
            }

            return true;
        }

        internal static string GetValue(UIControlPackage controlPackage)
        {
            var control = controlPackage.DataControls.First().Control;
            if (control is TextBlock)
            {
                return (controlPackage.DataControls.First().Control as TextBlock).Text;
            }
            else
            {
                return (controlPackage.DataControls.First().Control as DatePicker).Text;
            }
        }
    }
}
