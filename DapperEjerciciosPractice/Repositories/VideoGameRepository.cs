using DapperEjerciciosPractice.Models;
using Microsoft.Data.SqlClient;

namespace DapperEjerciciosPractice.Repositories
{
    public class VideoGameRepository : IVideoGamRepository
    {
        private readonly IConfiguration _configuration;

        public VideoGameRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<List<VideoGame>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
