using FundooNotes;
using FundooNotes.Manger.Interface;
using FundooNotes.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooNotes.Manger.Manger
{
    public class CollaboratorManger : ICollaboratorManger
    {
        private readonly ICollaboratorRepository repository;
        public CollaboratorManger(ICollaboratorRepository repository)
        {
            this.repository = repository;
        }
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
