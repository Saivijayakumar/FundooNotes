//-----------------------------------------------------------------------
// <copyright file="NoteManger.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace FundooNotes.Manger.Manger
{
    using System;
    using System.Collections.Generic;
    using FundooNotes.Manger.Interface;
    using FundooNotes.Repository.Interface;
    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// NoteManger class
    /// </summary>
    public class NoteManger : INoteManger
    {
        /// <summary>
        /// INoteRepository object Initialize
        /// </summary>
        private readonly INoteRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="NoteManger" /> class
        /// </summary>
        /// <param name="repository">object name</param>
        public NoteManger(INoteRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Creating Note
        /// </summary>
        /// <param name="noteData">Total data of note</param>
        /// <returns>true or false</returns>
        public bool CreateNote(NoteModel noteData)
        {
            try
            {
                return this.repository.CreateNote(noteData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// UnPin the Note
        /// </summary>
        /// <param name="noteId">Note Id</param>
        /// <returns>true or false</returns>
        public bool UnPin(int noteId)
        {
            try
            {
                return this.repository.UnPin(noteId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Pin the Note
        /// </summary>
        /// <param name="noteId">Note Id</param>
        /// <returns>true or false</returns>
        public bool Pin(int noteId)
        {
            try
            {
                return this.repository.Pin(noteId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Help to add reminder
        /// </summary>
        /// <param name="updateReminder">It contain note Id and new data</param>
        /// <returns>true or false</returns>
        public bool AddReminder(NoteModel updateReminder)
        {
            try
            {
                return this.repository.AddReminder(updateReminder);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Remove Reminder for Note
        /// </summary>
        /// <param name="noteId">Note Id</param>
        /// <returns>true or false</returns>
        public bool RemoveReminder(int noteId)
        {
            try
            {
                return this.repository.RemoveReminder(noteId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Change color
        /// </summary>
        /// <param name="UpdateColor">Getting NoteID and Color</param>
        /// <returns>true or false</returns>
        public bool ChangeColor(NoteModel updateColor)
        {
            try
            {
                return this.repository.ChangeColor(updateColor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Trash The Note
        /// </summary>
        /// <param name="noteId">Note Id</param>
        /// <returns>true or false</returns>
        public bool TrashTheNote(int noteId)
        {
            try
            {
                return this.repository.TrashTheNote(noteId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Restore The Note
        /// </summary>
        /// <param name="noteId">Note Id</param>
        /// <returns>true or false</returns>
        public bool RestoreTheNote(int noteId)
        {
            try
            {
                return this.repository.RestoreTheNote(noteId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Un Archive
        /// </summary>
        /// <param name="noteId">Note Id</param>
        /// <returns>true or false</returns>
        public bool UnArchieve(int noteId)
        {
            try
            {
                return this.repository.UnArchieve(noteId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Archive Note
        /// </summary>
        /// <param name="noteId">Note Id</param>
        /// <returns>true or false</returns>
        public bool Archieve(int noteId)
        {
            try
            {
                return this.repository.Archieve(noteId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Updating Note 
        /// </summary>
        /// <param name="updateNoteModel">Updated Values</param>
        /// <returns>IAction Result</returns>
        public bool UpdateNote(NoteModel updateNoteModel)
        {
            try
            {
                return this.repository.UpdateNote(updateNoteModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Delete permanently
        /// </summary>
        /// <param name="noteId">Note Id</param>
        /// <returns>true or false</returns>
        public bool Deletepermanently(int noteId)
        {
            try
            {
                return this.repository.Deletepermanently(noteId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// get notes for particular user
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>true or false</returns>
        public List<NoteModel> GetNotes(int userId)
        {
            try
            {
                return this.repository.GetNotes(userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// get Trash Notes
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>true or false</returns>
        public List<NoteModel> GetTrashNotes(int userId)
        {
            try
            {
                return this.repository.GetTrashNotes(userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// get Archive Notes
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>true or false</returns>
        public List<NoteModel> GetArchiveNotes(int userId)
        {
            try
            {
                return this.repository.GetArchiveNotes(userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// get Reminder Notes
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>true or false</returns>
        public List<NoteModel> GetReminderNotes(int userId)
        {
            try
            {
                return this.repository.GetReminderNotes(userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Deleting all notes in trash
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>true or false</returns>
        public bool EmptyTrash(int userId)
        {
            try
            {
                return this.repository.EmptyTrash(userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Adding Image to note
        /// </summary>
        /// <param name="noteId">Note Id</param>
        /// <param name="image">Image path</param>
        /// <returns>true or false</returns>
        public bool AddImage(int noteId, IFormFile image)
        {
            try
            {
                return this.repository.AddImage(noteId, image);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Remove Image for Note
        /// </summary>
        /// <param name="noteId">Note Id</param>
        /// <returns>true or false</returns>
        public bool RemoveImage(int noteId)
        {
            try
            {
                return this.repository.RemoveImage(noteId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
