using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Reservation.Data;
using Reservation.Models;

namespace Reservation.Pages.ParkingSpaces
{
    public class CreateModel : PageModel
    {
        private readonly Reservation.Data.ReservationContext _context;

        public CreateModel(Reservation.Data.ReservationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ParkingSpace ParkingSpace { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ParkingSpace.Add(ParkingSpace);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
