using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6AirlineReservation.Classes
{
    /// <summary>
    /// Class for managing passenger information
    /// </summary>
    class clsPassManage
    {
        /// <summary>
        /// List for passenger objects
        /// </summary>
        private List<clsPassenger> lstPassengers { get; set; }

        /// <summary>
        /// Class object for SQL statements
        /// </summary>
        private clsFlightSQL flightSQL;

        /// <summary>
        /// Data access class object declaration
        /// </summary>
        private clsDataAccess db;

        /// <summary>
        /// Variable for the number of passengers returned from SQL Query
        /// </summary>
        int numOfPass;

        /// <summary>
        /// Constructor
        /// </summary>
        public clsPassManage()
        {
            try
            {
                flightSQL = new clsFlightSQL();
                db = new clsDataAccess();
                numOfPass = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Returns a List of Passenger objects taken from the DB
        /// </summary>
        /// <param name="numOfFlights"></param>
        /// <returns></returns>
        public List<clsPassenger> GetPassengers(string fID)
        {
            try
            {
                DataSet ds = new DataSet();

                lstPassengers = new List<clsPassenger>();

                // Query DB for all passengers on selected flight from Main Window
                ds = db.ExecuteSQLStatement(flightSQL.SelectAllPassengers(fID), ref numOfPass);
                // For each query, Create a passengers object and add to List of Passenger object
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    lstPassengers.Add(new clsPassenger(ds.Tables[0].Rows[i][0].ToString(), ds.Tables[0].Rows[i][1].ToString(), ds.Tables[0].Rows[i][2].ToString(),
                                ds.Tables[0].Rows[i][3].ToString(), fID));
                }
                
                return lstPassengers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
