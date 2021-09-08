using FundooNotes.Manger.Interface;
using FundooNotes.Repository.Interface;
using System;
using System.Collections.Generic;

namespace FundooNotes.Manger.Manger
{
    public class LableManger : ILableManger
    {
        private readonly ILableRepository lableRepository;
        public LableManger(ILableRepository lableRepository)
        {
            this.lableRepository = lableRepository;
        }
        public string AddLable(LableModel lable)
        {
            try
            {
                return lableRepository.AddLable(lable);
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
                return lableRepository.AddLableInNote(lable);
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
                return lableRepository.DeleteLable(deleteData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string removeLableInNote(int lableId)
        {
            try
            {
                return lableRepository.removeLableInNote(lableId);
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
                return lableRepository.RenameLable(updateLable);
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
                return lableRepository.GetAllLables(userId);
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
                return lableRepository.GetNoteLables(noteId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<NoteModel> GetLables(helperLableModel lableData)
        {
            try
            {
                return lableRepository.GetLables(lableData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
