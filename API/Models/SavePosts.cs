using System;
using System.Data.SQLite;
using API.Models.Interfaces;

namespace API.Models
{
    public class SavePosts : ISavePosts
    {
        public void SavePost(Posts BigAlsPosts)
        {
            string cs = @"URI = file:C:\Users\birdc\source\repos\pa4-agcrofoot-1\posts.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            using var cmd = new SQLiteCommand(con);

            cmd.CommandText = @"INSERT INTO BigAlsPosts(id, text, timestamp) VALUES(@id, @text, @timestamp)";
            cmd.Parameters.AddWithValue("@id", BigAlsPosts.ID);
            cmd.Parameters.AddWithValue("@text", BigAlsPosts.Text);
            cmd.Parameters.AddWithValue("@timestamp", BigAlsPosts.Timestamp);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}