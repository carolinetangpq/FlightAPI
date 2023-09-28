using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiFlightInfo.Models;

namespace WebApiFlightInfo
{
    public interface IFlightRepository
    {

        //All flights 
        IEnumerable<Flight> GetAllFlights(); 
        //Flight number
        Flight GetFlightNumber(string Id);

        //get Flight by source & dest
        IEnumerable<Flight> GetFlightSourceDest(string source, string des);

        //Add flight
        Flight AddFlight(Flight flight);

        //Flight Date
        IEnumerable<Flight> GetFlightDate(DateTime dateTime);

        //Get operational flights based on date 
        IEnumerable<Flight> GetFlightByDate(DateTime dateTime);

        //Update flight 
        Flight UpdateFlight(Flight flight);

        //Delete Flight 
        Flight DeleteFlight(string Id); 


    }
}
