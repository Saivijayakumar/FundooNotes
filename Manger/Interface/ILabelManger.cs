//-----------------------------------------------------------------------
// <copyright file="ILabelManger.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace FundooNotes.Manger.Interface
{
    using System.Collections.Generic;

    /// <summary>
    /// ILabelManger Class
    /// </summary>
    public interface ILabelManger
    {
        /// <summary>
        /// Add label to user
        /// </summary>
        /// <param name="label">label info</param>
        /// <returns>result as string</returns>
        string AddLabel(LabelModel label);

        /// <summary>
        /// Add label to note
        /// </summary>
        /// <param name="label">label info</param>
        /// <returns>result as string</returns>
        string AddLabelInNote(LabelModel label);

        /// <summary>
        /// remove label in note
        /// </summary>
        /// <param name="labelId">label id</param>
        /// <returns>result as string</returns>
        string RemoveLabelInNote(int labelId);

        /// <summary>
        /// delete label by label name and user id
        /// </summary>
        /// <param name="deleteData">delete label</param>
        /// <returns>result as string</returns>
        string DeleteLabel(LabelModel deleteData);

        /// <summary>
        /// rename label
        /// </summary>
        /// <param name="updateLabel">update data</param>
        /// <returns>result as string</returns>
        string RenameLabel(LabelModel updateLabel);

        /// <summary>
        /// get all labels 
        /// </summary>
        /// <param name="userId">user id</param>
        /// <returns>list of all labels</returns>
        List<LabelModel> GetAllLabels(int userId);

        /// <summary>
        /// get only note labels
        /// </summary>
        /// <param name="noteId">note id</param>
        /// <returns>list of note labels</returns>
        List<LabelModel> GetNoteLabels(int noteId);

        /// <summary>
        /// get labels by user
        /// </summary>
        /// <param name="labelData">label data</param>
        /// <returns>list of notes</returns>
        List<NoteModel> GetLabels(LabelModel labelData);
    }
}
