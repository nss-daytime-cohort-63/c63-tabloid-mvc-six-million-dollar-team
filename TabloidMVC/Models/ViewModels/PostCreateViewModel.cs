using System.Collections.Generic;

namespace TabloidMVC.Models.ViewModels
{
    public class PostCreateViewModel
    {
        public Post Post { get; set; }
        public Category Category { get; set; }
        public List<Category> CategoryOptions { get; set; }
        
    }
}
