using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace Assignment6AirlineReservation.Classes
{
    /// <summary>
    /// Class for SQL statements
    /// </summary>
    internal class clsFlightSQL
    {
        /// <summary>
        /// SQL method returning all flight data from Flight DB
        /// </summary>
        /// <returns>All data for the given invoice.</returns>
        public string SelectAllFlights()
        {
            //Should probably not have SQL statements behind the UI
            string sSQL = "SELECT Flight_ID, Flight_Number, Aircraft_Type FROM FLIGHT";

            return sSQL;
        }
        /// <summary>
        /// SQL method for returning all passengers on a selected Flight from DB
        /// </summary>
        /// <returns></returns>
        public string SelectAllPassengers(string fID)
        {
            string sSQL = "SELECT PASSENGER.Passenger_ID, First_Name, Last_Name, Seat_Number " +
                        "FROM FLIGHT_PASSENGER_LINK, FLIGHT, PASSENGER " +
                        "WHERE FLIGHT.FLIGHT_ID = FLIGHT_PASSENGER_LINK.FLIGHT_ID AND " +
                        "FLIGHT_PASSENGER_LINK.PASSENGER_ID = PASSENGER.PASSENGER_ID AND " +
                        "FLIGHT.FLIGHT_ID = " + fID;
            return sSQL;
        }
        /// <summary>
        /// Method for inserting a new passenger into the DB
        /// </summary>
        public void AddPassenger()
        {
            //Inserting a passenger
            string sSQL = "INSERT INTO PASSENGER(First_Name, Last_Name) VALUES('FirstName','LastName')";

            //Get the passenger's ID
            string pID = "SELECT Passenger_ID from Passenger where First_Name = 'Shawn' AND Last_Name = 'Cowder'";

            //Insert into the link table
            sSQL = "INSERT INTO Flight_Passenger_Link(Flight_ID, Passenger_ID, Seat_Number) " +
                   "VALUES( 1 , 6 , 3)";
        }
    }
}
