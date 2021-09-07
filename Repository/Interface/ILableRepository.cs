using System;
using System.Collections.Generic;
using System.Text;

namespace FundooNotes.Repository.Interface
{
    public interface ILableRepository
    {
        string AddLable(LableModel lable);
        string AddLableInNote(LableModel lable);
        string removeLableInNote(int lableId);
        string DeleteLable(helperLableModel deleteData);
        string RenameLable(helperLableModel updateLable);
        List<LableModel> GetAllLables(int userId);
        List<LableModel> GetNoteLables(int noteId);
        List<LableModel> GetLables(helperLableModel lableData);
    }
}
