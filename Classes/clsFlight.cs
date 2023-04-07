using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6AirlineReservation.Classes
{
    /// <summary>
    /// Flight class
    /// </summary>
    class clsFlight
    {
        /// <summary>
        /// Variable for the Flight class object's ID
        /// </summary>
        private string flightID { get; set; }
        /// <summary>
        /// Variable for the Flight class object's Number
        /// </summary>
        private string flightNum { get; set; }
        /// <summary>
        /// Variable for the Flight class object's Aircraft Type
        /// </summary>
        private string flightType { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="fID"></param>
        /// <param name="fNum"></param>
        /// <param name="fType"></param>
        public clsFlight(string fID, string fNum, string fType) { 
            flightID = fID;
            flightNum = fNum;
            flightType = fType;
        }

        /// <summary>
        /// Method for returning the private flightID property
        /// </summary>
        public string FlightID
        {
            get { return flightID; }
        }

        /// <summary>
        /// Method for displaying formatted text of:
        /// Flight Number - Flight Type
        /// </summary>
        /// <returns></returns>
        public string DisplayText
        {
            get
            {
                return $"{flightNum} - {flightType}";
            }
        }

        /// <summary>
        /// Override the ToString method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{flightNum} {flightType}";
        }
    }
}
