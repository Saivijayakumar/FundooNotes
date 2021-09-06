﻿using FundooNotes.Repository.Context;
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
    }
}
