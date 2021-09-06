using FundooNotes.Manger.Interface;
using FundooNotes.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

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

        public string DeleteLable(string lableName)
        {
            try
            {
                return lableRepository.DeleteLable(lableName);
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

        public string RenameLable(string updateLableName, string lableName)
        {
            try
            {
                return lableRepository.RenameLable(updateLableName, lableName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
