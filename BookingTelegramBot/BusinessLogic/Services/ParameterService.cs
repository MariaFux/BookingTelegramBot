using BookingTelegramBot.Repository;
using BookingTelegramBot.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingTelegramBot.BusinessLogic.Services
{
    public class ParameterService : IParameterService
    {
        public ParameterRepo parameterRepo;

        public ParameterService(ParameterRepo parameterRepo)
        {
            this.parameterRepo = parameterRepo;
        }        

        public IEnumerable<Parameter> GetAll()
        {
            return parameterRepo.GetAll();
        }

        public Parameter GetParameterByID(int parameterID)
        {
            return parameterRepo.GetParameterByID(parameterID);
        }

        public void Insert(Parameter parameter)
        {
            parameterRepo.Insert(parameter);
        }        

        public void Update(Parameter parameter)
        {
            parameterRepo.Update(parameter);
        }

        public void Delete(int parameterID)
        {
            parameterRepo.Delete(parameterID);
        }

        public void Save()
        {
            parameterRepo.Save();
        }
    }
}
