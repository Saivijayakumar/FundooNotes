using FundooNotes.Manger.Interface;
using FundooNotes.Repository.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

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

        public bool AddReminder(NoteUpdateModel updatedData)
        {
            try
            {
                return this.repository.AddReminder(updatedData);
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

        public bool ChangeColor(NoteUpdateModel color)
        {
            try
            {
                return this.repository.ChangeColor(color);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

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

        public bool UpdateNote(updateNoteModel updateNoteModel)
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

        public bool AddImage(int noteId, IFormFile image)
        {
            try
            {
                return this.repository.AddImage(noteId,image);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

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
