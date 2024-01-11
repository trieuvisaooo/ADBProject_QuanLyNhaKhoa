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
using System.Collections.ObjectModel;
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
    public sealed partial class DentistView_Appointment : Page
    {
        private DentistInfoVM viewModel = new DentistInfoVM();

        public DentistView_Appointment()
        {
            this.InitializeComponent();
        }

        private DenView_DenAppoinmentVM dentistAppointmentViewModel = new DenView_DenAppoinmentVM();

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            viewModel = e.Parameter as DentistInfoVM;
            viewModel.getInfo(viewModel);
            AppointmentList.ItemsSource = dentistAppointmentViewModel.GetAppointments((App.Current as App).ConnectionString, viewModel.Id);
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(DentistView_DenMakeAppointment), viewModel);
        }
    }
}
