//-----------------------------------------------------------------------
// <copyright file="LabelManger.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace FundooNotes.Manger.Manger
{
    using System;
    using System.Collections.Generic;
    using FundooNotes.Manger.Interface;
    using FundooNotes.Repository.Interface;

    /// <summary>
    /// labelManger class
    /// </summary>
    public class LabelManger : ILabelManger
    {
        /// <summary>
        /// ILabelRepository object Initialize
        /// </summary>
        private readonly ILabelRepository labelRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelManger" /> class
        /// </summary>
        /// <param name="labelRepository">object name</param>
        public LabelManger(ILabelRepository labelRepository)
        {
            this.labelRepository = labelRepository;
        }

        /// <summary>
        /// Add label to user
        /// </summary>
        /// <param name="label">label info</param>
        /// <returns>result as string</returns>
        public string AddLabel(LabelModel label)
        {
            try
            {
                return this.labelRepository.AddLabel(label);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Add label to note
        /// </summary>
        /// <param name="label">label info</param>
        /// <returns>result as string</returns>
        public string AddLabelInNote(LabelModel label)
        {
            try
            {
                return this.labelRepository.AddLabelInNote(label);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// delete label by label name and user id
        /// </summary>
        /// <param name="deleteData">delete label</param>
        /// <returns>result as string</returns>
        public string DeleteLabel(LabelModel deleteData)
        {
            try
            {
                return this.labelRepository.DeleteLabel(deleteData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// remove label in note
        /// </summary>
        /// <param name="labelId">label id</param>
        /// <returns>result as string</returns>
        public string RemoveLabelInNote(int labelId)
        {
            try
            {
                return this.labelRepository.RemoveLabelInNote(labelId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// rename label
        /// </summary>
        /// <param name="updatelabel">update data</param>
        /// <returns>result as string</returns>
        public string RenameLabel(LabelModel updateLabel)
        {
            try
            {
                return this.labelRepository.RenameLabel(updateLabel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// get all labels 
        /// </summary>
        /// <param name="userId">user id</param>
        /// <returns>list of all labels</returns>
        public List<LabelModel> GetAllLabels(int userId)
        {
            try
            {
                return this.labelRepository.GetAllLabels(userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// get only note labels
        /// </summary>
        /// <param name="noteId">note id</param>
        /// <returns>list of note labels</returns>
        public List<LabelModel> GetNoteLabels(int noteId)
        {
            try
            {
                return this.labelRepository.GetNoteLabels(noteId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// get labels by user
        /// </summary>
        /// <param name="labelData">label data</param>
        /// <returns>list of notes</returns>
        public List<NoteModel> GetLabels(LabelModel labelData)
        {
            try
            {
                return this.labelRepository.GetLabels(labelData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
