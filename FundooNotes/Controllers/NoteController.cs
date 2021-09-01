//-----------------------------------------------------------------------
// <copyright file="NoteController.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace FundooNotes.Controllers
{
    using System;
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
                    return this.Ok(new { Status = true, Message = "New Note called " + noteData.Title + " is Add Successfull" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Note added Unsuccessfull" });
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
        public IActionResult ChangeTitle(int userId, int noteId)
        {
            try
            {
                bool result = this.noteManger.ChangeTitle(userId, noteId);
                if (result == true)
                {
                    return this.Ok(new { Status = true, Result = "Title changed Successfull For note ID " + noteId });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Result = "Title changed Unsuccessfull For note ID " + noteId });
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
        public IActionResult ChangeDescription(int userId, int noteId)
        {
            try
            {
                bool result = this.noteManger.ChangeDescription(userId, noteId);
                if (result == true)
                {
                    return this.Ok(new { Status = true, Result = "Description changed Successfull For note ID " + noteId });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Result = "Description changed Unsuccessfull For note ID " + noteId });
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
        /// <param name="userId">User Id</param>
        /// <param name="noteId">Note Id</param>
        /// <returns>IAction Result</returns>
        [HttpPut]
        [Route("api/UnPin")]
        public IActionResult UnPin(int userId, int noteId)
        {
            try
            {
                bool result = this.noteManger.UnPin(userId, noteId);
                if (result == true)
                {
                    return this.Ok(new { Status = true, Result = "UnPin Successfull For note ID " + noteId });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Result = "UnPin Unsuccessfull For note ID " + noteId });
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
        /// <param name="userId">User Id</param>
        /// <param name="noteId">Note Id</param>
        /// <returns>IAction Result</returns>
        [HttpPut]
        [Route("api/Pin")]
        public IActionResult Pin(int userId, int noteId)
        {
            try
            {
                bool result = this.noteManger.Pin(userId, noteId);
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
    }
}
