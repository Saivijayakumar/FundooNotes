using System.Collections.Generic;

namespace FundooNotes.Manger.Interface
{
    public interface INoteManger
    {
        bool CreateNote(NoteModel noteData);
        bool ChangeTitle(int userId, int noteId, string updatedData);
        bool ChangeDescription(int userId, int noteId, string updatedData);
        bool UnPin(int noteId);
        bool Pin(int noteId);
        bool AddReminder(int noteId, string updatedData);
        bool RemoveReminder(int noteId);
        bool ChangeColor(int noteId, string color);
        bool Archieve(int noteId);
        bool Delete(int noteId);
        bool UpdateNote(int noteId, string titleData, string descriptionData);
        bool Deletepermanently(int noteId);
        List<NoteModel> GetNotes(int userId);
        List<NoteModel> GetTrashNotes(int userId);
        List<NoteModel> GetArchiveNotes(int userId);
        List<NoteModel> GetReminderNotes(int userId);
    }
}
