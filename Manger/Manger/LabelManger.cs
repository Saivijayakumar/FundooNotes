//-----------------------------------------------------------------------
// <copyright file="UserController.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace FundooNotes.Manger.Manger
{
    using FundooNotes.Manger.Interface;
    using FundooNotes.Repository.Interface;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// labelManger class
    /// </summary>
    public class LabelManger : ILabelManger
    {
        /// <summary>
        /// IlabelRepository object Initialize
        /// </summary>
        private readonly ILabelRepository labelRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="labelController" /> class
        /// </summary>
        /// <param name="repository">object name</param>
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
                return labelRepository.AddLabel(label);
            }
            catch(Exception ex)
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
                return labelRepository.AddLabelInNote(label);
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
        public string DeleteLabel(HelperLabelModel deleteData)
        {
            try
            {
                return labelRepository.DeleteLabel(deleteData);
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
                return labelRepository.RemoveLabelInNote(labelId);
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
        public string RenameLabel(HelperLabelModel updateLabel)
        {
            try
            {
                return labelRepository.RenameLabel(updateLabel);
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
                return labelRepository.GetAllLabels(userId);
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
                return labelRepository.GetNoteLabels(noteId);
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
        public List<NoteModel> GetLabels(HelperLabelModel labelData)
        {
            try
            {
                return labelRepository.GetLabels(labelData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
