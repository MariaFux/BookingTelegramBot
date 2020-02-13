using BookingTelegramBot.BLL.Interfaces;
using BookingTelegramBot.DAL.Entities;
using BookingTelegramBot.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingTelegramBot.BLL.Services
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

        public Parameter GetParameterById(int parameterId)
        {
            return parameterRepo.GetParameterById(parameterId);
        }

        public void Insert(Parameter parameter)
        {
            parameterRepo.Insert(parameter);
        }

        public void Update(Parameter parameter)
        {
            parameterRepo.Update(parameter);
        }

        public void Delete(int parameterId)
        {
            parameterRepo.Delete(parameterId);
        }

        public void Save()
        {
            parameterRepo.Save();
        }
    }
}
