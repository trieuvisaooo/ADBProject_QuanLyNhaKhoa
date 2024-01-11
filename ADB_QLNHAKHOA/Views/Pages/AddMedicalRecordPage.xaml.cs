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
    public sealed partial class AddMedicalRecordPage : Page
    {
        public AddMedicalRecordPage()
        {
            this.InitializeComponent();
        }

        private void SaveProfileButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
        private void addServiceButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddService));
        }

        private void AddMedicineButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddMedicin));
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(DentistView_CustomerRecord));
        }
    }
}
