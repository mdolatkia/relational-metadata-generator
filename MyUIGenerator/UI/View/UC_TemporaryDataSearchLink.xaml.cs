
using MyUILibrary;
using MyUILibrary.EntityArea;
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
    /// Interaction logic for UC_TemporaryViewLink.xaml
    /// </summary>
    public partial class UC_TemporaryDataSearchLink : UserControl, IAG_View_TemporaryView
    {
        public UC_TemporaryDataSearchLink()
        {
            InitializeComponent();
        }



        public event EventHandler<Arg_TemporaryDisplayViewRequested> TemporaryDisplayViewRequested;
        //public event EventHandler<Arg_TemporaryDisplayViewRequested> TemporarySearchViewRequested;

        public void SetLinkText(string text)
        {
            lblInfo.Content = text;
        }

        private void btnLink_Click(object sender, RoutedEventArgs e)
        {
            if (TemporaryDisplayViewRequested != null)
            {
                TemporaryDisplayViewRequested(this, new Arg_TemporaryDisplayViewRequested() { DataItem = DataItem, LinkType = TemporaryLinkType.DataView, Column = Column });

            }
        }

        public object DataItem
        {
            set;
            get;
        }

        private void btnLinkSearch_Click(object sender, RoutedEventArgs e)
        {
            if (TemporaryDisplayViewRequested != null)
            {
                TemporaryDisplayViewRequested(this, new Arg_TemporaryDisplayViewRequested() { DataItem = DataItem, LinkType = TemporaryLinkType.SerachView, Column = Column });

            }
        }

        //public object SearchDataItem
        //{
        //    set;
        //    get;
        //}

        //public void SetSearchLinkText(string text)
        //{
        //    btnLinkSearch.Content = text;
        //}

        public DataAccess.Column Column
        {
            set;
            get;
        }

        public TemporaryLinkType LinkType
        {
            set
            {
                if (value == TemporaryLinkType.SerachView)
                {
                    btnLink.Visibility = System.Windows.Visibility.Collapsed;
                }
                else if (value == TemporaryLinkType.DataView)
                {
                    btnLinkSearch.Visibility = System.Windows.Visibility.Collapsed;
                }
            }
        }

        private void btnLinkInfo_Click(object sender, RoutedEventArgs e)
        {
            if (TemporaryDisplayViewRequested != null)
            {
                TemporaryDisplayViewRequested(this, new Arg_TemporaryDisplayViewRequested() { DataItem = DataItem, LinkType = TemporaryLinkType.Info, Column = Column });
            }
        }

        private void btnLinkClear_Click(object sender, RoutedEventArgs e)
        {
            if (TemporaryDisplayViewRequested != null)
            {
                TemporaryDisplayViewRequested(this, new Arg_TemporaryDisplayViewRequested() { DataItem = DataItem, LinkType = TemporaryLinkType.Clear, Column = Column });
            }
        }
    }
}
