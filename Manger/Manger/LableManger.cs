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
    }
}
