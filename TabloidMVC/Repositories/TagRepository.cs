using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.Extensions.Configuration;
using TabloidMVC.Models;

namespace TabloidMVC.Repositories
{
    public class TagRepository : BaseRepository, ITagRepository
    {
        
        private readonly IConfiguration _config;
        public TagRepository(IConfiguration config) : base(config) 
        {
            _config = config;
        }

        public void Add(Tag tag) 
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Tag ([Name]) 
                                    OUTPUT INSERTED.ID  
                                    VALUES (@name)";
                    cmd.Parameters.AddWithValue("@name", tag.Name);
                
                    int id = (int)cmd.ExecuteScalar();

                    tag.Id = id;
                }      
            }
        }

        public List<Tag> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT id, name FROM Category";
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
                    tags = tags.OrderBy(tag => tag.Name).ToList();
                    reader.Close();
                    return tags;
                }

            }
        }
    }
 } 
