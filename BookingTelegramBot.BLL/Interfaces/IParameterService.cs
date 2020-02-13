using BookingTelegramBot.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingTelegramBot.BLL.Interfaces
{
    interface IParameterService
    {
        IEnumerable<Parameter> GetAll();
        Parameter GetParameterById(int parameterId);
        void Insert(Parameter parameter);
        void Update(Parameter parameter);
        void Delete(int parameterId);
        void Save();
    }
}
