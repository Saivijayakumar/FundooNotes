using FundooNotes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooNotes.Repository.Interface
{
    public interface INoteRepository
    {
        bool CreateNote(NoteModel noteData);
        bool ChangeTitle(int userId, int noteId);
    }
}
