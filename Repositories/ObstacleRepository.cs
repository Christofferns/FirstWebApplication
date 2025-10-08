using Dapper;
using FirstWebApplication.Data;
using FirstWebApplication.Models;

namespace FirstWebApplication.Repositories
{
    public class ObstacleRepository
    {
        private readonly DapperContext _context;
        public ObstacleRepository(DapperContext context) => _context = context;

        public async Task<int> CreateAsync(ObstacleData item)
        {
            const string sql = @"
INSERT INTO Obstacles (ObstacleName, ObstacleHeight, ObstacleDescription)
VALUES (@ObstacleName, @ObstacleHeight, @ObstacleDescription);";
            using var conn = _context.CreateConnection();
            return await conn.ExecuteAsync(sql, item); // 1 ved suksess
        }

        public async Task<IEnumerable<ObstacleData>> GetAllAsync()
        {
            const string sql = @"
SELECT Id, ObstacleName, ObstacleHeight, ObstacleDescription
FROM Obstacles
ORDER BY Id DESC;";
            using var conn = _context.CreateConnection();
            return await conn.QueryAsync<ObstacleData>(sql);
        }
    }
}
