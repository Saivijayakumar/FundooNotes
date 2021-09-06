//-----------------------------------------------------------------------
// <copyright file="ICollaboratorManger.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace FundooNotes.Manger.Interface
{
    using System.Collections.Generic;

    /// <summary>
    /// interface class
    /// </summary>
    public interface ICollaboratorManger
    {
        /// <summary>
        /// Add Collaborator
        /// </summary>
        /// <param name="collaborator">Total data of collaborator</param>
        /// <returns>Output string</returns>
        string AddCollaborator(CollaboratorModel collaborator);

        /// <summary>
        /// Remove Collaborator
        /// </summary>
        /// <param name="collaborator">collaborator ID</param>
        /// <returns>Output string</returns>
        string RemoveCollaborator(int collaborator);

        /// <summary>
        /// Get Collaborator
        /// </summary>
        /// <param name="noteId">Note ID</param>
        /// <returns>Output string</returns>
        List<CollaboratorModel> GetCollaborator(int noteId);
    }
}
