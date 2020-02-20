using BookingTelegramBot.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookingTelegramBot.DAL.Interfaces
{
    interface IParameterRepo
    {
        Task<IEnumerable<Parameter>> GetAll();
        Task<Parameter> GetParameterById(int parameterId);
        void Insert(Parameter parameter);
        void Update(Parameter parameter);
        void Delete(int parameterId);
        Task Save();
    }
}
