//-----------------------------------------------------------------------
// <copyright file="UserController.cs" company="Bridgelabz">
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
    /// Collaborator Controller class
    /// </summary>
    public class CollaboratorController : ControllerBase
    {
        /// <summary>
        /// object for ICollaboratorManger
        /// </summary>
        private readonly ICollaboratorManger collaboratorManger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollaboratorController" /> class
        /// </summary>
        /// <param name="collaboratorManger">object name</param>
        public CollaboratorController(ICollaboratorManger collaboratorManger)
        {
            this.collaboratorManger = collaboratorManger;
        }

        /// <summary>
        /// Add Collaborator
        /// </summary>
        /// <param name="collaborator">Total data of collaborator</param>
        /// <returns>IAction Result</returns>
        [HttpPost]
        [Route("api/Add Collaborator")]
        public IActionResult AddCollaborator([FromBody] CollaboratorModel collaborator)
        {
            try
            {
                string result = this.collaboratorManger.AddCollaborator(collaborator);
                if (result == "Collaborator Added Successfull")
                {
                    return this.Ok(new { Status = true, Message = result+" For "+collaborator.collaboratorEmail});
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Remove Collaborator
        /// </summary>
        /// <param name="collaboratorId">collaborator ID</param>
        /// <returns>IAction Result</returns>
        [HttpDelete]
        [Route("api/Remove Collaborator")]
        public IActionResult RemoveCollaborator(int collaboratorId)
        {
            try
            {
                string result = this.collaboratorManger.RemoveCollaborator(collaboratorId);
                if (result == "Collaborator Removed Successfull")
                {
                    return this.Ok(new { Status = true, Message = result});
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Get Collaborator
        /// </summary>
        /// <param name="collaboratorId">Note ID</param>
        /// <returns>IAction Result</returns>
        [HttpPost]
        [Route("api/Get Collaborator")]
        public IActionResult GetCollaborator(int noteId)
        {
            try
            {
                List<string> collaboratorList = this.collaboratorManger.GetCollaborator(noteId);
                if (collaboratorList != null)
                {
                    return this.Ok(new ResponseModel<List<string>>() { Status = true, Message = "collaborator List", Data = collaboratorList });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message =" No collaborator" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
