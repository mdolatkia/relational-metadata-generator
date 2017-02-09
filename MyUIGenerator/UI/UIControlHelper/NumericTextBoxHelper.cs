
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
    public static class NumericTextBoxHelper
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
                var textBox = new RadMaskedNumericInput();
                textBox.ValueChanged += (sender, e) => textBox_ValueChanged(sender, e, package);
                if (!columnSetting.GridView)
                {
                    textBox.Width = 200;
                    textBox.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                }
                else
                    textBox.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
                //textBox.Mask = "###";
                textBox.IsLastPositionEditable = false;
                textBox.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Left;
                //textBox.SpinMode = Telerik.Windows.Controls.MaskedInput.SpinMode.Position;
                //textBox.TextMode = Telerik.Windows.Controls.MaskedInput.TextMode.MaskedText;
                textBox.IsClearButtonVisible = false;
                textBox.Mask = "";
                textBox.Value = null;
                //  textBox.FormatString = "";
                //  textBox.EmptyContent = "";
                //textBox.TextMode = Telerik.Windows.Controls.MaskedInput.TextMode.PlainText;
                //textBox.sho
                //   textBox.InputBehavior = Telerik.Windows.Controls.MaskedInput.InputBehavior.Replace;

                //            if(correspondingTypeProperty.ColumnType.NumericColumnType.Precision)
                //textBox.ty
                textBox.MinHeight = 24;
                textBox.IsReadOnly = columnSetting.IsReadOnly;
                //textBox.Margin = new System.Windows.Thickness(5);

                textBox.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                package.DataControls.Add(new UIControl() { Control = textBox, UIControlSetting = controlUISetting });
            }

            return package;
        }

        static void textBox_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e, UIControlPackage uiControlPackage)
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
            var control = controlPackage.DataControls.First().Control;
            if (control is TextBlock)
            {
                (controlPackage.DataControls.First().Control as TextBlock).Text = value;
            }
            else
            {
                if (value == "<Null>" || value == null)
                    (controlPackage.DataControls.First().Control as RadMaskedNumericInput).Value = null;
                else
                {
                    if (value == "")
                        value = "0";
                    (controlPackage.DataControls.First().Control as RadMaskedNumericInput).Value = Convert.ToDouble(value);
                }

                if (columnSetting != null)
                    if (columnSetting.IsReadOnly)
                        (controlPackage.DataControls.First().Control as RadMaskedNumericInput).IsReadOnly = true;
                    else
                        (controlPackage.DataControls.First().Control as RadMaskedNumericInput).IsReadOnly = false;

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
                if ((controlPackage.DataControls.First().Control as RadMaskedNumericInput).Value == null)
                    return "<Null>";
                else
                    return (controlPackage.DataControls.First().Control as RadMaskedNumericInput).Value.ToString();
            }
        }
    }
}
