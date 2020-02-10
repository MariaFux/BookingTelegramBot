using BookingTelegramBot.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookingTelegramBot.Repository
{
    public class ParameterRepo : IParameterRepo
    {
        public BookingRoomDbContext context;
        public ParameterRepo(BookingRoomDbContext context)
        {
            this.context = context;
        }        

        public IEnumerable<Parameter> GetAll()
        {
            return context.Parameters.ToList();
        }

        public Parameter GetParameterByID(int parameterID)
        {
            return context.Parameters.Find(parameterID);
        }

        public void Insert(Parameter parameter)
        {
            context.Parameters.Add(parameter);
        }        

        public void Update(Parameter parameter)
        {
            context.Entry(parameter).State = EntityState.Modified;
        }

        public void Delete(int parameterID)
        {
            Parameter parameter = context.Parameters.Find(parameterID);
            context.Parameters.Remove(parameter);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
