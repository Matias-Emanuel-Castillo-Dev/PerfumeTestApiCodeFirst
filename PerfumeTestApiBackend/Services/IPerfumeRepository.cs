using PerfumeTestApiBackend.Models.DTOs;

namespace PerfumeTestApiBackend.Services
{
    public interface IPerfumeRepository
    {
        Task<IEnumerable<PerfumeDTO?>> GetAllAsync();
        Task<PerfumeDTO?> GetByIdAsync(int id);

    }
}
