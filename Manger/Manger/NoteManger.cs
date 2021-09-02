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
        public bool UnPin(int userId, int noteId)
        {
            try
            {
                return this.repository.UnPin(userId, noteId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Pin(int userId, int noteId)
        {
            try
            {
                return this.repository.Pin(userId, noteId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool AddReminder(int userId, int noteId, string updatedData)
        {
            try
            {
                return this.repository.AddReminder(userId, noteId, updatedData);
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
    }
}
