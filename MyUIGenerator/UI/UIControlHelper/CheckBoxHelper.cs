
using MyUILibrary;
using MyUILibrary.EntityArea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Telerik.Windows.Controls;

namespace MyUIGenerator.UIControlHelper
{
    public static class CheckBoxHelper
    {
        internal static UIControlPackage GenerateControl(DataAccess.Column correspondingTypeProperty, ColumnSetting columnSetting)
        {
            UIControlPackage package = new UIControlPackage();
            package.DataControls = new List<UIControl>();
            UIControlSetting controlUISetting = new UIControlSetting();
            controlUISetting.DesieredColumns = 1;
            controlUISetting.DesieredRows = 1;
            var control = new CheckBox();
            control.Checked += (sender, e) => control_Checked(sender, e, package); 
            //textBox.Mask = "###";

            //  textBox.FormatString = "";
            //  textBox.EmptyContent = "";
            //textBox.TextMode = Telerik.Windows.Controls.MaskedInput.TextMode.PlainText;
            //textBox.sho
            //   textBox.InputBehavior = Telerik.Windows.Controls.MaskedInput.InputBehavior.Replace;

            //            if(correspondingTypeProperty.ColumnType.NumericColumnType.Precision)
            //textBox.ty
            control.IsEnabled = !columnSetting.IsReadOnly;
            //control.Margin = new System.Windows.Thickness(5);
            control.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            control.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            package.DataControls.Add(new UIControl() { Control = control, UIControlSetting = controlUISetting });
            return package;
        }

       
        static void control_Checked(object sender, System.Windows.RoutedEventArgs e, UIControlPackage uiControlPackage)
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
            if (value == "<Null>" || value == null)
                (controlPackage.DataControls.First().Control as CheckBox).IsChecked = null;
            else
            {
                if (value == "" || value == "0")
                    value = "false";
                else if (value == "1")
                    value = "true";
                (controlPackage.DataControls.First().Control as CheckBox).IsChecked = Convert.ToBoolean(value);
            }

            if (columnSetting != null)
                (controlPackage.DataControls.First().Control as CheckBox).IsEnabled = !columnSetting.IsReadOnly;


            return true;
        }

        internal static string GetValue(UIControlPackage controlPackage)
        {
            if ((controlPackage.DataControls.First().Control as CheckBox).IsChecked == null)
                return "<Null>";
            else
            {
                return ((controlPackage.DataControls.First().Control as CheckBox).IsChecked == true ? "1" : "0");
            }
        }
    }
}
