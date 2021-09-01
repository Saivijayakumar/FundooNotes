using FundooNotes;
using FundooNotes.Repository.Context;
using FundooNotes.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public bool ChangeTitle(int userId, int noteId)
        {
            try
            {
                var noteData = this.userContext.Note.Where(d => d.UserId == userId && d.NoteId == noteId).FirstOrDefault();
                if (noteData != null)
                {
                    noteData.Title = "now it changed";
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
