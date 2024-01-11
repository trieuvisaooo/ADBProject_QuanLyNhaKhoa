using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using ADB_QLNHAKHOA.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class StaffView_CustomerRecord : Page
    {
        public ObservableCollection<Patient> Patients { get; } = new ObservableCollection<Patient>();

        public StaffView_CustomerRecord()
        {
            this.InitializeComponent();
            this.Loaded += StaffView_CustomerRecord_Loaded;
        }


        private void StaffView_CustomerRecord_Loaded(object sender, RoutedEventArgs e)
        {
            // Load patients here. This is just a sample data.
            Patients.Add(new Patient { Name = "John Doe", AppointmentDate = DateTime.Now });
            Patients.Add(new Patient { Name = "Jane Doe", AppointmentDate = DateTime.Now.AddDays(1) });
        }
    }
}
