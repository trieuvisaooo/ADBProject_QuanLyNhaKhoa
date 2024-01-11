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

namespace ADB_QLNHAKHOA.Views
{
    public sealed partial class StaffView_StaffInfo : Page
    {
        public StaffView_StaffInfo()
        {
            this.InitializeComponent();
        }

        private void makeAppointment_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            // Add logic for handling the "Đăng Kí" button click
            // For example, you can retrieve values from controls like DenList, AppoDate, AppoTime, and perform the appointment registration logic.
        }

        private void cancel_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            // Add logic for handling the "Hủy" button click
            // For example, you can navigate to another page or perform any cancellation logic.
        }
    }
}
