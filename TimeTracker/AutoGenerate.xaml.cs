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
using System.Windows.Shapes;
using TimeTracker.Models;

namespace TimeTracker
{
    /// <summary>
    /// Interaction logic for AutoGenerate.xaml
    /// </summary>
    public partial class AutoGenerate : Window
    {

        private TimeTrackerDBContext context = new TimeTrackerDBContext();
        CollectionViewSource employeeViewSource;
        public AutoGenerate()
        {
            InitializeComponent();
            // the name is conventional comes from table name from datasource +viewSource
            employeeViewSource = ((CollectionViewSource)(FindResource("employeeViewSource")));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource employeeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("employeeViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // employeeViewSource.Source = [generic data source]
        }

        private void BtnFirst_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnPrevious_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnLast_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
