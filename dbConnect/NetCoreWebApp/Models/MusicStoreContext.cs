using MySql.Data.MySqlClient;  
using System;  
using System.Collections.Generic;  
  
namespace NetCoreWebApp.Models  
{  
    public class MusicStoreContext  
    {  
        public string ConnectionString { get; set; }  
  
        public MusicStoreContext(string connectionString)  
        {  
            this.ConnectionString = connectionString;  
        }  
  
        private MySqlConnection GetConnection()  
        {  
            return new MySqlConnection(ConnectionString);  
        }  
  
        public List<Album> GetAllAlbums()  
        {  
            List<Album> list = new List<Album>();  
  
            using (MySqlConnection conn = GetConnection())  
            {  
                conn.Open();  
                MySqlCommand cmd = new MySqlCommand("select * from Album where id < 10", conn);  
  
                using (var reader = cmd.ExecuteReader())  
                {  
                    while (reader.Read())  
                    {  
                        list.Add(new Album()  
                        {  
                            Id = Convert.ToInt32(reader["Id"]),  
                            Name = reader["Name"].ToString(),   
                            ArtistName = reader["ArtistName"].ToString(),  
                            Price = Convert.ToInt32(reader["Price"]),  
                            Genre = reader["genre"].ToString()  
                        });  
                    }  
                }  
            }  
            return list;  
        }

        public Album GetAlbum(int id)
        {
            Album a = new Album();
            using (MySqlConnection conn = GetConnection())  
            {  
                conn.Open();  
                MySqlCommand cmd = new MySqlCommand($"select * from Album where id = {id}", conn);  
  
                using (var reader = cmd.ExecuteReader())  
                {  
                    if (reader.Read())  
                    {
                        a.Id = Convert.ToInt32(reader["Id"]);  
                        a.Name = reader["Name"].ToString(); 
                        a.ArtistName = reader["ArtistName"].ToString();  
                        a.Price = Convert.ToInt32(reader["Price"]);  
                        a.Genre = reader["genre"].ToString();    
                    }  
                }  
            }
            return a;
        }
    }  
}  