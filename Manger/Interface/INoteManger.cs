using System.Collections.Generic;

namespace FundooNotes.Manger.Interface
{
    public interface INoteManger
    {
        bool CreateNote(NoteModel noteData);
        bool UnPin(int noteId);
        bool Pin(int noteId);
        bool AddReminder(NoteUpdateModel updatedData);
        bool RemoveReminder(int noteId);
        bool ChangeColor(NoteUpdateModel color);
        bool TrashTheNote(int noteId);
        bool RestoreTheNote(int noteId);
        bool UnArchieve(int noteId);
        bool Archieve(int noteId);
        bool UpdateNote(int noteId, string titleData, string descriptionData);
        bool Deletepermanently(int noteId);
        List<NoteModel> GetNotes(int userId);
        List<NoteModel> GetTrashNotes(int userId);
        List<NoteModel> GetArchiveNotes(int userId);
        List<NoteModel> GetReminderNotes(int userId);
        bool EmptyTrash(int userId);
    }
}
