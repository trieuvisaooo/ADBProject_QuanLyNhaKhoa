using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using ADB_QLNHAKHOA.ViewModels;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ADB_QLNHAKHOA.Views.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DentistView_DentistList : Page
    {
        private DentistInfoViewModel viewModel = new DentistInfoViewModel();
        public DentistView_DentistList()
        {
            this.InitializeComponent();
            AccountList.ItemsSource = viewModel.getStaffs();

        }

        public void StaffButton_Clicked(object sender, RoutedEventArgs e)
        {

            this.Frame.Navigate(typeof(DentistView_StaffList));
        }

        public void DentistButton_Clicked(object sender, RoutedEventArgs e)
        {
        }


        public void ItemClick(object sender, ItemClickEventArgs e)
        {
            var item = e.ClickedItem as DentistInfoViewModel;

            if (item != null)
            {
                this.Frame.Navigate(typeof(AdminView_DentistInfo), item);
            }
        }

        public void Search_click(object sender, RoutedEventArgs e)
        {
            AccountList.ItemsSource = viewModel.getStaffsByName(search_box.Text);
        }
    }
}
