//-----------------------------------------------------------------------
// <copyright file="LabelController.cs" company="Bridgelabz">
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
    /// label controller class
    /// </summary>
    public class LabelController : ControllerBase
    {
        /// <summary>
        /// object for ILabelManger
        /// </summary>
        private ILabelManger labelManger;

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelController" /> class
        /// </summary>
        /// <param name="labelManger">object name</param>
        public LabelController(ILabelManger labelManger)
        {
            this.labelManger = labelManger;
        }

        /// <summary>
        /// Add label to user
        /// </summary>
        /// <param name="label">label info</param>
        /// <returns>IAction Result</returns>
        [HttpPost]
        [Route("api/Add label")]
        public IActionResult AddLabel([FromBody] LabelModel label)
        {
            try
            {
                string result = this.labelManger.AddLabel(label);
                if (result == "label Added Successfull")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Add label Method",Data = result });
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
        /// Add label to note
        /// </summary>
        /// <param name="label">label info</param>
        /// <returns>IAction Result</returns>
        [HttpPost]
        [Route("api/Add Label To Note")]
        public IActionResult AddLabelInNote([FromBody] LabelModel label)
        {
            try
            {
                string result = this.labelManger.AddLabelInNote(label);
                if (result == "label Added To Note Successfull")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Add label Method", Data = result });
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
        /// remove label in note
        /// </summary>
        /// <param name="labelId">label id</param>
        /// <returns>IAction Result</returns>
        [HttpDelete]
        [Route("api/Remove Label In Note")]
        public IActionResult RemoveLabelInNote(int labelId)
        {
            try
            {
                string result = this.labelManger.RemoveLabelInNote(labelId);
                if (result == "label Removed Successfull")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Remove label Method", Data = result });
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
        /// delete label by label name and user id
        /// </summary>
        /// <param name="deleteData">label name and user id</param>
        /// <returns>IAction Result</returns>
        [HttpDelete]
        [Route("api/Delete Label")]
        public IActionResult DeleteLabel([FromBody] LabelModel deleteData)
        {
            try
            {
                string result = this.labelManger.DeleteLabel(deleteData);
                if (result == "label Deleted Successfull")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Delete label Method", Data = result });
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
        /// rename label
        /// </summary>
        /// <param name="updatelabel">update lable name as lable name ,user id and label Id</param>
        /// <returns>IAction Result</returns>
        [HttpPut]
        [Route("api/Rename Label")]
        public IActionResult RenameLabel([FromBody] LabelModel updateLabel)
        {
            try
            {
                string result = this.labelManger.RenameLabel(updateLabel);
                if (result == "label Name Updated Successfull")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Rename label Method", Data = result });
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
        /// get all labels 
        /// </summary>
        /// <param name="userId">user id</param>
        /// <returns>IAction Result</returns>
        [HttpPost]
        [Route("api/Get All Labels")]
        public IActionResult GetAllLabels(int userId)
        {
            try
            {
                List<LabelModel> result = this.labelManger.GetAllLabels(userId);
                if (result.Count > 0)
                {
                    return this.Ok(new ResponseModel<List<LabelModel>>() { Status = true, Message = "Get label Method", Data = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Result = "No labels Present at given UserId" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// get only note labels
        /// </summary>
        /// <param name="noteId">note id</param>
        /// <returns>IAction Result</returns>
        [HttpPost]
        [Route("api/Get Note Labels")]
        public IActionResult GetNoteLabels(int noteId)
        {
            try
            {
                List<LabelModel> result = this.labelManger.GetNoteLabels(noteId);
                if (result.Count > 0)
                {
                    return this.Ok(new ResponseModel<List<LabelModel>>() { Status = true, Message = "Get Note label Method", Data = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Result = "No labels Present at given NoteId" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// get labels by user
        /// </summary>
        /// <param name="labelData">label name and user id</param>
        /// <returns>IAction Result</returns>
        [HttpPost]
        [Route("api/Get Labels")]
        public IActionResult GetLabels([FromBody] LabelModel labelData)
        {
            try
            {
                List<NoteModel> result = this.labelManger.GetLabels(labelData);
                if (result.Count > 0)
                {
                    return this.Ok(new ResponseModel<List<NoteModel>>() { Status = true, Message = "Get labels Method", Data = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Result = "No labels Present at given NoteId" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
