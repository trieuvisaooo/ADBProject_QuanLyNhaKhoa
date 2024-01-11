using ADB_QLNHAKHOA.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ADB_QLNHAKHOA.Views.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AdminView_AdminAccountPage : Page
    {
        private AdminInfoViewModel viewModel = new AdminInfoViewModel();
        public AdminView_AdminAccountPage()
        {
            this.InitializeComponent();
            AccountList.ItemsSource = viewModel.getStaffs();
        }
        public void StaffButton_Clicked(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AdminView_StaffAccountPage));
        }

        public void DentistButton_Clicked(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AdminView_DentistAccountPage));
        }

        public void AdminButton_Clicked(object sender, RoutedEventArgs e)
        {

        }

        public void ItemClick(object sender, ItemClickEventArgs e)
        {
            var item = e.ClickedItem as AdminInfoViewModel;
            Debug.WriteLine(item.Password);
            if (item != null)
            {
                this.Frame.Navigate(typeof(AdminView_AdminInfo), item);
            }
        }

        public void Search_click(object sender, RoutedEventArgs e)
        {
            AccountList.ItemsSource = viewModel.getStaffsByName(search_box.Text);
        }
    }
}
