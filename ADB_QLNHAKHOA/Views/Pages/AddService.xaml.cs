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
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ADB_QLNHAKHOA.Views.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddService : Page
    {
        public AddService()
        {
            this.InitializeComponent();
            List<string> dvList = new List<string>
            {
                "Dịch vụ 1",
                "Dịch vụ 2",
                "Dịch vụ 3"
            };

            DichVuCombo.ItemsSource = dvList;
        }

        private void ThemButton_Click(object sender, RoutedEventArgs e)
        {
        }
        private void HuyButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddMedicalRecordPage));
        }
    }
}
