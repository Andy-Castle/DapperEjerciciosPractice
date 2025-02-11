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

        public Task AddAsync(VideoGame videoGame)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<VideoGame>> GetAllAsync()
        {
            using var connection = GetConnection();

            var videoGame = await connection.QueryAsync<VideoGame>("Select * from VideoGames");

            return videoGame.ToList();
        }

        public async Task<VideoGame> GetByIdAsync(int id)
        {
           using (var connection = GetConnection())
            {
                connection.Open();

                var videoGame = await connection
                    .QueryFirstOrDefaultAsync<VideoGame>("Select * from VideoGames where Id = @Id", new { Id = id });

                return videoGame;
            }
        }

        public Task UpdateAsync(VideoGame videoGame)
        {
            throw new NotImplementedException();
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
