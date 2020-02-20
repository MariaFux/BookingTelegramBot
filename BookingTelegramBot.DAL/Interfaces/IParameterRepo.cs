using BookingTelegramBot.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingTelegramBot.DAL.Interfaces
{
    interface IParameterRepo
    {
        IEnumerable<Parameter> GetAll();
        Parameter GetParameterById(int parameterId);
        void Insert(Parameter parameter);
        void Update(Parameter parameter);
        void Delete(int parameterId);
        void Save();
    }
}
