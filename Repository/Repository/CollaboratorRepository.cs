//-----------------------------------------------------------------------
// <copyright file="CollaboratorRepository.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace FundooNotes.Repository.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FundooNotes.Repository.Context;
    using FundooNotes.Repository.Interface;

    /// <summary>
    /// CollaboratorRepository class
    /// </summary>
    public class CollaboratorRepository : ICollaboratorRepository
    {
        /// <summary>
        /// Object for UserContext
        /// </summary>
        private readonly UserContext userContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollaboratorRepository" /> class
        /// </summary>
        /// <param name="userContext">Initialize object</param>
        public CollaboratorRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }

        /// <summary>
        /// Add Collaborator
        /// </summary>
        /// <param name="collaborator">Total collaborator data</param>
        /// <returns>Final response</returns>
        public string AddCollaborator(CollaboratorModel collaborator)
        {
            try
            {
                var ownerEmail = (from o in this.userContext.Note
                                  join i in this.userContext.Users
                                  on o.UserId equals i.UserId
                                  where collaborator.NoteId == o.NoteId
                                  select i.Email).SingleOrDefault();
                var emailOccurrence = this.userContext.Collaborator.Where(x => x.collaboratorEmail == collaborator.collaboratorEmail && x.NoteId == collaborator.NoteId).FirstOrDefault();
                if (ownerEmail.Equals(collaborator.collaboratorEmail) == false && emailOccurrence == null)
                {
                    this.userContext.Collaborator.Add(collaborator);
                    this.userContext.SaveChanges();
                    return "Collaborator Added Successfull";
                }

                return "Collaborator Added UnSuccessfull No duplicate Emails are allowed";
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
                var listOfCollaborator = this.userContext.Collaborator.Where(x => x.NoteId == noteId).ToList();
                if (listOfCollaborator != null)
                {
                    return listOfCollaborator;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Remove Collaborator
        /// </summary>
        /// <param name="collaboratorId">collaborator ID</param>
        /// <returns>Output string</returns>
        public string RemoveCollaborator(int collaboratorId)
        {
            try
            {
                var resultData = this.userContext.Collaborator.Find(collaboratorId);
                if (resultData != null)
                {
                    this.userContext.Collaborator.Remove(resultData);
                    this.userContext.SaveChanges();
                    return "Collaborator Removed Successfull";
                }

                return "Collaborator Removed UnSuccessfull ";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
