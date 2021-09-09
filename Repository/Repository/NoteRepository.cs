//-----------------------------------------------------------------------
// <copyright file="NoteRepository.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace FundooNotes.Repository.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using EFCore.BulkExtensions;
    using FundooNotes.Repository.Context;
    using FundooNotes.Repository.Interface;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// NoteRepository class
    /// </summary>
    public class NoteRepository : INoteRepository
    {
        /// <summary>
        /// Object for UserContext
        /// </summary>
        private readonly UserContext userContext;

        /// <summary>
        /// this object is used to access the data of cloudinary
        /// </summary>
        private readonly IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="NoteRepository" /> class
        /// </summary>
        /// <param name="userContext">Initialize object for userContext</param>
        /// <param name="configuration">Initialize object for configuration</param>
        public NoteRepository(UserContext userContext, IConfiguration configuration)
        {
            this.userContext = userContext;
            this.configuration = configuration;
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

        /// <summary>
        /// Pin the Note
        /// </summary>
        /// <param name="noteId">Note Id</param>
        /// <returns>true or false</returns>
        public bool Pin(int noteId)
        {
            try
            {
                var noteData = this.userContext.Note.Where(d => d.NoteId == noteId).FirstOrDefault();
                if (noteData != null)
                {
                    noteData.Pin = true;
                    noteData.Archieve = false;
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

        /// <summary>
        /// Help to add reminder
        /// </summary>
        /// <param name="updatedData">It contain note Id and new data</param>
        /// <returns>true or false</returns>
        public bool AddReminder(NoteModel updateReminder)
        {
            try
            {
                var noteData = this.userContext.Note.Where(d => d.NoteId == updateReminder.NoteId).FirstOrDefault();
                if (noteData != null)
                {
                    noteData.RemindMe = updateReminder.RemindMe;
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

        /// <summary>
        /// Remove Reminder for Note
        /// </summary>
        /// <param name="noteId">Note Id</param>
        /// <returns>true or false</returns>
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

        /// <summary>
        /// Change color
        /// </summary>
        /// <param name="color">Getting NoteID and Color</param>
        /// <returns>true or false</returns>
        public bool ChangeColor(NoteModel UpdateColor)
        {
            try
            {
                var noteData = this.userContext.Note.Find(UpdateColor.NoteId);
                if (noteData != null)
                {
                    noteData.Color = UpdateColor.Color;
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

        /// <summary>
        /// Trash The Note
        /// </summary>
        /// <param name="noteId">Note Id</param>
        /// <returns>true or false</returns>
        public bool TrashTheNote(int noteId)
        {
            try
            {
                var noteData = this.userContext.Note.Find(noteId);
                if (noteData != null)
                {
                    noteData.Trash = true;
                    noteData.RemindMe = null;
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

        /// <summary>
        /// Restore The Note
        /// </summary>
        /// <param name="noteId">Note Id</param>
        /// <returns>true or false</returns>
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

        /// <summary>
        /// Un Archive
        /// </summary>
        /// <param name="noteId">Note Id</param>
        /// <returns>true or false</returns>
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

        /// <summary>
        /// Archive Note
        /// </summary>
        /// <param name="noteId">Note Id</param>
        /// <returns>true or false</returns>
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

        /// <summary>
        /// Updating Note 
        /// </summary>
        /// <param name="updateNoteModel">Updated Values</param>
        /// <returns>IAction Result</returns>
        public bool UpdateNote(NoteModel updateNoteModel)
        {
            try
            {
                var noteData = this.userContext.Note.Find(updateNoteModel.NoteId);
                if (noteData != null)
                {
                    noteData.Title = updateNoteModel.Title;                    
                    noteData.Description = updateNoteModel.Description;
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

        /// <summary>
        /// Delete permanently
        /// </summary>
        /// <param name="noteId">Note Id</param>
        /// <returns>true or false</returns>
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

        /// <summary>
        /// get notes for particular user
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>true or false</returns>
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

        /// <summary>
        /// get Trash Notes
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>true or false</returns>
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

        /// <summary>
        /// get Archive Notes
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>true or false</returns>
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

        /// <summary>
        /// get Reminder Notes
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>true or false</returns>
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

        /// <summary>
        /// Deleting all notes in trash
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>true or false</returns>
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
                var noteData = this.userContext.Note.Find(noteId);
                if (noteData != null)
                {
                    Account account = new Account(this.configuration["CloudinaryAccount:CloudName"], this.configuration["CloudinaryAccount:ApiKey"], this.configuration["CloudinaryAccount:ApiSecret"]);
                    Cloudinary cloudinary = new Cloudinary(account);
                    ImageUploadParams uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(image.FileName, image.OpenReadStream())
                    };
                    var uploadResult = cloudinary.Upload(uploadParams);
                    noteData.Image = uploadResult.Url.ToString();
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

        /// <summary>
        /// Remove Image for Note
        /// </summary>
        /// <param name="noteId">Note Id</param>
        /// <returns>true or false</returns>
        public bool RemoveImage(int noteId)
        {
            try
            {
                var noteData = this.userContext.Note.Find(noteId);
                if (noteData != null)
                {
                    noteData.Image = null;
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
    }
}
