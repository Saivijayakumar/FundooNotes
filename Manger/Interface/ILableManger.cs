using System;
using System.Collections.Generic;
using System.Text;

namespace FundooNotes.Manger.Interface
{
    public interface ILableManger
    {
        string AddLable(LableModel lable);
        string removeLableInNote(int lableId);
        string DeleteLable(string lableName);
        string RenameLable(string updateLableName, string lableName);
        List<LableModel> GetAllLables(int userId);
        List<LableModel> GetNoteLables(int noteId);
        List<LableModel> GetLables(int userId, string lableName);
    }
}
