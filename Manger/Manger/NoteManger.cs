using FundooNotes;
using FundooNotes.Manger.Interface;
using FundooNotes.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooNotes.Manger.Manger
{
    public class NoteManger : INoteManger
    {
        private readonly INoteRepository repository;
        public NoteManger(INoteRepository repository)
        {
            this.repository = repository;
        }

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
        
        public bool ChangeTitle(int userId, int noteId, string updatedData)
        {
            try
            {
                return this.repository.ChangeTitle(userId,noteId, updatedData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ChangeDescription(int userId, int noteId, string updatedData)
        {
            try
            {
                return this.repository.ChangeDescription(userId, noteId, updatedData);
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
                return this.repository.UnPin(noteId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

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

        public bool AddReminder(int noteId, string updatedData)
        {
            try
            {
                return this.repository.AddReminder(noteId, updatedData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

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

        public bool ChangeColor(int noteId, string color)
        {
            try
            {
                return this.repository.ChangeColor(noteId, color);
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
                return this.repository.Archieve(noteId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Delete(int noteId)
        {
            try
            {
                return this.repository.Delete(noteId);
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
                return this.repository.UpdateNote(noteId,titleData,descriptionData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

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
    }
}
