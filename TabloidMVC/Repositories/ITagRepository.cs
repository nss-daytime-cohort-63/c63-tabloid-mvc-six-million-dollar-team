﻿using System.Collections.Generic;
using TabloidMVC.Models;


namespace TabloidMVC.Repositories
{
    public interface ITagRepository
    {
        List<Tag> GetAll();

        public void Add(Tag tag); 
    }
}
