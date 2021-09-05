using System;
using System.Collections.Generic;
using System.Text;

namespace FundooNotes.Repository.Interface
{
    public interface ICollaboratorRepository
    {
        string AddCollaborator(CollaboratorModel collaborator);
        string RemoveCollaborator(int collaborator);
        List<string> GetCollaborator(int noteId);
    }
}
