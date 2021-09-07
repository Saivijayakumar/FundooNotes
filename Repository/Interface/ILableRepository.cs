using System;
using System.Collections.Generic;
using System.Text;

namespace FundooNotes.Repository.Interface
{
    public interface ILableRepository
    {
        /// <summary>
        /// Add lable to user
        /// </summary>
        /// <param name="lable">lable info</param>
        /// <returns>result as string</returns>
        string AddLable(LableModel lable);

        /// <summary>
        /// Add lable to note
        /// </summary>
        /// <param name="lable">lable info</param>
        /// <returns>result as string</returns>
        string AddLableInNote(LableModel lable);

        /// <summary>
        /// remove lable in note
        /// </summary>
        /// <param name="lableId">lable id</param>
        /// <returns>result as string</returns>
        string removeLableInNote(int lableId);

        /// <summary>
        /// delete lable by lable name and user id
        /// </summary>
        /// <param name="deleteData">delete lable</param>
        /// <returns>result as string</returns>
        string DeleteLable(helperLableModel deleteData);

        /// <summary>
        /// rename lable
        /// </summary>
        /// <param name="updateLable">update data</param>
        /// <returns>result as string</returns>
        string RenameLable(helperLableModel updateLable);

        /// <summary>
        /// get all lables 
        /// </summary>
        /// <param name="userId">user id</param>
        /// <returns>list of all lables</returns>
        List<LableModel> GetAllLables(int userId);

        /// <summary>
        /// get only note lables
        /// </summary>
        /// <param name="noteId">note id</param>
        /// <returns>list of note lables</returns>
        List<LableModel> GetNoteLables(int noteId);

        /// <summary>
        /// get lables by user
        /// </summary>
        /// <param name="lableData">lable data</param>
        /// <returns>list of lables</returns>
        List<LableModel> GetLables(helperLableModel lableData);
    }
}
