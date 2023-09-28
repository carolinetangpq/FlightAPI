using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiFlightInfo.Exceptions;
using WebApiFlightInfo.Models;

namespace WebApiFlightInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private IFlightRepository flightRepo;

        public FlightController(IFlightRepository _flightRepo)
        {
            this.flightRepo = _flightRepo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Flight> flights;
            try
            {
                flights = (IEnumerable<Flight>)flightRepo.GetAllFlights();
                return Ok(flights);
            }
            catch (SqlException e)
            {
                if (e.Message.Contains("Timeout"))
                {
                    return StatusCode(408, e.Message);
                }
                return StatusCode(500, e.Message);
            }

            catch (RecordNotFoundException e)
            {
                return StatusCode(200, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }

        //Get api/FlightController/{id}
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                Flight flights;
                flights = flightRepo.GetFlightNumber(id);
                return Ok(flights);
            }

            catch (SqlException e)
            {
                if (e.Message.Contains("Timeout"))
                {
                    return StatusCode(408, e.Message);
                }

                return StatusCode(500, e.Message);
            }

            catch (RecordNotFoundException e)
            {
                return StatusCode(200, e.Message);
            }

            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Flight flight)
        {
            try
            {
                flightRepo.UpdateFlight(flight);
                return Ok(flight);
            }

            catch (SqlException e)
            {
                if (e.Message.Contains("Timeout"))
                {
                    return StatusCode(408, e.Message);
                }

                return StatusCode(500, e.Message);
            }


            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Flight flight)
        {   
            try
            {
                flightRepo.AddFlight(flight);
                return StatusCode(201, flight);
            }

            catch (SqlException e)
            {
                if (e.Message.Contains("Timeout"))
                {
                    return StatusCode(408, e.Message);
                }
                return StatusCode(500, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        } 

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                flightRepo.DeleteFlight(id);
                return Ok();
            }

            catch (RecordNotFoundException ex)
            {
                return StatusCode(200, ex.Message);
            }
            catch (SqlException e)
            {
                if (e.Message.Contains("Timeout"))
                {
                    return StatusCode(408, e.Message);
                }
                return StatusCode(500, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }

        //[HttpGet("GetByNameDept/Name={Name}&dept={dept}")]
        [HttpGet("bydate/FlightDate={flight_date}")]
        public IActionResult GetFlightDate(DateTime flight_date)
        {
            IEnumerable<Flight> flight; 
            try
            {
                flight = (IEnumerable<Flight>)flightRepo.GetFlightDate(flight_date);
                return Ok(flight); 
            }

            catch (SqlException e)
            {
                return StatusCode(500, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }

        [HttpGet("flightsource={flightsource}&dest={dest}")]
        public IActionResult GetFlightSourceDest(string flightsource, string dest)
        {
            IEnumerable<Flight> flight; 
            try
            {
                flight = (IEnumerable<Flight>)flightRepo.GetFlightSourceDest(flightsource, dest);
                return Ok(flight);
            }

            catch (RecordNotFoundException ex)
            {
                return StatusCode(200, ex.Message);
            }
            catch (SqlException e)
            {
                if (e.Message.Contains("Timeout"))
                {
                    return StatusCode(408, e.Message);
                }
                return StatusCode(500, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }

        [HttpGet("operational/flight_date=flight_date")]
        public IActionResult GetFlightByDate(DateTime date)
        {
            IEnumerable<Flight> flight; 
            try
            {
                flight = (IEnumerable<Flight>)flightRepo.GetFlightByDate(date);
                return Ok(flight);
            }

            catch (RecordNotFoundException ex)
            {
                return StatusCode(200, ex.Message);
            }
            catch (SqlException e)
            {
                if (e.Message.Contains("Timeout"))
                {
                    return StatusCode(408, e.Message);
                }
                return StatusCode(500, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }

    }
}
