using FundooNotes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooNotes.Manger.Interface
{
    public interface INoteManger
    {
        bool CreateNote(NoteModel noteData);
        bool ChangeTitle(int userId, int noteId, string updatedData);
        bool ChangeDescription(int userId, int noteId, string updatedData);
        bool UnPin(int userId, int noteId);
        bool Pin(int userId, int noteId);
        bool AddReminder(int userId, int noteId, string updatedData);
        bool RemoveReminder(int noteId);

    }
}
