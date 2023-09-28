using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiFlightInfo.Models
{
    [System.Serializable]
    [Table("Flight")]
    public class Flight
    {

        [Key]
        public string flightId { get; set; }
        public string flightSource { get; set; }
        public string flightDestination { get; set; }
        public DateTime flightDateTime { get; set; }
    }
}
