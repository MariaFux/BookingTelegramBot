using BookingTelegramBot.DAL.EF;
using BookingTelegramBot.DAL.Entities;
using BookingTelegramBot.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingTelegramBot.DAL.Repositories
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

        public Parameter GetParameterById(int parameterId)
        {
            return context.Parameters.Find(parameterId);
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

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
