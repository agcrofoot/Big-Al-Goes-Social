using System;
using System.Data.SQLite;
using API.Models.Interfaces;

namespace API.Models
{
    public class SavePost : IInsertPost, IDeletePost, IEditPost
    {
        public void InsertPost(BigAlsPosts value)
        {
            string cs = @"URI = file:C:\Users\birdc\source\repos\pa3-agcrofoot-1\posts.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            using var cmd = new SQLiteCommand(con);


            cmd.CommandText = @"INSERT INTO BigAlsPosts(text, timestamp) VALUES(@text, @timestamp)";
            cmd.Parameters.AddWithValue("@text", value.Text);
            cmd.Parameters.AddWithValue("@timestamp", DateTime.Now.ToString());
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        public void DeletePost(int id)
        {
            string cs = @"URI = file:C:\Users\birdc\source\repos\pa3-agcrofoot-1\posts.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            using var cmd = new SQLiteCommand(con);

            cmd.CommandText = @"DELETE FROM BigAlsPosts WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        public void EditPost(int id, BigAlsPosts value)
        {
            string cs = @"URI = file:C:\Users\birdc\source\repos\pa3-agcrofoot-1\posts.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            using var cmd = new SQLiteCommand(con);

            cmd.CommandText = @"UPDATE BigAlsPosts SET text = @text WHERE id = @id";
            cmd.Parameters.AddWithValue("@text", value.Text);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();
            cmd.ExecuteNonQuery();

        }
    }
}