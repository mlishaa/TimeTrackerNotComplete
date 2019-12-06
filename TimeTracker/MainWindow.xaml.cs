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
using TimeTracker.Models;
namespace TimeTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private TimeTrackerViewModel repo = new TimeTrackerViewModel();
        public MainWindow()
        {
            InitializeComponent();
            //TimeTrackerDBContext context = new TimeTrackerDBContext();
            //EmployeeAddTest(context);

            //dgEmployees.ItemsSource = (from e in context.Employees
            //                           select e).ToList();

            dgEmployees.ItemsSource = repo.GetALlEmployees();
            
        }
        private Employee GenerateTestEmployee(TimeTrackerDBContext context)
        {
            return new Employee()
            {
                FirstName = "Test",
                lastName = "Waine",
                Gender = true,
                DateOfBirth = DateTime.Parse("3/05/1965"),
                Department = "TEST",
                Role = "TESTROLE",
                HireTime = DateTime.Now.AddYears(-2),
                Salary = new Random().Next(100, 100000),
                TimeCards = new List<TimeCard>()
                {
                    new TimeCard()
                    {
                        SubmissionDate = DateTime.Now.AddDays(-7),
                        MondayHours = 8,
                        TuesdayHours=7,
                        WedesdayHours=6,
                        ThursdayHours=8,
                        FridayHours=9,
                        SaturdayHours=6,
                        SundayHours=0
                    }
                }
            };
            
        }



        private void BtnTest_Click(object sender, RoutedEventArgs e)
        {
            if ((dgEmployees.SelectedItem as Employee).TimeCards == null)
            {
                MessageBox.Show("Null");
            }
            else
                MessageBox.Show("Not Null");
        }



        private void DgEmployees_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Employee current = dgEmployees.SelectedItem as Employee;
            // text block value
            txtEmployeeRecord.Text = string.Format("ID# {0} - {1} - {2} | {3}",
                current.ID, current.lastName, current.FirstName, current.Role);
            // set the data grid

            dgTimeCards.ItemsSource = current.TimeCards;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

            
         if(dgEmployees.SelectedItem != null && MessageBox.Show("Are you sure you want to delete ? this will delete ? /n"+
                "this will delete the time card as well","Confirm Delete",
                MessageBoxButton.YesNo,MessageBoxImage.Stop)== MessageBoxResult.Yes)
            {
                try
                {
                    repo.DeleteANEmployee((dgEmployees.SelectedItem as Employee).ID);
                    dgEmployees.ItemsSource = repo.GetALlEmployees();


                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
               
            }
        }

        private void BtnAddEmployee_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSearchLast_Click(object sender, RoutedEventArgs e)
        {
          dgEmployees.ItemsSource = repo.SearchByLastName(txtLastName.Text);

        }
    }
}
