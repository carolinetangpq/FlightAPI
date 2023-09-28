using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiFlightInfo.Exceptions;
using WebApiFlightInfo.Models;

namespace WebApiFlightInfo.Repository
{
    public class FlightRepository : IFlightRepository
    {
        private readonly AppDbContext context; 

        public FlightRepository(AppDbContext appDbContext)
        {
            this.context = appDbContext; 
        }

        public IEnumerable<Flight> GetAllFlights()
        {
            return context.Flights; 
        } 

        public Flight GetFlightNumber(string id)
        {
            var flight = context.Flights.Find(id);
            if (flight == null)
            {
                RecordNotFoundException ex = new RecordNotFoundException($"Flight with {id} not found.");
                throw ex;
            }

            return flight; 

        }

        public Flight AddFlight(Flight flight)
        {
            using (var con = context)
            {
                con.Flights.Add(flight);
                con.SaveChanges();
                return flight;
            }

        }
        public Flight DeleteFlight(string id)
        {
            var flight = context.Flights.Find(id); 
            if (flight == null)
            {
                RecordNotFoundException ex = new RecordNotFoundException($"Flight with {id} not found.");
                throw ex;
            }
            else
            {
                context.Flights.Remove(flight);
                context.SaveChanges(); 
            }

            return flight; 
        }

        public Flight UpdateFlight(Flight flightChanges)
        {
            var flight = context.Flights.Attach(flightChanges);
            flight.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return flightChanges; 

        }

        //search flights by the date 
        public IEnumerable<Flight> GetFlightDate(DateTime dateTime)
        {

            using (var con = context)
            {
                DateTime onlyDate = dateTime.Date; //only get the date 
                var flight = con.Flights.Where(item => item.flightDateTime.Date == onlyDate).ToList(); 

                if (flight.Count == 0)
                {
                    RecordNotFoundException ex = new RecordNotFoundException($"There is no such flights at {dateTime} ");
                    throw ex;
                }

                return flight; 
            }
        }

        //get operational flights before the scheduled date
        public IEnumerable<Flight> GetFlightByDate(DateTime dateTime)
        {
            DateTime onlyDate = dateTime.Date; //only get the date 
            using (var con = context)
            {
                var flight = con.Flights.Where(item => item.flightDateTime.Date > onlyDate).ToList();

                if (flight.Count == 0)
                {
                    RecordNotFoundException ex = new RecordNotFoundException($"No flights found on {dateTime}");
                    throw ex;
                }

                return flight;
            }
        }

        public IEnumerable<Flight> GetFlightSourceDest(string source, string dest)
        {
            using (var con = context)
            {
                var flight = con.Flights.Where(item => item.flightSource.Trim() == source && item.flightDestination.Trim() == dest).ToList();

                if (flight.Count == 0)
                {
                    RecordNotFoundException ex = new RecordNotFoundException($"There is no such source flight or destination flight ");
                    throw ex;
                }

                return flight; 
            }
        }


    }
}
