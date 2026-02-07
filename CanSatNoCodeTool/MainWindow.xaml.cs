using System;
using System.IO;
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

namespace CanSatNoCodeTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeWebView();
        }

        private async void InitializeWebView()
        {
            await BlocklyView.EnsureCoreWebView2Async();
            var path = System.IO.Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Blockly",
                "index.html");
            if (!File.Exists(path))
            {
                MessageBox.Show("Blockly/index.html not found.");
                Application.Current.Shutdown();
            }
            BlocklyView.Source = new Uri(path);
        }

    }
}