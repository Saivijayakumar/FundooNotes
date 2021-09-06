using System;
using System.Collections.Generic;
using System.Text;

namespace FundooNotes.Repository.Interface
{
    public interface ILableRepository
    {
        string AddLable(LableModel lable);
        string removeLableInNote(int lableId);
        string DeleteLable(string lableName);
    }
}
