using FundooNotes.Repository.Context;
using FundooNotes.Repository.Interface;
using System;
using System.Linq;

namespace FundooNotes.Repository.Repository
{
    public class NoteRepository : INoteRepository
    {
        /// <summary>
        /// Object for UserContext
        /// </summary>
        private readonly UserContext userContext;

        public NoteRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }

        /// <summary>
        /// Created a note 
        /// </summary>
        /// <param name="noteData">Data about note</param>
        /// <returns>true or false</returns>
        public bool CreateNote(NoteModel noteData)
        {
            try
            {
                if (noteData != null)
                {
                    this.userContext.Note.Add(noteData);
                    this.userContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ChangeTitle(int userId, int noteId, string updatedData)
        {
            try
            {
                var noteData = this.userContext.Note.Where(d => d.UserId == userId && d.NoteId == noteId).FirstOrDefault();
                if (noteData != null)
                {
                    noteData.Title = updatedData;
                    this.userContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ChangeDescription(int userId, int noteId, string updatedData)
        {
            try
            {
                var noteData = this.userContext.Note.Where(d => d.UserId == userId && d.NoteId == noteId).FirstOrDefault();
                if (noteData != null)
                {
                    noteData.Description = updatedData;
                    this.userContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool UnPin(int userId, int noteId)
        {
            try
            {
                var noteData = this.userContext.Note.Where(d => d.UserId == userId && d.NoteId == noteId).FirstOrDefault();
                if (noteData != null)
                {
                    noteData.Pin = false;
                    this.userContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Pin(int userId, int noteId)
        {
            try
            {
                var noteData = this.userContext.Note.Where(d => d.UserId == userId && d.NoteId == noteId).FirstOrDefault();
                if (noteData != null)
                {
                    noteData.Pin = true;
                    this.userContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool AddReminder(int userId, int noteId, string updatedData)
        {
            try
            {
                var noteData = this.userContext.Note.Where(d => d.UserId == userId && d.NoteId == noteId).FirstOrDefault();
                if (noteData != null)
                {
                    noteData.RemindMe = updatedData;
                    this.userContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool RemoveReminder(int userId, int noteId)
        {
            try
            {
                var noteData = this.userContext.Note.Where(d => d.UserId == userId && d.NoteId == noteId).FirstOrDefault();
                if (noteData != null)
                {
                    noteData.RemindMe = "No Reminder";
                    this.userContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
