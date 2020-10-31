using System;
using System.Collections.Generic;
using API.Models.Interfaces;
using System.Data.SQLite;

namespace API.Models
{
    public class ReadPostData : IGetAllPosts, IGetPost
    {
        public List<BigAlsPosts> GetAllPosts()
        {
            string cs = @"URI = file:C:\Users\birdc\source\repos\pa3-agcrofoot-1\posts.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM BigAlsPosts";;
            using var cmd = new SQLiteCommand(stm, con);

            using SQLiteDataReader rdr = cmd.ExecuteReader();

            List<BigAlsPosts> allPosts = new List<BigAlsPosts>();
            while(rdr.Read())
            {
                allPosts.Add(new BigAlsPosts(){ID = rdr.GetInt32(0), Text = rdr.GetString(1), Timestamp = rdr.GetString(2)});
            }
            return allPosts;
        }

        public BigAlsPosts GetPost(int id)
        {
            string cs = @"URI = file:C:\Users\birdc\source\repos\pa3-agcrofoot-1\posts.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM BigAlsPosts WHERE id = @id";
            using var cmd = new SQLiteCommand(stm,con);
            cmd.Parameters.AddWithValue("@id",id);
            cmd.Prepare();
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            rdr.Read();
            return new BigAlsPosts(){ID = rdr.GetInt32(0), Text = rdr.GetString(1), Timestamp = rdr.GetString(2)};
        }
    }
}