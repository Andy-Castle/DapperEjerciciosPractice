using DapperEjerciciosPractice.Models;

namespace DapperEjerciciosPractice.Repositories
{
    public interface IVideoGamRepository
    {
        Task<List<VideoGame>> GetAllAsync();

        Task<VideoGame> GetByIdAsync(int id);

        Task AddAsync(VideoGame videoGame);

        Task UpdateAsync(VideoGame videoGame);

        Task DeleteAsync(int id);
    }
}
