using SPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPA.Services
{
    public interface IConsultantsService
    {
        Task<IEnumerable<Consultant>> GetConsultantsList();
        Task<Consultant> GetConsultantById(int id);
        Task<Consultant> CreateConsultant(Consultant consultant);
        Task UpdateConsultant(Consultant consultant);
        Task DeleteConsultant(Consultant consultant);
    }
}
