using Note_Taking.DTOModels;
using System.Collections.Generic;

namespace Note_Taking.Abstract
{
    public interface INoteData
    {
        void CreateNote(NoteDTO obj);

        List<NoteDTO> NoteList();

        NoteDTO EditNote(int id);

        void Delete(int id);

        void Edited(NoteDTO obj);

    }
}
