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
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Forms;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ADB_QLNHAKHOA.Views.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AdminView_AdminInfo : Page
    {
        private AdminInfoViewModel viewModel = new AdminInfoViewModel();
        private int _id;

        public AdminView_AdminInfo()
        {
            this.InitializeComponent();

        }
        public AdminView_AdminInfo(int id)
        {
            this.InitializeComponent();
            _id = id;
            MessageBox.Show(_id.ToString());
            viewModel.getInfo(viewModel, _id);
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ModifyInfoBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
