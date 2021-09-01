using FundooNotes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooNotes.Manger.Interface
{
    public interface INoteManger
    {
        bool CreateNote(NoteModel noteData);
        bool ChangeTitle(int userId, int noteId);

    }
}
