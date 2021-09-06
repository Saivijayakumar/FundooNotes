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
    }
}
