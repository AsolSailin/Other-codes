using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
// Added
using Wpf_Images.Windows;

namespace Wpf_Images
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ListImg.ItemsSource = App.Connection.Material.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            MaterialAddWindow addWindow = new MaterialAddWindow();
            addWindow.Show();
            this.Close();
        }
    }
}
