using ADB_QLNHAKHOA.Views;
using ADB_QLNHAKHOA.Views.Pages;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Forms;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ADB_QLNHAKHOA
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AdminWindow : Window
    {
        private int _id;
        public int Id { get { return _id; } }

        public AdminWindow(int id)
        {   
            _id = id;
            this.InitializeComponent();
            App.SetTitleBarColors(this);
            this.AppWindow.TitleBar.ExtendsContentIntoTitleBar = true;
            this.SetTitleBar(TitleBar);
            contentFrame.CacheSize = 4;
            NvgtView.SelectedItem = NvgtView.MenuItems[0];
            FrameInflate(0);
            
        }

        private void FrameInflate(int index)
        {
            switch (index)
            {
                case 0:
                    NvgtView.Header = "Thông Tin Cá Nhân";
                    var adminInfo = new AdminView_AdminInfo(_id);
                    contentFrame.Navigate(adminInfo.GetType(), adminInfo);
                    break;
                case 1:
                    NvgtView.Header = "Khách Hàng";
                    contentFrame.Navigate(typeof(StaffView_CustomerInfo));
                    break;
                case 2:
                    NvgtView.Header = "Hồ Sơ Bệnh Án";
                    contentFrame.Navigate(typeof(StaffView_CustomerRecord));
                    break;
            }
        }

        private void NvgtView_ItemInvoked(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewItemInvokedEventArgs args)
        {
            switch (args.InvokedItemContainer.Tag)
            {
                case "0":
                    FrameInflate(0);
                    break;
                case "1":
                    FrameInflate(1);
                    break;
                case "2":
                    FrameInflate(2);
                    break;
            }
        }

        private void NvgtView_SelectionChanged(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewSelectionChangedEventArgs args)
        {
            switch (args.SelectedItemContainer.Tag)
            {
                case "0":
                    FrameInflate(0);
                    break;
                case "1":
                    FrameInflate(1);
                    break;
                case "2":
                    FrameInflate(2);
                    break;
            }
        }
    }
}
