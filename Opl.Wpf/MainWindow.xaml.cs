using MahApps.Metro.Controls;
using Microsoft.AspNetCore.Components.WebView.Wpf;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Radzen;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Opl.Metro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddWpfBlazorWebView();

            serviceCollection.AddRadzenComponents();
            serviceCollection.AddTransient<HttpClient>();
            serviceCollection.AddMemoryCache();


            Resources.Add("services", serviceCollection.BuildServiceProvider());

            Application.Current.DispatcherUnhandledException += Current_DispatcherUnhandledException;
        }

        private void Current_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            System.Windows.MessageBox.Show(e.Exception.ToString());
            e.Handled = true;
        }


        private async void ButtonOpenDevTools_Click(object sender, RoutedEventArgs e)
        {
            await blazorWebView.WebView.EnsureCoreWebView2Async();
            blazorWebView.WebView.CoreWebView2.OpenDevToolsWindow(); 
        }
    }
}