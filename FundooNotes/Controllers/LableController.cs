//-----------------------------------------------------------------------
// <copyright file="CollaboratorController.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace FundooNotes.Controllers
{
    using FundooNotes.Manger.Interface;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Lable controller class
    /// </summary>
    public class LableController : ControllerBase
    {
        /// <summary>
        /// object for ILableManger
        /// </summary>
        private ILableManger lableManger;

        /// <summary>
        /// Initializes a new instance of the <see cref="LableController" /> class
        /// </summary>
        /// <param name="lableManger"></param>
        public LableController(ILableManger lableManger)
        {
            this.lableManger = lableManger;
        }

        /// <summary>
        /// Add lable to user
        /// </summary>
        /// <param name="lable">lable info</param>
        /// <returns>IAction Result</returns>
        [HttpPost]
        [Route("api/Add Lable")]
        public IActionResult AddLable([FromBody] LableModel lable)
        {
            try
            {
                string result = this.lableManger.AddLable(lable);
                if (result == "Lable Added Successfull")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Add Lable Method",Data = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Result = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Add lable to note
        /// </summary>
        /// <param name="lable">lable info</param>
        /// <returns>IAction Result</returns>
        [HttpPost]
        [Route("api/Add Lable To Note")]
        public IActionResult AddLableInNote([FromBody] LableModel lable)
        {
            try
            {
                string result = this.lableManger.AddLableInNote(lable);
                if (result == "Lable Added To Note Successfull")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Add Lable Method", Data = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Result = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// remove lable in note
        /// </summary>
        /// <param name="lableId">lable id</param>
        /// <returns>IAction Result</returns>
        [HttpDelete]
        [Route("api/Remove Lable In Note")]
        public IActionResult removeLableInNote(int lableId)
        {
            try
            {
                string result = this.lableManger.removeLableInNote(lableId);
                if (result == "Lable Removed Successfull")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Remove Lable Method", Data = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Result = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// delete lable by lable name and user id
        /// </summary>
        /// <param name="deleteData">delete lable</param>
        /// <returns>IAction Result</returns>
        [HttpDelete]
        [Route("api/Delete Lable")]
        public IActionResult DeleteLable([FromBody] helperLableModel deleteData)
        {
            try
            {
                string result = this.lableManger.DeleteLable(deleteData);
                if (result == "Lable Deleted Successfull")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Delete Lable Method", Data = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Result = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// rename lable
        /// </summary>
        /// <param name="updateLable">update data</param>
        /// <returns>IAction Result</returns>
        [HttpPut]
        [Route("api/Rename Lable")]
        public IActionResult RenameLable([FromBody] helperLableModel updateLable)
        {
            try
            {
                string result = this.lableManger.RenameLable(updateLable);
                if (result == "Lable Name Updated Successfull")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Rename Lable Method", Data = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Result = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// get all lables 
        /// </summary>
        /// <param name="userId">user id</param>
        /// <returns>IAction Result</returns>
        [HttpPost]
        [Route("api/Get All Lables")]
        public IActionResult GetAllLables(int userId)
        {
            try
            {
                List<LableModel> result = this.lableManger.GetAllLables(userId);
                if (result.Count > 0)
                {
                    return this.Ok(new ResponseModel<List<LableModel>>() { Status = true, Message = "Get Lable Method", Data = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Result = "No lables Present at given UserId" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// get only note lables
        /// </summary>
        /// <param name="noteId">note id</param>
        /// <returns>IAction Result</returns>
        [HttpPost]
        [Route("api/Get Note Lables")]
        public IActionResult GetNoteLables(int noteId)
        {
            try
            {
                List<LableModel> result = this.lableManger.GetNoteLables(noteId);
                if (result.Count > 0)
                {
                    return this.Ok(new ResponseModel<List<LableModel>>() { Status = true, Message = "Get Note Lable Method", Data = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Result = "No lables Present at given NoteId" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// get lables by user
        /// </summary>
        /// <param name="lableData">lable data</param>
        /// <returns>IAction Result</returns>
        [HttpPost]
        [Route("api/Get Lables")]
        public IActionResult GetLables([FromBody] helperLableModel lableData)
        {
            try
            {
                List<NoteModel> result = this.lableManger.GetLables(lableData);
                if (result.Count > 0)
                {
                    return this.Ok(new ResponseModel<List<NoteModel>>() { Status = true, Message = "Get Lables Method", Data = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Result = "No lables Present at given NoteId" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
