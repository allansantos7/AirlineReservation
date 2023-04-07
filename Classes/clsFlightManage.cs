using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace Assignment6AirlineReservation.Classes
{
    /// <summary>
    /// Flight manage class
    /// </summary>
    class clsFlightManage
    {
        /// <summary>
        /// List containing the Flight classes
        /// </summary>
        private List<clsFlight> lstFlights { get; set; }

        /// <summary>
        /// Class object for SQL statements
        /// </summary>
        private clsFlightSQL flightSQL;

        /// <summary>
        /// Data access class object declaration
        /// </summary>
        private clsDataAccess db;

        /// <summary>
        /// Variable for the number of flights taken from SQL query
        /// </summary>
        private int numOfFlights;

        /// <summary>
        /// constructor
        /// </summary>
        public clsFlightManage()
        {
            lstFlights = new List<clsFlight>();
            flightSQL = new clsFlightSQL();
            db = new clsDataAccess();
            numOfFlights = 0;
        }
        /// <summary>
        /// Returns a list of flights taken from the DB
        /// </summary>
        /// <returns></returns>
        public List<clsFlight> getFlights()
        {
            try
            {
                DataSet ds;
                
                // Query database for All flights and return # of rows assigned to numOfFlights variables
                ds = db.ExecuteSQLStatement(flightSQL.SelectAllFlights(), ref numOfFlights);
                // For each query, create a flight object and add to a list of Flights object
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    lstFlights.Add(new clsFlight(ds.Tables[0].Rows[i][0].ToString(), ds.Tables[0].Rows[i][1].ToString(), ds.Tables[0].Rows[i][2].ToString()));
                }
                
                return lstFlights;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
 