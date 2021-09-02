//-----------------------------------------------------------------------
// <copyright file="NoteController.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace FundooNotes.Controllers
{
    using System;
    using System.Collections.Generic;
    using FundooNotes.Manger.Interface;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Note controller class
    /// </summary>
    public class NoteController : ControllerBase
    {
        /// <summary>
        /// object for INoteManger
        /// </summary>
        private readonly INoteManger noteManger;

        /// <summary>
        /// Initializes a new instance of the <see cref="NoteController" /> class
        /// </summary>
        /// <param name="noteManger">object name</param>
        public NoteController(INoteManger noteManger)
        {
            this.noteManger = noteManger;
        }

        /// <summary>
        /// Creating Note
        /// </summary>
        /// <param name="noteData">Total data of note</param>
        /// <returns>IAction Result</returns>
        [HttpPost]
        [Route("api/CreateNote")]
        public IActionResult CreateNote([FromBody] NoteModel noteData)
        {
            try
            {
                bool result = this.noteManger.CreateNote(noteData);
                if (result == true)
                {
                    return this.Ok(new { Status = true, Message = "New Note called '" + noteData.Title + "' is Add Successfull" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Note added Unsuccessfull you have to give either title or description" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Changing title of Note
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="noteId">Note Id</param>
        /// <returns>IAction Result</returns>
        [HttpPut]
        [Route("api/ChangeTitle")]
        public IActionResult ChangeTitle(int userId, int noteId, string updatedData)
        {
            try
            {
                bool result = this.noteManger.ChangeTitle(userId, noteId, updatedData);
                if (result == true)
                {
                    return this.Ok(new { Status = true, Result = "Title changed Successfull For note ID " + noteId });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Result = "Title changed Unsuccessfull ''check the trash is false or true'' For note ID " + noteId });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Changing Description  of Note
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="noteId">Note Id</param>
        /// <returns>IAction Result</returns>
        [HttpPut]
        [Route("api/ChangeDescription")]
        public IActionResult ChangeDescription(int userId, int noteId, string updatedData)
        {
            try
            {
                bool result = this.noteManger.ChangeDescription(userId, noteId, updatedData);
                if (result == true)
                {
                    return this.Ok(new { Status = true, Result = "Description changed Successfull For note ID " + noteId });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Result = "Description changed Unsuccessfull ''check the trash is false or true'' For note ID " + noteId });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// UnPin the Note
        /// </summary>
        /// <param name="noteId">Note Id</param>
        /// <returns>IAction Result</returns>
        [HttpPut]
        [Route("api/UnPin")]
        public IActionResult UnPin(int noteId)
        {
            try
            {
                bool result = this.noteManger.UnPin(noteId);
                if (result == true)
                {
                    return this.Ok(new { Status = true, Result = "UnPin Successfull For note ID " + noteId });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Result = "UnPin Unsuccessfull ''check the trash is false or true'' For note ID " + noteId });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Pin the Note
        /// </summary>
        /// <param name="noteId">Note Id</param>
        /// <returns>IAction Result</returns>
        [HttpPut]
        [Route("api/Pin")]
        public IActionResult Pin(int noteId)
        {
            try
            {
                bool result = this.noteManger.Pin(noteId);
                if (result == true)
                {
                    return this.Ok(new { Status = true, Result = "Pin Successfull For note ID " + noteId });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Result = "Pin Unsuccessfull ''check the trash is false or true'' For note ID " + noteId });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Added Reminder
        /// </summary>
        /// <param name="noteId">note id</param>
        /// <param name="dataChanged">Updated data</param>
        /// <returns>Iaction result</returns>
        [HttpPut]
        [Route("api/AddReminder")]
        public IActionResult AddReminder(int noteId, string updatedData)
        {
            try
            {
                bool result = this.noteManger.AddReminder(noteId, updatedData);
                if (result == true)
                {
                    return this.Ok(new { Status = true, Result = "Remind added Successfull For note ID " + noteId });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Result = "Remind added Unsuccessfull ''check the trash is false or true'' For note ID " + noteId });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Remove Reminder for Note
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="noteId">Note Id</param>
        /// <returns>IAction Result</returns>
        [HttpPut]
        [Route("api/RemoveReminder")]
        public IActionResult RemoveReminder(int noteId)
        {
            try
            {
                bool result = this.noteManger.RemoveReminder(noteId);
                if (result == true)
                {
                    return this.Ok(new { Status = true, Result = "Reminder Removed Successfull For note ID " + noteId });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Result = "Reminder Removed Unsuccessfull For note ID " + noteId });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// method for Color change
        /// </summary>
        /// <param name="noteId">note id</param>
        /// <param name="color">updated color</param>
        /// <returns>Iaction result</returns>
        [HttpPut]
        [Route("api/color")]
        public IActionResult ChangeColor(int noteId, string color)
        {
            try
            {
                bool result = this.noteManger.ChangeColor(noteId, color);
                if (result == true)
                {
                    return this.Ok(new { Status = true, Result = "Color changed Successfull For note ID " + noteId });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Result = "Color changed Unsuccessfull ''check the trash is false or true'' For note ID " + noteId });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Add and remove Archive
        /// </summary>
        /// <param name="noteId">Note Id</param>
        /// <returns>IAction Result</returns>
        [HttpPut]
        [Route("api/Archive")]
        public IActionResult Archieve(int noteId)
        {
            try
            {
                bool result = this.noteManger.Archieve(noteId);
                if (result == true)
                {
                    return this.Ok(new { Status = true, Result = "Archieve updated Successfull For note ID " + noteId });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Result = "Archieve updated Unsuccessfull ''check the trash is false or true'' For note ID " + noteId });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Delete and restore
        /// </summary>
        /// <param name="noteId">Note Id</param>
        /// <returns>IAction Result</returns>
        [HttpPut]
        [Route("api/Delete And Restore")]
        public IActionResult Delete(int noteId)
        {
            try
            {
                bool result = this.noteManger.Delete(noteId);
                if (result == true)
                {
                    return this.Ok(new { Status = true, Result = "Trash coloum updated Successfull For note ID " + noteId });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Result = "Trash coloum updated Unsuccessfull ''check the trash is false or true'' For note ID " + noteId });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/Update")]
        public IActionResult UpdateNote(int noteId,string titleData,string descriptionData)
        {
            try
            {
                bool result = this.noteManger.UpdateNote(noteId,titleData,descriptionData);
                if (result == true)
                {
                    return this.Ok(new { Status = true, Result = "Data Updated Successfull For note ID " + noteId });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Result = "Data Updated Unsuccessfull ''check the trash is false or true'' For note ID " + noteId });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Delete permanently
        /// </summary>
        /// <param name="noteId">Note Id</param>
        /// <returns>IAction Result</returns>
        [HttpDelete]
        [Route("api/Delete permanently")]
        public IActionResult Deletepermanently(int noteId)
        {
            try
            {
                bool result = this.noteManger.Deletepermanently(noteId);
                if (result == true)
                {
                    return this.Ok(new { Status = true, Result = "Delete of Note permanently is Successfull For note ID " + noteId });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Result = "Delete of Note permanently is Unsuccessfull ''check the trash is false or true'' For note ID " + noteId });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// get notes for perticular user
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>IAction Result</returns>
        [HttpPost]
        [Route("api/GetNotes")]
        public IActionResult GetNotes(int userId)
        {
            try
            {
                List<NoteModel> notes = this.noteManger.GetNotes(userId);
                if (notes != null)
                {
                    return this.Ok(new ResponseModel<List<NoteModel>>() { Status = true, Message = "Geting notes Successfull ", Data = notes });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Geting notes UnSuccessfull May be you don't have any notes" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// get Trash Notes
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>IAction Result</returns>
        [HttpPost]
        [Route("api/GetTrashNotes")]
        public IActionResult GetTrashNotes(int userId)
        {
            try
            {
                List<NoteModel> notes = this.noteManger.GetTrashNotes(userId);
                if (notes != null)
                {
                    return this.Ok(new ResponseModel<List<NoteModel>>() { Status = true, Message = "Geting Trash notes Successfull ", Data = notes });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Geting Trash notes UnSuccessfull May be you don't have any notes" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
        /// <summary>
        /// get Archive Notes
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>IAction Result</returns>
        [HttpPost]
        [Route("api/Get Archive Notes")]
        public IActionResult GetArchiveNotes(int userId)
        {
            try
            {
                List<NoteModel> notes = this.noteManger.GetArchiveNotes(userId);
                if (notes != null)
                {
                    return this.Ok(new ResponseModel<List<NoteModel>>() { Status = true, Message = "Geting Archive notes Successfull ", Data = notes });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Geting Archive notes UnSuccessfull May be you don't have any notes or ''check the trash is false or true''" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// get Reminder Notes
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>IAction Result</returns>
        [HttpPost]
        [Route("api/Get Reminder Notes")]
        public IActionResult GetReminderNotes(int userId)
        {
            try
            {
                List<NoteModel> notes = this.noteManger.GetReminderNotes(userId);
                if (notes != null)
                {
                    return this.Ok(new ResponseModel<List<NoteModel>>() { Status = true, Message = "Geting Reminder notes Successfull ", Data = notes });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Geting Reminder notes UnSuccessfull May be you don't have any notes or ''check the trash is false or true''" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
