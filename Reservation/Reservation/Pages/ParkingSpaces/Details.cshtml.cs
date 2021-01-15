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
    public class DetailsModel : PageModel
    {
        private readonly Reservation.Data.ReservationContext _context;

        public DetailsModel(Reservation.Data.ReservationContext context)
        {
            _context = context;
        }

        public ParkingSpace ParkingSpace { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ParkingSpace = await _context.ParkingSpace.FirstOrDefaultAsync(m => m.Id == id);

            if (ParkingSpace == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
