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
using TestWPFApp1.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace TestWPFApp1
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var aaa = new TestDbContext();

            var serviceProvider = aaa.GetInfrastructure<IServiceProvider>();
            var a = (ILoggerFactory)serviceProvider.GetService(typeof(ILoggerFactory));

            a.AddDebug();

            var list = aaa.GT_Meisai.ToList();
            foreach (var val in list)
            {
                MessageBox.Show(val.No.ToString());
            }
        }
    }
}
