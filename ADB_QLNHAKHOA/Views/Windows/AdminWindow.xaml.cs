using ADB_QLNHAKHOA.ViewModels;
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
                    BaseViewModel viewModel = new AdminInfoViewModel(_id);
                    contentFrame.Navigate(typeof(AdminView_AdminInfo), viewModel); 
                    break;
                case 1:
                    NvgtView.Header = "Kho thuốc";
                    contentFrame.Navigate(typeof(AdminView_MedicinePage));
                    break;
                case 2:
                    NvgtView.Header = "Tài khoản";
                    contentFrame.Navigate(typeof(AdminView_StaffAccountPage));
                    break;
                case 3:
                    NvgtView.Header = "Dịch vụ";
                    contentFrame.Navigate(typeof(AdminView_ServiceListPage));
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
                case "3":
                    FrameInflate(3);
                    break;
                case "SignOut":
                    Window LogInWindow = new LoginWindow();
                    LogInWindow.Activate();
                    this.Close();
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
                case "3":
                    FrameInflate(3);
                    break;
                case "SignOut":
                    break;
            }
        }
    }
}
