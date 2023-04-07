using Assignment6AirlineReservation.Classes;
using Assignment6AirlineReservation.Windows;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
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

namespace Assignment6AirlineReservation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        clsDataAccess clsData;
        clsFlightManage flightManager;
        clsPassManage passManager;

        wndAddPassenger wndAddPass;
        

        public MainWindow()
        {
            try
            {
                InitializeComponent();
                Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;

                flightManager = new clsFlightManage();
                passManager = new clsPassManage();
                clsData = new clsDataAccess();

                // Populate Flight combobox list on window load
                UpdateFlightList();

                ////This should probably be in a new class.  Would be nice if this new class
                ////returned a list of Flight objects that was then bound to the combo box
                ////Also should show the flight number and aircraft type together
                //ds = clsData.ExecuteSQLStatement(sSQL, ref iRet);

                ////Should probably bind a list of flights to the combo box
                //for(int i = 0; i < iRet; i++)
                //{
                //    cbChooseFlight.Items.Add(ds.Tables[0].Rows[i][0]);
                //}
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Method for Updating Flight combobox dropdown list
        /// Binds the combo box using a List of Flights
        /// </summary>
        private void UpdateFlightList()
        {
            cbChooseFlight.ItemsSource = flightManager.getFlights();
            cbChooseFlight.DisplayMemberPath = "DisplayText";
        }

        /// <summary>
        /// Method for when the user selects a flight in the combo box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbChooseFlight_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //string selection = cbChooseFlight.SelectedItem.ToString();  //This is wrong, if a list of flights was in the combo box, then could get the selected flight in an object
                
                // Create flight reference
                clsFlight clsSelectedFlight = (clsFlight)cbChooseFlight.SelectedItem;

                // Enables Passenger buttons once Flight has been selected
                cbChoosePassenger.IsEnabled = true;
                gPassengerCommands.IsEnabled = true;

                //Should be using a flight object to get the flight ID here
                if (clsSelectedFlight.FlightID == "2")
                {
                    CanvasA380.Visibility = Visibility.Hidden;
                    Canvas767.Visibility = Visibility.Visible;
                }
                else
                {
                    Canvas767.Visibility = Visibility.Hidden;
                    CanvasA380.Visibility = Visibility.Visible;
                }

                //I think this should be in a new class to hold SQL statments
                //If the cbChooseFlight was bound to a list of Flights, the selected object would have the flight ID

                //Probably put in a new class

                //cbChoosePassenger.Items.Clear();//Don't need if assigning a list of passengers to the combo box

                //Would be nice if code from another class executed the SQL above, added each passenger into a Passenger object,
                //then into a list of Passengers to be returned and bound to the combo box
                //for (int i = 0; i < iRet; i++)
                //{
                //    cbChoosePassenger.Items.Add(ds.Tables[0].Rows[i][1] + " " + ds.Tables[0].Rows[i][2]);
                //}
                UpdatePassengerList(clsSelectedFlight);

            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Method for updating the Passenger combo box list
        /// Binds the combo box using a list of passengers for the selected Flight
        /// </summary>
        /// <param name="flight"></param>
        private void UpdatePassengerList(clsFlight flight)
        {
                cbChoosePassenger.ItemsSource = passManager.GetPassengers(flight.FlightID);
        }

        /// <summary>
        /// Method for when the Add passenger button is pressed.
        /// Displays the Add Passenger window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddPassenger_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                wndAddPass = new wndAddPassenger();
                wndAddPass.ShowDialog();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Method for Handling Errors
        /// Top level method when called displays a message to the user with the error,
        /// If an error occurs when displaying, save a file into the C drive with the Exception message.
        /// </summary>
        /// <param name="sClass"></param>
        /// <param name="sMethod"></param>
        /// <param name="sMessage"></param>
        private void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (System.Exception ex)
            {
                System.IO.File.AppendAllText(@"C:\Error.txt", Environment.NewLine + "HandleError Exception: " + ex.Message);
            }
        }
    }
}
