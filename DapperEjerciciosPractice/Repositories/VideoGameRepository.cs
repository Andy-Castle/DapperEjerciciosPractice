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

        public async Task AddAsync(VideoGame videoGame)
        {
            using var connection = GetConnection();

            var query = "Insert into VideoGames (Title, Publisher, Developer, Platform, ReleaseDate) values (@Title, @Publisher, @Developer, @Platform, @ReleaseDate); SELECT CAST(SCOPE_IDENTITY() AS  int);" ;

            int newId = await connection.QuerySingleAsync<int>(query, videoGame);

            videoGame.Id = newId;
           
        }

        public async Task DeleteAsync(int id)
        {
            using var connection = GetConnection();

            await connection.ExecuteAsync("Delete from VideoGames where Id = @Id", new { Id = id });
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

        public async Task UpdateAsync(VideoGame videoGame)
        {
            using var connection = GetConnection();

            await connection
                .ExecuteAsync("Update VideoGames set Title = @Title, Publisher = @Publisher, Developer = @Developer, Platform = @Platform, ReleaseDate = @ReleaseDate where Id = @Id", videoGame);
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
