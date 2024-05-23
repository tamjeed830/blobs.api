using blobs.api.models;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace blobs.api.Data
{
    public class BlogsRepository
    {
        private readonly IConfiguration _config;
        public BlogsRepository(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        public async Task<IEnumerable<Blogs>> GetAllBlogsAsync()
        {
            using (var conn = Connection)
            {
                string sQuery = "SELECT BlogId, Title, Content, Author, PublishedDate FROM Blogs";
                conn.Open();
                var result = await conn.QueryAsync<Blogs>(sQuery);
                return result;
            }
        }
    }
}
