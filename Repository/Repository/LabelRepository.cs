//-----------------------------------------------------------------------
// <copyright file="LabelRepository.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace FundooNotes.Repository.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FundooNotes.Repository.Context;
    using FundooNotes.Repository.Interface;

    /// <summary>
    /// LabelRepository class
    /// </summary>
    public class LabelRepository : ILabelRepository
    {
        /// <summary>
        /// Object for UserContext
        /// </summary>
        private readonly UserContext userContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelRepository" /> class
        /// </summary>
        /// <param name="userContext">Initialize object</param>
        public LabelRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }

        /// <summary>
        /// add label to user
        /// </summary>
        /// <param name="label">label info</param>
        /// <returns>output message as string</returns>
        public string AddLabel(LabelModel label)
        {
            try
            {
                var labelOccurrence = this.userContext.Label.Where(x => x.LabelName == label.LabelName && x.UserId == label.UserId && x.NoteId == null).SingleOrDefault();
                if (labelOccurrence == null)
                {
                    this.userContext.Label.Add(label);
                    this.userContext.SaveChanges();
                    return "label Added Successfull";
                }

                return "label Added UnSuccessfull";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// add label to to note
        /// </summary>
        /// <param name="label">label info</param>
        /// <returns>output message as string</returns>
        public string AddLabelInNote(LabelModel label)
        {
            try
            {
                var labelPresent = this.userContext.Label.Where(x => x.LabelName == label.LabelName && x.NoteId == label.NoteId && x.UserId == label.UserId).SingleOrDefault();
                if (labelPresent == null)
                {
                    this.userContext.Label.Add(label);
                    this.userContext.SaveChanges();
                    label.NoteId = null;
                    label.LabelId = 0;
                    this.AddLabel(label);
                    return "label Added To Note Successfull";
                }

                return "label Added To Note UnSuccessfull";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// remove label for note
        /// </summary>
        /// <param name="labelId">label id</param>
        /// <returns>output message as string</returns>
        public string RemoveLabelInNote(int labelId)
        {
            try
            {
                var labelData = this.userContext.Label.Find(labelId);
                if (labelData != null)
                {
                    this.userContext.Label.Remove(labelData);
                    this.userContext.SaveChanges();
                    return "label Removed Successfull";
                }

                return "label Removed UnSuccessfull";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// delete label form user
        /// </summary>
        /// <param name="deleteData">user id and label name</param>
        /// <returns>output message as string</returns>
        public string DeleteLabel(HelperLabelModel deleteData)
        {
            try
            {
                var labelList = this.userContext.Label.Where(x => x.LabelName == deleteData.LabelName && x.UserId == deleteData.UserId).ToList();
                if (labelList.Count > 0)
                {
                    this.userContext.Label.RemoveRange(labelList);
                    this.userContext.SaveChanges();
                    return "label Deleted Successfull";
                }

                return "label Deleted UnSuccessfull";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// method for rename label
        /// </summary>
        /// <param name="updatelabel">getting values for Rename the label</param>
        /// <returns>output message as string</returns>
        public string RenameLabel(HelperLabelModel updatelabel)
        {
            try
            {
                if (updatelabel.LabelName != updatelabel.UpdateLabelName)
                {
                    string result = "label Name Updated UnSuccessfull";
                    var newlabelOccurrence = this.userContext.Label.Where(x => x.LabelName == updatelabel.UpdateLabelName && x.UserId == updatelabel.UserId && x.NoteId == null).SingleOrDefault();
                    var labelList = this.userContext.Label.Where(x => x.LabelName == updatelabel.LabelName && x.UserId == updatelabel.UserId).ToList();
                    if (labelList.Count > 0)
                    {
                        result = "label Name Updated Successfull";
                        if (newlabelOccurrence != null)
                        {
                            this.userContext.Label.Remove(newlabelOccurrence);
                            this.userContext.SaveChanges();
                            Console.WriteLine($"Merge the '{updatelabel.LabelName}' label with the '{updatelabel.UpdateLabelName}' label? All notes labeled with '{updatelabel.LabelName}' will be replaced with '{updatelabel.UpdateLabelName}', and the '{updatelabel.LabelName}' label will be deleted.");
                        }

                        foreach (var i in labelList)
                        {
                            i.LabelName = updatelabel.UpdateLabelName;
                        }

                        this.userContext.SaveChanges();
                    }

                    return result;
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Getting all labels 
        /// </summary>
        /// <param name="userId">user id to get all labels of </param>
        /// <returns>list of labels</returns>
        public List<LabelModel> GetAllLabels(int userId)
        {
            try
            {
                var allLabels = this.userContext.Label.Where(x => x.UserId == userId && x.NoteId == null).ToList();
                if (allLabels.Count > 0)
                {
                    return allLabels;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Getting labels of note
        /// </summary>
        /// <param name="noteId">note id to get all labels of note</param>
        /// <returns>list of labels</returns>
        public List<LabelModel> GetNoteLabels(int noteId)
        {
            try
            {
                var allNoteLabels = this.userContext.Label.Where(x => x.NoteId == noteId).ToList();
                if (allNoteLabels.Count > 0)
                {
                    return allNoteLabels;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Getting  labels by label name
        /// </summary>
        /// <param name="labelData">receive only user id and label name</param>
        /// <returns>list of labels</returns>
        public List<NoteModel> GetLabels(HelperLabelModel labelData)
        {
            try
            {
                var labeledNotes = (from n in this.userContext.Note
                                               join l in this.userContext.Label
                                               on n.UserId equals l.UserId
                                               where l.LabelName == labelData.LabelName && l.UserId == labelData.UserId && l.NoteId != null
                                               select n).ToList();
                if (labeledNotes.Count > 0)
                {
                    return labeledNotes;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
