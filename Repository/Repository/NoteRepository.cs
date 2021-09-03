using EFCore.BulkExtensions;
using FundooNotes.Repository.Context;
using FundooNotes.Repository.Interface;
using System;
using System.Collections.Generic;
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
                if (noteData.Title != null || noteData.Description != null)
                {
                    this.userContext.Note.Add(noteData);
                    this.userContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool UnPin(int noteId)
        {
            try
            {
                var noteData = this.userContext.Note.Where(d => d.NoteId == noteId).FirstOrDefault();
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

        public bool Pin(int noteId)
        {
            try
            {
                var noteData = this.userContext.Note.Where(d =>d.NoteId == noteId).FirstOrDefault();
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

        public bool AddReminder(NoteUpdateModel updatedData)
        {
            try
            {
                var noteData = this.userContext.Note.Where(d =>d.NoteId == updatedData.noteId).FirstOrDefault();
                if (noteData != null)
                {
                    noteData.RemindMe = updatedData.newData;
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

        public bool RemoveReminder(int noteId)
        {
            try
            {
                var noteData = this.userContext.Note.Find(noteId);
                if (noteData != null)
                {
                    noteData.RemindMe = null;
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

        public bool ChangeColor(NoteUpdateModel color)
        {
            try
            {
                var noteData = this.userContext.Note.Find(color.noteId);
                if (noteData != null)
                {
                    noteData.Color = color.newData;
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

        public bool TrashTheNote(int noteId)
        {
            try
            {
                var noteData = this.userContext.Note.Find(noteId);
                if(noteData != null)
                {
                    noteData.Trash = true;
                    this.userContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool RestoreTheNote(int noteId)
        {
            try
            {
                var noteData = this.userContext.Note.Find(noteId);
                if (noteData != null)
                {
                    noteData.Trash = false;
                    this.userContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool UnArchieve(int noteId)
        {
            try
            {
                var noteData = this.userContext.Note.Find(noteId);
                if (noteData != null)
                {
                    noteData.Archieve = false;
                    this.userContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Archieve(int noteId)
        {
            try
            {
                var noteData = this.userContext.Note.Find(noteId);
                if (noteData != null)
                {
                    noteData.Archieve = true;
                    noteData.Pin = false;
                    this.userContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool UpdateNote(int noteId, string titleData, string descriptionData)
        {
            try
            {
                var noteData = this.userContext.Note.Find(noteId);
                if (noteData != null)
                {
                    noteData.Title = titleData;                    
                    noteData.Description = descriptionData;
                    this.userContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch(ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Deletepermanently(int noteId)
        {
            try
            {
                var noteData = this.userContext.Note.Where(x => x.NoteId == noteId && x.Trash == true).FirstOrDefault();
                if (noteData != null)
                {
                    this.userContext.Remove(noteData);
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

        public List<NoteModel> GetNotes(int userId)
        {
            try
            {
                var noteData = this.userContext.Note.Where(x => x.UserId == userId && x.Archieve == false && x.Trash == false).ToList();
                if (noteData.Count > 0)
                {
                    return noteData;
                }
                return null;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<NoteModel> GetTrashNotes(int userId)
        {
            try
            {
                var noteData = this.userContext.Note.Where(x => x.UserId == userId && x.Archieve == false && x.Trash == true).ToList();
                if (noteData.Count > 0)
                {
                    return noteData;
                }
                return null;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<NoteModel> GetArchiveNotes(int userId)
        {
            try
            {
                var noteData = this.userContext.Note.Where(x => x.UserId == userId && x.Archieve == true && x.Trash == false).ToList();
                if (noteData.Count > 0)
                {
                    return noteData;
                }
                return null;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<NoteModel> GetReminderNotes(int userId)
        {
            try
            {
                var noteData = this.userContext.Note.Where(x => x.UserId == userId && x.RemindMe != null && x.Trash == false).ToList();
                if (noteData.Count > 0)
                {
                    return noteData;
                }
                return null;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool EmptyTrash(int userId)
        {
            try
            {
                var noteData = this.userContext.Note.Where(x => x.UserId == userId).ToList();
                if (noteData.Count > 0)
                {
                    this.userContext.BulkDelete(noteData);
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
