using System;
using System.Collections.Generic;
using System.Text;

namespace FundooNotes.Manger.Interface
{
    public interface ILableManger
    {
        string AddLable(LableModel lable);
        string removeLableInNote(int lableId);
        string DeleteLable(helperLableModel deleteData);
        string RenameLable(helperLableModel updateLable);
        List<LableModel> GetAllLables(int userId);
        List<LableModel> GetNoteLables(int noteId);
        List<LableModel> GetLables(helperLableModel lableData);
    }
}
