using Microsoft.AspNetCore.Mvc;
using Note_Taking.Abstract;
using Note_Taking.DTOModels;
using System;

namespace Note_Taking.Controllers
{
   
    public class HomeController : Controller
    {
        public INoteData _noteData;

        public HomeController(INoteData noteData)
        {
            _noteData = noteData;
        }

        // Home view
        public IActionResult Index()
        {
            return View();
        }
        
        //Note Create View
        [HttpGet]
        public IActionResult CreateNote()
        {
            return View();
        }

        //Note Create view post method
        [HttpPost]
        public IActionResult CreateNote(NoteDTO obj)
        {
            obj.CreateDate = DateTime.Now;
            obj.UpdateDate = DateTime.Now;
            _noteData.CreateNote(obj);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditNote(int id)
        {
            return View(_noteData.EditNote(id));
        }

        [HttpPost]
        public IActionResult EditNote(NoteDTO obj)
        {
            obj.UpdateDate = DateTime.Now;
            _noteData.Edited(obj);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult NoteList()
        {
            return View(_noteData.NoteList());
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_noteData.EditNote(id));
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteNote(int id)
        {
            _noteData.Delete(id);
            return RedirectToAction("NoteList");
        }

    }
}
