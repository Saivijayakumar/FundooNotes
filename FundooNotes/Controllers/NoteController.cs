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
        /// Changeing title of Note
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="noteId">Note Id</param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/ChangeTitle")]
        public IActionResult ChangeTitle(int userId,int noteId)
        {
            try
            {
                bool result = this.noteManger.ChangeTitle(userId, noteId);
                if (result == true)
                {
                    return this.Ok(new { Status = true, Result = "Title changed Successfull For note" + noteId });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Result = "Title changed Unsuccessfull For note" + noteId });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
