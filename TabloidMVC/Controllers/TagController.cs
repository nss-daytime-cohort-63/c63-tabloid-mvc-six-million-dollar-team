using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TabloidMVC.Models;
using TabloidMVC.Repositories;
using System;


namespace TabloidMVC.Controllers
{
    [Authorize]
    public class TagController : Controller
    {
        private readonly ITagRepository _tagRepository;
        private readonly IPostRepository _postRepository;
        


        public TagController(ITagRepository tagRepository,)
        {
           

        // GET: Tags
        public ActionResult Index()
        {
            List<Tag> tags = _tagRepository.GetAllTags();
            
            return View(tags);  
        }

   

        // GET: Tags/Create
        public ActionResult Create()
        {

        
           
                return View();
           
        }

        // POST: Tags/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
         public ActionResult Create()
        {
            try
            {
                _tagRepository.AddTag(tag);
            }
            catch
            {
                
            }
        }

        // GET: Tags/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Tags/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Tags/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Tags/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
