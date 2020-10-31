using System;
namespace API.Models
{
    public class BigAlsPosts
    {
        public int ID{get; set;}
        public string Text{get; set;}
        public string Timestamp{get; set;}
        public override string ToString()
        {
            return ID + " " + Text + " " + Timestamp;
        }
    }
}