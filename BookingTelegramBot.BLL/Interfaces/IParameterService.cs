using BookingTelegramBot.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookingTelegramBot.BLL.Interfaces
{
    interface IParameterService
    {
        Task<IEnumerable<ParameterDTO>> GetAllAsync();
        Task<ParameterDTO> GetParameterByIdAsync(int parameterId);
        void Insert(ParameterDTO parameter);
        void Update(ParameterDTO parameter);
        void Delete(int parameterId);
        Task SaveAsync();
    }
}
