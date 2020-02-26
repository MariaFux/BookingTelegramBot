using AutoMapper;
using BookingTelegramBot.BLL.DTO;
using BookingTelegramBot.BLL.Interfaces;
using BookingTelegramBot.DAL.Entities;
using BookingTelegramBot.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookingTelegramBot.BLL.Services
{
    public class ParameterService : IParameterService
    {
        private readonly ParameterRepo _parameterRepo;
        private readonly IMapper _mapper;

        public ParameterService(ParameterRepo parameterRepo, IMapper mapper)
        {
            _parameterRepo = parameterRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ParameterDTO>> GetAllAsync()
        {
            var parameters = await _parameterRepo.GetAllAsync();
            var parametersDTO = _mapper.Map<IEnumerable<ParameterDTO>>(parameters);
            return parametersDTO;
        }

        public async Task<ParameterDTO> GetParameterByIdAsync(int parameterId)
        {
            var parameter = await _parameterRepo.GetParameterByIdAsync(parameterId);
            var parameterDTO = _mapper.Map<ParameterDTO>(parameter);
            return parameterDTO;
        }

        public void Insert(ParameterDTO parameter)
        {
            _parameterRepo.Insert(_mapper.Map<Parameter>(parameter));
        }

        public void Update(ParameterDTO parameter)
        {
            _parameterRepo.Update(_mapper.Map<Parameter>(parameter));
        }

        public void Delete(int parameterId)
        {
            _parameterRepo.Delete(parameterId);
        }

        public async Task SaveAsync()
        {
            await _parameterRepo.SaveAsync();
        }
    }
}
