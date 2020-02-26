using BookingTelegramBot.DAL.EF;
using BookingTelegramBot.DAL.Entities;
using BookingTelegramBot.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingTelegramBot.DAL.Repositories
{
    public class ParameterRepo : IParameterRepo
    {
        private readonly BookingRoomDbContext _context;
        public ParameterRepo(BookingRoomDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Parameter>> GetAllAsync()
        {
            return await _context.Parameters.ToListAsync();
        }

        public async Task<Parameter> GetParameterByIdAsync(int parameterId)
        {
            return await _context.Parameters.FindAsync(parameterId);
        }

        public void Insert(Parameter parameter)
        {
            _context.Parameters.Add(parameter);
        }

        public void Update(Parameter parameter)
        {
            _context.Entry(parameter).State = EntityState.Modified;
        }

        public void Delete(int parameterId)
        {
            Parameter parameter = _context.Parameters.Find(parameterId);
            _context.Parameters.Remove(parameter);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
