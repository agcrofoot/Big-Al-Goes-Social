using System.Collections.Generic;

namespace API.Models.Interfaces
{
    public interface IReadAllPosts
    {
        public List<Posts> GetPosts();
    }
}