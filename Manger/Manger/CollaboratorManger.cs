//-----------------------------------------------------------------------
// <copyright file="CollaboratorManger.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace FundooNotes.Manger.Manger
{
    using System;
    using FundooNotes.Manger.Interface;
    using System.Collections.Generic;
    using FundooNotes.Repository.Interface;

    /// <summary>
    /// CollaboratorManger class
    /// </summary>
    public class CollaboratorManger : ICollaboratorManger
    {
        /// <summary>
        /// object for ICollaboratorRepository
        /// </summary>
        private readonly ICollaboratorRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="LableController" /> class
        /// </summary>
        /// <param name="repository">object name</param>
        public CollaboratorManger(ICollaboratorRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Add Collaborator
        /// </summary>
        /// <param name="collaborator">Total data of collaborator</param>
        /// <returns>Output string</returns>
        public string AddCollaborator(CollaboratorModel collaborator)
        {
            try
            {
                return this.repository.AddCollaborator(collaborator);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get Collaborator
        /// </summary>
        /// <param name="noteId">Note ID</param>
        /// <returns>Output string</returns>
        public List<CollaboratorModel> GetCollaborator(int noteId)
        {
            try
            {
                return this.repository.GetCollaborator(noteId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Remove Collaborator
        /// </summary>
        /// <param name="collaborator">collaborator ID</param>
        /// <returns>Output string</returns>
        public string RemoveCollaborator(int collaboratorId)
        {
            try
            {
                return this.repository.RemoveCollaborator(collaboratorId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
