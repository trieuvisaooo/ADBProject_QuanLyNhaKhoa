﻿using Microsoft.UI.Xaml;
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
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddMedicin : Page
    {
        public AddMedicin()
        {
            this.InitializeComponent();
            List<string> thuocList = new List<string>
            {
                "Thuốc 1",
                "Thuốc 2",
                "Thuốc 3"
            };

            ThuocCombo.ItemsSource = thuocList;
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
