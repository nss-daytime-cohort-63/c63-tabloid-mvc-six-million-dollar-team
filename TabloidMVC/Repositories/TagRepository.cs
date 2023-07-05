using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.Extensions.Configuration;
using TabloidMVC.Models;
using Microsoft.Data.SqlClient;
namespace TabloidMVC.Repositories
{
    public class TagRepository : BaseRepository, ITagRepository
    {
        private readonly IConfiguration _config;
        public TagRepository(IConfiguration config) : base(config)
        {
            _config = config;
        }
        public List<Tag> GetAllTags()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT id, name FROM Tag";
                    var reader = cmd.ExecuteReader();
                    var tags = new List<Tag>();
                    while (reader.Read())
                    {
                        tags.Add(new Tag()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name"))
                        });
                    }
                    tags = tags.OrderBy(tag => tag.Name).ToList(); //this line sorts the names
                    return tags;
                }
            }
        }
        public Tag GetTagById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id, [Name]
                        FROM Tag
                        WHERE Id = @id
                    ";
                    cmd.Parameters.AddWithValue("@id", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Tag tag = new Tag()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name"))
                            };

                            return tag;
                        }

                        return null;
                    }
                }
            }
        }
        public void AddTag(Tag tag)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                    INSERT INTO Tag ([Name])
                                    OUTPUT INSERTED.ID
                                    VALUES (@name)";
                    cmd.Parameters.AddWithValue("@name", tag.Name);
                    int id = (int)cmd.ExecuteScalar();
                    tag.Id = id;
                }
            }
        }
        public void DeleteTag(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    DELETE FROM Tag
                    WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void UpdateTag(Tag tag)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    UPDATE Tag
                    SET
                    Name = @name
                    WHERE Id = @id";
                    
                    cmd.Parameters.AddWithValue("@name", tag.Name);
                    cmd.Parameters.AddWithValue("@id", tag.Id);

                    cmd.ExecuteNonQuery();

                }
            }
        }
    }
}