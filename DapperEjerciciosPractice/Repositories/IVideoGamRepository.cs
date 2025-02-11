using DapperEjerciciosPractice.Models;

namespace DapperEjerciciosPractice.Repositories
{
    public interface IVideoGamRepository
    {
        Task<List<VideoGame>> GetAllAsync();
    }
}
