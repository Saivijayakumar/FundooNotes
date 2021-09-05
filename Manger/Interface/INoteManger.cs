//-----------------------------------------------------------------------
// <copyright file="INoteManger.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace FundooNotes.Manger.Interface
{
    using System.Collections.Generic;

    /// <summary>
    /// interface class
    /// </summary>
    public interface INoteManger
    {
        /// <summary>
        /// Creating Note
        /// </summary>
        /// <param name="noteData">Total data of note</param>
        /// <returns>true or false</returns>
        bool CreateNote(NoteModel noteData);

        /// <summary>
        /// UnPin the Note
        /// </summary>
        /// <param name="noteId">Note Id</param>
        /// <returns>true or false</returns>
        bool UnPin(int noteId);

        /// <summary>
        /// Pin the Note
        /// </summary>
        /// <param name="noteId">Note Id</param>
        /// <returns>true or false</returns>
        bool Pin(int noteId);

        /// <summary>
        /// Help to add reminder
        /// </summary>
        /// <param name="updatedData">It contain note Id and new data</param>
        /// <returns>true or false</returns>
        bool AddReminder(NoteUpdateModel updatedData);

        /// <summary>
        /// Remove Reminder for Note
        /// </summary>
        /// <param name="noteId">Note Id</param>
        /// <returns>true or false</returns>
        bool RemoveReminder(int noteId);

        /// <summary>
        /// Change color
        /// </summary>
        /// <param name="color">Getting NoteID and Color</param>
        /// <returns>true or false</returns>
        bool ChangeColor(NoteUpdateModel color);

        /// <summary>
        /// Trash The Note
        /// </summary>
        /// <param name="noteId">Note Id</param>
        /// <returns>true or false</returns>
        bool TrashTheNote(int noteId);

        /// <summary>
        /// Restore The Note
        /// </summary>
        /// <param name="noteId">Note Id</param>
        /// <returns>true or false</returns>
        bool RestoreTheNote(int noteId);

        /// <summary>
        /// Un Archive
        /// </summary>
        /// <param name="noteId">Note Id</param>
        /// <returns>true or false</returns>
        bool UnArchieve(int noteId);

        /// <summary>
        /// Archive Note
        /// </summary>
        /// <param name="noteId">Note Id</param>
        /// <returns>true or false</returns>
        bool Archieve(int noteId);

        /// <summary>
        /// Updating Note 
        /// </summary>
        /// <param name="updateNoteModel">Updated Values</param>
        /// <returns>IAction Result</returns>
        bool UpdateNote(updateNoteModel updateNoteModel);

        /// <summary>
        /// Delete permanently
        /// </summary>
        /// <param name="noteId">Note Id</param>
        /// <returns>true or false</returns>
        bool Deletepermanently(int noteId);

        /// <summary>
        /// get notes for particular user
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>true or false</returns>
        List<NoteModel> GetNotes(int userId);

        /// <summary>
        /// get Trash Notes
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>true or false</returns>
        List<NoteModel> GetTrashNotes(int userId);

        /// <summary>
        /// get Archive Notes
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>true or false</returns>
        List<NoteModel> GetArchiveNotes(int userId);

        /// <summary>
        /// get Reminder Notes
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>true or false</returns>
        List<NoteModel> GetReminderNotes(int userId);

        /// <summary>
        /// Deleting all notes in trash
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>true or false</returns>
        bool EmptyTrash(int userId);
    }
}
