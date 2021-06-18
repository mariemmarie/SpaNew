using Microsoft.EntityFrameworkCore;
using SPA.Data;
using SPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPA.Services
{
    public class ConsultantsService : IConsultantsService

    {
        private readonly ApplicationDbContext _context;

        public ConsultantsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Consultant>> GetConsultantsList()
        {
            return await _context.Consultants
                .ToListAsync();
        }

        public async Task<Consultant> GetConsultantById(int id)
        {
            return await _context.Consultants
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Consultant> CreateConsultant(Consultant consultant)
        {
            _context.Consultants.Add(consultant);
            await _context.SaveChangesAsync();
            return consultant;
        }
        public async Task UpdateConsultant(Consultant consultant)
        {
            _context.Consultants.Update(consultant);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteConsultant(Consultant consultant)
        {
            _context.Consultants.Remove(consultant);
            await _context.SaveChangesAsync();

        }
    }
}
