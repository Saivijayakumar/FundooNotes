<<<<<<< HEAD
﻿using FundooNotes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooNotes.Manger.Interface
{
    public interface INoteManger
    {
        bool CreateNote(NoteModel noteData);
        bool ChangeTitle(int userId, int noteId, string updatedData);
        bool ChangeDescription(int userId, int noteId, string updatedData);
        bool UnPin(int userId, int noteId);
        bool Pin(int userId, int noteId);
        bool AddReminder(int userId, int noteId, string updatedData);
        bool RemoveReminder(int noteId);

=======
﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Manger.Interface
{
    public interface INoteManger
    {
>>>>>>> 451872bf57a85d050b56e8bb1909f07f50543b72
    }
}
