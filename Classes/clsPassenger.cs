using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6AirlineReservation.Classes
{
    /// <summary>
    /// Passenger class
    /// </summary>
    class clsPassenger
    {
        /// <summary>
        /// Passenger's ID
        /// </summary>
        private string passID { get; set; }
        /// <summary>
        /// Passenger's first name
        /// </summary>
        private string firstName { get; set;}
        /// <summary>
        /// Passenger's last name
        /// </summary>
        private string lastName { get; set;}
        /// <summary>
        /// Passenger's seat number on flight
        /// </summary>
        private string passSeat { get; set;}
        /// <summary>
        /// Passenger's flight number
        /// </summary>
        private string passFlight { get; set;}

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="passID"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="passSeat"></param>
        /// <param name="passFlight"></param>
        public clsPassenger(string passID, string firstName, string lastName, string passSeat, string passFlight)
        {
            this.passID = passID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.passSeat = passSeat;
            this.passFlight = passFlight;
        }



        /// <summary>
        /// Passenger class toString method
        /// </summary>
        public override string ToString()
        {
            return $"{firstName} {lastName}";
        }

    }
}
