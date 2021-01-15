using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Reservation.Data;
using Reservation.Models;

namespace Reservation.Pages.ParkingSpaces
{
    public class IndexModel : PageModel
    {
        private readonly Reservation.Data.ReservationContext _context;

        public IndexModel(Reservation.Data.ReservationContext context)
        {
            _context = context;
        }

        public IList<ParkingSpace> ParkingSpace { get;set; }

        public async Task OnGetAsync()
        {
            ParkingSpace = await _context.ParkingSpace.ToListAsync();
        }
    }
}
