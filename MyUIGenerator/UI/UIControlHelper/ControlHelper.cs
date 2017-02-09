
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
    public static class ControlHelper
    {
        internal static UIControlPackage GenerateControl(DataAccess.Column column, ColumnSetting columnSetting)
        {
            if (column.ColumnKeyValue == null)
            {
                if (AgentHelper.GetColumnType(column) == Enum_UIColumnType.Text)
                    return UIControlHelper.TextBoxHelper.GenerateControl(column, columnSetting);
                else if (AgentHelper.GetColumnType(column) == Enum_UIColumnType.Numeric)
                    return UIControlHelper.NumericTextBoxHelper.GenerateControl(column, columnSetting);
                else if (AgentHelper.GetColumnType(column) == Enum_UIColumnType.Date)
                    return UIControlHelper.DatePickerHelper.GenerateControl(column, columnSetting);
                else if (AgentHelper.GetColumnType(column) == Enum_UIColumnType.Boolean)
                    return UIControlHelper.CheckBoxHelper.GenerateControl(column, columnSetting);
                else
                    return UIControlHelper.TextBoxHelper.GenerateControl(column, columnSetting);
            }
            else
            {
                return UIControlHelper.KeyValueControlHelper.GenerateControl(column, columnSetting);
            }
        }
        internal static UIControlPackage GenerateControlPackage(object view, ColumnSetting columnSetting)
        {
            UIControlPackage package = new UIControlPackage();
            package.DataControls = new List<UIControl>();

            UIControl control = new UIControl();
            control.UIControlSetting = new UIControlSetting();
            if (columnSetting.aG_EnumViewControlInsertionMode == AG_EnumViewControlInsertionMode.NewLine)
                control.UIControlSetting.DesieredColumns = 10;
            else
                control.UIControlSetting.DesieredColumns = 1;
            control.UIControlSetting.DesieredRows = 1;
            control.Control = view;
            package.DataControls.Add(control);
            return package;
        }
        //internal static UIControlSetting GenerateUISetting(DataAccess.Column nD_Type_Property, UISetting.DataPackageUISetting.UI_PackagePropertySetting uI_PackagePropertySetting)
        //{
        //    throw new NotImplementedException();
        //}

        internal static bool SetValue(DataAccess.Column column, UIControlPackage controlPackage, string value, ColumnSetting columnSetting)
        {
            if (column.ColumnKeyValue == null)
            {
                if (AgentHelper.GetColumnType(column) == Enum_UIColumnType.Text)
                    return TextBoxHelper.SetValue(controlPackage, value, columnSetting);
                else if (AgentHelper.GetColumnType(column) == Enum_UIColumnType.Numeric)
                    return NumericTextBoxHelper.SetValue(controlPackage, value, columnSetting);
                else if (AgentHelper.GetColumnType(column) == Enum_UIColumnType.Date)
                    return DatePickerHelper.SetValue(controlPackage, value, columnSetting);
                else if (AgentHelper.GetColumnType(column) == Enum_UIColumnType.Boolean)
                    return CheckBoxHelper.SetValue(controlPackage, value, columnSetting);
                else
                    return TextBoxHelper.SetValue(controlPackage, value, columnSetting);
            }
            else
                return KeyValueControlHelper.SetValue(controlPackage, column, value, columnSetting);

        }

        //internal static bool SetValue(ColumnControl typePropertyControl, string value)
        //{
        //    if (typePropertyControl.UI_PropertySetting.PropertyType == CommonDefinitions.CommonUISettings.Enum_UI_PropertyType.Text)
        //    {
        //        return ControlHelpers.TextBoxHelper.SetValue(typePropertyControl, value);
        //    }
        //    else
        //        return ControlHelpers.TextBoxHelper.SetValue(typePropertyControl, value);
        //}

        internal static string GetValue(DataAccess.Column column, UIControlPackage controlPackage)
        {
            if (column.ColumnKeyValue == null)
            {
                if (AgentHelper.GetColumnType(column) == Enum_UIColumnType.Text)
                    return TextBoxHelper.GetValue(controlPackage);
                else if (AgentHelper.GetColumnType(column) == Enum_UIColumnType.Numeric)
                    return NumericTextBoxHelper.GetValue(controlPackage);
                else if (AgentHelper.GetColumnType(column) == Enum_UIColumnType.Date)
                    return DatePickerHelper.GetValue(controlPackage);
                else if (AgentHelper.GetColumnType(column) == Enum_UIColumnType.Boolean)
                    return CheckBoxHelper.GetValue(controlPackage);
                else
                    return TextBoxHelper.GetValue(controlPackage);
            }
            else
                return KeyValueControlHelper.GetValue(controlPackage, column);
        }


        public static UIControl GetUIControl(UIControlPackage aG_UIControlPackage)
        {
            return aG_UIControlPackage.DataControls.First();
        }

    }
}
