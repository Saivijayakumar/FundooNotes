using System;
using System.Collections.Generic;
using System.Text;

namespace FundooNotes.Manger.Interface
{
    public interface ICollaboratorManger
    {
        string AddCollaborator(CollaboratorModel collaborator);
        string RemoveCollaborator(int collaborator);
        List<string> GetCollaborator(int noteId);
    }
}
