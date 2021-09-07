using FundooNotes.Repository.Context;
using FundooNotes.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FundooNotes.Repository.Repository
{
    public class LableRepository : ILableRepository
    {
        /// <summary>
        /// Object for UserContext
        /// </summary>
        private readonly UserContext userContext;

        public LableRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }
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

        public string RenameLable(helperLableModel updateLable)
        {
            try
            {
                var lableList = this.userContext.Lable.Where(x => x.lableName == updateLable.LableName && x.UserId == updateLable.UserId).ToList();
                if (lableList.Count > 0)
                {
                    foreach(var i in lableList)
                    {
                        i.lableName = updateLable.UpdateLableName;
                    }
                    this.userContext.SaveChanges();
                    return "Lable Name Updated Successfull";
                }
                return "Lable Name Updated UnSuccessfull";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<LableModel> GetAllLables(int userId)
        {
            try
            {
                var allLables = this.userContext.Lable.Where(x => x.UserId == userId).ToList();
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
