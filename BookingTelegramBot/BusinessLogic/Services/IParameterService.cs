using BookingTelegramBot.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingTelegramBot.BusinessLogic.Services
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
