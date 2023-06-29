using TabloidMVC.Models;
using System.Collections.Generic;

namespace TabloidMVC.Repositories
{
    public interface ITagRepository
    {
        List<Tag> GetAllTags();
        void AddTag(Tag tag);
        void DeleteTag(int id);
        void UpdateTag(Tag tag);
    }
}