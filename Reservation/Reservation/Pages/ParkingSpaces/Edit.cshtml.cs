using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Reservation.Data;
using Reservation.Models;

namespace Reservation.Pages.ParkingSpaces
{
    public class EditModel : PageModel
    {
        private readonly Reservation.Data.ReservationContext _context;

        public EditModel(Reservation.Data.ReservationContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ParkingSpace).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParkingSpaceExists(ParkingSpace.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ParkingSpaceExists(int id)
        {
            return _context.ParkingSpace.Any(e => e.Id == id);
        }
    }
}
