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
        public BookingRoomDbContext context;
        public ParameterRepo(BookingRoomDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Parameter>> GetAllAsync()
        {
            return await context.Parameters.ToListAsync();
        }

        public async Task<Parameter> GetParameterByIdAsync(int parameterId)
        {
            return await context.Parameters.FindAsync(parameterId);
        }

        public void Insert(Parameter parameter)
        {
            context.Parameters.Add(parameter);
        }

        public void Update(Parameter parameter)
        {
            context.Entry(parameter).State = EntityState.Modified;
        }

        public void Delete(int parameterId)
        {
            Parameter parameter = context.Parameters.Find(parameterId);
            context.Parameters.Remove(parameter);
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
