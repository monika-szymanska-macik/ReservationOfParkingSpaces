using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservation.Models
{
    public class ParkingSpace
    {
        public int Id { get; set; }
        public string TypeOfParkingSpace { get; set; }
        public decimal Price { get; set; }
    }
}
