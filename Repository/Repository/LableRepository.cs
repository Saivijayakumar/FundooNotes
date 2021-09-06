using FundooNotes.Repository.Context;
using FundooNotes.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                var lableOccurrence = this.userContext.Lable.Where(x => x.lableName == lable.lableName).SingleOrDefault();
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

        public string DeleteLable(string lableName)
        {
            try
            {
                var lableList = this.userContext.Lable.Where(x => x.lableName == lableName).ToList();
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

        public string RenameLable(string updateLableName , string lableName)
        {
            try
            {
                var lableList = this.userContext.Lable.Where(x => x.lableName == lableName).ToList();
                if (lableList.Count > 0)
                {
                    foreach(var i in lableList)
                    {
                        i.lableName = updateLableName;
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

        public List<LableModel> GetLables(int userId, string lableName)
        {
            try
            {
                var labledNotes = this.userContext.Lable.Where(x => x.UserId == userId && x.lableName == lableName).ToList();
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
