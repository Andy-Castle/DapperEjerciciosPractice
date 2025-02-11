using Dapper;
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

        public async Task<List<VideoGame>> GetAllAsync()
        {
            using var connection = GetConnection();

            var videoGame = await connection.QueryAsync<VideoGame>("Select * fron VideoGames");

            return videoGame.ToList();
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
