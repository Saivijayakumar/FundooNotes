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
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Note controller class
    /// </summary>
    [Authorize]
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
                    return this.BadRequest(new { Status = false, Result = "Pin Unsuccessfull For note ID " + noteId });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Help to add reminder
        /// </summary>
        /// <param name="updatedData">It contain note Id and new data</param>
        /// <returns>IAction Result</returns>
        [HttpPut]
        [Route("api/AddReminder")]
        public IActionResult AddReminder(NoteUpdateModel updatedData)
        {
            try
            {
                bool result = this.noteManger.AddReminder(updatedData);
                if (result == true)
                {
                    return this.Ok(new { Status = true, Result = "Remind added Successfull " });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Result = "Remind added Unsuccessfull" });
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
        /// Change color
        /// </summary>
        /// <param name="color">Getting NoteID and Color</param>
        /// <returns>IAction Result</returns>
        [HttpPut]
        [Route("api/color")]
        public IActionResult ChangeColor(NoteUpdateModel color)
        {
            try
            {
                bool result = this.noteManger.ChangeColor(color);
                if (result == true)
                {
                    return this.Ok(new { Status = true, Result = "Color changed Successfull For note ID " + color.noteId });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Result = "Color changed Unsuccessfull For note ID " + color.noteId });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Trash The Note
        /// </summary>
        /// <param name="noteId">Note Id</param>
        /// <returns>IAction Result</returns>
        [HttpPut]
        [Route("api/Send To Trash")]
        public IActionResult TrashTheNote(int noteId)
        {
            try
            {
                bool result = this.noteManger.TrashTheNote(noteId);
                if (result == true)
                {
                    return this.Ok(new { Status = true, Result = "Note Send To Trash Successfull" });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Result = "Note Send To Trash UnSuccessfull" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Restore The Note
        /// </summary>
        /// <param name="noteId">Note Id</param>
        /// <returns>IAction Result</returns>
        [HttpPut]
        [Route("api/Restore Note")]
        public IActionResult RestoreTheNote(int noteId)
        {
            try
            {
                bool result = this.noteManger.RestoreTheNote(noteId);
                if (result == true)
                {
                    return this.Ok(new { Status = true, Result = "Note Restore Successfull" });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Result = "Note Restore UnSuccessfull" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Un Archive
        /// </summary>
        /// <param name="noteId">Note Id</param>
        /// <returns>IAction Result</returns>
        [HttpPut]
        [Route("api/Un Archieve")]
        public IActionResult UnArchieve(int noteId)
        {
            try
            {
                bool result = this.noteManger.UnArchieve(noteId);
                if (result == true)
                {
                    return this.Ok(new { Status = true, Result = "Note UnArchieve is Successfull" });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Result = "Note UnArchieve is UnSuccessfull" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Archive Note
        /// </summary>
        /// <param name="noteId">Note Id</param>
        /// <returns>IAction Result</returns>
        [HttpPut]
        [Route("api/Archieve")]
        public IActionResult Archieve(int noteId)
        {
            try
            {
                bool result = this.noteManger.Archieve(noteId);
                if (result == true)
                {
                    return this.Ok(new { Status = true, Result = "Note Archieve is Successfull" });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Result = "Note Archieve is UnSuccessfull" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Updating Note 
        /// </summary>
        /// <param name="updateNoteModel">Updated Values</param>
        /// <returns>IAction Result</returns>
        [HttpPut]
        [Route("api/Update")]
        public IActionResult UpdateNote(updateNoteModel updateNoteModel)
        {
            try
            {
                bool result = this.noteManger.UpdateNote(updateNoteModel);
                if (result == true)
                {
                    return this.Ok(new { Status = true, Result = "Data Updated Successfull For note ID " + updateNoteModel.noteId });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Result = "Data Updated Unsuccessfull For note ID " + updateNoteModel.noteId });
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
                    return this.BadRequest(new { Status = false, Result = "Delete of Note permanently is Unsuccessfull For note ID " + noteId });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// get notes for particular user
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

        /// <summary>
        /// Deleting all notes in trash
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>IAction Result</returns>
        [HttpDelete]
        [Route("api/Empty Trash")]
        public IActionResult EmptyTrash(int userId)
        {
            try
            {
                bool result = this.noteManger.EmptyTrash(userId);
                if (result == true)
                {
                    return this.Ok(new { Status = true, Message = "Empty Trash is Successfull" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Empty Trash is UnSuccessfull" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
