using Note_Taking.Abstract;
using Note_Taking.DTOModels;
using Note_Taking.Models;
using System.Collections.Generic;
using System.Linq;

namespace Note_Taking.Concrete
{
    public class NoteData : INoteData
    {
        private readonly NoteDbContext _db;
        public NoteData(NoteDbContext db)
        {
            _db = db;
        }

        public void CreateNote(NoteDTO obj)
        {
            Note CreateNote = new Note();

            CreateNote.Title = obj.Title;
            CreateNote.Body = obj.Body;
            CreateNote.CreateDate = obj.CreateDate;
            CreateNote.UpdateDate = obj.UpdateDate;

            _db.Entry(CreateNote).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _db.SaveChanges();
            
        }


        public NoteDTO EditNote(int id)
        {
            Note EditNote = _db.Notes.Where(x => x.NoteId == id).FirstOrDefault();
            NoteDTO EditNoteDTO = new NoteDTO();

            EditNoteDTO.NoteId = EditNote.NoteId;
            EditNoteDTO.Title = EditNote.Title;
            EditNoteDTO.Body = EditNote.Body;
            EditNoteDTO.UpdateDate = EditNote.UpdateDate;
            EditNoteDTO.CreateDate = EditNote.CreateDate;
            return EditNoteDTO;
        }

        public void Edited(NoteDTO obj)
        {
            Note EditNote = _db.Notes.Where(x => x.NoteId == obj.NoteId).FirstOrDefault();
            
            EditNote.Title = obj.Title;
            EditNote.Body = obj.Body;
            EditNote.UpdateDate = obj.UpdateDate;

            _db.Entry(EditNote).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
        }

        public List<NoteDTO> NoteList()
        {
            List<NoteDTO> ListDTO = new List<NoteDTO>();
            var List = _db.Notes.ToList();

            foreach (var item in List)
            {
                NoteDTO obj = new NoteDTO();
                obj.NoteId = item.NoteId;
                obj.Title = item.Title;
                obj.Body = item.Body;
                obj.CreateDate = item.CreateDate;
                obj.UpdateDate = item.UpdateDate;

                ListDTO.Add(obj);

            }

            return ListDTO;
        }

        public void Delete(int id)
        {
            Note DeleteNote = _db.Notes.Where(x => x.NoteId == id).FirstOrDefault();
            _db.Entry(DeleteNote).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _db.SaveChanges();
        }
    }
}
