
using MyUILibrary;
using MyUILibrary.EntityArea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace MyUIGenerator.UIControlHelper
{
    public class LabelHelper
    {
        internal static UIControl GenerateLabelControl(string title,string tooltip)
        {
            UIControl uiControl = new UIControl();
            UIControlSetting controlUISetting = new UIControlSetting();
            //if (title.Length>50)
            //controlUISetting.DesieredColumns = 2;
            //else
                controlUISetting.DesieredColumns = 1;
            controlUISetting.DesieredRows = 1;
            var label = new Label();
            label.Margin = new System.Windows.Thickness(2, 0, 0, 2);
            label.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            label.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
            label.VerticalContentAlignment = System.Windows.VerticalAlignment.Center;
            label.Content = title;
            uiControl.Control = label;
            uiControl.UIControlSetting = controlUISetting ;
       
            if (!string.IsNullOrEmpty(tooltip))
            {
                ToolTipService.SetToolTip(label, tooltip);
            }
            return uiControl;
        }

        //internal static UIControlSetting GenerateUISetting(DataAccess.Column nD_Type_Property, UISetting.DataPackageUISetting.UI_PackagePropertySetting uI_PackagePropertySetting)
        //{
        //    return new UIControlSetting() { DesieredColumns = 1, DesieredRows = 1 };
        //}

     

        internal static void Highlight(UIControl uIControl, string message)
        {
           if(uIControl.Control is Label)
           {
               ToolTipService.SetToolTip((uIControl.Control as Label), message);
               (uIControl.Control as Label).Foreground = Brushes.Red;
               (uIControl.Control as Label).FontWeight = System.Windows.FontWeights.Bold;
           }
        }
        internal static void DeHighlight(UIControl uIControl)
        {
            if (uIControl.Control is Label)
            {
                ToolTipService.SetToolTip((uIControl.Control as Label), null);
                (uIControl.Control as Label).Foreground = Brushes.Black;
                (uIControl.Control as Label).FontWeight = System.Windows.FontWeights.Normal;
            }
        }
    }
}
