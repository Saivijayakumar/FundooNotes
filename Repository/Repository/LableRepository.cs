//-----------------------------------------------------------------------
// <copyright file="LableRepository.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace FundooNotes.Repository.Repository
{
    using System;
    using System.Linq;
    using FundooNotes.Repository.Context;
    using FundooNotes.Repository.Interface;
    using System.Collections.Generic;

    public class LableRepository : ILableRepository
    {
        /// <summary>
        /// Object for UserContext
        /// </summary>
        private readonly UserContext userContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="LableRepository" /> class
        /// </summary>
        /// <param name="userContext"></param>
        public LableRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }

        /// <summary>
        /// add lable to user
        /// </summary>
        /// <param name="lable">lable info</param>
        /// <returns>output message as string</returns>
        public string AddLable(LableModel lable)
        {
            try
            {
                var lableOccurrence = this.userContext.Lable.Where(x => x.lableName == lable.lableName && x.UserId == lable.UserId && x.NoteId == null).SingleOrDefault();
                if (lableOccurrence == null)
                {
                    this.userContext.Lable.Add(lable);
                    this.userContext.SaveChanges();
                    return "Lable Added Successfull";
                }
                return "Lable Added UnSuccessfull";
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// add lable to to note
        /// </summary>
        /// <param name="lable">lable info</param>
        /// <returns>output message as string</returns>
        public string AddLableInNote(LableModel lable)
        {
            try
            {
                var lablePresent = this.userContext.Lable.Where(x => x.lableName == lable.lableName && x.NoteId == lable.NoteId && x.UserId == lable.UserId).SingleOrDefault();
                if(lablePresent == null)
                {
                    this.userContext.Lable.Add(lable);
                    this.userContext.SaveChanges();
                    lable.NoteId = null;
                    lable.lableId = 0;
                    AddLable(lable);
                    return "Lable Added To Note Successfull";
                }
                return "Lable Added To Note UnSuccessfull";
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// remove lable for note
        /// </summary>
        /// <param name="lableId">lable id</param>
        /// <returns>output message as string</returns>
        public string removeLableInNote(int lableId)
        {
            try
            {
                var lableData = this.userContext.Lable.Find(lableId);
                if (lableData != null)
                {
                    this.userContext.Lable.Remove(lableData);
                    this.userContext.SaveChanges();
                    return "Lable Removed Successfull";
                }
                return "Lable Removed UnSuccessfull";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// delete lable form user
        /// </summary>
        /// <param name="deleteData">user id and lable name</param>
        /// <returns>output message as string</returns>
        public string DeleteLable(helperLableModel deleteData)
        {
            try
            {
                var lableList = this.userContext.Lable.Where(x => x.lableName == deleteData.LableName && x.UserId == deleteData.UserId).ToList();
                if (lableList.Count > 0)
                {
                    this.userContext.Lable.RemoveRange(lableList);
                    this.userContext.SaveChanges();
                    return "Lable Deleted Successfull";
                }
                return "Lable Deleted UnSuccessfull";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// method for rename lable
        /// </summary>
        /// <param name="updateLable">getting values for Rename the lable</param>
        /// <returns>output message as string</returns>
        public string RenameLable(helperLableModel updateLable)
        {
            try
            {
                if (updateLable.LableName != updateLable.UpdateLableName)
                {
                    string result = "Lable Name Updated UnSuccessfull";
                    var newLableOccurrence = this.userContext.Lable.Where(x => x.lableName == updateLable.UpdateLableName && x.UserId == updateLable.UserId && x.NoteId == null).SingleOrDefault();
                    var lableList = this.userContext.Lable.Where(x => x.lableName == updateLable.LableName && x.UserId == updateLable.UserId).ToList();
                    if (lableList.Count > 0)
                    {
                        result = "Lable Name Updated Successfull";
                        if (newLableOccurrence != null)
                        {
                            this.userContext.Lable.Remove(newLableOccurrence);
                            this.userContext.SaveChanges();
                            Console.WriteLine($"Merge the '{updateLable.LableName}' label with the '{updateLable.UpdateLableName}' label? All notes labeled with '{updateLable.LableName}' will be replaced with '{updateLable.UpdateLableName}', and the '{updateLable.LableName}' label will be deleted.");
                        }
                        foreach (var i in lableList)
                        {
                            i.lableName = updateLable.UpdateLableName;
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
        /// Getting all lables 
        /// </summary>
        /// <param name="userId">user id to get all lables of </param>
        /// <returns>list of lables</returns>
        public List<LableModel> GetAllLables(int userId)
        {
            try
            {
                var allLables = this.userContext.Lable.Where(x => x.UserId == userId && x.NoteId == null).ToList();
                if(allLables.Count > 0)
                {
                    return allLables;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Getting Lables of note
        /// </summary>
        /// <param name="noteId">note id to get all lables of note</param>
        /// <returns>list of lables</returns>
        public List<LableModel> GetNoteLables(int noteId)
        {
            try
            {
                var allNoteLables = this.userContext.Lable.Where(x => x.NoteId == noteId).ToList();
                if (allNoteLables.Count > 0)
                {
                    return allNoteLables;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Getting  lables by lable name
        /// </summary>
        /// <param name="lableData">receive only user id and lable name</param>
        /// <returns>list of lables</returns>
        public List<LableModel> GetLables(helperLableModel lableData)
        {
            try
            {
                var labledNotes = this.userContext.Lable.Where(x => x.UserId == lableData.UserId && x.lableName == lableData.LableName).ToList();
                if (labledNotes.Count > 0)
                {
                    return labledNotes;
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
