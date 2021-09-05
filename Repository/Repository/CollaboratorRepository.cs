using FundooNotes.Repository.Context;
using FundooNotes.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FundooNotes.Repository.Repository
{
    public class CollaboratorRepository : ICollaboratorRepository
    {
        /// <summary>
        /// Object for UserContext
        /// </summary>
        private readonly UserContext userContext;

        public CollaboratorRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }

        /// <summary>
        /// Add Collaborator
        /// </summary>
        /// <param name="collaborator">Total collaborator data</param>
        /// <returns>Final responce</returns>
        public string AddCollaborator(CollaboratorModel collaborator)
        {
            try
            {
                var emailOccurrence = this.userContext.Collaborator.Where(x => x.collaboratorEmail == collaborator.collaboratorEmail && x.NoteId == collaborator.NoteId).FirstOrDefault();
                if (emailOccurrence == null)
                {
                    this.userContext.Collaborator.Add(collaborator);
                    this.userContext.SaveChanges();
                    return "Collaborator Added Successfull";
                }
                return "Collaborator Added UnSuccessfull No duplicate Emails are allowed";
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<string> GetCollaborator(int noteId)
        {
            try
            {
                var collaboratorList = this.userContext.Collaborator.Where(x => x.NoteId == noteId).Select(x => x.collaboratorEmail).ToList();
                if (collaboratorList != null)
                {
                    return collaboratorList;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

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
